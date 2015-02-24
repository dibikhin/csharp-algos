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
    internal static void PartitionOver(Node list, int num) {
        var curNode = list;
        Node pivot = null;
        while (curNode != null) {
            if (curNode.Data == num) {
                pivot = curNode;
                break;
            }
            curNode = curNode.Next;
        }
    }
}

internal class Node {
	public int? Data { get; set; }
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
    public void Run_OnTestCases_AssertPasses(Node origList, Node partitionedList, int num) {
        Algos.PartitionOver(origList, num);
		Assert.AreEqual(expected: partitionedList.ToJson(), actual: origList.ToJson());
    }
}

class TestCaseStorage {   
    static IEnumerable TestCases {
        get {
            yield return new TestCaseData(ComposeLinkedList(), ComposeLinkedListPartitioned(), 6);
        }
    }
    
    static Node ComposeLinkedList() {
        Node list = new Node(5);
        list.AppendToTail(new Node(6)).AppendToTail(new Node(7));
        return list;
    }
    
    static Node ComposeLinkedListPartitioned() {
        Node list = new Node(5);
        list.AppendToTail(new Node(7));
        return list;
    }
}