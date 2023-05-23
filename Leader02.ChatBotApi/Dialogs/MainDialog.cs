// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio CoreBot v4.18.1

using Leader02.ChatBotApi.CognitiveModels;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using Microsoft.Extensions.Logging;
using Microsoft.Recognizers.Text.DataTypes.TimexExpression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Leader.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Leader02.ChatBotApi.Dialogs;

public class MainDialog : ComponentDialog
{
    private readonly IRequirementRepository _requirementRepository;
    private readonly ILegalActRepository _legalActRepository;
    private readonly ISubDepartmentRepository _subDepartmentRepository;
    private readonly ILogger _logger;

    // Dependency injection uses this constructor to instantiate MainDialog
    public MainDialog(FeedBackDialog feedBackDialog, ConsultationDialog consultationDialog, RepeatQuestionDialog repeatQuestionDialog,
        ILogger<MainDialog> logger, IServiceScopeFactory serviceScopeFactory)
        : base(nameof(MainDialog))
    {
        _logger = logger;
        _requirementRepository = serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<IRequirementRepository>();
        _legalActRepository = serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<ILegalActRepository>();
        _subDepartmentRepository = serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<ISubDepartmentRepository>();

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

    // Shows a warning if the requested From or To cities are recognized as entities but they are not in the Airport entity list.
    // In some cases LUIS will recognize the From and To composite entities as a valid cities but the From and To Airport values
    // will be empty if those entity values can't be mapped to a canonical item in the Airport.
    private static async Task ShowWarningForUnsupportedCities(ITurnContext context, FlightBooking luisResult, CancellationToken cancellationToken)
    {
        var unsupportedCities = new List<string>();

        var fromEntities = luisResult.FromEntities;
        if (!string.IsNullOrEmpty(fromEntities.From) && string.IsNullOrEmpty(fromEntities.Airport))
        {
            unsupportedCities.Add(fromEntities.From);
        }

        var toEntities = luisResult.ToEntities;
        if (!string.IsNullOrEmpty(toEntities.To) && string.IsNullOrEmpty(toEntities.Airport))
        {
            unsupportedCities.Add(toEntities.To);
        }

        if (unsupportedCities.Any())
        {
            var messageText = $"Sorry but the following airports are not supported: {string.Join(',', unsupportedCities)}";
            var message = MessageFactory.Text(messageText, messageText, InputHints.IgnoringInput);
            await context.SendActivityAsync(message, cancellationToken);
        }
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
            //ищем в обязательствах
            await stepContext.Context.SendActivityAsync(MessageFactory.Text("json с требованием", inputHint: InputHints.IgnoringInput), cancellationToken);
            return await stepContext.BeginDialogAsync(nameof(FeedBackDialog), null, cancellationToken);
        }

        //ищем в органах власти
        if (userMessage != null && ((userMessage.ToLower().Contains("орган") && userMessage.ToLower().Contains("власт")) ||
                                    userMessage.ToLower().Contains("какой департамент")))
        {
            //ищем в органах власти
            await stepContext.Context.SendActivityAsync(MessageFactory.Text("json с органов власти", inputHint: InputHints.IgnoringInput)
                , cancellationToken);
            return await stepContext.BeginDialogAsync(nameof(FeedBackDialog), null, cancellationToken);
        }

        //ищем в нпа
        if (userMessage != null && (userMessage.ToLower().Contains("нпа") ||
                                    (userMessage.ToLower().Contains("прав") && userMessage.ToLower().Contains("акт")) ||
                                    (userMessage.ToLower().Contains("норм") && userMessage.ToLower().Contains("права")) ||
                                    userMessage.ToLower().Contains("закон")))
        {
            //ищем в нпа
            await stepContext.Context.SendActivityAsync(MessageFactory.Text("json с нпа", inputHint: InputHints.IgnoringInput), cancellationToken);
            return await stepContext.BeginDialogAsync(nameof(FeedBackDialog), null, cancellationToken);
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