<Query Kind="Program">
  <Reference>C:\Libs\nunitlite.dll</Reference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite.Runner</Namespace>
</Query>

void Main() {
    new NUnitLite.Runner.TextUI().Execute(new[] { "-noheader" });
}

static class Algos {
    internal static bool IsSamePermutation(string one, string two) {
        return Enumerable.SequenceEqual(one.OrderBy(c => c), two.OrderBy(c => c));
    }
    
    internal static bool IsSamePermutationOnLists(string one, string two) {
        return one.Sort() == two.Sort();
    }
    
    static string Sort(this string orig) {
        var charList = orig.ToList();
        charList.Sort();
        return string.Join("", charList);
    }
}

[TestFixture]
internal class Tests { 
    [Test, TestCaseSource(typeof(TestCaseStorage), "TestCases")]
    public bool IsSamePermutation_OnTestCases_ReturnsExpected(string one, string two) {
		return Algos.IsSamePermutation(one, two);
    }
    
    [Test, TestCaseSource(typeof(TestCaseStorage), "TestCases")]
    public bool IsSamePermutationOnLists_OnTestCases_ReturnsExpected(string one, string two) {
		return Algos.IsSamePermutationOnLists(one, two);
    }
}

class TestCaseStorage {
    static IEnumerable TestCases {
        get {
            //yield return new TestCaseData("", "").Returns();
            yield return new TestCaseData("aaa", "aaa").Returns(true);
            yield return new TestCaseData("abc", "abc").Returns(true);
            yield return new TestCaseData("bca", "cba").Returns(true);
            yield return new TestCaseData("sdf", "wer").Returns(false);
            yield return new TestCaseData("abca", "caba").Returns(true);
            yield return new TestCaseData("sdfff", "wwwer").Returns(false);
        }
    }
}
