namespace TestingExceptions.Tests;

public class GiftCardTests
{
    // Kwota jest większa od 0 i nie przekracza salda	-> Saldo zostaje pomniejszone
    // 100 zł	40 zł	Saldo: 60 zł

    // {MethodUnderTest}_{Scenario}_{ExpectedBehavior}

    private readonly GiftCard giftCard = new GiftCard(100);

    [Fact]
    public void Redeem_AmountIsGreaterThanZeroAndDoesNotExceedBalance_BalanceIsReduced()
    {       
        // Act
        giftCard.Redeem(40);

        // Assert
        Assert.Equal(60, giftCard.Balance);
    }

    // Kwota jest równa saldu	Saldo zostaje pomniejszone do 0
    // 100 zł	100 zł Saldo: 0 zł

    [Fact]
    public void Redeem_AmountIsEqualToBalance_BalanceIsReducedToZero()
    {
        // Act
        giftCard.Redeem(100);

        // Assert
        Assert.Equal(0, giftCard.Balance);
    }

    // Kwota jest większa niż saldo	Zgłoszony zostaje błąd    
    [Fact]
    public void Redeem_AmountIsGreaterThanBalance_ThrowsInvalidOperationException()
    {
        // Act
        Action act = () => giftCard.Redeem(150);

        // Assert
        Assert.Throws<InvalidOperationException>(act);        

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => giftCard.Redeem(150));
    }

    // Kwota jest równa 0	Zgłoszony zostaje błąd

    [Fact]
    public void Redeem_AmountIsEqualZero_ThrowsArgumentException()
    {
 
        // Act
        Action act = () => giftCard.Redeem(0);

        // Assert
        Assert.Throws<ArgumentException>(act);

    }

    // Kwota jest ujemna	Zgłoszony zostaje błąd
    // 100 zł	-10 zł	ArgumentException

    [Fact]
    public void Redeem_AmountIsNegative_ThrowsArgumentException()
    {        
        // Act & Assert
        Assert.Throws<ArgumentException>(() => giftCard.Redeem(-10));
    }
}
