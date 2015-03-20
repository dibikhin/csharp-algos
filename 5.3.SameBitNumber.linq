<Query Kind="Program">
  <Reference>C:\Libs\nunitlite.dll</Reference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite.Runner</Namespace>
</Query>

void Main() {
    new NUnitLite.Runner.TextUI().Execute(new[] { "-noheader" });
}

static class Algos {
    internal static int? ComputeNextSmallestSameOneBits(this int num) {
        // find fst 1
        // if next is 1 shift r after next inc
        // else set next to 1, this to 0
        // check if guessed ok
        
        var pos = -1;
        for (var n = 0; n <= 30; n++) {
            if (num.GetBit(n)) {
                pos = n;
                break;
            }
        }
        var newNum = 0;
        if ((num & (1 << pos + 1)) != 0) {
            
        } else {
            newNum = num.SetBit(pos + 1);
            newNum = newNum.ClearBit(pos);
        }
        return newNum;
    }
    
    internal static int? ComputeNextLargestSameOneBits(this int num) {
        return 0;
    }
}

class TestCaseStorage {
    static IEnumerable TestCases {
        get {
            yield return new TestCaseData(
                "0011".ToInt32(),
                "0101".ToInt32(),
                "0000".ToInt32());
            yield return new TestCaseData(
                "0101".ToInt32(),
                "0110".ToInt32(),
                "0000".ToInt32());
            yield return new TestCaseData(
                "0110".ToInt32(),
                "1010".ToInt32(),
                "0000".ToInt32());
            yield return new TestCaseData(
                "1010".ToInt32(),
                "1100".ToInt32(),
                "0000".ToInt32());
            yield return new TestCaseData(
                "1100".ToInt32(),
                null, // 0b1000
                "0000".ToInt32());
//            yield return new TestCaseData(
//                "00000000".ToInt32(),
//                "00000000".ToInt32(),
//                "00000000".ToInt32());
//            yield return new TestCaseData(
//                "00000000000000000000000000000000".ToInt32(),
//                "00000000000000000000000000000000".ToInt32(),
//                "00000000000000000000000000000000".ToInt32());
        }
    }
}

[TestFixture]
internal class Tests {
    [Test, TestCaseSource(typeof(TestCaseStorage), "TestCases")]
    public void Run_OnTestCases_AssertPasses(
        int num, int? nextSmallest, int? nextLargest) {
        
		Assert.AreEqual(
            expected: nextSmallest, actual: num.ComputeNextSmallestSameOneBits());
        
        Assert.AreEqual(
            expected: nextLargest, actual: num.ComputeNextLargestSameOneBits());
    }
}

static class Helpers {
    internal static int ToInt32(this string str) {
        return Convert.ToInt32(str, 2);
    }
    
    internal static string ToBinStr(this int num) {
        return "0b" + Convert.ToString(num, 2);
    }
    
    internal static bool GetBit(this int num, int i) {
        return (num & (1 << i)) != 0;
    }
    
    internal static int ClearBit(this int num, int i) {
        var mask = ~(1 << i);
        return mask & num;
    }
    internal static int SetBit(this int num, int i) {
         return num | (1 << i);
    }
}