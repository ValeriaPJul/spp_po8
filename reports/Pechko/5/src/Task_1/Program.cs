public interface IBuilding
{
    void Open();
    void Close();
}

public abstract class PublicBuilding : IBuilding
{
    public abstract void Open();
    public abstract void Close();

    public void PublicService()
    {
        Console.WriteLine("Providing public service");
    }
}

public class Theatre : PublicBuilding
{
    public override void Open()
    {
        Console.WriteLine("Opening theatre...");
    }

    public override void Close()
    {
        Console.WriteLine("Closing theatre...");
    }

    public void Play()
    {
        Console.WriteLine("Starting play...");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Theatre theatre = new Theatre();
        theatre.Open();
        theatre.PublicService();
        theatre.Play();
        theatre.Close();
    }
}
