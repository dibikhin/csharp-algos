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
        return (T)new object();
    }

    public void Push(T obj) {

    }
    
    private int _count = 0;
    private Node<T> _top = null;
}

class Node<T> {
    T Data { get; set; }
    Node<T> Next { get; set; }
}

[TestFixture]
internal class Tests { 
    [Test, TestCaseSource(typeof(TestCaseStorage), "TestCases")]
    public void Run_OnTestCases_AssertPasses(MyStack<string> s, int count) {
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
        var q = new MyStack<string>();
        q.Push(str1);
        q.Push(str2);
        return q;
    }
}