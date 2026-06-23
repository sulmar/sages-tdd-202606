namespace TestNaming.Tests;

public class AccessControlTests
{

    // {MethodUnderTest}_[Scenario]_[ExpectedResult]

    // {MethodUnderTest}_[Scenario]_[ExpectedBehavior]

    [Fact]
    public void CanEnter_ActiveBadge_ReturnsTrue()
    {
        // Arrange
        var accessControl = new AccessControl();
        var badge = new Badge { IsActive = true };

        // Act
        var result = accessControl.CanEnter(badge);

        // Assert
        Assert.True(result);
        
    }

    [Fact]
    public void CanEnter_InactiveBadge_ReturnsFalse()
    {
        // Arrange
        var accessControl = new AccessControl();
        var badge = new Badge { IsActive = false };

        // Act
        var result = accessControl.CanEnter(badge);

        // Assert
        Assert.False(result);
    }
}
