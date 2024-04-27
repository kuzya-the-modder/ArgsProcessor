namespace Kuzya;

public class Args
{ // Wrapper Dictionary<string,string>
    Dictionary<string, string> self;
    public Args(string[] args)
    {
        self = Parse(args);
    }
    public string? GetArg(string name)
    {
        if (self.TryGetValue(name, out var value)) return value;
        return null;
    }
    public string? GetArg(params string[] aliases)
    {
        foreach (var name in aliases) if (self.TryGetValue(name, out var value)) return value;
        return null;
    }
    public bool HasFlag(string name)
    {
        var value = GetArg(name);
        return value is not null && value == string.Empty;
    }
    public bool HasFlag(params string[] aliases)
    {
        foreach (var name in aliases) if (HasFlag(name)) return true;
        return false;
    }
    public static Dictionary<string, string> Parse(string[] args)
    {
        string? name = null;
        var kvs = new Dictionary<string, string>();
        foreach (var arg in args)
        {
            // arg[0] == '-' -> name
            // else -> value 
            if (arg[0] == '-')
            {
                // name
                if (name is not null)
                {
                    // fix flags
                    kvs.Add(name, string.Empty);
                }
                name = arg[1..(arg.Length)];
            }
            else
            {
                // value
                if (name is null) continue; //throw new InvalidArgsFormatException("Invalid Argument Typo");
                try
                {
                    kvs.Add(name, arg);
                }
                catch (ArgumentException) { }
                name = null;
            }
        }
        return kvs;
    }
    public static Args New(string[] args) => new Args(args);
}