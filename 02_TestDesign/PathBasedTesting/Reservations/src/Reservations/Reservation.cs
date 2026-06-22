namespace Reservations;

public class Reservation
{
    public User? Owner { get; set; }

    public bool CanCancel(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        if (user.IsAdmin)
        {
            return true;
        }

        if (user == Owner)
        {
            return true;
        }

        return false;
    }
}

public class User
{
    public bool IsAdmin { get; set; }
}
