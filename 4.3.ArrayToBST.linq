<Query Kind="Program">
  <Reference>C:\Libs\MongoDB.Bson.dll</Reference>
  <Reference>C:\Libs\nunitlite.dll</Reference>
  <Namespace>MongoDB.Bson</Namespace>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite.Runner</Namespace>
</Query>

void Main() {
    new NUnitLite.Runner.TextUI().Execute(new[] { "-noheader" });
}

static class Algos {
    internal static Node ToBST(this int[] arr) {
        if (arr.Length == 0) return null;
        return MakeTree(0, arr.Length - 1, arr);
    }
    
    private static Node MakeTree(int bot, int top, int[] arr) {
        if (bot > top) return null;
        var mid = (top + bot) / 2;
        var midVal = arr[mid];
        //bot.Dump("b"); top.Dump("t"); midVal.Dump("m");
        return new Node {
            Right = MakeTree(bot, mid - 1, arr),
            Data = midVal,
            Left = MakeTree(mid + 1, top, arr) };
    }
} 
// 0        0        0
// 0 1      0 1      
// 0 1 2    0 1 2

internal class Node {
    public Node Left { get; set; }
    public int Data { get; set; }
    public Node Right { get; set; }
}

[TestFixture]
internal class Tests {
    [Test, TestCaseSource(typeof(TestCaseStorage), "TestCases")]
    public void Run_OnTestCases_AssertPasses(int[] arr, Node tree) {
        tree.ToJson().Dump("t"); arr.ToBST().ToJson().Dump("a");
		Assert.AreEqual(expected: tree.ToJson(), actual: arr.ToBST().ToJson());
    }
}

class TestCaseStorage {
    static IEnumerable TestCases {
        get {
            yield return new TestCaseData(new int[0], (Node)null);
            yield return new TestCaseData(new [] { 123 }, new Node { Data = 123 });
            yield return new TestCaseData(new [] { 543, 9876 },
                new Node { 
                    Left = new Node { Data = 543 }, 
                    Data = 9876 });
            yield return new TestCaseData(new [] { 12, 34, 56 },
                new Node { 
                    Left = new Node { Data = 12 }, 
                    Data = 34, 
                    Right = new Node { Data = 56 } });
        }
    }
}