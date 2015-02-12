<Query Kind="Program">
  <Reference>C:\Libs\nunitlite.dll</Reference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite.Runner</Namespace>
</Query>

void Main()
{
    new NUnitLite.Runner.TextUI().Execute(new[] { "-noheader" });
}

// 1-thread, array-splitting, tree-recursive version, orig. array is unchanged
static class Algos {
    class ListPair {
        public List<int> FirstList { get; set; }
        public List<int> SecondList { get; set; }

        public ListPair() {
            FirstList = new List<int>();
            SecondList = new List<int>();
        }
        
        public ListPair(List<int> list) {
            FirstList = new List<int> { list[0] };
            SecondList = new List<int> { list[1] };
        }
    }    
    
    public static List<int> MergeSort(List<int> list) {
        if (list.Count == 0) return list;
        return Merge(Split(list));
    }
    
    static List<int> Merge(ListPair listPair) {
        var tempList = new List<int>();
        int f = 0, s = 0, cnt = 0;
        while (f < listPair.FirstList.Count || s < listPair.SecondList.Count) {
            cnt += 1;
            
            if (f >= listPair.FirstList.Count) {
                tempList.Add(listPair.SecondList[s]);
                s += 1;
                continue;
            }
            
            if (s >= listPair.SecondList.Count) {
                tempList.Add(listPair.FirstList[f]);
                f += 1;
                continue;
            }
            
            if (listPair.FirstList[f] < listPair.SecondList[s]) {
                tempList.Add(listPair.FirstList[f]);
                f += 1;                
            } else {
                tempList.Add(listPair.SecondList[s]);
                s += 1;
            }
        }              
        
        return tempList;
    }
    
    static ListPair Split(List<int> list) {
        if (list.Count == 1) return new ListPair { FirstList = list };
        if (list.Count == 2) return new ListPair(list);
        
        var middleIx = list.Count / 2;
        var leftList = list.GetRange(0, list.Count - middleIx);
        var rightList = list.GetRange(list.Count - middleIx, middleIx);

        return new ListPair { 
            FirstList = MergeSort(leftList), 
            SecondList = MergeSort(rightList)
        };
    } 
}

[TestFixture]
public class MergeSortTests
{ 
    [SetUp]
    public void init() { }
	
    [Test, TestCaseSource(typeof(MyFactoryClass), "TestCases")]
    public bool MergeSort_OnUnsortedArray_ReturnsSortedArray(List<int> list, List<int> sortedArr) {
		return Enumerable.SequenceEqual(Algos.MergeSort(list), sortedArr);
    }
     
    [TearDown]
    public void done() {  }
}

static class TestHelper {
    public static List<int> ToIntList(this string str) {
        if (string.IsNullOrWhiteSpace(str)) return new List<int>();
        
        // "321" -> new List<int> { 3, 2, 1 } // "-321" -> fail
        return str.Select(c => int.Parse(c.ToString())).ToList();
    }
}

class MyFactoryClass
{   
    static IEnumerable TestCases
    {
        get
        {
            yield return new TestCaseData("".ToIntList(), "".ToIntList()).Returns( true );
            
            yield return new TestCaseData("2".ToIntList(), "2".ToIntList()).Returns( true );
            yield return new TestCaseData("2".ToIntList(), "15".ToIntList()).Returns( false );
                        
            yield return new TestCaseData("33".ToIntList(), "33".ToIntList()).Returns( true );
            yield return new TestCaseData("23".ToIntList(), "23".ToIntList()).Returns( true );
            yield return new TestCaseData("32".ToIntList(), "23".ToIntList()).Returns( true );
                        
            yield return new TestCaseData("32313".ToIntList(), "12333".ToIntList()).Returns( true );
            
            yield return new TestCaseData("325".ToIntList(), "235".ToIntList()).Returns( true );
            yield return new TestCaseData("3021".ToIntList(), "0123".ToIntList()).Returns( true );
            yield return new TestCaseData("3275".ToIntList(), "2357".ToIntList()).Returns( true );
            yield return new TestCaseData("3142".ToIntList(), "1234".ToIntList()).Returns( true );
            
            yield return new TestCaseData("65318724".ToIntList(), "12345678".ToIntList()).Returns( true );

            yield return new TestCaseData("321".ToIntList(), "123".ToIntList()).Returns( true );
            yield return new TestCaseData("4321".ToIntList(), "1234".ToIntList()).Returns( true );
            yield return new TestCaseData("54321".ToIntList(), "12345".ToIntList()).Returns( true );
            
            yield return new TestCaseData(new List<int> { 5, 4, 3, 2, 1, 0, -1 }, new List<int> { -1, 0, 1, 2, 3, 4, 5 } ).Returns( true );            
            
            // 1,45,87,444,999 12,45,45,78,1000,1100
            
//            Enumerable.Range(0, 1000000).Reverse().ToList();
//            Enumerable.Range(0, 1000000).ToList().Sort();
            
//            var range = Enumerable.Range(0, 1000);
//            yield return new TestCaseData(range.Reverse().ToList(), range.ToList()).Returns( true );
        }
    }
}