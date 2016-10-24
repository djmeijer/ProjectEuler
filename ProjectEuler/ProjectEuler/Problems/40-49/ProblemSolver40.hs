{-
Champernowne's constant

An irrational decimal fraction is created by concatenating the positive integers: 0.123456789101112131415161718192021...
It can be seen that the 12th digit of the fractional part is 1.
If d_{n} represents the n^{th} digit of the fractional part, find the value of the following expression.
d_{1} × d_{10} × d_{100} × d_{1000} × d_{10000} × d_{100000} × d_{1000000}

-}

import Data.Char
-- import Criterion.Main

main :: IO ()
main = print $ answer (fraction 1) (parts 0)
-- main = defaultMain [
--   bgroup "answer" [ bench "default" $ whnf (answer (fraction 1)) (parts 0) ]
--   ]

parts :: Int -> [Int]
parts y = take 6 [10^x|x<-[y..]]

fraction :: Int -> String
fraction x = concatMap show [x..]

answer :: String -> [Int] -> Int
answer a b = product $ map ((digitToInt . (a !!)) . subtract 1) b

-- Compilation      ghc -O2 -threaded <filename>.hs
-- Execution        ./<filename> +RTS -N
-- Performance      ./<filename> --output <filename>.html
--                  done in 258.3 μs, answer 210