public class User
{
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string Email {get; set;}
    public string Password {get; set;}
    public string Role {get; set;}
    public static User LoggedInUser {get; set;}

    public User(string name, string lastname, string email, string password, string role)
    {
        FirstName = name;
        LastName = lastname;
        Email = email;
        Password = password;
        Role = role;
    }

    public User()
    {

    }

    public override string ToString()
    {
        return $"Client Name: {FirstName} {LastName}\tCLient Email: {Email}\tRole: {Role}";
    }

    public static User ToUser(string str)
    {
        var users = str.Split('\t');
        var name = users[0].Split(": ")[1];
        return new User()
        {
            FirstName = name.Split(" ")[0],
            LastName = name.Split(" ")[1],
            Email = users[1].Split(": ")[1],
            // Password = users[3],
            Role = users[2].Split(": ")[1]
        };
    }

}