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
    internal static List<Node> LevelsToLinkedLists(this Node tree) {
        if (tree == null) return new List<Node>();
        return MakeLinkedLists();
    }
    
    private static List<Node> MakeLinkedLists() {
        return new List<Node>();
    }
}

internal class Node {
    public Node Left { get; set; }
    public int Data { get; set; }
    public Node Right { get; set; }
}

[TestFixture]
internal class Tests {
    [Test, TestCaseSource(typeof(TestCaseStorage), "TestCases")]
    public void Run_OnTestCases_AssertPasses(Node tree, List<Node> levelLists) {
        levelLists.ToJson().Dump("l"); tree.LevelsToLinkedLists().ToJson().Dump("t");
		Assert.AreEqual(expected: levelLists.ToJson(), actual: tree.LevelsToLinkedLists().ToJson());
    }
}

class TestCaseStorage {
    static IEnumerable TestCases {
        get {
            yield return new TestCaseData((Node)null, new List<Node>());
            yield return new TestCaseData(new Node { Data = 123 }, new List<Node> { new Node { Data = 123 } });
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