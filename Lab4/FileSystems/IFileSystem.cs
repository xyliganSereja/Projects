using Itmo.ObjectOrientedProgramming.Lab4.DirectoryPackage;
using Itmo.ObjectOrientedProgramming.Lab4.FilePackage;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

public interface IFileSystem
{
    public string Name { get; }
    public string Mode { get; }
    void AddDirectory(IDirectory directory);
    void DeleteDirectory(string name);
    IDirectory? CopyDirectory(string path);
    IDirectory? FindDirectory(string path);
    IFile? FindFile(string path);
    void Show();
}