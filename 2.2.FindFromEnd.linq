<Query Kind="Program">
  <Reference>C:\Libs\nunitlite.dll</Reference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite.Runner</Namespace>
</Query>

void Main() {
    new NUnitLite.Runner.TextUI().Execute(new[] { "-noheader" });
}

static class Algos {
    internal static int FindFromEnd (Node node, int num) {
        var stack = new Stack<Node>();
        
        var curNode = node;
		while (curNode != null) {
			stack.Push(curNode);
			curNode = curNode.Next;
		}
        
        var cnt = 1;
        while (stack.Count >= 0) {
            var stNode = stack.Pop();
            if (stNode.Data == num)
                return cnt;
            cnt += 1;
        }
        
        return -1;
    }
}

internal class Node {
	public int? Data { get; private set; }
	public Node Next { get; set; }
	
	internal Node () { }
	
	internal Node (int val) {
		Data = val;
	}
	
	internal Node AppendToTail (Node newTail) {
		var n = this;
		while (n.Next != null) {
			n = n.Next;
		}
		n.Next = newTail;
		return newTail;
	}
}

[TestFixture]
internal class Tests { 
    [Test, TestCaseSource(typeof(TestCaseStorage), "TestCases")]
    public void RemoveDuplicates_OnTestCases_AssertPasses(Node list, int num, int pos) {
		Assert.AreEqual(expected: pos, actual: Algos.FindFromEnd(list, num));
    }
}

class TestCaseStorage {   
    static IEnumerable TestCases {
        get {
            yield return new TestCaseData(ComposeLinkedListDistinct(), 5, 3);
        }
    }
    
    static Node ComposeLinkedListDistinct() {
        Node list = new Node(5);
        list.AppendToTail(new Node(6)).AppendToTail(new Node(7));
        return list;
    }
}