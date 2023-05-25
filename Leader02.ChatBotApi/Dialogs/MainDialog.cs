﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio CoreBot v4.18.1

using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using Leader02.Application.IServices;
using Newtonsoft.Json;

namespace Leader02.ChatBotApi.Dialogs;

public class MainDialog : ComponentDialog
{
    private readonly IRequirementService _requirementService;
    private readonly ILegalActService _legalActService;
    private readonly ISubDepartmentService _subDepartmentService;
    private readonly ILogger _logger;

    // Dependency injection uses this constructor to instantiate MainDialog
    public MainDialog(FeedBackDialog feedBackDialog,
        ConsultationDialog consultationDialog, RepeatQuestionDialog repeatQuestionDialog, ILogger<MainDialog> logger,
        IRequirementService requirementService, ILegalActService legalActService, ISubDepartmentService subDepartmentService)
        : base(nameof(MainDialog))
    {
        _logger = logger;
        _requirementService = requirementService;
        _legalActService = legalActService;
        _subDepartmentService = subDepartmentService;

        AddDialog(new TextPrompt(nameof(TextPrompt)));
        AddDialog(feedBackDialog);
        AddDialog(consultationDialog);
        AddDialog(repeatQuestionDialog);

        var waterfallSteps = new WaterfallStep[]
        {
            IntroStepAsync, ActStepAsync, FinalStepAsync,
        };

        AddDialog(new WaterfallDialog(nameof(WaterfallDialog), waterfallSteps));

        // The initial child Dialog to run.
        InitialDialogId = nameof(WaterfallDialog);
    }

    private async Task<DialogTurnResult> IntroStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
    {
        var promptMessage = MessageFactory.Text("Напишите ваш вопрос или запишите голосовое сообщение.", inputHint: InputHints.IgnoringInput);

        return await stepContext.PromptAsync(nameof(TextPrompt), new PromptOptions {Prompt = promptMessage}, cancellationToken);
    }

    private async Task<DialogTurnResult> ActStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
    {
        var userMessage = stepContext.Result.ToString();

        //ищем в требованиях
        if (userMessage != null && (userMessage.ToLower().Contains("обяза") ||
                                    userMessage.ToLower().Contains("треб") ||
                                    userMessage.ToLower().Contains("нужн")))
        {
            var requirement = await _requirementService.FindManyByBasicRequirement(userMessage, cancellationToken);
            if (requirement != null)
            {
                await stepContext.Context.SendActivityAsync(
                    MessageFactory.Text(JsonConvert.SerializeObject(requirement), inputHint: InputHints.IgnoringInput), cancellationToken);

                return await stepContext.BeginDialogAsync(nameof(FeedBackDialog), null, cancellationToken);
            }
        }

        //ищем в органах власти
        if (userMessage != null && ((userMessage.ToLower().Contains("орган") && userMessage.ToLower().Contains("власт")) ||
                                    userMessage.ToLower().Contains("какой департамент")))
        {
            var subDepartment = await _subDepartmentService.FindByNameOrDescription(userMessage, cancellationToken);
            if (subDepartment != null)
            {
                await stepContext.Context.SendActivityAsync(
                    MessageFactory.Text(JsonConvert.SerializeObject(subDepartment), inputHint: InputHints.IgnoringInput), cancellationToken);

                return await stepContext.BeginDialogAsync(nameof(FeedBackDialog), null, cancellationToken);
            }
        }

        //ищем в нпа
        if (userMessage != null && (userMessage.ToLower().Contains("нпа") ||
                                    (userMessage.ToLower().Contains("прав") && userMessage.ToLower().Contains("акт")) ||
                                    (userMessage.ToLower().Contains("норм") && userMessage.ToLower().Contains("права")) ||
                                    userMessage.ToLower().Contains("закон")))
        {
            var legalAct = await _legalActService.FindByName(userMessage, cancellationToken);
            if (legalAct != null)
            {
                await stepContext.Context.SendActivityAsync(
                    MessageFactory.Text(JsonConvert.SerializeObject(legalAct), inputHint: InputHints.IgnoringInput), cancellationToken);

                return await stepContext.BeginDialogAsync(nameof(FeedBackDialog), null, cancellationToken);
            }
        }

        await stepContext.Context.SendActivityAsync(
            MessageFactory.Text("Я не смог распознать ваш вопрос по ключевым словам.", inputHint: InputHints.IgnoringInput), cancellationToken);

        var promptMessage = MessageFactory.Text("Хотите ли вы уточнить вопрос или записаться на консультирование?", inputHint: InputHints.IgnoringInput);

        return await stepContext.PromptAsync(nameof(TextPrompt), new PromptOptions {Prompt = promptMessage}, cancellationToken);
    }

    private async Task<DialogTurnResult> FinalStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
    {
        var userMessage = stepContext.Result.ToString();

        if (userMessage != null && userMessage.ToLower() == "консультирование")
        {
            return await stepContext.BeginDialogAsync(nameof(ConsultationDialog), null, cancellationToken);
        }

        return await stepContext.BeginDialogAsync(nameof(RepeatQuestionDialog), null, cancellationToken);
    }
}