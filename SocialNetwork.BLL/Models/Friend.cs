namespace SocialNetwork.BLL.Models;

public class Friend
{
    public Friend(int id, int userId, int friendId, string friendName, string friendEmail)
    {
        Id = id;
        UserId = userId;
        FriendId = friendId;
        FriendName = friendName;
        FriendEmail = friendEmail;
    }

    public int Id {get; }
    public int UserId { get; }
    public int FriendId { get; }
    public string FriendName { get; set; }
    public string FriendEmail { get; set; }
}
