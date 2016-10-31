{-
Problem description - Pandigital products
-----------------------------------------
We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once;
for example, the 5-digit number, 15234, is 1 through 5 pandigital.
The product 7254 is unusual, as the identity, 39 × 186 = 7254, containing multiplicand, multiplier, and
product is 1 through 9 pandigital.
Find the sum of all products whose multiplicand/multiplier/product identity can be written as a 1 through
9 pandigital.
HINT: Some products can be obtained in more than one way so be sure to only include it once in your sum.

Problem analysis
----------------
- For x * y = z wat is the upper limit for x and y? An insane boundary would be 987.654.321, this can't
  be computed.
- How can we divide 9 items into 3 buckets where ordering is relevant? Generate all permutations of the
  9 items and then per item create all possible partitions.

Runtime information
-------------------
Compilation      ghc -O2 -threaded <filename>.hs
Execution        ./<filename> +RTS -N
                 for performance run output use: --output <filename>.html
Time             11.95 s
Answer           45228
-}

import Data.Digits
import Data.List
-- import Criterion.Main

main :: IO()
main = print $ answer [1..9]
-- main = defaultMain [bgroup "answer" [bench "default" $ whnf answer [1..9]]]

answer :: [Int] -> Int
answer xs = sum $ nub $ map (!! 2) $ filter (isPandigital xs) $ map (map (unDigits 10)) $ concatMap (buckets 1 2) $ permutations xs

-- Isn't there a package which can do partitioning?
buckets :: Int -> Int -> [Int] -> [[[Int]]]
buckets f s xs
 | f == fm            = [bl]
 | f /= fm && s == sm = bl : buckets (f + 1) (f + 2) xs
 | otherwise          = bl : buckets f (s + 1) xs
 where l = length xs
       fm = l - 2
       sm = l - 1
       bl = [take f xs, take (s - f) (takeLastNElements (l - f) xs), takeLastNElements (l - s) xs]

isPandigital :: [Int] -> [Int] -> Bool
isPandigital xs ys = x * y == z && null (l `intersect` r) && null (lr `intersect` m) && sort (lr `union` m) == xs
  where x = head ys
        y = ys !! 1
        z = ys !! 2
        l = digits 10 x
        r = digits 10 y
        lr = l `union` r
        m = digits 10 (x * y)

-- There are much more efficient algorithms out there.
takeLastNElements :: Int -> [Int] -> [Int]
takeLastNElements n xs = reverse $ take n $ reverse xs