namespace Walle;
public class Token
{
    public string Value { get; private set; }
    public TokenType Type { get; private set; }
    public CodeLocation Location { get; private set; }

    public Token(TokenType type, string value, CodeLocation location)
    {
        this.Type = type;
        this.Value = value;
        this.Location = location;
    }

    public override string ToString()
        => string.Format("{0} [{1}]", Type, Value);
}

public struct CodeLocation
{
    public string File;
    public int Line;
    public int Column;
}


public enum TokenType
{
    Unknwon,
    Number,
    Text,
    Keyword,
    Identifier,
    Symbol,
    Shape
}

public class TokenValues
{
    protected TokenValues() { }

    public const string Add = "Addition"; // +
    public const string Sub = "Subtract"; // -
    public const string Mul = "Multiplication"; // *
    public const string Div = "Division"; // /

    public const string Assign = "Assign"; // =
    public const string ValueSeparator = "ValueSeparator"; // ,
    public const string StatementSeparator = "StatementSeparator"; // ;

    public const string OpenBracket = "OpenBracket"; // (
    public const string ClosedBracket = "ClosedBracket"; // )
    public const string OpenCurlyBraces = "OpenCurlyBraces"; // {
    public const string ClosedCurlyBraces = "ClosedCurlyBraces"; // }

    public const string point = "point";
    public const string circle = "circle";
    public const string line = "line";
    public const string segment = "segment";
    public const string ray = "ray";
    public const string arc = "arc";
    public const string sequence = "sequence";
    public const string color = "color";
    public const string restore = "restore";
    public const string draw = "draw";
    public const string import = "import";
    public const string measure = "measure";
    public const string print = "print";

}
