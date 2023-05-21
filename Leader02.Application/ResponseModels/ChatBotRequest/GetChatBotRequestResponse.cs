using Leader02.Application.DtoModels;

namespace Leader02.Application.ResponseModels.ChatBotRequest;

public class GetChatBotRequestResponse
{
    public List<ChatBotRequestDto> ChatBotRequests { get; set; } = new();
}