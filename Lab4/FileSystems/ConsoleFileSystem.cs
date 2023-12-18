using System;
using System.Collections.Generic;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.DirectoryPackage;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.FilePackage;
using Itmo.ObjectOrientedProgramming.Lab4.Parser;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

public class ConsoleFileSystem : IFileSystem
{
    private readonly Dictionary<string, IDirectory> _directories;

    public ConsoleFileSystem(string name, string mode)
    {
        Name = name;
        Mode = mode;
        _directories = new Dictionary<string, IDirectory>();
    }

    public string Name { get; }
    public string Mode { get; }

    public void AddDirectory(IDirectory directory)
    {
        if (directory is null)
        {
            throw new DirectoryException("Directory is null");
        }

        _directories.TryAdd(directory.Name, directory);
    }

    public void DeleteDirectory(string name)
    {
        _directories.Remove(name);
    }

    public IDirectory? CopyDirectory(string path)
    {
        return FindDirectory(path)?.Clone();
    }

    public IFile? CopyFile(string path)
    {
        return FindFile(path)?.Clone();
    }

    public IDirectory? FindDirectory(string path)
    {
        var parser = new PathParser(path);
        string name = parser.Parse();
        _directories.TryGetValue(name, out IDirectory? currDirectory);
        while (!parser.IsEndOfString())
        {
            currDirectory = currDirectory?.FindDirectory(name);
        }

        return currDirectory;
    }

    public IFile? FindFile(string path)
    {
        if (path is null)
        {
            throw new FileSystemException("File path is null");
        }

        int index = path.Length;
        while (char.IsLetter(path[index - 1]))
        {
            index--;
        }

        path = path.Substring(0, index - 1);
        IDirectory? currDirectory = FindDirectory(path);
        if (currDirectory is null)
        {
            return null;
        }

        return currDirectory.FindFile(path.Substring(index));
    }

    public void Show()
    {
        var sb = new StringBuilder();
        foreach (IDirectory directory in _directories.Values)
        {
            directory.ToString(sb, 0);
        }

        Console.WriteLine(sb.ToString());
    }
}
