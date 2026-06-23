namespace TestingVoidMethods.Tests;


public class IndustrialCameraTests
{
    private readonly IndustrialCamera camera = new();

    [Fact]
    public void TakePicture_FirstPicture_SetLastCapturedImage()
    {        
        // Act
        camera.TakePicture();

        // Assert
        Assert.Equal("img_seq_0001.jpg", camera.LastCapturedImage);
    }

    [Fact]
    public void TakePicture_NextPicture_SetLastCapturedImageNameAsImgSeq0002()
    {
        // Arrange
        camera.TakePicture(); // First picture

        // Act
        camera.TakePicture(); // Next picture

        // Assert
        Assert.Equal("img_seq_0002.jpg", camera.LastCapturedImage);
    }

    [Fact]
    public void TakePicture_ThirdPicture_SetLastCapturedImageNameAsImgSeq0003()
    {
        // Arrange        
        camera.TakePicture(); // First picture
        camera.TakePicture(); // Second picture

        // Act        
        camera.TakePicture(); // Third picture

        // Assert
        Assert.Equal("img_seq_0003.jpg", camera.LastCapturedImage);
    }

    [Fact]
    public void TakePicture_OverSequenceLimit_SetLastCapturedImageNameAsImgSeq0001()
    {
        // Arrange
        HelperIndustrialCamera helperCamera = new();
        helperCamera.SetSequence(int.MaxValue);

        //for (int i = 0; i < byte.MaxValue; i++)
        //{
        //    camera.TakePicture(); // Take 255 pictures
        //}


        // Act
        helperCamera.TakePicture(); // This should reset the sequence

        // Assert
        Assert.Equal("img_seq_0001.jpg", helperCamera.LastCapturedImage);
    }


    internal class HelperIndustrialCamera : IndustrialCamera
    {
        public void SetSequence(int sequence)
        {
            this._sequence = sequence;
        }        
    }

}
