{-
Problem description - Pandigital prime
--------------------------------------
We shall say that an n-digit number is pandigital if it makes use of all the digits
1 to n exactly once. For example, 2143 is a 4-digit pandigital and is also prime.
What is the largest n-digit pandigital prime that exists?

Problem analysis
----------------
- Largest n-digit number that is pandigital has n=9: 987654321.
- Find all pandigital numbers for a given n by calculating all permutations of 1 to n.

Runtime information
-------------------
Compilation      ghc -O2 -threaded <filename>.hs
Execution        ./<filename> +RTS -N
                 for performance run output use: --output <filename>.html
Time             2.066 ns
Answer           7652413
-}

import Criterion.Main
import Data.List
import Data.Numbers.Primes

main :: IO ()
-- main = print $ answer 0
main = defaultMain [
  bgroup "answer" [ bench "default" $ whnf answer 0 ]
  ]

answer :: Int -> Int
answer n = head [x|x<-allPandigitalNumbers,isPrime x]

allPandigitalNumbers :: [Int]
allPandigitalNumbers = concat $ reverse [nDigitPandigitalNumbers x|x<-[1..9]]

nDigitPandigitalNumbers :: Int -> [Int]
nDigitPandigitalNumbers n = sortBy (flip compare) $ map (foldl (\x y -> 10*x+y) 0) (permutations [1..n])