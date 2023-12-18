using System.Drawing;
using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays.DisplayDrivers;

public interface IDisplayDriver
{
    void AddColor(Color color);
    void Print(StringBuilder? text);
}