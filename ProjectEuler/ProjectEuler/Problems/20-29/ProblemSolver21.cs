namespace ProjectEuler
{
    class ProblemSolver21 : Solver
    {
        protected override void DoCalculation()
        {
            this.SetAnswer(31626);
        }

        // Haskell solution

        // main = print t
        
        // d i = sum[x | x < -[1..i - 1], mod i x == 0]
        // p = [[x, y]|x<-[1..9999],y<-[x..9999],x/=y,d x==y,d y==x]
        // t = sum[sum[x, y] |[x, y] < -p]

        // -- Compiling: ghc -O2 -threaded<filename>.hs
        // -- Execution: ./<filename.hs> +RTS -N
        // -- Done in about 3s, answer: 31626.
    }
}