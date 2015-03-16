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
    internal static bool IsBST(this TreeNode tree) {
        if (tree == null) throw new ArgumentNullException("tree");
        return IsBstRec(tree);
    }
    
    private static bool IsBstRec(TreeNode tree) {
        if (tree.Left == null || tree.Right == null) return true;
        if (tree.Left == null && tree.Right != null)
            return tree.Data <= tree.Right.Data;
        if (tree.Right == null && tree.Left != null)
            return tree.Left.Data <= tree.Data;
        if (tree.Left != null && tree.Right != null)
            return tree.Left.Data <= tree.Right.Data;
        var leftIsBst = IsBstRec(tree.Left);
        var rightIsBst = IsBstRec(tree.Right);
        return leftIsBst && rightIsBst;
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
    public void Run_OnTestCases_AssertPasses(TreeNode tree, bool isBST) {        
		Assert.AreEqual(expected: isBST, actual: tree.IsBST());
    }
}

class TestCaseStorage {
    static IEnumerable TestCases {
        get {
            yield return new TestCaseData((TreeNode)null, false).Throws(typeof(ArgumentNullException));
            yield return new TestCaseData(
                new TreeNode { Data = 123 },
                true);
            yield return new TestCaseData(
                new TreeNode { 
                    Left = new TreeNode { Data = 543 }, 
                    Data = 9876 },
                true);
            yield return new TestCaseData(
                new TreeNode {
                    Data = 9876,
                    Right = new TreeNode { Data = 345 } },
                true); // shouldn't pass, but it does
            yield return new TestCaseData(
                new TreeNode { 
                    Left = new TreeNode { Data = 12 }, 
                    Data = 34, 
                    Right = new TreeNode { Data = 56 } },
                true);
           yield return new TestCaseData(
                new TreeNode { 
                    Left = new TreeNode {
                        Left = new TreeNode { Data = 99 },
                        Data = 12,
                        Right = new TreeNode { Data = 88 } 
                        }, 
                    Data = 34, 
                    Right = new TreeNode { Data = 56 } },
                false);
        }
    }
}