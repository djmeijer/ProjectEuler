using System;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
	  internal class ProblemSolver37 : Solver
	  {
		    protected override void DoCalculation()
		    {
			      var truncatablePrimes = new List<long>();

			      for (long x = 10; truncatablePrimes.Count < 11; x++)
			      {
				        if (IsRecursivePrime(x))
				        {
					          truncatablePrimes.Add(x);
				        }
			      }

			      long sum = 0;
			      foreach (var item in truncatablePrimes)
			      {
				        Console.WriteLine(item);
				        sum += item;
			      }

			      SetAnswer(sum);
			      //SetAnswer(748317);
		    }

		    private static bool IsRecursivePrime(long x, bool? left = null)
		    {
			      if (x < 10)
			      {
				        return IsPrime(x);
			      }
			      if (!left.HasValue)
			      {
				        return IsPrime(x) && IsRecursivePrime(x, true) && IsRecursivePrime(x, false);
			      }
		        if (left.Value)
		        {
		            var t = x.ToString().ToCharArray();
		            var xx = "";
		            for (int i = 1; i < t.Length; i++)
		            {
		                xx += t[i];
		            }

		            return IsPrime(x) && IsRecursivePrime(int.Parse(xx), true);
		        }
		        else
		        {
		            var xx = x / 10;
		            return IsPrime(x) && IsRecursivePrime(xx, false);
		        }
		    }

		    private static bool IsPrime(long candidate)
		    {
			      if ((candidate & 1) == 0)
			      {
				        return candidate == 2;
			      }
			      for (int i = 3; (i * i) <= candidate; i += 2)
			      {
				        if (candidate % i == 0)
				        {
					          return false;
				        }
			      }
			      return candidate != 1;
		    }
	  }
}