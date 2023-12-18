using System;
using System.Drawing;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays.DisplayDrivers;

public class ConsoleDisplayDriver : IDisplayDriver
{
    private Color _color;

    public void AddColor(Color color)
    {
        _color = color;
    }

    public void Print(StringBuilder? text)
    {
        if (text is null)
        {
            throw new MessageException("Message is null");
        }

        Console.WriteLine(Crayon.Output.Rgb(_color.R, _color.G, _color.B).Text(text.ToString()));
    }
}