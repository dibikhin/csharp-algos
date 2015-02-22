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
    internal static void InstantRemove (Node node) {
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
    public void Run_OnTestCases_AssertPasses (Node origList, Node cleanList, Node extraNode) {
        Algos.InstantRemove(extraNode);
		Assert.AreEqual(expected: cleanList.ToJson(), actual: origList.ToJson());
    }
}

class TestCaseStorage {   
    static IEnumerable TestCases {
        get {
            yield return new TestCaseData(ComposeLinkedListDirty(), ComposeLinkedListClean(), new Node(6));
        }
    }
    
    static Node ComposeLinkedListDirty() {
        Node list = new Node(5);
        list.AppendToTail(new Node(6)).AppendToTail(new Node(7));
        return list;
    }
    
    static Node ComposeLinkedListClean() {
        Node list = new Node(5);
        list.AppendToTail(new Node(7));
        return list;
    }
}