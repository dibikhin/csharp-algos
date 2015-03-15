<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	IsPrime(1).Dump();
	IsPrime(2).Dump();
	IsPrime(3).Dump();
	IsPrime(179425033).Dump();	  // -> true
	
	IsPrime(16).Dump();
	IsPrime(600851475143).Dump(); // -> false	
}

// Define other methods and classes here

bool IsPrime(long num) {
	var result = true;
	Parallel.For(2, (int)Math.Sqrt(num), 
		(i, loopState) =>
		{
			if(num % i == 0) {				
				result = false;
				loopState.Break();
			}
		});
	return result;	
}