namespace Kuzya;

public static class Args {
    public static Dictionary<string,string> Parse(string[] args) {
        string? name = null;
        var kvs = new Dictionary<string, string>();
        foreach (var arg in args) {
            // arg[0] == '-' -> name
            // else -> value 
            if(arg[0] == '-') {
                // name
                if (name is not null) {
                    // fix flags
                    kvs.Add(name, string.Empty);
                }
                name = arg[1..(arg.Length)];
            } else {
                // value
                if(name is null) continue; //throw new InvalidArgsFormatException("Invalid Argument Typo");
                try {
                    kvs.Add(name,arg);
                } catch (ArgumentException) {}
                name = null;
            }
        }
        return kvs;
    }
} 