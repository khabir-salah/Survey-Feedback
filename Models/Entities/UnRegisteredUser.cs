public class UnRegisteredUser
{
    public string Email {get; set;}

    public UnRegisteredUser(string email)
    {
        Email = email;
        
    }

    public UnRegisteredUser()
    {

    }

    public override string ToString()
    {
        return $"Client Email: {Email}";
    }

    public static UnRegisteredUser ToUnRegistered(string str)
    {
        var unRegister = str.Split(',');
        return new UnRegisteredUser()
        {
            Email = unRegister[0],
        };
    }
}