<Query Kind="Program">
  <Reference>C:\Libs\nunitlite.dll</Reference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite.Runner</Namespace>
</Query>

void Main() {
    new NUnitLite.Runner.TextUI().Execute(new[] { "-noheader" });
}

static class Algos {
    internal static int[,] Rotate(this int[,] arr) {
        for (var n = 0; n < arr.GetLength(0); n++)
            for (var p = 0; p < arr.GetLength(1); p++)
                if (n > p) {
                    var temp = arr[p, n];
                    arr[p, n] = arr[n, p];
                    arr[n, p] = temp;
                }        
        return arr;
    }
}

[TestFixture]
internal class Tests { 
    [Test, TestCaseSource(typeof(TestCaseStorage), "TestCases")]
    public void Run_OnTestCases_AssertPasses(int[,] inputArr, int[,] expected) {
		Assert.AreEqual(expected: expected, actual: inputArr.Rotate());
    }
}

class TestCaseStorage {   
    static IEnumerable TestCases {
        get {
            yield return new TestCaseData(new int[,] { { 1, 2 }, { 3, 4 } }, new int[,] { { 1, 3 }, { 2, 4 } });
        }
    }
}