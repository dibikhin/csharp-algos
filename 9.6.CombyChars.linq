<Query Kind="Program">
  <Reference>C:\Libs\nunitlite.dll</Reference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite.Runner</Namespace>
</Query>

void Main() {
    new NUnitLite.Runner.TextUI().Execute(new[] { "-noheader" });
}

class Algos {
    internal static string GenCombs(string chars, int count) {
        // () -> L ( I ) R
        var chars1 = "L(I)R";
        var list = new List<string>();
        var chars2 = chars1.Replace("L", chars1 + "L");
        chars2 = chars2.Replace("L", "");
        chars2 = chars2.Replace("I", "");
        chars2 = chars2.Replace("R", "");        
        list.Add(chars2);
        
        return string.Join(", ", list);
    }
}

[TestFixture]
internal class Tests {
    [Test, TestCaseSource(typeof(TestCaseStorage), "TestCases")]
    public void Run_OnTestCases_AssertPasses(string chars, int count, string combs) {
		Assert.AreEqual(expected: combs, actual: Algos.GenCombs(chars, count));
    }
}

class TestCaseStorage {
    static IEnumerable TestCases {
        get {
            yield return new TestCaseData("()", 1, "()");
            yield return new TestCaseData("()", 2, "()(), (())");
            yield return new TestCaseData("()", 3, "()()(), ((())), ()(()), (())(), (()())");
                                                   // "()(), (()), (()), (()), (())"
        }
    }
}