<Query Kind="Program">
  <Reference>C:\Libs\MongoDB.Bson.dll</Reference>
  <Reference>C:\Libs\nunitlite.dll</Reference>
  <Namespace>MongoDB.Bson</Namespace>
  <Namespace>MongoDB.Bson.IO</Namespace>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite.Runner</Namespace>
</Query>

void Main() {
    new NUnitLite.Runner.TextUI().Execute(new[] { "-noheader" });
}

static class Algos {
    internal static Node RemoveDups (Node node) {
        var hashSet = new HashSet<int?>();
        Node.Traverse(node, (n) => hashSet.Add(n.Data));
        return node;
    }
}

internal class Node {
	public int? Data { get; private set; }
	public Node Next { get; set; }
    //public Node Rand { get; set; }
    //public IEnumerable<int> Nums { get; set; }
	
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
	
	internal void Traverse () {
		var currentNode = this;
		while (currentNode != null) {
			("Data: " + currentNode.Data).Dump();
			currentNode = currentNode.Next;
		}
	}
    
    internal static void Traverse (Node node, Action<Node> add) {
		var currentNode = node;
		while (currentNode != null) {
			add(currentNode);
			currentNode = currentNode.Next;
		}
	}
	
	internal Node ExtractNext () {
		if (this.Next == null) return null;
		
		var extracted = Next;		
		Next = Next.Next;
		return extracted;		
	}
	
	internal Node InsertAfter (Node inserting) {
		if (inserting != null) {
			inserting.Next = Next;
			Next = inserting;
		}
		return inserting;
	}
}

[TestFixture]
internal class Tests { 
    [Test, TestCaseSource(typeof(TestCaseStorage), "TestCases")]
    public void RemoveDuplicates_OnTestCases_AssertPasses(Node listDups, Node listDistinct) {
        var cfg = new JsonWriterSettings();
        cfg.Indent = true;
        //listDistinct.ToJson(cfg).Dump();
		Assert.AreEqual(expected: listDistinct.ToJson(), actual: Algos.RemoveDups(listDups).ToJson());
    }
}

class TestCaseStorage {   
    static IEnumerable TestCases {
        get {
            yield return new TestCaseData(ComposeLinkedList(), ComposeLinkedListDistinct());
        }
    }
    
    static Node ComposeLinkedList() {
        var list = ComposeLinkedListDistinct();
        list.AppendToTail(new Node(7));
        //list.Traverse(); "---".Dump();
        //list.Traverse();
        return list;
    }
    
    static Node ComposeLinkedListDistinct() {
        Node list = new Node(5);
//        list.Rand = new Node(9);
//        list.Nums = new [] { 3, 2, 1 };
//        list.Rand.Next = new Node(11);
        list.AppendToTail(new Node(6));        
        list.AppendToTail(new Node(7));
        return list;
    }
}