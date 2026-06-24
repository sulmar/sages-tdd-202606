namespace Reservations;

public class Reservation
{
    public User? Owner { get; set; }

    public bool CanCancel(User user)
    {
        ArgumentNullException.ThrowIfNull(user);

        return user.IsAdmin || user == Owner;
    }
}

public class User
{
    public bool IsAdmin { get; set; }
}
