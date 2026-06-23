namespace TestingVoidMethods.Tests;

public class NameCreatorTests
{

    private readonly NameCreator nameCreator = new();


    [Fact]
    public void CreateImageName_SequenceEqual1_ReturnsExpectedName1()
    {       
        // Act
        string result = nameCreator.CreateImageName(1);

        // Assert
        Assert.Equal("img_seq_0001.jpg", result);
    }

    [Fact]
    public void CreateImageName_SequenceEqual2_ReturnsExpectedName2()
    {        

        // Act
        string result = nameCreator.CreateImageName(2);

        // Assert
        Assert.Equal("img_seq_0002.jpg", result);
    }
}
