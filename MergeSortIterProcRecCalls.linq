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

// 1-thread, tree-recursive calls, iterative process, in place swaps, orig. array is modified
public static class Algos {
    public class ListRange {
        public List<int> List;
        
        public int Count { get { return To - From + 1; } } // '+1' would fail
        
        public int From { 
            get { return _from; }
            set {
                //if (value <= To)
                    _from = value;
//                else { 
//                    var ioore = new IndexOutOfRangeException("From should be less or equal than To");
//                    ioore.Data.Add("new From value", value);
//                    ioore.Data.Add("To", To);
//                    throw ioore;
//                }
            } 
        }
        
        public int To {
            get { return _to; }
                set {
                    //if (value >= From)
                        _to = value;
//                    else { 
//                        var ioore = new IndexOutOfRangeException("From should be less or equal than To");
//                        ioore.Data.Add("From", From);
//                        ioore.Data.Add("new To value", value);
//                        throw ioore;
//                    }
                }
        }
        
        private int _from;
        private int _to;
    }
    
    public class ListPair {
        public ListRange FirstList;
        public ListRange SecondList;

        public ListPair() {
            FirstList = new ListRange();
            SecondList = new ListRange();
        }
        
//        public ListPair(ListRange listRange) {
//            FirstList = new ListRange { From = listRange.From, To = listRange.From, List = listRange.List };
//            SecondList = new ListRange { From = 1, To = 1, List = listRange.List };
//        }
    }    
    
    public static List<int> MergeSort(List<int> list) {
        if (list.Count == 0) return list;
        if (list.Count == 1) return list;
        var sortedListRange = MergeSortInner(
            new ListRange { From = 0, To = list.Count - 1, List = list });
        return sortedListRange.List;
    }
    
    static ListRange MergeSortInner(ListRange listRange, int dep = 10) {        
        return Merge(Split(listRange, dep));
    }
    
    internal static ListPair Split(ListRange listRange, int dep, bool test = false) {
        if (dep < 1) {
            throw new Exception(); 
        }
        
        if (listRange.Count == 1) {
            return new ListPair { FirstList = listRange, SecondList = listRange };
        }
        
        var middleIx = listRange.Count / 2;
        var leftEnd = listRange.Count - middleIx - 1;        
        
        var leftListRange = new ListRange { From = listRange.From, To = listRange.From + leftEnd, List = listRange.List };
        var rightListRange = new ListRange { From = listRange.From + leftEnd + 1, To = listRange.To, List = listRange.List };

        if (test)
            return new ListPair { FirstList = leftListRange, SecondList = rightListRange };
        else
            return new ListPair { 
                    FirstList = MergeSortInner(leftListRange, dep - 1), 
                    SecondList = MergeSortInner(rightListRange, dep - 1) };
    }
    
    internal static ListRange Merge(ListPair listPair) {        
        //var f = listPair.FirstList.From;
        //var s = listPair.SecondList.From;
        var cnt = 0;
        //int? fst = null, snd = null;

//        while (true) {
//            cnt += 1;
//            
//            f.Dump("f"); s.Dump("s");
//            
//            if (f <= listPair.FirstList.To) {
//                fst = listPair.FirstList.List[f];
//            }
//            
//            if (s <= listPair.SecondList.To) {
//                snd = listPair.SecondList.List[s];
//            }
// 
//            if (fst > snd) {
//                var temp = listPair.FirstList.List[f];
//                listPair.FirstList.List[f] = listPair.FirstList.List[s];
//                listPair.FirstList.List[s] = temp;
//            }
//            
//            if (f == listPair.FirstList.To && s == listPair.SecondList.To)
//                break;
//            
//            if (f < listPair.FirstList.To)
//                f += 1;
//                
//            if (s < listPair.SecondList.To)
//                s += 1;
//        }
    
        "".Dump("Merge");
        listPair.Dump("lp_merge");
        
        for(var f = listPair.FirstList.From; f<=listPair.FirstList.To; f++) {
            for(var s = listPair.SecondList.From; s<=listPair.SecondList.To; s++) {
                var fst = listPair.FirstList.List[f];
                var snd = listPair.FirstList.List[s];
                if (fst > snd) {                    
                    listPair.FirstList.List[s] = fst;
                    listPair.FirstList.List[f] = snd;
                    f.Dump("f");s.Dump("s"); listPair.Dump("lp");
                }
            }
        }
        
        return new ListRange { 
            From = listPair.FirstList.From, To = listPair.SecondList.To,
            List = listPair.FirstList.List }; // = Range1 + Range2
    }
}

