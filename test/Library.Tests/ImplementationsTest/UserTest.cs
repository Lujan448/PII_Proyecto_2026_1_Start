using Library;

namespace LibraryTests;

[TestFixture]
public class UserTest
{
    [Test]
    public void CheckUserAtrributes_IfAttributesAreRight_ReturnTrue()
    {
        User user = new User("María", 19, "Uruguay");
        Assert.That(user.Name, Is.EqualTo("María"));
        Assert.That(user.Age, Is.EqualTo(19));
        Assert.That(user.Country, Is.EqualTo("Uruguay"));
    }

    [Test]
    public void CreateCount_IfUserIsValid_CountIsCreate()
    {
        User user = new User("María", 19, "Uruguay");
        List<User> users = new List<User>();
        user.CreateCount(users);
        Assert.That(users, Does.Contain(user));
    }

    [Test]
    public void CreateCount_IfUserAlreadyExists_UserIsNotAddedTwice()
    {
        User user = new User("María", 19, "Uruguay");
        List<User> users = new List<User>();
        user.CreateCount(users);
        user.CreateCount(users);
        Assert.That(users.Count, Is.EqualTo(1));
    }

    [Test]
    public void CreateCount_IfICreateAnAcount_UserDoesExist()
    {
        User user = new User("María", 19, "Uruguay");
        List<User> users = new List<User>();
        user.CreateCount(users);
        Assert.That(users, Does.Contain(user));
    }


    [Test]
    public void CreateCount_IfDontCreateCount_UserDoesNotExist()
    {
        User user = new User("María", 19, "Uruguay");
        List<User> users = new List<User>();
        Assert.That(users, Does.Not.Contain(user));
    }

    [Test]
    public void CreateCount_IfUserIsValid_ReturnTrue()
    {
        User user = new User("María", 19, "Uruguay");
        Assert.That(user.UserIsValid(), Is.True);
    }

    [Test]
    public void CreateCount_IfUserIsNotValid_ReturnFalse()
    {
        User user = new User("", 19, "Uruguay");
        Assert.That(user.UserIsValid(), Is.False);
    }
}