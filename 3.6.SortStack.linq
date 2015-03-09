<Query Kind="Program">
  <Reference>C:\Libs\nunitlite.dll</Reference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite.Runner</Namespace>
</Query>

void Main() {
    new NUnitLite.Runner.TextUI().Execute(new[] { "-noheader" });
}

static class Algos {
    internal static Stack<int> BubbleSort(this Stack<int> unsorted) {
        return unsorted;
    }
}

[TestFixture]
internal class Tests { 
    [Test, TestCaseSource(typeof(TestCaseStorage), "TestCases")]
    public void Run_OnTestCases_AssertPasses(Stack<int> unsortedStack, Stack<int> sortedStack) {
		Assert.AreEqual(expected: sortedStack, actual: unsortedStack.BubbleSort());
    }
}

class TestCaseStorage {   
    static IEnumerable TestCases {
        get {
            yield return new TestCaseData(new Stack<int>(new [] { 1, 2, 3 }), new Stack<int>(new [] { 3, 2, 1 }));
        }
    }
}