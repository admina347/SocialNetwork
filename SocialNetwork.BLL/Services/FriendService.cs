using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;

namespace SocialNetwork.BLL.Services;

public class FriendService
{
    IFriendRepository friendRepository;
    IUserRepository userRepository;
    public FriendService()
    {
        userRepository = new UserRepository();
        friendRepository = new FriendRepository();
    }
    public void AddToFriends(FriendAddData friendAddData)
    {
        var findUserEntity = this.userRepository.FindByEmail(friendAddData.FriendEmail);
        if (findUserEntity is null) throw new UserNotFoundException();
        // проверить в друзьях пользователь?
        var findFriendEntity = friendRepository.FindByFriendId(findUserEntity.id,friendAddData.UserId);
        if (findFriendEntity != null) throw new UserAlredyInFriendsException();

        var friendEntity = new FriendEntity()
        {
            friend_id = findUserEntity.id,
            user_id = friendAddData.UserId
        };

        if (this.friendRepository.Create(friendEntity) == 0)
            throw new Exception();
    }
    public IEnumerable<Friend> FindAllByUserId(int userId)
    {
        var friends = new List<Friend>();

        friendRepository.FindAllByUserId(userId).ToList().ForEach(f =>
        {
            var userEntity = userRepository.FindById(f.friend_id);
            //var recipientUserEntity = userRepository.FindById(m.recipient_id);

            friends.Add(new Friend(f.id, f.user_id, f.friend_id, userEntity.firstname, userEntity.email));
        });

        return friends;
    }
}