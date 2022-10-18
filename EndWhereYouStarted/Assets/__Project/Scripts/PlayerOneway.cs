
public class PlayerOneway
{
    private Oneway _capture;
    public Oneway GetCapture() => _capture;

    public void Capture(Oneway newCapture)
    {
        _capture = newCapture;
    }
}
