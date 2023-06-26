using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalCostHireKWorkers.TotalCostHireKWorkers
{
	internal class MinHeap
	{
		private readonly List<Worker> heap;

		private void Swap(int i, int j)
		{
			(heap[i], heap[j]) = (heap[j], heap[i]);
		}

		private void SiftDown(int curIdx, int endIdx)
		{
			int childOneIdx = curIdx * 2 + 1;
			while(childOneIdx <= endIdx)
			{
				int swapIdx = childOneIdx;
				int childTwoIdx = curIdx * 2 + 2;
				if(childTwoIdx <= endIdx && heap[childTwoIdx].cost < heap[childOneIdx].cost)
				{
					swapIdx = childTwoIdx;
				}
				if (heap[swapIdx].cost < heap[curIdx].cost)
				{
					Swap(swapIdx, curIdx);
					curIdx = swapIdx;
					childOneIdx = curIdx * 2 + 1;
				}
				else
				{
					return;
				}
			}
		}

		private void SiftUp(int curIdx)
		{
			int parentIdx = (curIdx - 1) / 2;
			while(parentIdx >= 0 && heap[parentIdx].cost > heap[curIdx].cost)
			{
				Swap(parentIdx, curIdx);
				curIdx = parentIdx;
				parentIdx = (curIdx - 1) / 2;
			}
		}

		public MinHeap()
		{
			heap = new List<Worker>();
		}

		public void Push(int cost, int position)
		{
			heap.Add(new Worker(cost, position));
			SiftUp(heap.Count - 1);
		}

		public void Pop()
		{
			Swap(0, heap.Count - 1);
			Worker removedWorker = heap[^1];
			heap.RemoveAt(heap.Count - 1);
			SiftDown(0, heap.Count - 1);
		}

		public Worker Peek()
		{
			return heap[0];
		}

		public bool IsEmpty()
		{
			return heap.Count == 0;
		}
	}
}
