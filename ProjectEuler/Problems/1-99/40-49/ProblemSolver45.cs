using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Problems
{
    internal class ProblemSolver45 : Solver
    {
        private readonly List<ulong> _hexagonalNumbers;
        private readonly Dictionary<ulong, Tuple<int, int, int>> _intersectedNumbers;
        private readonly List<ulong> _pentagonalNumbers;
        private readonly List<ulong> _triangleNumbers;

        public ProblemSolver45()
        {
            _triangleNumbers = new List<ulong> {1};
            _pentagonalNumbers = new List<ulong> {1};
            _hexagonalNumbers = new List<ulong> {1};
            _intersectedNumbers = new Dictionary<ulong, Tuple<int, int, int>> {{1, new Tuple<int, int, int>(1, 1, 1)}};
        }

        protected override void DoCalculation()
        {
            while (_intersectedNumbers.Count < 3)
            {
                var t = GetNextTriangleNumber();
                ulong p;
                ulong h;
                while ((p = _pentagonalNumbers.Last()) < t) GetNextPentagonalNumber();
                while ((h = _hexagonalNumbers.Last()) < t) GetNextHexagonalNumber();
                if (t == p && t == h)
                    _intersectedNumbers.Add(t,
                        new Tuple<int, int, int>(_triangleNumbers.Count, _pentagonalNumbers.Count,
                            _hexagonalNumbers.Count));
            }

            SetAnswer(_intersectedNumbers.Last().Key);
            //SetAnswer(1533776805);
        }

        private ulong GetNextTriangleNumber()
        {
            var n = Convert.ToUInt64(_triangleNumbers.Count + 1);
            var newNumber = n * (n + 1) / 2;
            _triangleNumbers.Add(newNumber);
            return newNumber;
        }

        private ulong GetNextPentagonalNumber()
        {
            var n = Convert.ToUInt64(_pentagonalNumbers.Count + 1);
            var newNumber = n * (3 * n - 1) / 2;
            _pentagonalNumbers.Add(newNumber);
            return newNumber;
        }

        private ulong GetNextHexagonalNumber()
        {
            var n = Convert.ToUInt64(_hexagonalNumbers.Count + 1);
            var newNumber = n * (2 * n - 1);
            _hexagonalNumbers.Add(newNumber);
            return newNumber;
        }
    }
}