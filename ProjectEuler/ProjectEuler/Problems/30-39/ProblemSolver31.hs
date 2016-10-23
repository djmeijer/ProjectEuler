-- import Criterion.Main

-- This is a combinatorics problem.
-- TODO: It could be solved with a taylor expansion series?

main :: IO ()
main = print $ payments coins (length coins) 200
-- main = defaultMain [
--   bgroup "payments" [ bench "200" $ whnf (payments coins (length coins)) 200
--                     , bench "150" $ whnf (payments coins (length coins)) 150
--                     , bench "100" $ whnf (payments coins (length coins)) 100
--                ]
--   ]

coins :: [Int]
coins = [1,2,5,10,20,50,100,200]

payments :: [Int] -> Int -> Int -> Int
payments c s t
   | t < 0     = 0
   | t == 0    = 1
   | s == 1    = 1
   | otherwise = payments c (s - 1) t + payments c s (t - (c !! (s - 1)))

-- Compilation      ghc -O2 -threaded <filename>.hs
-- Execution        ./<filename> +RTS -N
-- Performance      ./<filename> --output coins.html
--                  done in 822.3 μs, answer 73682