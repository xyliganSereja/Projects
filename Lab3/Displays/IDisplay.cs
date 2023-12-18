using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public interface IDisplay
{
    void AddText(string text);
    void AddColor(Color color);
    void Print();
}