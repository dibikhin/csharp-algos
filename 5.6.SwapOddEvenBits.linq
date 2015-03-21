<Query Kind="Program">
  <Reference>C:\Libs\nunitlite.dll</Reference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite.Runner</Namespace>
</Query>

void Main() {
    new NUnitLite.Runner.TextUI().Execute(new[] { "-noheader" });
}

static class Algos {
    internal static int SwapOddEvenBits(this int num) {
        var oddMask  = "01010101010101010101010101010101".ToInt32();
        var evenMask = "10101010101010101010101010101010".ToInt32();
        
        var oddMaskedNum = (num & oddMask) << 1;
        var evenMaskedNum = (num & evenMask) >> 1;
        
        return oddMaskedNum | evenMaskedNum;
//((("0011".ToInt32() & "0101".ToInt32()) << 1) | (("0011".ToInt32() & "1010".ToInt32()) >> 1)).ToBinStr().Dump();
//((("0101".ToInt32() & "0101".ToInt32()) << 1) | (("0101".ToInt32() & "1010".ToInt32()) >> 1)).ToBinStr().Dump();
//        return num;
    }
}

class TestCaseStorage {
    static IEnumerable TestCases {
        get {
//            yield return new TestCaseData(
//                "0011".ToInt32(),
//                "0011".ToInt32());
//            yield return new TestCaseData(
//                "0101".ToInt32(),
//                "1010".ToInt32());
            yield return new TestCaseData(
                "0110".ToInt32(),
                "0110".ToInt32());
//            yield return new TestCaseData(
//                "1010".ToInt32(),
//                "0101".ToInt32());
        }
    }
}

[TestFixture]
internal class Tests {
    [Test, TestCaseSource(typeof(TestCaseStorage), "TestCases")]
    public void Run_OnTestCases_AssertPasses(
        int num, int swappedBits) {
		Assert.AreEqual(
            expected: swappedBits, actual: num.SwapOddEvenBits());
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