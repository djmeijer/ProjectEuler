main :: IO ()
main = print $ countCoins (length coins) 200

coins :: [Integer]
coins = [1,2,5,10,20,50,100,200]

countCoins :: Int -> Integer -> Integer
countCoins 1 _ = 1
countCoins n x = sum $ map addCoin [0 .. x `div` coins !! pred n]
  where addCoin k = countCoins (pred n) (x - k * coins !! pred n)