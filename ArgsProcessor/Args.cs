using System.Net;

namespace Kuzya;

public class Args
{ // Wrapper Dictionary<string,string>
    #region Class
    Dictionary<string, string> self;
    public readonly string nodePath;
    public Args(string[] args) {
        (self, nodePath) = Parse(args);
    }
    public override string ToString() =>  $"[{nodePath}] : {string.Join(' ', self)}";
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
    #endregion
    #region Parsing
    public static (Dictionary<string, string>, string) Parse(params string[] args)
    {
        int last = args.Length + 1;
        Array.Resize(ref args, last);
        args[last-1] = "-";
        string? name = null;
        string? value = null;
        bool readNodes = true;
        string nodePath = string.Empty;
        var kvs = new Dictionary<string, string>();
        foreach (var arg in args)
        {   
            #region READ_NODES
            if (readNodes)
            {
                // read node path, like: git push help -arg value; {"push","help"} -> string[] node_path
                if (arg[0] == '-' || arg[0] == '/') { readNodes = false; } // break and start reading of args
                else { nodePath += arg + " "; continue; }
            }
            #endregion
            void Add(string name,string value) {
                try
                {
                    kvs.Add(name,value);
                }
                catch (Exception e) {
                    if (e is ArgumentException)
                    {
                        kvs.Remove(name);
                        kvs.Add(name,value);
                    }
                }
            }
            #region READ_ARGS
            if (arg[0] == '-' || arg[0] == '/')
            { // arg -> name
                if (name is not null && value is not null)
                {
                    Add(name, value[0..^1]);
                    name = null; value = null;
                }
                if (name is null)
                {
                    name = arg[1..arg.Length];
                    // value = null;
                }
                else
                {
                    Add(name,string.Empty);
                    name = arg[1..arg.Length];
                    value = null;
                }  
            }
            else
            { // arg -> value
                value += arg+" ";   
                // else: not handling empty values, but may be treated as single, example: -path D:\Folder Name\
            }
            #endregion
        }
        return (kvs, nodePath == string.Empty ? nodePath : nodePath[0..^1]);
    }
    #endregion
    public static Args New(string[] args) => new Args(args);
}
