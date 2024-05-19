using Kuzya;

public static class Debug
{
    public static void Main(string[] argvs)
    { Args args = Args.New(argvs);
        if(args.HasFlag("version","v")) Console.WriteLine("v-1.0");
        Console.WriteLine(args.ToString());
    }
}