[TestFixture]
public class MergeSortTests
{	
    [Test, TestCaseSource(typeof(TestCases), "FullUnsortedArrays")]
    public void MergeSort_OnUnsortedArray_ReturnsSortedArray(List<int> list, List<int> sortedArr) {
        var actual = Algos.MergeSort(list).ToJson();
        var expected = sortedArr.ToJson();
        Assert.AreEqual(expected, actual);  
    }
    
//    // ok
//    [Test, TestCaseSource(typeof(TestCases), "SplittebleArrays")]
//    public void Split_OnSplittebleArray_ReturnsSplittedToListPair(Algos.ListRange listRange, Algos.ListPair listPair) {
//        var actual = Algos.Split(listRange, 99999, test: true).ToJson();
//        var expected = listPair.ToJson();
//        Assert.AreEqual(expected, actual);
//    }
    
//    [Test, TestCaseSource(typeof(TestCases), "FullySortedArrays")]
//    public void Merge_OnFullySortedArray_ReturnSortedListRange(Algos.ListPair listPair, Algos.ListRange listRange) {
//        var actual = Algos.Merge(listPair).ToJson();
//        var expected = listRange.ToJson();
//        Assert.AreEqual(expected, actual);
//    }

//      // ok
//    [Test, TestCaseSource(typeof(TestCases), "PartiallySortedArrays")]
//    public void Merge_OnPartiallySortedArray_ReturnSortedListRange(Algos.ListPair listPair, Algos.ListRange listRange) {
//        var actual = Algos.Merge(listPair).ToJson();
//        var expected = listRange.ToJson();
//        Assert.AreEqual(expected, actual);
//    }
    
//    [Test, TestCaseSource(typeof(TestCases), "UnsortedArrays")]
//    public void Merge_OnUnsortedArray_ReturnSortedListRange(Algos.ListPair listPair, Algos.ListRange listRange) {
//        var actual = Algos.Merge(listPair).ToJson();
//        var expected = listRange.ToJson();
//        Assert.AreEqual(expected, actual);
//    }
}

static class TestHelper {
    internal static Dictionary<string, List<int>> ListStorage = new Dictionary<string, List<int>>();
    
    // Lists should be unique in one test run
    internal static List<int> ToIntList(this string str) {
        if (string.IsNullOrWhiteSpace(str)) {
            List<int> list = null;
            ListStorage.TryGetValue(str, out list);
            if (list == null) {
                list = new List<int>();
                ListStorage.Add(str, list);
                return list;
            }
        }
        
        List<int> list2 = null;
        ListStorage.TryGetValue(str, out list2);
        if (list2 == null) {
            var list3 = str.Select(c => int.Parse(c.ToString())).ToList();
            // "321" -> new List<int> { 3, 2, 1 } 
            // "-321" -> fail
            ListStorage.Add(str, list3);
            return list3;
        }
        
        return list2;
    }
}

class TestCases {   
    static IEnumerable FullUnsortedArrays {
        get {
//            yield return new TestCaseData("".ToIntList(), "".ToIntList());
//            
//            yield return new TestCaseData("4".ToIntList(), "4".ToIntList());
//                        
//            yield return new TestCaseData("44".ToIntList(), "44".ToIntList());
//            yield return new TestCaseData("45".ToIntList(), "45".ToIntList());
//            yield return new TestCaseData("54".ToIntList(), "54".ToIntList());
//  
//            yield return new TestCaseData("437".ToIntList(), "347".ToIntList());
//
//            yield return new TestCaseData("3275".ToIntList(), "2357".ToIntList());
//            yield return new TestCaseData("4253".ToIntList(), "2345".ToIntList());
//
//            yield return new TestCaseData("32313".ToIntList(), "12333".ToIntList());

//            yield return new TestCaseData("65318724".ToIntList(), "12345678".ToIntList());

            //yield return new TestCaseData("321".ToIntList(), "123".ToIntList());
            yield return new TestCaseData("4321".ToIntList(), "1234".ToIntList());
//            yield return new TestCaseData("54321".ToIntList(), "12345".ToIntList());

//            yield return new TestCaseData(new List<int> { 5, 4, 3, 2, 1, 0, -1 }, new List<int> { -1, 0, 1, 2, 3, 4, 5 } );
        }
    }
    
    static IEnumerable FullySortedArrays {
        get {
            yield return new TestCaseData(                
                new Algos.ListPair { FirstList = new Algos.ListRange { From = 2, To = 3, List = "57".ToIntList() } },
                new Algos.ListRange { From = 2, To = 3, List = "57".ToIntList() });            
            yield return new TestCaseData(
                new Algos.ListPair {
                    FirstList = new Algos.ListRange { From = 0, To = 1, List = "234".ToIntList() },
                    SecondList = new Algos.ListRange { From = 2, To = 2, List = "234".ToIntList() } },
                new Algos.ListRange { From = 0, To = 2, List = "234".ToIntList() });
            yield return new TestCaseData(
                new Algos.ListPair {
                    FirstList = new Algos.ListRange { From = 0, To = 1, List = "1234".ToIntList() },
                    SecondList = new Algos.ListRange { From = 2, To = 3, List = "1234".ToIntList() } },
                new Algos.ListRange { From = 0, To = 3, List = "1234".ToIntList() });
        }
    }
    
