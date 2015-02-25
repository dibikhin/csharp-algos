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
    internal static void PartitionOver(Node list, int pivotNum) {
        // find pivot
        var curNode = list;
        Node pivot = null;
        while (curNode != null) {
            if (curNode.Data == pivotNum) {
                pivot = curNode;
                break;
            }
            curNode = curNode.Next;
        }
        list.Dump();
        pivot.Dump();
        return;
        // partition it
        if (pivot != null) {
            curNode = list; // var!
            while (curNode != null) {
                var temp = curNode.Next;
                if (curNode.Data > pivot.Data) {                    
                    curNode.Next = pivot.Next;
                    pivot.Next = curNode;
                }
                curNode = temp;
            }
        }
        list.Dump();
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
        Algos.PartitionOver(origList, pivotNum: num);
		Assert.AreEqual(expected: partitionedList.ToJson(), actual: origList.ToJson());
    }
}

class TestCaseStorage {   
    static IEnumerable TestCases {
        get {
            yield return new TestCaseData(ComposeLinkedList(), ComposeLinkedListPartitioned(), 5);
        }
    }
    
    static Node ComposeLinkedList() {
        Node list = new Node(7);
        list.AppendToTail(new Node(4))
            .AppendToTail(new Node(9))
            .AppendToTail(new Node(5))
            .AppendToTail(new Node(8));
        return list;
    }
    
    static Node ComposeLinkedListPartitioned() {
        Node list = new Node(4);
        list.AppendToTail(new Node(5))
            .AppendToTail(new Node(9))
            .AppendToTail(new Node(7))
            .AppendToTail(new Node(8));
        return list;
    }
}