using System.IO;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.MyScanner;

#pragma warning disable CA1001
public class StringScanner : IScanner
#pragma warning restore CA1001
{
    private const int Size = 512;
    private readonly StringReader _reader;
    private readonly char[] _buffer = new char[Size];
    private string _nextToken;
    private int _bufferIdx;
    private int _bufferLen;

    public StringScanner(string str)
    {
        _nextToken = " ";
        _reader = new StringReader(str);
        NextString();
    }

    public string NextString()
    {
        var sb = new StringBuilder();
        NextBegin();
        while (!IsEnd() && !char.IsWhiteSpace(GetChar()))
        {
            sb.Append(ToNextChar());
        }

        string? str = _nextToken;
        _nextToken = sb.ToString();

        if (str is null)
        {
            throw new ScannerException("String in scanner is null");
        }

        return str;
    }

    public bool HasNext()
    {
        return _nextToken.Length != 0;
    }

    public bool Eof()
    {
        return IsEnd() && _nextToken.Length == 0;
    }

    public void Close()
    {
        _reader.Close();
    }

    public int NextInt()
    {
        if (IsEnd() && _nextToken.Length == 0)
        {
            throw new ScannerException("next token is not number");
        }

        if (!int.TryParse(_nextToken, out int number))
        {
            throw new ScannerException("next token is not number");
        }

        return number;
    }

    private void NextBegin()
    {
        while (!IsEnd() && char.IsWhiteSpace(GetChar()))
        {
            if (GetChar() == '\r' || GetChar() == '\n')
            {
                char prevChar = ToNextChar();
                if (GetChar() == '\n' && prevChar == '\r')
                {
                    ToNextChar();
                }
            }
            else
            {
                ToNextChar();
            }
        }
    }

    private char GetChar()
    {
        CheckBuffer();
        return _buffer[_bufferIdx];
    }

    private char ToNextChar()
    {
        CheckBuffer();
        return _buffer[_bufferIdx++];
    }

    private void CheckBuffer()
    {
        if (_bufferIdx == _bufferLen)
        {
            _bufferIdx = 0;
            _bufferLen = _reader.Read(_buffer);
        }
    }

    private bool IsEnd()
    {
        CheckBuffer();
        return _bufferIdx >= _bufferLen;
    }
}