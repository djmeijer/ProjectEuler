{-
Problem description - Pandigital multiples
------------------------------------------
Take the number 192 and multiply it by each of 1, 2, and 3:
192 × 1 = 192
192 × 2 = 384
192 × 3 = 576
By concatenating each product we get the 1 to 9 pandigital, 192384576. We will call 192384576
the concatenated product of 192 and (1,2,3). The same can be achieved by starting with 9 and
multiplying by 1, 2, 3, 4, and 5, giving the pandigital, 918273645, which is the concatenated
product of 9 and (1,2,3,4,5).
What is the largest 1 to 9 pandigital 9-digit number that can be formed as the concatenated
product of an integer with (1,2, ... , n) where n > 1?

Problem analysis
----------------
- For x=9 and n=5 the concatenated product is 918273645 (let's call this p). We are looking for
  a bigger p. Every p will start with x itself so we know the x we are looking for will start
  with a 9.
- The number x cannot contain duplicated digits.
- Number p must have 9 digits. Because of n > 1 we know that x cannot contain more than 4 digits.

Runtime information
-------------------
Compilation      ghc -O2 -threaded <filename>.hs
Execution        ./<filename> +RTS -N
                 for performance run output use: --output <filename>.html
Time             91.98 ms
Answer           932718654
-}

import Data.List
import Data.Ord
import Data.Char
-- import Criterion.Main

main :: IO()
main = print $ answer (9999,9)
-- main = defaultMain [bgroup "answer" [bench "default" $ whnf answer (9999,9)]]

answer :: (Int,Int) -> (Int,Int,String)
answer l = maximumBy (comparing (\(_,_,p)->p)) $ search l

search :: (Int,Int) -> [(Int,Int,String)]
search l = filter (\(_,_,p)-> isPandigital p) [(x,n,findConcatenatedProduct x n 1)|x<-[1..(fst l)],n<-[1..(snd l)]]

findConcatenatedProduct :: Int -> Int -> Int -> String
findConcatenatedProduct x m n
 | n == m    = show (x * n)
 | otherwise = show (x * n) ++ findConcatenatedProduct x m (n + 1)

isPandigital :: String -> Bool
isPandigital x = length n == 9 && sort n == [1..9]
 where n = map digitToInt x