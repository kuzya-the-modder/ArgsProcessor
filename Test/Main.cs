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
}