main :: IO ()
main = print $ payments 200 coins (length coins)

coins :: [Int]
coins = [1,2,5,10,20,50,100,200]

payments :: Int -> [Int] -> Int -> Int
payments t c s
   | t < 0     = 0
   | t == 0    = 1
   | s == 1    = 1
   | otherwise = payments t c (s - 1) + payments (t - (c !! (s - 1))) c s