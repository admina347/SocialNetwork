using SocialNetwork.DAL.Entities;

namespace SocialNetwork.DAL.Repositories;

public interface IFriendRepository
{
    int Create(FriendEntity friendEntity);
    IEnumerable<FriendEntity> FindAllByUserId(int userId);
    int Delete(int id);
    FriendEntity FindByFriendId(int friendId, int userId);
}
