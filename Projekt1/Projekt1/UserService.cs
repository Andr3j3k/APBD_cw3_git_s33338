namespace Projekt1;

public class UserService
{
    private List<User> _users=new List<User>();

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public List<User> GetAllUsers()
    {
        return _users;
    }

    public User? GetUserById(int id)
    {
        foreach (User user in _users)
        {
            if (user.Id == id)
            {
                return user;
            }
        }
        return null;
    }
}