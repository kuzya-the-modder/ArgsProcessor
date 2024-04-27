using Kuzya;
namespace ArgsTest {
    [TestClass]
    public class MainTest
    {
        [TestMethod]
        public void TestArguments() {
            var res = Args.New(new string[] {
                "-hello","world"
            });
            Assert.IsTrue(res.GetArg("hello") == "world");
        }
        [TestMethod]
        public void TestFlags()
        {
            var res = Args.New(new string[] {
                "-hello", "-help", "world",
            });
            // Assert.IsTrue(res.GetArg("help") == "world");
            Assert.IsTrue(res.HasFlag("hello"));
        }
    }
}