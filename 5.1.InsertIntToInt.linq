<Query Kind="Program">
  <Reference>C:\Libs\nunitlite.dll</Reference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite.Runner</Namespace>
</Query>

void Main() {
    new NUnitLite.Runner.TextUI().Execute(new[] { "-noheader" });
}

static class Algos {
    internal static int Insert(this int first, int second, int startPos) {
        return first | (second << startPos);
    }
}

static class Helpers {
    internal static int ToInt32(this string str) {
        return Convert.ToInt32(str, 2);
    }
}

[TestFixture]
internal class Tests {
    [Test, TestCaseSource(typeof(TestCaseStorage), "TestCases")]
    public void Run_OnTestCases_AssertPasses(
        int first, int second, int startPos, int result) {
		Assert.AreEqual(
            expected: result, actual: first.Insert(second, startPos: startPos));
    }
}

class TestCaseStorage {
    static IEnumerable TestCases {
        get {
            yield return new TestCaseData(
                "10000000000".ToInt32(), "10011".ToInt32(), /**/ 2, "10001001100".ToInt32());
        }
    }
}