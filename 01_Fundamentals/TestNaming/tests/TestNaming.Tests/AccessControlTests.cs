namespace TestNaming.Tests;

public class AccessControlTests
{

    // {MethodUnderTest}_[Scenario]_[ExpectedResult]

    // {MethodUnderTest}_[Scenario]_[ExpectedBehavior]

    private readonly AccessControl accessControl = new();
    private readonly Badge badge = new();

    [Fact]
    public void CanEnter_ActiveBadge_ReturnsTrue()
    {
        // Arrange        
        badge.IsActive = true;

        // Act
        var result = accessControl.CanEnter(badge);

        // Assert
        Assert.True(result);
        
    }

    [Fact]
    public void CanEnter_InactiveBadge_ReturnsFalse()
    {
        // Arrange
        badge.IsActive = false;

        // Act
        var result = accessControl.CanEnter(badge);

        // Assert
        Assert.False(result);
    }


    [Fact]
    public void CanEnter_EmptyBadge_ReturnsFalse()
    {        
        // Act
        var result = accessControl.CanEnter(null);
        
        // Assert
        Assert.False(result);
    }
}
