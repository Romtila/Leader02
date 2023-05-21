namespace Leader02.Application.RequestModels.ChatBotRequest;

public class CreateChatBotRequestRequest
{
    public Guid? Id { get; set; }
    public long UserId { get; set; }
    public string Message { get; set; } = string.Empty;
}