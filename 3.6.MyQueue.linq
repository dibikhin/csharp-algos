<Query Kind="Program">
  <Reference>C:\Libs\nunitlite.dll</Reference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite.Runner</Namespace>
</Query>

void Main() {
    new NUnitLite.Runner.TextUI().Execute(new[] { "-noheader" });
}

internal class MyQueue<T> {
    public int Count {
        get {
            return _stack1.Count;
        }
    }

    public T Dequeue() {
        Transfuse(_stack1, _stack2);
        var temp = _stack2.Pop();
        Transfuse(_stack2, _stack1);
        return temp;
    }

    public void Enqueue(T obj) {
        _stack1.Push(obj);
        _stack1.Dump();
    }

    private Stack<T> _stack1 = new Stack<T>();
    private Stack<T> _stack2 = new Stack<T>();
    
    private void Transfuse(Stack<T> @from, Stack<T> to) {
        while (@from.Count > 0) {
            to.Push(@from.Pop());
        }
    }
}

[TestFixture]
internal class Tests { 
    [Test, TestCaseSource(typeof(TestCaseStorage), "TestCases")]
    public void Run_OnTestCases_AssertPasses(MyQueue<string> q, int count) {
		Assert.AreEqual(expected: count, actual: q.Count);
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
    internal static MyQueue<string> Zero() {
        return new MyQueue<string>();
    }

    internal static MyQueue<string> One(string str) {
        var q = new MyQueue<string>();
        q.Enqueue(str);
        return q;
    }
    
    internal static MyQueue<string> Two(string str1, string str2) {
        var q = new MyQueue<string>();
        q.Enqueue(str1);
        q.Enqueue(str2);
        return q;
    }
}