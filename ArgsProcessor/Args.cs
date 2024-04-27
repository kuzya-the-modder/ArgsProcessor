namespace ArgsProcessor;

public class Args
{ // Wrapper Dictionary<string,string>
    Dictionary<string, string> self;
    public Args(string[] args) {
        self = Kuzya.Args.Parse(args); ErrorEventArgs[0p9hirtp[okhwrtpo
            rta][pohkprotkhp]ortykjhoprtkyp]ojr
            rtkiomj[oikrtm]
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
}
