using System;
using System.Collections.Generic;
using System.IO;

public interface ICommand
{
    void Execute();
    void UnExecute();
}

public class ReadFileCommand : ICommand
{
    private string filePath;

    public ReadFileCommand(string filePath)
    {
        this.filePath = filePath;
    }

    public void Execute()
    {
        string text = File.ReadAllText(filePath);
        Console.WriteLine(text);
    }

    public void UnExecute()
    {
        // Не применимо для операции чтения
    }
}

public class WriteFileCommand : ICommand
{
    private string filePath;
    private string text;
    private string backup;

    public WriteFileCommand(string filePath, string text)
    {
        this.filePath = filePath;
        this.text = text;
    }

    public void Execute()
    {
        backup = File.ReadAllText(filePath);
        File.WriteAllText(filePath, text);
    }

    public void UnExecute()
    {
        File.WriteAllText(filePath, backup);
    }
}

public class CommandInvoker
{
    private Stack<ICommand> commandHistory = new Stack<ICommand>();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        commandHistory.Push(command);
    }

    public void UndoLastCommand()
    {
        if (commandHistory.Count > 0)
        {
            ICommand command = commandHistory.Pop();
            command.UnExecute();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        CommandInvoker invoker = new CommandInvoker();
        ICommand readFileCommand = new ReadFileCommand("text.txt");
        ICommand writeFileCommand = new WriteFileCommand("text.txt", "Hello, World!");

        invoker.ExecuteCommand(readFileCommand);
        invoker.ExecuteCommand(writeFileCommand);
        invoker.UndoLastCommand();
    }
}
