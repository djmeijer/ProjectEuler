using System.Collections.Generic;

namespace ProjectEuler.Problems
{
    internal class ProblemSolver31 : Solver
    {
        /* Coin sums
         * 
         * In England the currency is made up of pound, £, and pence, p, and there
         * are eight coins in general circulation:
         *
         * 1p, 2p, 5p, 10p, 20p, 50p, £1 (100p) and £2 (200p).
         * It is possible to make £2 in the following way:
         *
         * 1×£1 + 1×50p + 2×20p + 1×5p + 1×2p + 3×1p
         * How many different ways can £2 be made using any number of coins?
         * 
         */

        protected override void DoCalculation()
        {
			//SetAnswer(CalculateNaive());
			SetAnswer(CalculateRecursive());
            //SetAnswer(73682);
        }

		private int CalculateRecursive()
		{
			var coins = new List<int> { 1, 2, 5, 10, 20, 50, 100, 200 };
			return Payments(coins, coins.Count, 200);
		}

		private int Payments(List<int> coins, int length, int amount)
		{
			if (amount < 0)
			{
				return 0;
			}
			if (amount == 0)
			{
				return 1;
			}
			if (length == 1)
			{
				return 1;
			}
			return Payments(coins, length - 1, amount) + Payments(coins, length, amount - coins[length - 1]);
		}

		private int CalculateNaive()
		{
			// Naive implementation.
			int[] coins = new int[] { 1, 2, 5, 10, 20, 50, 100, 200 };
			int amount = 200;
			int possibilities = 0;

			for (int a = 0; a <= amount; a++)
			{
				var aa = a * coins[0];
				if (aa <= amount)
				{
					for (int b = 0; b <= amount; b++)
					{
						var bb = b * coins[1];
						if (aa + bb <= amount)
						{
							for (int c = 0; c <= amount; c++)
							{
								var cc = c * coins[2];
								if (aa + bb + cc <= amount)
								{
									for (int d = 0; d <= amount; d++)
									{
										var dd = d * coins[3];
										if (aa + bb + cc + dd <= amount)
										{
											for (int e = 0; e <= amount; e++)
											{
												var ee = e * coins[4];
												if (aa + bb + cc + dd + ee <= amount)
												{
													for (int f = 0; f <= amount; f++)
													{
														var ff = f * coins[5];
														if (aa + bb + cc + dd + ee + ff <= amount)
														{
															for (int g = 0; g <= amount; g++)
															{
																var gg = g * coins[6];
																if (aa + bb + cc + dd + ee + ff + gg <= amount)
																{
																	for (int h = 0; h <= amount; h++)
																	{
																		var hh = h * coins[7];
																		if (aa + bb + cc + dd + ee + ff + gg + hh == amount)
																		{
																			possibilities++;
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return possibilities;
		}
    }
}