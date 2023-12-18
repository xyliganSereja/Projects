using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.DirectoryPackage;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.FilePackage;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Parser;

namespace Itmo.ObjectOrientedProgramming.Lab4.Systems;

public class System : ISystem
{
    private readonly Dictionary<string, IFileSystem> _systemDrives;

    public System()
    {
        _systemDrives = new Dictionary<string, IFileSystem>();
    }

    public IFileSystem? ConnectedSystem { get; private set; }
    public IDirectory? CurrDirectory { get; private set; }

    public void AddFileSystem(string name, string mode)
    {
        _systemDrives.TryAdd(name, new ConsoleFileSystem(name, mode));
    }

    public void AddFileSystem(IFileSystem fileSystem, string mode)
    {
        if (fileSystem is null)
        {
            throw new FileSystemException("File system is null");
        }

        _systemDrives.TryAdd(fileSystem.Name, fileSystem);
    }

    public void Run()
    {
        while (true)
        {
            string? line = Console.ReadLine();
            if (line is null)
            {
                throw new ParserException("Line is null");
            }

            CommandParser.Parse(line).Execute(this);
        }
    }

    public IDirectory? FindDirectory(string path)
    {
        CurrDirectory = ConnectedSystem?.FindDirectory(path);
        return CurrDirectory;
    }

    public IFile? FindFile(string path)
    {
        return ConnectedSystem?.FindFile(path);
    }

    public void ConnectSystem(string name, string mode)
    {
        if (mode != "local")
        {
            Console.WriteLine("This mode unsupported");
        }

        if (_systemDrives.TryGetValue(name, out IFileSystem? drive) && drive.Mode == "local")
        {
            ConnectedSystem = drive;
        }
    }

    public void DisconnectSystem()
    {
        ConnectedSystem = null;
    }
}