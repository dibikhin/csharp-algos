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
//        var arr = new int[0xffff];
//        foreach (var ch in str) {
//            arr[(int)ch] += 1;
//        }
//        arr.Where(i=>i>0).Dump();
        var chars = str.ToCharArray();
        var i = 0;
        var c = 1;
        var result = "";
        var chr = '#';
        while (i < chars.Length) {
            chr = chars[i];
            if (cnt == 1)
                result += chr;            
            if (i + 1 < chars.Length) {
                if (chars[i + 1] != chr) { 
                    result += c;
                    c = 1;
                } else
                    c += 1;      
            } else
                result += c;
            i += 1;
        }
        return result;
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
            yield return new TestCaseData("vvvvv").Returns("v5");
            yield return new TestCaseData("aabcccccaaa").Returns("a2b1c5a3");
        }
    }
}