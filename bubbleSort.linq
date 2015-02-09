<Query Kind="Program" />

void Main()
{
	var arr = new [] { 6, 4, 7, 2, 5 };
	BubbleSortAsc(arr).Dump();
}

// Define other methods and classes here

int[] BubbleSortAsc(int[] arr) {
	var swapped = true;
	do {
		swapped = false;
		for(int i = 0; i < arr.Length - 1; i++) {
			if (arr[i] > arr[i + 1]) {
				var tmp = arr[i];
				arr[i] = arr[i + 1];
				arr[i + 1] = tmp;
				swapped = true;
			}
		}
	} while(swapped);
	return arr;
}