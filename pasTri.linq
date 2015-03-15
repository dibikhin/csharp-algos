<Query Kind="Program" />

void Main()
{
	var rng = Enumerable.Range(0, 4);
	//rng.Select(n => rng.Select(k => PasTri(n, k)).Where(p => p > 0)).Dump();
	
	//PasTri(30, 15).Dump();
	
	var cache = new int[5, 5];
	//PasTriDyn(99, 54, cache).Dump();
	PasTriDyn(3, 1, cache).Dump(); // -> 3
	cache.Dump();
}

// Define other methods and classes here

static int PasTri(int n, int k) {
	if (n < 0 || k < 0 || k > n) return -1;
	return k == 0 || k == n
		? 1
		: PasTri(n - 1, k - 1) + PasTri(n - 1, k);
}

static int PasTriDyn(int n, int k, int[,] cache) {
	if (n < 0 || k < 0 || k > n) return -1;
	if( k == 0 || k == n) {
		cache[n, k] = 1;
		return 1;
	}
	else {
		var cachedFst = cache[n - 1, k - 1];
		var cachedSnd = cache[n - 1, k];
		if(cachedFst != 0 && cachedSnd != 0)
			return cachedFst + cachedSnd;
		else {
			var newVal = PasTriDyn(n - 1, k - 1, cache) + PasTriDyn(n - 1, k, cache);
			cache[n, k] = newVal;
			return newVal;
		}		
	}
}