<Query Kind="Program">
  <Reference>C:\Libs\nunitlite.dll</Reference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite.Runner</Namespace>
</Query>

void Main() {
    new NUnitLite.Runner.TextUI().Execute(new[] { "-noheader" });
}

static class Algos {
    internal static string MyReplace(this string str, string oldValue, string newValue) {
        var arr = str.ToCharArray();
        var stubChars = newValue.ToCharArray();
        var s = arr.Length - 1;
        var d = arr.Length - 1;
        while (s > 2 && d > 1) {            
            var sChar = arr[s];
            var dChar = arr[d];
            if (sChar == ' ') {
                s -= 1;
            } else {
                while (s > 2 && d > 1 && sChar != ' ') {
                    string.Join("", arr).Dump();
                    arr[d] = sChar;
                    arr[s] = dChar;
                    s -= 1;
                    d -= 1;
                    sChar = arr[s];
                    dChar = arr[d];      
                }
                for (var i = 2; i > -1 ; i--) {                        
                    arr[d] = stubChars[i];
                    d -= 1;
                    string.Join("", arr).Dump();
                    s.Dump("s");d.Dump("d");
                }                
            }
        }
        
        return string.Join("", arr);
    }
}

[TestFixture]
internal class Tests { 
    [Test, TestCaseSource(typeof(TestCaseStorage), "TestCases")]
    public void Run_OnTestCases_AssertPasses(string input, string oldValue, string newValue, string expected) {
		Assert.AreEqual(expected: expected, actual: input.MyReplace(oldValue, newValue));
    }
}

class TestCaseStorage {   
    static IEnumerable TestCases {
        get {
            yield return new TestCaseData("Mr John Smith    ", " ", "%20", "Mr%20John%20Smith");
        }
    }
}