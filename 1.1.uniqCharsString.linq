<Query Kind="Program">
  <Reference>C:\Libs\nunitlite.dll</Reference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite.Runner</Namespace>
</Query>

void Main() {
    new NUnitLite.Runner.TextUI().Execute(new[] { "-noheader" });
}

static class Algos {
    internal static bool IsCharsUnique(string str) {
        var hash = new HashSet<char>();
        foreach (var chr in str)
            if (hash.Contains(chr))
                return false;
            else
                hash.Add(chr);

        return true;
    }
    
    internal static bool IsCharsUniquePlain(string str) {
        const int charCount = 0xffff + 1;
        var arr = new int [charCount];
        foreach (var chr in str) {
            int ix = (int)chr;
            if (arr[ix] == 1)                
                return false;
            else
                arr[ix] = 1;
        }
        return true;
    }
}

[TestFixture]
internal class Tests {
    [Test, TestCaseSource(typeof(TestCaseStorage), "TestCases")]
    public bool IsCharsUnique_OnTestCases_ReturnsExpected(string str) {
		return Algos.IsCharsUnique(str);
    }
    
    [Test, TestCaseSource(typeof(TestCaseStorage), "TestCases")]
    public bool IsCharsUniquePlain_OnTestCases_ReturnsExpected(string str) {
		return Algos.IsCharsUniquePlain(str);
    }
}

class TestCaseStorage {   
    static IEnumerable TestCases {
        get {
            //yield return new TestCaseData("").Returns(true); should throw exception
            yield return new TestCaseData("\t").Returns(true);
            yield return new TestCaseData("\t\t").Returns(false);
            yield return new TestCaseData("asdf").Returns(true);
            yield return new TestCaseData("asddf").Returns(false);
            yield return new TestCaseData("aaasssddfff").Returns(false);
            yield return new TestCaseData("\u0000\u0000").Returns(false);
            yield return new TestCaseData("\uffff\uffff").Returns(false);
        }
    }
}
