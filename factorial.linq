<Query Kind="Program" />

void Main()
{
	Fact(5).Dump();
}

// Define other methods and classes here

private static int Fact(int cnt) {
	//return FactRec(5);
	//return FactIter(5);
	return FactIter2(5);
}

private static int FactRec(int num) {
	if (num > 0) return FactRec(num - 1) * num;
	else return 1;
}

private static int FactIter(int num) {
	var acc = 1;
	for (int i = 1; i <= num; i++) acc = acc * i;
	return acc;
}

private static int FactIter2(int num) {
	var acc = 1;
	if (num == 0) return 1;
	Enumerable.Range(1, num).ToList().ForEach(n => acc = acc * n);
	return acc;
}

private static int FactIter3(int num) {
	if (num == 0) return 1;
	return Enumerable.Range(1, num).Aggregate((acc, i) => acc * i);
}