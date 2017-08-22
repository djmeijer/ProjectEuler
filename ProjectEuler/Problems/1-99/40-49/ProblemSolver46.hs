{-
Problem description - Goldbach's other conjecture
-------------------------------------------------

It was proposed by Christian Goldbach that every odd composite number can be
written as the sum of a prime and twice a square.

9 = 7 + 2×1^2
15 = 7 + 2×2^2
21 = 3 + 2×3^2
25 = 7 + 2×3^2
27 = 19 + 2×2^2
33 = 31 + 2×1^2

It turns out that the conjecture was false.

What is the smallest odd composite that cannot be written as the sum of a prime and twice a square?

Problem analysis
----------------


Runtime information
-------------------
Compilation      ghc -O2 -threaded <filename>.hs
Execution        ./<filename> +RTS -N
                 for performance run output use: --output <filename>.html
Time             
Answer           5777
-}

--import Criterion.Main
import Data.List
import Data.Numbers.Primes

main :: IO ()
main = print answer
-- main = defaultMain [
--   bgroup "answer" [ bench "default" $ whnf head answer ]
--    ]

answer :: [Int]
answer = oddCompositeNumbers \\ conjectureNumbers

conjectureNumbers :: [Int]
conjectureNumbers = nub [n|n<-oddCompositeNumbers, p<-[2..n], isPrime p, s<-[1..n], p+(2*s*s) == n]

oddCompositeNumbers :: [Int]
oddCompositeNumbers = [n|n<-compositeNumbers,odd n]

compositeNumbers :: [Int]
compositeNumbers = [n|n<-[4..], not $ isPrime n]