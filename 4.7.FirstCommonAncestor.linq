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
        throw new Exception();
        return null;
    }
}

static class TreeNodeExts {
    internal static bool DescendantsContain(this TreeNode tree, TreeNode aimNode) {
        tree.Data.Dump(); aimNode.Data.Dump();
        if (tree.Data == aimNode.Data)
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
            var one = new TreeNode { Data = 23 };
            var two = new TreeNode { Data = 11 };
            var three = new TreeNode {
                    Parent = null,
                    Left = one,
                    Right = two,
                    Data = 67 };
            one.Parent = three;
            two.Parent = three;
            
            yield return new TestCaseData(
                three,
                one,
                two,
                three);
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
    public void Run_OnTestCases_AssertPasses(
        TreeNode tree, TreeNode nodeOne, TreeNode nodeTwo, TreeNode ancestor) {
		Assert.AreEqual(
            expected: ancestor.Data,
            actual: nodeOne.FindFirstCommonAncentorWith(nodeTwo, tree).Data);
    }
}