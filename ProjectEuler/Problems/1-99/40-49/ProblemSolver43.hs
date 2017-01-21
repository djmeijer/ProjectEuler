{-
Problem description - Sub-string divisibility
---------------------------------------------

The number, 1406357289, is a 0 to 9 pandigital number because it is made up of each of the
digits 0 to 9 in some order, but it also has a rather interesting sub-string divisibility property.
Let d1 be the 1st digit, d2 be the 2nd digit, and so on. In this way, we note the following:

d2d3d4=406 is divisible by 2
d3d4d5=063 is divisible by 3
d4d5d6=635 is divisible by 5
d5d6d7=357 is divisible by 7
d6d7d8=572 is divisible by 11
d7d8d9=728 is divisible by 13
d8d9d10=289 is divisible by 17
Find the sum of all 0 to 9 pandigital numbers with this property.

Problem analysis
----------------
- 1023456789

Runtime information
-------------------
Compilation      ghc -O2 -threaded <filename>.hs
Execution        ./<filename> +RTS -N
                 for performance run output use: --output <filename>.html
Time             86.87 ns
Answer           16695334890
-}

-- import Criterion.Main
import Data.List
import Data.Numbers.Primes

main :: IO ()
main = print $ sum answer
-- main = defaultMain [
--   bgroup "answer" [ bench "default" $ whnf sum answer ]
--   ]

answer :: [Int]
answer = [combine n|n<-permutations [0..9],head n/=0,propertyFilter n 0]

combine :: [Int] -> Int
combine = foldl (\x y->10*x+y) 0

propertyFilter :: [Int] -> Int -> Bool
propertyFilter ns x
  | x == 6    = propertyFilterFunction ns x
  | otherwise = propertyFilter ns (x+1) && propertyFilterFunction ns x

propertyFilterFunction :: [Int] -> Int -> Bool
propertyFilterFunction ns x = mod (combine (take 3 (drop (x+1) ns))) (primes!!x) == 0