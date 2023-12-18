namespace Itmo.ObjectOrientedProgramming.Lab4.MyScanner;

public interface IScanner
{
    string NextString();
    bool HasNext();
    bool Eof();
    void Close();
}