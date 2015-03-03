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
            return _stack1.Count != 0
                ? _stack1.Count
                : _stack2.Count;
        }
    }

    public T Dequeue() {
        while (_stack1.Count > 0) {
            var temp = _stack1.Pop();
            _stack2.Push(temp);
        }
        return _stack2.Pop();
    }

    public void Enqueue(T obj) {
        _stack1.Push(obj);
    }

    private Stack<T> _stack1 = new Stack<T>();
    private Stack<T> _stack2 = new Stack<T>();
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
}