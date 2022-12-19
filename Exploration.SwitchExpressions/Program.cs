using System.Data;
using Exploration.SwitchExpressions;

var command = new Command((int?)null);

var switchResult = command switch
{
    { IsString: true } when string.IsNullOrWhiteSpace(command.Text)  => "I'm an empty string",
    { IsString: true }  => $"I'm a string saying: {command.Text}",
    { IsNullableInt: true, Number: null } => "I'm a number, but null",
    { IsNullableInt: true, Number: >= 0 } => "I'm a non-negative number",
    { IsNullableInt: true } => "I'm just a number",
    _ => throw new StrongTypingException($"Invalid coproduct of {nameof(command)}")
};

var matchResult = command.Match(
    _ => "I'm a string",
    _ => "I'm a number"
);

Console.WriteLine(switchResult);
Console.WriteLine($"{matchResult} and that's all I can do :(");