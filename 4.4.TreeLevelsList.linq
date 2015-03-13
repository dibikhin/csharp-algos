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
    internal static List<ListNode> LevelsToLinkedLists(this TreeNode tree) {
        if (tree == null) return new List<ListNode>();
        return MakeLinkedLists(tree);
    }
    
    private static List<ListNode> MakeLinkedLists(TreeNode tree) {
        return new List<ListNode>();
    }
}

internal class TreeNode {
    public TreeNode Left { get; set; }
    public int Data { get; set; }
    public TreeNode Right { get; set; }
}

internal class ListNode {
    public ListNode Next { get; set; }
    public int Data { get; set; }
}

[TestFixture]
internal class Tests {
    [Test, TestCaseSource(typeof(TestCaseStorage), "TestCases")]
    public void Run_OnTestCases_AssertPasses(TreeNode tree, List<ListNode> levelLists) {
        levelLists.ToJson().Dump("l"); tree.LevelsToLinkedLists().ToJson().Dump("t");
		Assert.AreEqual(expected: levelLists.ToJson(), actual: tree.LevelsToLinkedLists().ToJson());
    }
}

class TestCaseStorage {
    static IEnumerable TestCases {
        get {
            yield return new TestCaseData((TreeNode)null, new List<ListNode>());
            yield return new TestCaseData(new TreeNode { Data = 123 }, new List<ListNode> { new ListNode { Data = 123 } });
            yield return new TestCaseData(new [] { 543, 9876 },
                new TreeNode { 
                    Left = new TreeNode { Data = 543 }, 
                    Data = 9876 });
            yield return new TestCaseData(new [] { 12, 34, 56 },
                new TreeNode { 
                    Left = new TreeNode { Data = 12 }, 
                    Data = 34, 
                    Right = new TreeNode { Data = 56 } });
        }
    }
}