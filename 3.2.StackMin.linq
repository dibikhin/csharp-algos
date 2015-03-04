<Query Kind="Program">
  <Reference>C:\Libs\nunitlite.dll</Reference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite.Runner</Namespace>
</Query>

void Main() {
    new NUnitLite.Runner.TextUI().Execute(new[] { "-noheader" });
}

internal class MyStack<T> {
    public int Count {
        get {
            return _count;
        }
    }

    public T Pop() {
        if (_top != null) {
            var node = _top;
            _top = _top.Next;
            _count -= 1;
            return node.Data;
        } else {
            throw new InvalidOperationException("your stack is empty");
        } 
    }

    public void Push(T obj) {
        var node = new Node<T> { Data = obj, Next = _top };
        _top = node;
        _count += 1;
    }
    
    private int _count = 0;
    public Node<T> _top = null;
}

internal class Node<T> {
    public T Data { get; set; }
    public Node<T> Next { get; set; }
}

[TestFixture]
internal class Tests { 
    [Test, TestCaseSource(typeof(TestCaseStorage), "TestCases")]
    public void Run_OnTestCases_AssertPasses(MyStack<string> s, int count) {
        s.Dump();
		Assert.AreEqual(expected: count, actual: s.Count);
    }
}

class TestCaseStorage {   
    static IEnumerable TestCases {
        get {
            yield return new TestCaseData(Data.Zero(), 0);
            yield return new TestCaseData(Data.One("zxcv"), 1);
            yield return new TestCaseData(Data.Two("asdf", "qwer"), 2);
        }
    }
}

static class Data {
    internal static MyStack<string> Zero() {
        return new MyStack<string>();
    }

    internal static MyStack<string> One(string str) {
        var s = new MyStack<string>();
        s.Push(str);
        return s;
    }
    
    internal static MyStack<string> Two(string str1, string str2) {
        var s = new MyStack<string>();
        s.Push(str1);
        s.Push(str2);
        return s;
    }
}