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
    internal static List<List<int>> Combinations(this List<int> list) {
        if (list.Count == 0) 
            return new List<List<int>> { "".ToIntList() };
        var combs = new List<List<int>> { "".ToIntList() };
        for (var n = 0; n < list.Count; n++) {        
            combs.Add(new List<int> { list[n] });
        }
        if (list.Count > 1) combs.Add(list);
        return combs;
    }
}

[TestFixture]
internal class MergeSortTests { 
    [Test, TestCaseSource(typeof(MyTestCases), "Lists")]
    public void Combinations_OnList_ReturnsListOfLists(List<int> list, List<List<int>> combs) {
		Assert.AreEqual(expected: combs.ToJson(), actual: list.Combinations().ToJson());
    }
}

static class TestHelper {
    internal static List<int> ToIntList(this string str) {
        if (string.IsNullOrWhiteSpace(str)) return new List<int>();
        
        // "321" -> new List<int> { 3, 2, 1 } 
        // "-321" -> fail
        return str.Select(c => int.Parse(c.ToString())).ToList();
    }
}

class MyTestCases {   
    static IEnumerable Lists {
        get {
            yield return new TestCaseData("".ToIntList(), new List<List<int>> { "".ToIntList() });
            yield return new TestCaseData("9".ToIntList(), new List<List<int>> { 
                "".ToIntList(), "9".ToIntList() });
            yield return new TestCaseData("87".ToIntList(), new List<List<int>> { 
                "".ToIntList(), "8".ToIntList(), "7".ToIntList(), "87".ToIntList() });
            yield return new TestCaseData("654".ToIntList(), new List<List<int>> { 
                "".ToIntList(), "6".ToIntList(), "5".ToIntList(), "4".ToIntList(),
                "65".ToIntList(),  "54".ToIntList(), "46".ToIntList(), "654".ToIntList() });
        }
    }
}