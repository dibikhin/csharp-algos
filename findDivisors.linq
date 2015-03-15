<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	FindDivisors(1).Dump();
	FindDivisors(2).Dump();
	FindDivisors(3).Dump();
	//FindDivisors(179425033).Dump();	  // -> true
	
	FindDivisors(16).Dump();
	///FindDivisors(600851475143).Dump(); // -> false	
}

// Define other methods and classes here

List<long> FindDivisors(long num) {
	//Parallel.For(2, num,
	//	i => { if(num % i == 0) divisors.Add(i); });
	var divisorsList = new List<long>();
	for(var i = 2; i < Math.Sqrt(num); i++)
		if(num % i == 0) {
			divisorsList.Add(i);
			break;
		}
	if(divisorsList.Count == 0) return divisorsList;
	var m = divisorsList[0];
	while(m * m <= num) {
		m = num / m;
		divisorsList.Add(m); // OutOfMemoryException :(
	}	
	return divisorsList;
}