using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public class PathParser : IParser
{
    private readonly string _path;
    private int _index;

    public PathParser(string path)
    {
        _path = path;
        _index = 0;
    }

    public string Parse()
    {
        var sb = new StringBuilder();
        while (char.IsLetter(_path[_index]))
        {
            sb.Append(_path[_index++]);
        }

        ToNextChar();
        return sb.ToString();
    }

    public bool IsEndOfString()
    {
        return _index >= _path.Length;
    }

    private void ToNextChar()
    {
        _index++;
    }
}