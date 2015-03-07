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

internal class MyStack {
    public Node<int> _top = null;
    
    public int Min {
        get {
            return _min;
        }
    }
    
    public int Count {
        get {
            return _count;
        }
    }

    public int Pop() {
        if (_top != null) {
            var node = _top;
            _top = _top.Next;
            _count -= 1;
            return node.Data;
        } else {
            throw new InvalidOperationException("your stack is empty");
        } 
    }

    public void Push(int obj) {
        var node = new Node<int> { Data = obj, Next = _top };
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
    public void Run_OnTestCases_AssertPasses(MyStack s, int count) {
		Assert.AreEqual(expected: count, actual: s.Count);
    }
    
    [Test]
    public void PushPop_OnEmpty_Empty() {
        var s = new MyStack();
        s.Push(12);
        s.Pop();
		Assert.AreEqual(expected: Data.Zero().ToJson(), actual: s.ToJson());
    }
    
    [Test]
    public void PushPushPop_OnEmpty_FirstElOnly() {        
        var s = new MyStack();
        s.Push(23);
        s.Push(24);
        s.Pop();
		Assert.AreEqual(expected: Data.One(23).ToJson(), actual: s.ToJson());
    }
    
    [Test]
    public void PushPushPopPop_OnEmpty_Empty() {        
        var s = new MyStack();
        s.Push(34);
        s.Push(35);
        s.Pop();
        s.Pop();
		Assert.AreEqual(expected: Data.Zero().ToJson(), actual: s.ToJson());
    }
    
    [Test]
    public void PushPopPush_OnEmpty_LastPushedOnly() {
        var s = new MyStack();
        s.Push(45);
        s.Pop();
        s.Push(46);
		Assert.AreEqual(expected: Data.One(46).ToJson(), actual: s.ToJson());
    }
    
    [Test]
    public void Push_OnEmpty_MinEqualsEl() {
        var s = new MyStack();
        s.Push(5);     
		Assert.AreEqual(expected: 5, actual: s.Min);
    }
}

class TestCaseStorage {   
    static IEnumerable TestCases {
        get {
            yield return new TestCaseData(Data.Zero(), 0);
            yield return new TestCaseData(Data.One(67), 1);
            yield return new TestCaseData(Data.Two(78, 79), 2);
        }
    }
}

static class Data {
    internal static MyStack Zero() {
        return new MyStack();
    }

    internal static MyStack One(int el) {
        var s = new MyStack();
        s.Push(el);
        return s;
    }
    
    internal static MyStack Two(int el1, int el2) {
        var s = new MyStack();
        s.Push(el1);
        s.Push(el2);
        return s;
    }
}