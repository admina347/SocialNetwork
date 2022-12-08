using SocialNetwork.BLL.Models;

namespace SocialNetwrok.PLL.Views;

public class UserFriendsView
{
    public void Show(IEnumerable<Friend> friends)
    {
        Console.WriteLine("Мои друзья");

        if (friends.Count() == 0)
        {
            Console.WriteLine("У вас нет друзей");
            return;
        }

        friends.ToList().ForEach(friend =>
        {
            Console.WriteLine("id:{0} - Друг: {1} email: {2}", friend.Id, friend.FriendName, friend.FriendEmail);
        });
    }
}
