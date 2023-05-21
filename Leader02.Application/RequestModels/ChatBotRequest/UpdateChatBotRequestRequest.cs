using Leader.Domain.Enums;

namespace Leader02.Application.RequestModels.ChatBotRequest;

public class UpdateChatBotRequestRequest
{
    public Guid? Id { get; set; }
    public long UserId { get; set; }
    public ChatBotRequestFeedBack? FeedBack { get; set; }
    public string? FeedBackString { get; set; }
}