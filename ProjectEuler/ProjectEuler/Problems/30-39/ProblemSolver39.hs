{-
Integer right triangles

If p is the perimeter of a right angle triangle with integral length sides, {a,b,c},
there are exactly three solutions for p = 120.

{20,48,52}, {24,45,51}, {30,40,50}

For which value of p ≤ 1000, is the number of solutions maximised?
-}

import Data.List
import Data.Ord
import Control.Parallel.Strategies
-- import Criterion.Main

main :: IO()
main = print $ answer 1000
-- main = defaultMain [
--   bgroup "answer" [ bench "default" $ whnf answer 1000 ] 
--   ]

answer :: Int -> (Int, Int)
answer x = maximumBy (comparing snd) ([(p, possibilities p) | p <- [2, 4 .. x]] `using` parList rdeepseq)

possibilities :: Int -> Int
possibilities p = length [(a, b, c) | c <- [1 .. p], b <- [1 .. c], a <- [1 .. b], a + b + c == p, a * a + b * b == c * c]

-- Compilation      ghc -O2 -threaded <filename>.hs
-- Execution        ./<filename> +RTS -N
-- Performance      ./<filename> --output <filename>.html
--                  done in 7.583 s, answer 840