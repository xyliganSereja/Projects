using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.DirectoryPackage;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.MyVisitor;

public static class Shower
{
    public static StringBuilder Show(IDirectory? directory, int currDepth, int depth)
    {
        if (directory is null)
        {
            throw new DirectoryException("directory is null");
        }

        var sb = new StringBuilder();
        foreach (IDirectory visitor in directory.DirectoryValues())
        {
            if (depth > 0)
            {
                sb.Append(new string(' ', 4 * currDepth) + visitor.Name);
                sb.Append(Show(directory, currDepth + 1, depth - 1));
            }
        }

        return sb;
    }

    public static StringBuilder Show(IDirectory? directory, int currDepth)
    {
        if (directory is null)
        {
            throw new DirectoryException("directory is null");
        }

        var sb = new StringBuilder();
        foreach (IDirectory visitor in directory.DirectoryValues())
        {
            sb.Append(new string(' ', 4 * currDepth) + visitor.Name);
            sb.Append(Show(directory, currDepth + 1));
        }

        return sb;
    }
}