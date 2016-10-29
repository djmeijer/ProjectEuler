{-
Problem description - Integer right triangles
---------------------------------------------
If p is the perimeter of a right angle triangle with integral length sides, {a,b,c},
there are exactly three solutions for p = 120.
{20,48,52}, {24,45,51}, {30,40,50}
For which value of p ≤ 1000, is the number of solutions maximised?

Problem analysis
----------------
- The perimeter p for a triangle {a, b, c} is p = a + b + c
- Use the Pythagorean theorem to force the triangle is a right angle triangle.
- Because of a^2 + b^2 = c^2 and p = a + b + c
  -> When a and b are odd, then c is even and also p is even.
  -> When a is even and b is odd, then c will be odd and p is even.
  -> When a is odd and b is even, then c will be odd and p even.
  -> When both a and b are even, then c and p are even.
  So we only have to look for even values of p.

Runtime information
-------------------
Compilation      ghc -O2 -threaded <filename>.hs
Execution        ./<filename> +RTS -N
                 for performance run output use: --output <filename>.html
Time             7.545 s
Answer           840
-}

import Data.List
import Data.Ord
import Control.Parallel.Strategies
-- import Criterion.Main

main :: IO()
main = print $ answer 1000
-- main = defaultMain [bgroup "answer" [bench "default" $ whnf answer 1000]]

answer :: Int -> (Int,Int)
answer x = maximumBy (comparing snd) ([(p,possibilities p)|p<-[2,4..x]] `using` parList rdeepseq)

possibilities :: Int -> Int
possibilities p = length [(a,b,c)|c<-[1..p],b<-[1..c],a<-[1..b],a+b+c==p,a*a+b*b==c*c]