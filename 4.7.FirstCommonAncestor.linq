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
        var list = new List<ListNode>();
        if (tree == null) return list;
        return MakeLinkedLists(tree, list, dep: 0);
    }
}

internal class TreeNode {
    public TreeNode Left { get; set; }
    public int Data { get; set; }
    public TreeNode Right { get; set; }
}

[TestFixture]
internal class Tests {
    [Test, TestCaseSource(typeof(TestCaseStorage), "TestCases")]
    public void Run_OnTestCases_AssertPasses(TreeNode tree, List<ListNode> levelLists) {
        //levelLists.ToJson().Dump("l"); tree.ToJson().Dump("t"); tree.LevelsToLinkedLists().ToJson().Dump("tlevs");
		Assert.AreEqual(expected: levelLists.ToJson(), actual: tree.LevelsToLinkedLists().ToJson());
    }
}

class TestCaseStorage {
    static IEnumerable TestCases {
        get {
            yield return new TestCaseData((TreeNode)null, new List<ListNode>());
            yield return new TestCaseData(
                new TreeNode { Data = 123 }, 
                new List<ListNode> { new ListNode { Data = 123 } });
            yield return new TestCaseData(
                new TreeNode { 
                    Left = new TreeNode { Data = 543 }, 
                    Data = 9876 },
                new List<ListNode> { 
                    new ListNode { Data = 9876 },
                    new ListNode { Data = 543 } });
            yield return new TestCaseData(
                new TreeNode { 
                    Left = new TreeNode { Data = 12 }, 
                    Data = 34, 
                    Right = new TreeNode { Data = 56 } },
                new List<ListNode> { 
                    new ListNode { Data = 34 },
                    new ListNode { Data = 12, Next = new ListNode { Data = 56 } } });
        }
    }
}