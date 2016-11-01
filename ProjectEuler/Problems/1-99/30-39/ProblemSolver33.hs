{-
Problem description - Digit cancelling fractions
---------------------------------------------
The fraction 49/98 is a curious fraction, as an inexperienced mathematician in attempting to simplify it may
incorrectly believe that 49/98 = 4/8, which is correct, is obtained by cancelling the 9s.
We shall consider fractions like, 30/50 = 3/5, to be trivial examples.
There are exactly four non-trivial examples of this type of fraction, less than one in value, and containing
two digits in the numerator and denominator.
If the product of these four fractions is given in its lowest common terms, find the value of the denominator.

Problem analysis
----------------
- Looks just straightforward.

Runtime information
-------------------
Compilation      ghc -O2 -threaded <filename>.hs
Execution        ./<filename> +RTS -N
                 for performance run output use: --output <filename>.html
Time             2.039 ms
Answer           100
-}

import Data.Digits
import Data.List
import Prelude
-- import Criterion.Main

main :: IO()
main = print $ answer [11..99]
-- main = defaultMain [bgroup "answer" [bench "default" $ whnf answer [11..99]]]

answer :: [Int] -> Float
answer xs = uncurry divide q ^^ (-1)
  where q = foldl (\(a,b)(x,y)->(a*x,b*y)) (1,1) [(x,y)|x<-xs,y<-xs,isDigitCancellingFraction x y]

isDigitCancellingFraction :: Int -> Int -> Bool
isDigitCancellingFraction x y = z < 1 && t && z == cancelledFraction x y
 where z = divide x y
       t = mod x 10 /= 0 || mod y 10 /= 0

cancelledFraction :: Int -> Int -> Float
cancelledFraction x y
 | null is || null xsf || null ysf = 0
 | otherwise                       = divide (head xsf) (head ysf)
 where is = xs `intersect` ys
       i = head is
       xs = digits 10 x 
       ys = digits 10 y
       xsf = filter (/=i) xs
       ysf = filter (/=i) ys

divide :: Int -> Int -> Float
divide x y = fromIntegral x / fromIntegral y