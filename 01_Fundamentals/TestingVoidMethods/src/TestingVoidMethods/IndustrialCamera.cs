namespace TestingVoidMethods;

public class IndustrialCamera
{
    protected int _sequence = 0;

    private readonly NameCreator _nameCreator = new();

    public string LastCapturedImage { get; private set; }

    public void TakePicture()
    {        
        try
        {
            checked
            {
                _sequence++;
            }
        }
        catch (OverflowException)
        {
            _sequence = 1;
        }
    
       
        LastCapturedImage = _nameCreator.CreateImageName(_sequence);

        // Tutaj byłby kod do przechwytywania i zapisu zdjęcia,
        // np. na dysku lub Amazon S3 lub Cloudflare R2
        // SaveToImageStorage(LastCapturedImage);
    }    
}

public class NameCreator
{
    public string CreateImageName(int sequence)
    {
        return $"img_seq_{sequence:D4}.jpg";
    }
}
