using System.Threading;
using System.Threading.Tasks;
using Leader.Domain.Interfaces;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Leader02.ChatBotApi.Dialogs;

public class RepeatQuestionDialog : CancelAndHelpDialog
{
    private readonly IRequirementRepository _requirementRepository;
    private readonly ILegalActRepository _legalActRepository;
    private readonly ISubDepartmentRepository _subDepartmentRepository;
    private readonly ILogger _logger;

    public RepeatQuestionDialog(ConsultationDialog consultationDialog,
        IServiceScopeFactory serviceScopeFactory, ILogger<RepeatQuestionDialog> logger)
        : base(nameof(RepeatQuestionDialog))
    {
        _logger = logger;
        _requirementRepository = serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<IRequirementRepository>();
        _legalActRepository = serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<ILegalActRepository>();
        _subDepartmentRepository = serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<ISubDepartmentRepository>();

        AddDialog(new TextPrompt(nameof(TextPrompt)));
        AddDialog(consultationDialog);

        var waterfallSteps = new WaterfallStep[]
        {
            FirstStepAsync, SecondStepAsync
        };

        AddDialog(new WaterfallDialog(nameof(WaterfallDialog), waterfallSteps));

        // The initial child Dialog to run.
        InitialDialogId = nameof(WaterfallDialog);
    }

    private async Task<DialogTurnResult> FirstStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
    {
        var incorrectMessage = MessageFactory.Text("Напишите ваш вопрос или запишите голосовое сообщение.",
            inputHint: InputHints.IgnoringInput);

        return await stepContext.PromptAsync(nameof(TextPrompt), new PromptOptions {Prompt = incorrectMessage}, cancellationToken);
    }

    private async Task<DialogTurnResult> SecondStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
    {
        var userMessage = stepContext.Result.ToString();

        //ищем в требованиях
        if (userMessage != null && (userMessage.ToLower().Contains("обяза") ||
                                    userMessage.ToLower().Contains("треб") ||
                                    userMessage.ToLower().Contains("нужн")))
        {
            //ищем в обязательствах
            await stepContext.Context.SendActivityAsync(
                MessageFactory.Text("json с требованием", inputHint: InputHints.IgnoringInput), cancellationToken);

            return await stepContext.ReplaceDialogAsync(nameof(FeedBackDialog), null, cancellationToken);
        }

        //ищем в органах власти
        if (userMessage != null && ((userMessage.ToLower().Contains("орган") && userMessage.ToLower().Contains("власт")) ||
                                    userMessage.ToLower().Contains("какой департамент")))
        {
            //ищем в органах власти
            await stepContext.Context.SendActivityAsync(
                MessageFactory.Text("json с требованием", inputHint: InputHints.IgnoringInput), cancellationToken);

            return await stepContext.ReplaceDialogAsync(nameof(FeedBackDialog), null, cancellationToken);
        }

        //ищем в нпа
        if (userMessage != null && (userMessage.ToLower().Contains("нпа") ||
                                    (userMessage.ToLower().Contains("прав") && userMessage.ToLower().Contains("акт")) ||
                                    (userMessage.ToLower().Contains("норм") && userMessage.ToLower().Contains("права")) ||
                                    userMessage.ToLower().Contains("закон")))
        {
            //ищем в нпа
            await stepContext.Context.SendActivityAsync(
                MessageFactory.Text("json с требованием", inputHint: InputHints.IgnoringInput), cancellationToken);

            return await stepContext.ReplaceDialogAsync(nameof(FeedBackDialog), null, cancellationToken);
        }

        await stepContext.Context.SendActivityAsync(
            MessageFactory.Text("Я не смог распознать ваш вопрос по ключевым словам, Вы можете записаться на консультирование.",
                inputHint: InputHints.IgnoringInput), cancellationToken);

        return await stepContext.BeginDialogAsync(nameof(ConsultationDialog), null, cancellationToken);
    }
}