using SocialNetwork.DAL.Entities;

namespace SocialNetwork.DAL.Repositories;

public class FriendRepository : BaseRepository, IFriendRepository
{
    public IEnumerable<FriendEntity> FindAllByUserId(int userId)
    {
        return Query<FriendEntity>(@"select * from friends where user_id = :user_id", new { user_id = userId });
    }

    public int Create(FriendEntity friendEntity)
    {
        return Execute(@"insert into friends (user_id,friend_id) values (:user_id,:friend_id)", friendEntity);
    }

    public int Delete(int id)
    {
        return Execute(@"delete from friends where id = :id_p", new { id_p = id });
    }
    //найти по id друга
    public FriendEntity FindByFriendId(int friendId, int userId)
    {
        return QueryFirstOrDefault<FriendEntity>(@"select * from friends where friend_id = :friend_id and user_id = :user_id", new { friend_id = friendId, user_id = userId});
    }
}