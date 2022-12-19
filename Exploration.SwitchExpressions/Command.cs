using FuncSharp;

namespace Exploration.SwitchExpressions;

public sealed class Command : Coproduct2<string, int?>
{
    public Command(string firstValue) : base(firstValue)
    {
    }

    public Command(int? secondValue) : base(secondValue)
    {
    }

    // doesn't have to follow the pattern IsNameOfType, but it makes sense
    public bool IsString => IsFirst;

    public bool IsNullableInt => IsSecond;
    
    // utilizes IOption, de-elevating it to direct type right away
    public string Text => First.GetOrDefault();

    // an example with a nullable reference type instead of IOption
    public int? Number => Second.GetOrDefault();
}