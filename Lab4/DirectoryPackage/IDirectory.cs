using System.Collections.Generic;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.FilePackage;

namespace Itmo.ObjectOrientedProgramming.Lab4.DirectoryPackage;

public interface IDirectory
{
    public string Name { get; }
    public IDirectory PrevDirectory { get; }
    void Rename(string name);
    bool AddDirectory(string name);
    bool AddDirectory(IDirectory directory);
    bool AddFile(string name);
    bool AddFile(IFile file);
    bool DeleteDirectory(string name);
    bool DeleteFile(string name);
    IDirectory? CopyDirectory(string name);
    IFile? CopyFile(string name);
    IDirectory? FindDirectory(string name);
    IFile? FindFile(string name);
    IDirectory Clone();
    IDirectory Clone(IDirectory directory);
    void ToString(StringBuilder sb, int depth);
    HashSet<IDirectory> DirectoryValues();
    HashSet<IFile> FileValues();
}