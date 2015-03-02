<Query Kind="Program">
  <Reference>C:\Libs\nunitlite.dll</Reference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite.Runner</Namespace>
</Query>

void Main() {
    new NUnitLite.Runner.TextUI().Execute(new[] { "-noheader" });
}

internal class MyQueue<T> {
    public int Count { get; set; }
    public T Data { get; set; }
    public T Pop() { return (T)new object(); }
    public void Push(T t) {}
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
            yield return new TestCaseData(new MyQueue<string>(), 0);
        }
    }
}