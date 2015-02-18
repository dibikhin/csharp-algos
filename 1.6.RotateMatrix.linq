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
        var newArr = new int[arr.GetLength(0), arr.GetLength(1)];
        for (var p = 0; p < arr.GetLength(1); p++)
            for (var n = arr.GetLength(0) - 1; n > -1; n--) {
                newArr[p, arr.GetLength(0) - 1 - n] = arr[n, p];                
            }
        return newArr;
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
            yield return new TestCaseData(
                new int[,] { { 1, 2 }, { 3, 4 } }, new int[,] { { 3, 1 }, { 4, 2 } });
            yield return new TestCaseData(
                new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9} },
                new int[,] { { 7, 4, 1 }, { 8, 5, 2 }, { 9, 6, 3} });
            yield return new TestCaseData(
                new int[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12}, { 13, 14, 15, 16} },
                new int[,] { { 13, 9, 5, 1 }, { 14, 10, 6, 2 }, { 15, 11, 7, 3}, { 16, 12, 8, 4} } );
        }
    }
}