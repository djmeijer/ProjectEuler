{-
Divisibility of factorials

The smallest number m such that 10 divides m! is m=5.
The smallest number m such that 25 divides m! is m=10.

Let s(n) be the smallest number m such that n divides m!.
So s(10)=5 and s(25)=10.
Let S(n) be ∑s(i) for 2 ≤ i ≤ n.
S(100)=2012.

Find S(10^8).
-}

import Math.Combinatorics.Exact.Factorial
import Control.Parallel.Strategies

main :: IO()
main = print $ sBig 10000

s :: Integer -> Int
s n = head [m|m<-[1..],mod (factorial m) n == 0]

sBig :: Integer -> Int
sBig n = sum ([s i|i<-[2..n]] `using` parList rdeepseq)