<Query Kind="Program" />

void Main()
{
	Node list;
	var node5 = new Node(5);
	list = node5;
	list.AppendToTail(new Node(6));
	var node7 = new Node(7);
	list.AppendToTail(node7);
	list.AppendToTail(new Node(50));
	list.AppendToTail(new Node(60));
	list.AppendToTail(new Node(70));
	list.Traverse(); "---".Dump();
	
	Node.RunWeave(Tuple.Create(node7, node5));
	list.Traverse();
    list.Dump();
}

// Define other methods and classes here

class Node {
	internal int? Data { get; private set; }
	internal Node Next { get; set; }
	
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
	
	internal static void RunWeave (Tuple<Node, Node> tp) {
		var newTp = tp;
		while(newTp.Item1 != null && newTp.Item2 != null)
			newTp = Node.Weave(newTp);
	}
	
	internal static Tuple<Node, Node> Weave (Tuple<Node, Node> tp) {
		var extracted = tp.Item1.ExtractNext();		
		if(extracted == null) return Tuple.Create<Node, Node> (null, null);
		
		var nextToExt = extracted.Next;
		var nextToIns = tp.Item2.Next;
		tp.Item2.InsertAfter(extracted);
		
		return Tuple.Create (nextToIns, nextToExt);
	}
}