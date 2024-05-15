using System;

public interface IRemote
{
    void Power();
    void VolumeUp();
    void VolumeDown();
    void ChannelUp();
    void ChannelDown();
}

public interface ITV
{
    void TurnOn();
    void TurnOff();
    void SetVolume(int percent);
    void SetChannel(int number);
}

public class Remote : IRemote
{
    protected ITV tv;

    public Remote(ITV tv)
    {
        this.tv = tv;
    }

    public void Power()
    {
        tv.TurnOn();
    }

    public void VolumeUp()
    {
        tv.SetVolume(10);
    }

    public void VolumeDown()
    {
        tv.SetVolume(-10);
    }

    public void ChannelUp()
    {
        tv.SetChannel(1);
    }

    public void ChannelDown()
    {
        tv.SetChannel(-1);
    }
}

public class AdvancedRemote : Remote
{
    public AdvancedRemote(ITV tv) : base(tv)
    {
    }

    public void Mute()
    {
        tv.SetVolume(0);
    }
}

public class SamsungTV : ITV
{
    public void TurnOn()
    {
        Console.WriteLine("Samsung TV is turned on.");
    }

    public void TurnOff()
    {
        Console.WriteLine("Samsung TV is turned off.");
    }

    public void SetVolume(int percent)
    {
        Console.WriteLine($"Samsung TV volume is set to {percent}%");
    }

    public void SetChannel(int number)
    {
        Console.WriteLine($"Samsung TV channel is set to {number}");
    }
}

public class LGTV : ITV
{
    public void TurnOn()
    {
        Console.WriteLine("LG TV is turned on.");
    }

    public void TurnOff()
    {
        Console.WriteLine("LG TV is turned off.");
    }

    public void SetVolume(int percent)
    {
        Console.WriteLine($"LG TV volume is set to {percent}%");
    }

    public void SetChannel(int number)
    {
        Console.WriteLine($"LG TV channel is set to {number}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        ITV samsung = new SamsungTV();
        IRemote remote = new Remote(samsung);
        remote.Power();
        remote.VolumeUp();
        remote.ChannelUp();

        ITV lg = new LGTV();
        IRemote advancedRemote = new AdvancedRemote(lg);
        advancedRemote.Power();
        advancedRemote.VolumeUp();
        advancedRemote.ChannelUp();
    }
}
