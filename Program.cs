using TotalCostHireKWorkers.TotalCostHireKWorkers;

namespace TotalCostHireKWorkers
{
	internal class Program
	{
		static void Main(string[] args)
		{
			TotalCostHireWorkers totalCost = new();
            Console.WriteLine(totalCost.TotalCost(new int[] { 17, 12, 10, 2, 7, 2, 11, 20, 8 }, 3, 4));
			Console.WriteLine(totalCost.TotalCost(new int[] { 1, 2, 4, 1 }, 3, 3));
            Console.WriteLine(totalCost.TotalCost(new int[] { 57, 33, 26, 76, 14, 67, 24, 90, 72, 37, 30 }, 11, 2));
        }
	}
}