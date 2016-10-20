main :: IO ()
main = print $ payments 200 [1,2,5,10,20,50,100,200]

payments :: Int -> [Int] -> Int
payments x a = sum test 0 x a

test :: Int -> Int -> [Int] -> Int
test x y a
   | x < y     = payments 1 a
   | x == y    = 1
   | x > y     = 0
   | otherwise = 0