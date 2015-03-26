<Query Kind="Program">
  <Reference>C:\Libs\nunitlite.dll</Reference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite.Runner</Namespace>
</Query>

void Main() {
    new NUnitLite.Runner.TextUI().Execute(new[] { "-noheader" });
}

static class Algos {
    internal static List<Path> FindPaths(this Grid grid) {
        return new List<Path>();
    }
}

[TestFixture]
internal class Tests {
    [Test, TestCaseSource(typeof(TestCaseStorage), "TestCases")]
    public void Run_OnTestCases_AssertPasses(Grid grid, List<Path> paths) {
		Assert.AreEqual(expected: paths, actual: grid.FindPaths());
    }
}

class TestCaseStorage {
    static IEnumerable TestCases {
        get {
            yield return new TestCaseData(
                new Grid { XSize = 2, YSize = 2 },
                new List<Path> {
                    new Path (
                        new List<Point> {
                            new Point(0, 0),
                            new Point(0, 1),
                            new Point(1, 1)}
                    ),
                    new Path (
                        new List<Point> {
                            new Point(0, 0),
                            new Point(1, 0),
                            new Point(1, 1)}
                    )
                });
        }
    }
}

class Grid {
    internal int XSize { get; set; }
    internal int YSize { get; set; }
}

class Path {
    internal Path(List<Point> points) {
    }
}

class Point {
    internal Point(int x, int y) {
    }
}