using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dijkstra
{
    public class MinHeap
    {
        private List<Node> list;

        public int HeapSize
        {
            get
            {
                return this.list.Count;
            }
        }

        /*
         * На входе неупорядоченный массив. Копируем его,
         * потом вызываем Heapify для каждой вершины, у которой есть 
         * хотя бы один потомок. Потомки гарантированно есть у первых HeapSize / 2 вершин.
         * Сложность O(N)
         */
        public MinHeap(Node[] source)
        {
            list = source.ToList();
            for (int i = this.HeapSize / 2; i >= 0; i--)
            {
                this.Heapify(i);
            }
        }

        // O(log(N))
        public Node GetMin()
        {
            Node result = this.list[0];
            this.list[0] = list[this.HeapSize - 1];
            this.list.RemoveAt(this.HeapSize - 1);
            this.Heapify(0);
            return result;
        }

        // O(log(N))
        public void Add(Node value)
        {
            this.list.Add(value);
            int i = this.HeapSize - 1;
            int parent = (i - 1) / 2;

            while (i > 0 && list[parent] > list[i])
            {
                Swap(i, parent);

                i = parent;
                parent = (i - 1) / 2;
            }
        }

        /*
         * Находим, где действительно должна лежать i-я вершина. Проталкиваем её вниз, 
         * пока она не встанет на своё место.
         * Сложность O(log(N))
         */
        private void Heapify(int i)
        {
            while (true)
            {
                int min = FindMinimumChild(i);

                if (min == i)
                    break;

                Swap(i, min);
                i = min;
            }
        }

        private int FindMinimumChild(int i)
        {
            int left = 2 * i + 1, right = 2 * i + 2;

            int min = i;

            if (left < this.HeapSize && this.list[left] < this.list[min])
                min = left;

            if (right < this.HeapSize && this.list[right] < list[min])
                min = right;

            return min;
        }

        private void Swap(int i, int j)
        {
            Node temp = this.list[i];
            this.list[i] = this.list[j];
            this.list[j] = temp;
        }
    }
}
