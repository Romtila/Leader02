namespace Leader02.Application.RequestModels.ChatBotRequest;

public class GetChatBotRequestsRequest
{
    public long? UserId { get; set; }
    public int? DepartmentId { get; set; }
    public int PageIndex { get; set; }
    public int PageLimit { get; set; }
}