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

internal class MyStack<T> {
    public Node<T> _top = null;
    
    public T Min {
        get {
            return _min;
        }
    }
    
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
        if (_min == Int32.MinValue) {
            _min = obj;
        } else if (obj < _min) {
            _min = obj;
        }
    }
    
    private int _count = 0;
    private int _min = Int32.MinValue;
}

internal class Node<T> {
    public T Data { get; set; }
    public Node<T> Next { get; set; }
}

[TestFixture]
internal class Tests { 
    [Test, TestCaseSource(typeof(TestCaseStorage), "TestCases")]
    public void Run_OnTestCases_AssertPasses(MyStack<string> s, int count) {
		Assert.AreEqual(expected: count, actual: s.Count);
    }
    
    [Test]
    public void PushPop_OnEmpty_Empty() {
        var s = new MyStack<string>();
        s.Push("asdf");
        s.Pop();
		Assert.AreEqual(expected: Data.Zero().ToJson(), actual: s.ToJson());
    }
    
    [Test]
    public void PushPushPop_OnEmpty_FirstElOnly() {        
        var s = new MyStack<string>();
        s.Push("asdf");
        s.Push("zxcv");
        s.Pop();
		Assert.AreEqual(expected: Data.One("asdf").ToJson(), actual: s.ToJson());
    }
    
    [Test]
    public void PushPushPopPop_OnEmpty_Empty() {        
        var s = new MyStack<string>();
        s.Push("asdf");
        s.Push("zxcv");
        s.Pop();
        s.Pop();
		Assert.AreEqual(expected: Data.Zero().ToJson(), actual: s.ToJson());
    }
    
    [Test]
    public void PushPopPush_OnEmpty_LastPushedOnly() {
        var s = new MyStack<string>();
        s.Push("asdf");
        s.Pop();
        s.Push("zxcv");
		Assert.AreEqual(expected: Data.One("zxcv").ToJson(), actual: s.ToJson());
    }
    
    [Test]
    public void Push_OnEmpty_MinEqualsEl() {
        var s = new MyStack<int>();
        s.Push(5);     
		Assert.AreEqual(expected: 5, actual: s.Min);
    }
}

class TestCaseStorage {   
    static IEnumerable TestCases {
        get {
            yield return new TestCaseData(Data.Zero(), 0);
            yield return new TestCaseData(Data.One("asdf"), 1);
            yield return new TestCaseData(Data.Two("poiu", "lkjh"), 2);
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