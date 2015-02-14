<Query Kind="Program">
  <Reference>C:\Libs\nunitlite.dll</Reference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite.Runner</Namespace>
</Query>

void Main() {
    new NUnitLite.Runner.TextUI().Execute(new[] { "-noheader" });
}

static class Algos {
    internal static string Compress(this string str) {
        var arr = new int[0xffff];
        foreach (var ch in str) {
            arr[(int)ch] += 1;
        }
        arr.Where(i=>i>0).Dump();
        return str;
    }
}

[TestFixture]
internal class Tests { 
    [Test, TestCaseSource(typeof(TestCaseStorage), "TestCases")]
    public string Run_OnTestCases_AssertPasses(string str) {
		return str.Compress();
    }
}

class TestCaseStorage {   
    static IEnumerable TestCases {
        get {
            yield return new TestCaseData("aabcccccaaa").Returns("a2b1c5a3");
        }
    }
}