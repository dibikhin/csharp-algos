<Query Kind="Program" />

void Main()
{
	BinarySearch(new int [] {}, 1).Dump();
	BinarySearch(new [] { 5, 6, 7 }, 8).Dump();
	BinarySearch(new [] { 5, 6, 7 }, 4).Dump();
	BinarySearch(new [] { 5, 6, 7 }, 5).Dump();
	BinarySearch(new [] { 5, 6, 7 }, 6).Dump();
	BinarySearch(new [] { 5, 6, 7 }, 7).Dump();
	BinarySearch(new [] { 5, 6, 7, 8 }, 8).Dump();
	BinarySearch(new [] { 5, 6, 7, 8, 9 }, 8).Dump();
}

// Define other methods and classes here

int BinarySearch(int [] arr, int num) {
	if(arr.Length == 0) return -1;
	
	var bottom = 0;
	var top = arr.Length - 1;
	var middle = 0;
	var middleVal = 0;
	
	while (bottom <= top) {
		middle = (top + bottom) / 2;
		middleVal = arr[middle];
		if (num == middleVal)
			return middle;
		if (num > middleVal)
			bottom = middle + 1;
		if (num < middleVal)
			top = middle - 1;
	}
	return -1;
}