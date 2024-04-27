using Kuzya;
namespace Testing;

[TestClass]
public class Main
{
    [TestMethod]
    public void Argument()
    { //
        var res = Args.New(new string[] {
            "-hello","world"
        });
        Assert.IsTrue(res.GetArg("hello") == "world");
    }
    [TestMethod]
    public void Flag()
    { //
        var res = Args.New(new string[] {
            "-hello", "-help", "world",
        });
        Assert.IsTrue(res.HasFlag("hello"));
    }
    [TestMethod]
    public void ToStr()
    { //
        var res = Args.New(new string[] {
            "-help","-hello","world"
        });
        Assert.IsTrue(res.ToString() == "[help, ] [hello, world]");
    }
}