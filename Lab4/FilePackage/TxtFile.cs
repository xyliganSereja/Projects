using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.FilePackage;

public class TxtFile : IFile
{
    public TxtFile(string name, string body)
    {
        Name = " ";
        Rename(name);
        Body = new StringBuilder(body);
    }

    public TxtFile(string name)
    {
        Name = " ";
        Rename(name);
        Body = new StringBuilder();
    }

    public string Name { get; private set; }
    public StringBuilder Body { get; }

    public override string ToString()
    {
        return Body.ToString();
    }

    public void Rename(string newName)
    {
        if (newName == "/")
        {
            throw new NamingException();
        }

        Name = newName;
    }

    public IFile Clone()
    {
        return new TxtFile(Name, Body.ToString());
    }
}