-- main :: IO()
-- main = print $ haskellForPresident 100 "Next"

-- haskellForPresident :: Int -> String -> String
-- haskellForPresident x ys
--  | x == 0 = ys
--  | otherwise = haskellForPresident (x-1) (ys ++ " in Next")

import Data.Numbers.Primes
import Criterion.Main

main :: IO()
main = print $ a1 10000
-- main = defaultMain [bgroup "answer" [bench "default" $ whnf a1 10000]]

a1 :: Int -> Int
a1 x = maximum $ take x $ filter (\p -> [f | f <- [1..p], p `mod` f == 0] == [1,p]) [1..]

a2 :: Int -> Int
a2 x = maximum $ take x primes