    static IEnumerable PartiallySortedArrays {
        get {
            yield return new TestCaseData(
                new Algos.ListPair { 
                    FirstList = new Algos.ListRange { From = 0, To = 0, List = "32".ToIntList() },
                    SecondList = new Algos.ListRange { From = 1, To = 1, List = "32".ToIntList() }},
                new Algos.ListRange { From = 0, To = 1, List = "23".ToIntList() });
            yield return new TestCaseData(
                new Algos.ListPair { 
                    FirstList = new Algos.ListRange { From = 2, To = 2, List = "8976".ToIntList() },
                    SecondList = new Algos.ListRange { From = 3, To = 3, List = "8976".ToIntList() }},
                new Algos.ListRange { From = 2, To = 3, List = "8967".ToIntList() });
            yield return new TestCaseData(
                new Algos.ListPair {
                    FirstList = new Algos.ListRange { From = 0, To = 1, List = "342".ToIntList() },
                    SecondList = new Algos.ListRange { From = 2, To = 2, List = "342".ToIntList() } },
                new Algos.ListRange { From = 0, To = 2, List = "234".ToIntList() });                
            yield return new TestCaseData(
                new Algos.ListPair {
                    FirstList = new Algos.ListRange { From = 0, To = 1, List =  "3412".ToIntList() },
                    SecondList = new Algos.ListRange { From = 2, To = 3, List = "3412".ToIntList() } },
                new Algos.ListRange { From = 0, To = 3, List = "1234".ToIntList() });
            yield return new TestCaseData(
                new Algos.ListPair {
                    FirstList = new Algos.ListRange { From = 0, To = 1, List =  "2435".ToIntList() },
                    SecondList = new Algos.ListRange { From = 2, To = 3, List = "2435".ToIntList() } },
                new Algos.ListRange { From = 0, To = 3, List = "2345".ToIntList() });
        }
    }        
    
    //static IEnumerable UnsortedArrays {
      //  get {
//            yield return new TestCaseData(
//                new Algos.ListPair {
//                    FirstList = new Algos.ListRange { From = 0, To = 0, List = "98".ToIntList() },
//                    SecondList = new Algos.ListRange { From = 1, To = 1, List = "98".ToIntList() } },
//                new Algos.ListRange { From = 0, To = 1, List = "89".ToIntList() });
//            yield return new TestCaseData(
//                new Algos.ListPair {
//                    FirstList = new Algos.ListRange { From = 0, To = 1, List = "325".ToIntList() },
//                    SecondList = new Algos.ListRange { From = 2, To = 2, List = "325".ToIntList() } },
//                new Algos.ListRange { From = 0, To = 2, List = "235".ToIntList() });
        //}
    //}
    
    static IEnumerable SplittebleArrays {
        get {            
            yield return new TestCaseData(
                new Algos.ListRange { From = 0, To = 1, List = "33".ToIntList() }, 
                new Algos.ListPair { 
                    FirstList = new Algos.ListRange { From = 0, To = 0, List = "33".ToIntList() },
                    SecondList = new Algos.ListRange { From = 1, To = 1, List = "33".ToIntList() } });
            yield return new TestCaseData(
                new Algos.ListRange { From = 2, To = 3, List = "2255".ToIntList() }, 
                new Algos.ListPair { 
                    FirstList = new Algos.ListRange { From = 2, To = 2, List = "2255".ToIntList() },
                    SecondList = new Algos.ListRange { From = 3, To = 3, List = "2255".ToIntList() } });
            yield return new TestCaseData(
                new Algos.ListRange { From = 0, To = 2, List = "436".ToIntList() }, 
                new Algos.ListPair {
                    FirstList = new Algos.ListRange { From = 0, To = 1, List = "436".ToIntList() },
                    SecondList = new Algos.ListRange { From = 2, To = 2, List = "436".ToIntList() } });
            yield return new TestCaseData(
                new Algos.ListRange { From = 0, To = 3, List = "3142".ToIntList() },
                new Algos.ListPair {
                    FirstList = new Algos.ListRange { From = 0, To = 1, List = "3142".ToIntList() },
                    SecondList = new Algos.ListRange { From = 2, To = 3, List = "3142".ToIntList() } });           
        }
    }
}