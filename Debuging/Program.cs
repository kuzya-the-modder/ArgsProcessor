public static class Debug {
    public static void Main() {
        string[] argvs = {"-hf","-hello","world" };
        var args = Kuzya.Args.Parse(argvs);
        Console.WriteLine(string.Join(' ', args));
    }
}