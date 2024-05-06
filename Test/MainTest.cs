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
        public void TestFlagsFirst()
        {
            var res = Args.New(new string[] {
                "-hello", "-help", "world",
            });
            Assert.IsTrue(res.HasFlag("hello"));
        }
        [TestMethod]
        public void TestFlagsLast()
        {
            var res = Args.New(new string[] {
                "-hello","world","-flag"
            });
            Assert.IsTrue(res.HasFlag("flag"));
        }
        [TestMethod]
        public void TestNodePath() {
            var res = Args.New(new string[] { 
                "node1","node2","node3","-flag1","-key","value","-flag2"
            });
            Assert.IsTrue(res.nodePath == "node1 node2 node3");
        }
    }
}