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
    internal static TreeNode FindFirstCommonAncentorWith(
        this TreeNode nodeOne, TreeNode nodeTwo, TreeNode tree) {
        // find first parent whose descendants contain this node
        if (nodeOne.DescendantsContain(nodeTwo))
            return nodeOne;
        else if (nodeOne.Parent != null
            && nodeOne.Parent.DescendantsContain(nodeTwo))
            return nodeOne.Parent;
        return null;
    }
}

static class TreeNodeExts {
    internal static bool DescendantsContain(this TreeNode tree, TreeNode aimNode) {
        if (tree.Left.Data == aimNode.Data || tree.Right.Data == aimNode.Data)
            return true;
        if (tree.Left == null && tree.Right == null)
            return false;
        if (tree.Left != null)
            return tree.Left.DescendantsContain(aimNode);
        if (tree.Right != null)
            return tree.Right.DescendantsContain(aimNode);
        return false;
    }
}

class TestCaseStorage {
    static IEnumerable TestCases {
        get {
            yield return new TestCaseData(
                new TreeNode {
                    Parent = null,
                    Left = new TreeNode { Data = 23 },
                    Right = new TreeNode { Data = 11 },
                    Data = 67 },
                new TreeNode { Data = 23 },
                new TreeNode { Data = 11 },
                new TreeNode { Data = 67 });
        }
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
    public void Run_OnTestCases_AssertPasses(TreeNode tree, TreeNode nodeOne, TreeNode nodeTwo, TreeNode ancestor) {
        tree.Dump();
		Assert.AreEqual(
            expected: ancestor.Data,
            actual: nodeOne.FindFirstCommonAncentorWith(nodeTwo, tree).Data);
    }
}