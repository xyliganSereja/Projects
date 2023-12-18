using System.Drawing;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab3.Displays.DisplayDrivers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class Display : IDisplay
{
    private readonly IDisplayDriver _displayDriver;
    private readonly StringBuilder _text;

    private Display(IDisplayDriver displayDriver)
    {
        _text = new StringBuilder();
        _displayDriver = displayDriver;
    }

    public static Display FileDisplay(string fileName)
    {
        return new Display(new FileDisplayDriver(fileName));
    }

    public static Display ConsoleDisplay()
    {
        return new Display(new ConsoleDisplayDriver());
    }

    public void AddText(string text)
    {
        _text.Append(text);
    }

    public void AddColor(Color color)
    {
        _displayDriver.AddColor(color);
    }

    public void Print()
    {
        _displayDriver.Print(_text);
    }
}