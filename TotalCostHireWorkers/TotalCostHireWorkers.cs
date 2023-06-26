namespace TotalCostHireKWorkers.TotalCostHireKWorkers
{
	internal class TotalCostHireWorkers
	{
		public long TotalCost(int[] costs, int k, int candidates)
		{
			int n = costs.Length;
			int leftIdx = 0;
			int rightIdx = n - 1;
			MinHeap minHeapLeft = new();
			MinHeap minHeapRight = new();
			while (leftIdx < candidates)
			{
				minHeapLeft.Push(costs[leftIdx], leftIdx++);
			}
			while (rightIdx >= n - candidates && rightIdx > leftIdx)
			{
				minHeapRight.Push(costs[rightIdx], rightIdx--);
			}
			long totalCost = 0;
			for (int candidate = 1; candidate <= k; ++candidate)
			{
				Worker leftWorker = !minHeapLeft.IsEmpty() ? minHeapLeft.Peek() : new Worker(int.MaxValue, -1);
				Worker rightWorker = !minHeapRight.IsEmpty() ? minHeapRight.Peek() : new Worker(int.MaxValue, - 1);
				if (leftWorker.cost < rightWorker.cost)
				{
					totalCost += leftWorker.cost;
					minHeapLeft.Pop();
					if (leftIdx <= rightIdx)
					{
						minHeapLeft.Push(costs[leftIdx], ++leftIdx);
					}
				}
				else if (leftWorker.cost > rightWorker.cost)
				{
					totalCost += rightWorker.cost;
					minHeapRight.Pop();
					if (rightIdx >= leftIdx)
					{
						minHeapRight.Push(costs[rightIdx], --rightIdx);
					}
				}
				else
				{
					totalCost += leftWorker.cost;
					minHeapLeft.Pop();
					if (leftIdx <= rightIdx)
					{
						minHeapLeft.Push(costs[leftIdx], leftIdx++);
					}
				}
			}
			return totalCost;
		}
	}
}
