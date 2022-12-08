using Moq;
using NUnit.Framework;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;

namespace SocialNetwork.DAL.Tests.Repositories;

[TestFixture]
public class UserRepositoryTests
{
    [Test]
    public void FindAllMustReturnCorrectValue()
    {
        var list = new List<UserEntity> {
            new UserEntity()
            {
                firstname = "Антон"
            },
            new UserEntity()
            {
                firstname = "Иван"
            },
            new UserEntity()
            {
                firstname = "Алексей"
                },
            };
            

        Mock<IUserRepository> mock = new Mock<IUserRepository>();

        mock.Setup(v => v.FindAll()).Returns(list);
            
        Assert.That(mock.Object.FindAll().Any(user => user.firstname == "Антон"));
        Assert.That(mock.Object.FindAll().Any(user => user.firstname == "Иван"));
        Assert.That(mock.Object.FindAll().Any(user => user.firstname == "Алексей"));
            
    }
}
