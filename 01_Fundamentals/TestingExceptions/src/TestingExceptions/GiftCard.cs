namespace TestingExceptions;

public class GiftCard
{
    public decimal Balance { get; private set; }

    public GiftCard(decimal balance)
    {
        Balance = balance;
    }

    public void Redeem(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Amount must be greater than zero", nameof(amount));
        }

        if (amount > Balance)
        {
            throw new InvalidOperationException("Insufficient funds");
        }

        Balance -= amount;
    }
}