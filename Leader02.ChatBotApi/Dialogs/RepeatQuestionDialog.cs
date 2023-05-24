using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Leader02.Application.IServices;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using Microsoft.Extensions.Logging;

namespace Leader02.ChatBotApi.Dialogs;

public class RepeatQuestionDialog : CancelAndHelpDialog
{
    private readonly IRequirementService _requirementService;
    private readonly ILegalActService _legalActService;
    private readonly IDepartmentService _departmentService;
    private readonly ILogger _logger;

    public RepeatQuestionDialog(ConsultationDialog consultationDialog, ILogger<RepeatQuestionDialog> logger, IRequirementService requirementService,
        ILegalActService legalActService, IDepartmentService departmentService)
        : base(nameof(RepeatQuestionDialog))
    {
        _logger = logger;
        _requirementService = requirementService;
        _legalActService = legalActService;
        _departmentService = departmentService;

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
            var requirement = await _requirementService.FindByBasicRequirementDescriptionAndDetail(userMessage, cancellationToken);

            await stepContext.Context.SendActivityAsync(
                MessageFactory.Text(JsonSerializer.Serialize(requirement), inputHint: InputHints.IgnoringInput), cancellationToken);

            return await stepContext.ReplaceDialogAsync(nameof(FeedBackDialog), null, cancellationToken);
        }

        //ищем в нпа
        if (userMessage != null && (userMessage.ToLower().Contains("нпа") ||
                                    (userMessage.ToLower().Contains("прав") && userMessage.ToLower().Contains("акт")) ||
                                    (userMessage.ToLower().Contains("норм") && userMessage.ToLower().Contains("права")) ||
                                    userMessage.ToLower().Contains("закон")))
        {
            var legalAct = await _legalActService.FindByName(userMessage, cancellationToken);

            await stepContext.Context.SendActivityAsync(
                MessageFactory.Text(JsonSerializer.Serialize(legalAct), inputHint: InputHints.IgnoringInput), cancellationToken);

            return await stepContext.ReplaceDialogAsync(nameof(FeedBackDialog), null, cancellationToken);
        }

        //ищем в органах власти
        if (userMessage != null && ((userMessage.ToLower().Contains("орган") && userMessage.ToLower().Contains("власт")) ||
                                    userMessage.ToLower().Contains("какой департамент")))
        {
            var department = await _departmentService.FindByAbbreviationOrNameOrDescription(userMessage, cancellationToken);

            await stepContext.Context.SendActivityAsync(
                MessageFactory.Text(JsonSerializer.Serialize(department), inputHint: InputHints.IgnoringInput), cancellationToken);

            return await stepContext.ReplaceDialogAsync(nameof(FeedBackDialog), null, cancellationToken);
        }

        await stepContext.Context.SendActivityAsync(
            MessageFactory.Text("Я не смог распознать ваш вопрос по ключевым словам, Вы можете записаться на консультирование.",
                inputHint: InputHints.IgnoringInput), cancellationToken);

        return await stepContext.BeginDialogAsync(nameof(ConsultationDialog), null, cancellationToken);
    }
}