using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.MyScanner;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public static class CommandParser
{
    public static ICommand Parse(string line)
    {
        var scanner = new StringScanner(line);
        string command = scanner.NextString();
        switch (command)
        {
            case "connect":
            {
                if (!scanner.HasNext())
                {
                    throw new ParserException("'connect' command must contain the name");
                }

                string name = scanner.NextString();
                if (!scanner.HasNext())
                {
                    throw new ParserException("'connect' command must contain the mode");
                }

                string mode = scanner.NextString();
                return new ConnectCommand(name, mode);
            }

            case "disconnect":
            {
                return new DisconnectCommand();
            }

            case "tree":
            {
                if (!scanner.HasNext())
                {
                    throw new ParserException("Unknown command");
                }

                string str = scanner.NextString();
                if (str == "goto")
                {
                    if (!scanner.HasNext())
                    {
                        throw new ParserException("'tree goto' command must contain the path");
                    }

                    string path = scanner.NextString();
                    if (scanner.HasNext())
                    {
                        throw new ParserException("Too much argument for 'tree goto' command");
                    }

                    return new GotoCommand(path);
                }

                if (str == "list")
                {
                    if (!scanner.HasNext())
                    {
                        throw new ParserException("'tree list' command must contain the path");
                    }

                    if (scanner.HasNext() && scanner.NextString() == "-d")
                    {
                        if (!scanner.HasNext())
                        {
                            throw new ParserException("This command must contain a number to depth");
                        }

                        return new LsCommand(scanner.NextInt());
                    }

                    return new LsCommand();
                }

                throw new ParserException("Unknown command");
            }

            case "file":
            {
                if (!scanner.HasNext())
                {
                    throw new ScannerException("Unknown command");
                }

                string secondCommandWord = scanner.NextString();
                if (secondCommandWord == "show")
                {
                    if (!scanner.HasNext())
                    {
                        throw new ParserException("'file show' command should contain path");
                    }

                    string path = scanner.NextString();
                    if (scanner.HasNext() && scanner.NextString() == "-m")
                    {
                        if (!scanner.HasNext())
                        {
                            throw new ParserException("This command must contain a type");
                        }

                        string mode = scanner.NextString();
                        return new CatCommand(path, mode);
                    }

                    return new CatCommand(path);
                }

                if (secondCommandWord == "move" || secondCommandWord == "copy")
                {
                    if (!scanner.HasNext())
                    {
                        throw new ParserException("'file move' command should contain path");
                    }

                    string from = scanner.NextString();
                    if (!scanner.HasNext())
                    {
                        throw new ParserException("'file move' command should contain path");
                    }

                    string to = scanner.NextString();
                    if (scanner.HasNext())
                    {
                        throw new ParserException("'file move' contain too much arguments");
                    }

                    if (secondCommandWord == "move")
                    {
                        return new FileMoveCommand(from, to);
                    }

                    return new FileCopyCommand(from, to);
                }

                if (secondCommandWord == "delete")
                {
                    if (!scanner.HasNext())
                    {
                        throw new ParserException("'file delete' command should contain path");
                    }

                    return new FileDeleteCommand(scanner.NextString());
                }

                if (secondCommandWord == "rename")
                {
                    if (!scanner.HasNext())
                    {
                        throw new ParserException("'file rename' command should contain path and new file name");
                    }

                    string path = scanner.NextString();
                    if (!scanner.HasNext())
                    {
                        throw new ParserException("'file rename' command should contain new file name");
                    }

                    string newName = scanner.NextString();
                    if (scanner.HasNext())
                    {
                        throw new ParserException("'file rename' contain too much arguments");
                    }

                    return new FileRenameCommand(path, newName);
                }

                throw new ParserException("Unknown command");
            }

            default: throw new ParserException("Unknown command");
        }
    }
}