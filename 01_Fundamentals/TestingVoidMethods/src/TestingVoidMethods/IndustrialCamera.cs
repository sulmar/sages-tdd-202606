namespace TestingVoidMethods;

public class IndustrialCamera
{
    private int _sequence = 0;

    public string LastCapturedImage { get; private set; }

    public void TakePicture()
    {
        _sequence++;
        LastCapturedImage = $"img_seq_{_sequence:D4}.jpg";

        // Tutaj byłby kod do przechwytywania i zapisu zdjęcia,
        // np. na dysku lub Amazon S3 lub Cloudflare R2
        // SaveToImageStorage(LastCapturedImage);
    }
}
