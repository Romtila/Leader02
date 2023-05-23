using System.Threading;
using System.Threading.Tasks;
using Leader.Domain.Interfaces;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Leader02.ChatBotApi.Dialogs;

public class ConsultationDialog : CancelAndHelpDialog
{
    private readonly IRequirementRepository _requirementRepository;
    private readonly ILegalActRepository _legalActRepository;
    private readonly ISubDepartmentRepository _subDepartmentRepository;
    private readonly ILogger _logger;

    public ConsultationDialog(IServiceScopeFactory serviceScopeFactory, ILogger<ConsultationDialog> logger)
        : base(nameof(ConsultationDialog))
    {
        _logger = logger;
        _requirementRepository = serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<IRequirementRepository>();
        _legalActRepository = serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<ILegalActRepository>();
        _subDepartmentRepository = serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<ISubDepartmentRepository>();

        AddDialog(new TextPrompt(nameof(TextPrompt)));

        var waterfallSteps = new WaterfallStep[]
        {
            FirstStepAsync
        };

        AddDialog(new WaterfallDialog(nameof(WaterfallDialog), waterfallSteps));

        // The initial child Dialog to run.
        InitialDialogId = nameof(WaterfallDialog);
    }

    private async Task<DialogTurnResult> FirstStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
    {
        await stepContext.Context.SendActivityAsync(
            MessageFactory.Text("{ссылка на консультирование}", inputHint: InputHints.IgnoringInput), cancellationToken);

        return await stepContext.EndDialogAsync(null, cancellationToken);
    }
}