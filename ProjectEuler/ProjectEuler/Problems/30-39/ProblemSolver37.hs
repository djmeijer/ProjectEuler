{-
Truncatable primes

The number 3797 has an interesting property. Being prime itself, it is possible to continuously
remove digits from left to right, and remain prime at each stage: 3797, 797, 97, and 7. Similarly
we can work from right to left: 3797, 379, 37, and 3.

Find the sum of the only eleven primes that are both truncatable from left to right and right to left.

NOTE: 2, 3, 5, and 7 are not considered to be truncatable primes.
-}

import Data.Numbers.Primes
import Data.Digits
-- import Criterion.Main

main :: IO()
main = print $ answer 11
-- main = defaultMain [
--   bgroup "isTruncatablePrime" [ bench "answer" $ whnf answer 11 ]
--   ]

answer :: Int -> Integer
answer n = sum $ take n [x|x<-[10..],isTruncatablePrime x]

isTruncatablePrime :: Integer -> Bool
isTruncatablePrime x = isPrime x && isRecursivePrime x True && isRecursivePrime x False 

isRecursivePrime :: Integer -> Bool -> Bool
isRecursivePrime x l
 | x < 10    = isPrime x
 | l         = isPrime x && isRecursivePrime (unDigits 10 $ tail $ digits 10 x) l
 | otherwise = isPrime x && isRecursivePrime (div x 10) l

-- Compilation      ghc -O2 -threaded <filename>.hs
-- Execution        ./<filename> +RTS -N
-- Performance      ./<filename> --output <filename>.html
--                  done in 1.123 s, answer 748317