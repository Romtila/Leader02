using System.Threading;
using System.Threading.Tasks;
using Leader.Domain.Interfaces;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Leader02.ChatBotApi.Dialogs;

public class FeedBackDialog : CancelAndHelpDialog
{
    private readonly IRequirementRepository _requirementRepository;
    private readonly ILegalActRepository _legalActRepository;
    private readonly ISubDepartmentRepository _subDepartmentRepository;
    private readonly ILogger _logger;

    public FeedBackDialog(ConsultationDialog consultationDialog, RepeatQuestionDialog repeatQuestionDialog,
        IServiceScopeFactory serviceScopeFactory, ILogger<FeedBackDialog> logger)
        : base(nameof(FeedBackDialog))
    {
        _logger = logger;
        _requirementRepository = serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<IRequirementRepository>();
        _legalActRepository = serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<ILegalActRepository>();
        _subDepartmentRepository = serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<ISubDepartmentRepository>();

        AddDialog(new TextPrompt(nameof(TextPrompt)));
        AddDialog(consultationDialog);
        AddDialog(repeatQuestionDialog);

        var waterfallSteps = new WaterfallStep[]
        {
            FirstStepAsync, SecondStepAsync, ThirdStepAsync
        };

        AddDialog(new WaterfallDialog(nameof(WaterfallDialog), waterfallSteps));

        // The initial child Dialog to run.
        InitialDialogId = nameof(WaterfallDialog);
    }

    private async Task<DialogTurnResult> FirstStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
    {
        var requirementMessage = MessageFactory.Text("Дан ли полный ответ на Ваш вопрос?", inputHint: InputHints.IgnoringInput);
        return await stepContext.PromptAsync(nameof(TextPrompt), new PromptOptions {Prompt = requirementMessage}, cancellationToken);
    }

    private async Task<DialogTurnResult> SecondStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
    {
        var userMessage = stepContext.Result.ToString();

        if (userMessage != null && userMessage.ToLower() == "да")
        {
            await stepContext.Context.SendActivityAsync(
                MessageFactory.Text("Спасибо за обращение. Рад был помочь.", inputHint: InputHints.IgnoringInput), cancellationToken);

            return await stepContext.EndDialogAsync(null, cancellationToken);
        }

        var promptMessage = MessageFactory.Text("Хотите ли вы уточнить вопрос или записаться на консультирование?", inputHint: InputHints.IgnoringInput);

        return await stepContext.PromptAsync(nameof(TextPrompt), new PromptOptions {Prompt = promptMessage}, cancellationToken);
    }

    private async Task<DialogTurnResult> ThirdStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
    {
        var userMessage = stepContext.Result.ToString();

        if (userMessage != null && userMessage.ToLower() == "консультирование")
        {
            return await stepContext.BeginDialogAsync(nameof(ConsultationDialog), null, cancellationToken);
        }

        return await stepContext.BeginDialogAsync(nameof(RepeatQuestionDialog), null, cancellationToken);
    }
}