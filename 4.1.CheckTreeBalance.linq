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
    internal static bool IsBalanced(this TreeNode tree) {
        if (tree == null) throw new ArgumentNullException("tree");
        var depths = new List<int>();
        IsBalanced(tree, depths, 0);
        return (depths.Max() - depths.Min()) < 2;
    }
    
    private static void IsBalanced(TreeNode tree, List<int> depths, int dep) {
        if (tree == null) {
            depths.Add(dep);
            return;
        }
        IsBalanced(tree.Left, depths, dep + 1);
        IsBalanced(tree.Right, depths, dep + 1);
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
    public void Run_OnTestCases_AssertPasses(TreeNode tree, bool isBalanced) {
        //levelLists.ToJson().Dump("l"); tree.ToJson().Dump("t"); tree.LevelsToLinkedLists().ToJson().Dump("tlevs");
		Assert.AreEqual(expected: isBalanced, actual: tree.IsBalanced());
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
                    Left = new TreeNode { Data = 2345 }, 
                    Data = 4325, 
                    Right = new TreeNode { Data = 5432 } },
                true);
            yield return new TestCaseData(
                new TreeNode { 
                    Left = new TreeNode { 
                        Data = 12,
                        Left = new TreeNode { Data = 87 } }, 
                    Data = 34, 
                    Right = new TreeNode { Data = 56 } },
                true);
            yield return new TestCaseData(
                new TreeNode { 
                    Left = new TreeNode { 
                        Data = 99,
                        Left = new TreeNode { 
                            Data = 88 } }, 
                    Data = 77 },
                false);
            yield return new TestCaseData(
                new TreeNode { 
                    Left = new TreeNode { 
                        Data = 99,
                        Left = new TreeNode { 
                            Data = 88, 
                            Left = new TreeNode { Data = 66 } } }, 
                    Data = 77 },
                false);
        }
    }
}