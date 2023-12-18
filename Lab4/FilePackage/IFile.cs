using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab4.FilePackage;

public interface IFile
{
    public string Name { get; }
    public StringBuilder Body { get; }
    string ToString();
    void Rename(string newName);
    IFile Clone();
}