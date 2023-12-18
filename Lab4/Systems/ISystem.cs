using Itmo.ObjectOrientedProgramming.Lab4.DirectoryPackage;
using Itmo.ObjectOrientedProgramming.Lab4.FilePackage;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Systems;

public interface ISystem
{
    public IFileSystem? ConnectedSystem { get; }
    public IDirectory? CurrDirectory { get; }
    void AddFileSystem(string name, string mode);
    void AddFileSystem(IFileSystem fileSystem, string mode);
    void Run();

    IDirectory? FindDirectory(string path);
    IFile? FindFile(string path);
    void ConnectSystem(string name, string mode);
    void DisconnectSystem();
}