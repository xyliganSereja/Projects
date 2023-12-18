using System;
using System.Drawing;
using System.IO;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays.DisplayDrivers;

public class FileDisplayDriver : IDisplayDriver
{
    private readonly string _fileName;
    private Color _color;

    public FileDisplayDriver(string fileName)
    {
        _fileName = fileName;
    }

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

        try
        {
            var writer = new StreamWriter(_fileName);
            writer.WriteLine(Crayon.Output.Rgb(_color.R, _color.G, _color.B).Text(text.ToString()));
            writer.Close();
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine("File not found" + e.Message + e.StackTrace);
        }
    }
}