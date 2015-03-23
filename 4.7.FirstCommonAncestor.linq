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
    internal static TreeNode FindFirstCommonAncentorWith(this TreeNode nodeOne, TreeNode nodeTwo) {
        return null;
    }
}

internal class TreeNode {
    public TreeNode Parent { get; set; }
    
    public TreeNode Left { get; set; }    
    public TreeNode Right { get; set; }
    
    public int Data { get; set; }
}

[TestFixture]
internal class Tests {
    [Test, TestCaseSource(typeof(TestCaseStorage), "TestCases")]
    public void Run_OnTestCases_AssertPasses(TreeNode nodeOne, TreeNode nodeTwo, TreeNode anc) {
		Assert.AreEqual(expected: anc.ToJson(), actual: node.FindFirstCommonAncentorWith(nodeTwo).ToJson());
    }
}

class TestCaseStorage {
    static IEnumerable TestCases {
        get {
            yield return new TestCaseData();
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