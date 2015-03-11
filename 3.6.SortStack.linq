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

static class Algos {
    internal static Stack<int> BubbleSort(this Stack<int> unsorted) {
        var tempStack = new Stack<int>();
        int? temp1 = null;
        int? temp2 = null;

        bool swapped;
        do {
            swapped = false;
            while (unsorted.Count > 0) {
                if (temp1 == null) {
                    temp1 = unsorted.Pop();
                }
                if (unsorted.Count > 0 && temp2 == null) {
                    temp2 = unsorted.Pop();
                }
                if (temp1.HasValue && temp2.HasValue) {
                    if (temp2 < temp1) {
                        tempStack.Push(temp1.Value);
                        temp1 = null;
                        swapped = true;
                    } else {
                        tempStack.Push(temp2.Value);
                        temp2 = null;
                    }
                }
            }

            if (temp1 != null) {
                tempStack.Push(temp1.Value);
                temp1 = null;
            }
            if (temp2 != null) {
                tempStack.Push(temp2.Value);
                temp2 = null;
            }
    
            while (tempStack.Count > 0) {
                unsorted.Push(tempStack.Pop());
            }
        } while (!swapped);
        
        return unsorted;
    }
}

[TestFixture]
internal class Tests {
    [Test, TestCaseSource(typeof(TestCaseStorage), "TestCases")]
    public void Run_OnTestCases_AssertPasses(Stack<int> unsortedStack, Stack<int> sortedStack) {
		Assert.AreEqual(
            expected: sortedStack.ToJson(), actual: unsortedStack.BubbleSort().ToJson());
    }
}

class TestCaseStorage {   
    static IEnumerable TestCases {
        get {
//            yield return new TestCaseData(
//                new Stack<int>(), new Stack<int>());
//            yield return new TestCaseData(
//                new Stack<int>(new [] { 1 }), new Stack<int>(new [] { 1 }));
//            yield return new TestCaseData(
//                new Stack<int>(new [] { 2, 1 }), new Stack<int>(new [] { 1, 2 }));
            yield return new TestCaseData(
                new Stack<int>(new [] { 3, 2, 1 }), new Stack<int>(new [] { 1, 2, 3 }));
        }
    }
}