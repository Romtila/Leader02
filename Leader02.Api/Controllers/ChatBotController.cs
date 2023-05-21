using Leader02.Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Leader02.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ChatBotController : ControllerBase
{
    private readonly IChatBotService _chatBotService;

    public ChatBotController(IChatBotService chatBotService)
    {
        _chatBotService = chatBotService;
    }
}