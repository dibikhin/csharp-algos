<Query Kind="Program" />

void Main()
{
	// 0 1 1 2 3 5 8 13
	
	//FibRec(0, 1, 2).Dump(); // -> 1
	//FibRec(0, 1, 6).Dump(); // -> 5 
	
	//FibIter(0, 1, 2).Dump(); // -> 1
	//FibIter(0, 1, 6).Dump(); // -> 5
	
	FibEnum(0, 1).Take(4).Dump(); // -> 0 1 1 2
	FibEnum(0, 1).Take(6).Dump(); // -> 0 1 1 2 3 5
}

// Define other methods and classes here

int FibRec(int fst, int snd, int lim) {
	var sum = fst + snd;
	return sum + snd < lim
		? FibRec(snd, sum, lim)
		: sum;
}

int FibIter(int fst, int snd, int lim) {
	var sum = 0;
	var f = fst;
	var s = snd;
	while(true) {
		if(sum + snd >= lim) 
			return sum;
		else {
			sum = f + s;
			f = s;
			s = sum;
		}
	}
}

IEnumerable<int> FibEnum(int fst, int snd) {
	yield return fst;
	yield return snd;
	var sum = 0;
	var f = fst;
	var s = snd;
	while(true){
		sum = f + s;
		f = s;
		s = sum;
		yield return sum;
	}
}