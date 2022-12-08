using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwrok.PLL.Helpers;

namespace SocialNetwrok.PLL.Views;

public class FriendAddView
{
    UserService userService;
    FriendService friendService;

    public FriendAddView(UserService userService, FriendService friendService)
    {
        this.userService = userService;
        this.friendService = friendService;
    }

    public void Show(User user)
    {
        var friendAddData = new FriendAddData();

        Console.Write("Введите почтовый адрес друга: ");
        friendAddData.FriendEmail = Console.ReadLine();

        friendAddData.UserId = user.Id;

        try
        {
            friendService.AddToFriends(friendAddData);

            SuccessMessage.Show("Друг успешно добавлен!");

            user = userService.FindById(user.Id);
        }

        catch (UserNotFoundException)
        {
            AlertMessage.Show("Пользователь не найден!");
        }
        //добавлено
        catch (UserAlredyInFriendsException)
        {
            AlertMessage.Show("Пользователь уже у вас в друзьях!");
        }

        catch (ArgumentNullException)
        {
            AlertMessage.Show("Введите корректное значение!");
        }

        catch (Exception)
        {
            AlertMessage.Show("Произошла ошибка при добавлении в друзья!");
        }

    }
}
