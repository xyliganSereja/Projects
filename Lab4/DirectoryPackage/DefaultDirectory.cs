using System.Collections.Generic;
using System.Linq;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.FilePackage;

namespace Itmo.ObjectOrientedProgramming.Lab4.DirectoryPackage;

public class DefaultDirectory : IDirectory
{
    private readonly HashSet<IDirectory> _directories;
    private readonly HashSet<IFile> _files;
    public DefaultDirectory(string name)
    {
        PrevDirectory = this;
        Name = " ";
        Rename(name);
        _directories = new HashSet<IDirectory>();
        _files = new HashSet<IFile>();
    }

    public DefaultDirectory(HashSet<IDirectory> directories, HashSet<IFile> files, string name)
    {
        Name = " ";
        Rename(name);
        PrevDirectory = this;
        _directories = new HashSet<IDirectory>(directories);
        _files = new HashSet<IFile>(files);
    }

    private DefaultDirectory(string name, IDirectory directory)
    {
        Name = " ";
        Rename(name);
        PrevDirectory = directory;
        _directories = new HashSet<IDirectory>();
        _files = new HashSet<IFile>();
    }

    private DefaultDirectory(HashSet<IDirectory> directories, HashSet<IFile> files, string name, IDirectory prevDirectory)
    {
        Name = " ";
        Rename(name);
        _directories = directories;
        _files = files;
        PrevDirectory = prevDirectory;
        Name = name;
    }

    public string Name { get; private set;  }
    public IDirectory PrevDirectory { get; private set; }
    public void Rename(string name)
    {
        if (name is null)
        {
            throw new DirectoryException("Directory name is null");
        }

        if (ContainsDirectoryName(name) || ContainsFileName(name))
        {
            throw new DirectoryException("Name is already exists");
        }

        foreach (char ch in name)
        {
            if (!char.IsLetter(ch) && !char.IsNumber(ch))
            {
                throw new DirectoryException("Invalid naming");
            }
        }

        Name = name;
    }

    public bool AddDirectory(string name)
    {
        return _directories.Add(new DefaultDirectory(name, this));
    }

    public bool AddFile(string name)
    {
        return _files.Add(new TxtFile(name));
    }

    public bool AddDirectory(IDirectory directory)
    {
        if (directory is null)
        {
            throw new DirectoryException("Directory is null");
        }

        return _directories.Add(directory.Clone(this));
    }

    public bool AddFile(IFile file)
    {
        if (file is null)
        {
            throw new FileException("File is null");
        }

        return _files.Add(file.Clone());
    }

    public bool DeleteDirectory(string name)
    {
        IDirectory? directory = FindDirectory(name);
        if (directory is null)
        {
            return false;
        }

        _directories.Remove(directory);
        return true;
    }

    public bool DeleteFile(string name)
    {
        IFile? file = FindFile(name);
        if (file is null)
        {
            return false;
        }

        _files.Remove(file);
        return true;
    }

    public IDirectory? CopyDirectory(string name)
    {
        return FindDirectory(name)?.Clone();
    }

    public IFile? CopyFile(string name)
    {
        return FindFile(name)?.Clone();
    }

    public void ToString(StringBuilder sb, int depth)
    {
        if (sb is null)
        {
            throw new DirectoryException("Error when trying to build a list");
        }

        sb.Append(new string(' ', 4 * depth).Concat(Name).Concat("\n"));
        foreach (IDirectory directory in _directories)
        {
            directory.ToString(sb, depth + 1);
        }

        foreach (IFile file in _files)
        {
            sb.Append(file.Name.Concat("\n"));
        }
    }

    public IDirectory Clone()
    {
        return new DefaultDirectory(_directories, _files, Name);
    }

    public IDirectory Clone(IDirectory directory)
    {
        return new DefaultDirectory(_directories, _files, Name, directory);
    }

    public IFile? FindFile(string name)
    {
        foreach (IFile file in _files)
        {
            if (file.Name == name)
            {
                return file;
            }
        }

        return null;
    }

    public IDirectory? FindDirectory(string name)
    {
        if (name == "..")
        {
            return PrevDirectory;
        }

        foreach (IDirectory directory in _directories)
        {
            if (directory.Name == name)
            {
                return directory;
            }
        }

        return null;
    }

    public HashSet<IDirectory> DirectoryValues()
    {
        return new HashSet<IDirectory>(_directories);
    }

    public HashSet<IFile> FileValues()
    {
        return new HashSet<IFile>(_files);
    }

    private bool ContainsDirectoryName(string name)
    {
        foreach (IDirectory directory in _directories)
        {
            if (directory.Name == name)
            {
                return true;
            }
        }

        return false;
    }

    private bool ContainsFileName(string name)
    {
        foreach (IFile file in _files)
        {
            if (file.Name == name)
            {
                return true;
            }
        }

        return false;
    }
}