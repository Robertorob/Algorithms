## FarNodes (Диаметр графа)
Задача: найти две самы удалённые друг отдруга вершины

Решение: 

1. Запускаем обход в глубину с любой вершины и находим самую удалённую вершину v1
1. Запускаем обход в глубину с вершины V1 и находим самую удалённую от неё v22.
1. v1, v2 - решение

## Убрать пути, которые не входят в наикратчайшие
Дан граф, есть вершины А и Б. Нужно найти крайтчайшие пути от А до Б и

убрать все ребра, которые не принадлежат этим кратчайшим путям


## Алгоритм дейкстры (Dijkstra) и Двоичная куча (Binary heap -> Min heap)
Найти все кратчайшие расстояния от заданной вершины до всех остальных вершин

*Решение*: Смотрим алгоритм на русскоязычной википедии (на ней есть step-by-step пример). Для хранения ещё не посещённых вершин используем двоичную кучу, где ключом является кратчайшее расстояние. Структура данных: список вершин (Node), где у каждой вершины есть набор ребёр с весами (Edge) (т.е. не просто соседи, но и расстояние до этого соседа).

```
Node[] g = new Node[6]
{
	new Node(0,             new Edge(5, 14), new Edge(1, 7), new Edge(2, 9)),
	new Node(int.MaxValue,  new Edge(0, 7), new Edge(2, 10), new Edge(3, 15)),
	new Node(int.MaxValue,  new Edge(0, 9), new Edge(1, 10), new Edge(3, 11), new Edge(5, 2)),
	new Node(int.MaxValue,  new Edge(1, 15), new Edge(2, 11), new Edge(4, 6)),
	new Node(int.MaxValue,  new Edge(5, 9), new Edge(3, 6) ),
	new Node(int.MaxValue,  new Edge(0, 14), new Edge(2, 2), new Edge(4, 9))
};

MinHeap heap = new MinHeap();

Node node = g[0];

while(true)
{
	node.Checked = true;

	foreach (var n in node.Neibhs)
	{
		if (g[n.NodeNumber].Checked)
			continue;

		g[n.NodeNumber].Value = Min(n.Weight + node.Value, g[n.NodeNumber].Value);
		heap.Add(g[n.NodeNumber]);
	}

	node = heap.GetMin();

	if (node == null)
		break;
}
```

## Игра Ним
Играют двое. На столе лежат палочки. Пусть их будет 10. Для любого количества палочек заданы варианты, сколько можно взять палочек.

Например для 10 палочек: можно взять только 2 палочки

Для 8 палочек можно взять только 1, 2 или 3 палочки. И так далее.

Для 7 палочек, например, нет вариантов. Это значит, что тот, у кого осталось 7 палочек - проиграл.

Все эти данные известны обоим игрокам. Оба игрока играют оптимально. Определить, кто выиграет.

Решение: представить нужно всё в виде графа, где 10 палочек - это вершина под номером 10. 

Из неё ведёт только один путь: в вершину под номером 8 (8 палочек осталось)

Из вершины 8 идут пути в 3 вершины: 5, 6, 7. Потому что можно взять 1, 2 или 3 палочки.

И так далее строим граф.

Потом запускаем рекурсивную функцию, которая определяет для каждой вершины её "выигрышность"

```
public static Result GetResult(List<Node> g, int n)
{
	if (!g[n].Neibhs.Any())
		return Result.Loss;

	if (g[n].Neibhs.Any(f => GetResult(g, f) == Result.Loss))
		return Result.Win;

	return Result.Loss;
}
```

## Sum Root to Leaf Numbers

https://www.interviewbit.com/problems/sum-root-to-leaf-numbers/

Given a binary tree containing digits from 0-9 only, each root-to-leaf path could represent a number.

An example is the root-to-leaf path 1->2->3 which represents the number 123.

Find the total sum of all root-to-leaf numbers % 1003.

Example :
```
    1
   / \
  2   3
``` 
The root-to-leaf path 1->2 represents the number 12.

The root-to-leaf path 1->3 represents the number 13.

Return the sum = (12 + 13) % 1003 = 25 % 1003 = 25.

**Решение**

Создаём дополнительную рекурсивную функцию ListNumbers для узла: возвращает список чисел, которые есть в этом узле. Пример:
```
	    2
	   / \
	  4   5
	 / \
	7   8 
```	
Для 2 вершины: 247, 248, 25 (это финальные числа, которые нужно потом просто просуммировать)

Для 4 вершины: 47, 48 (они будут использованы при обработке вершины 2 когда будет рассматриваться левая ветка у вершины 2)

{11 2 4 5 7 8 -1 -1 -1 -1 -1 -1} - сериализованное представление этого дерева (Test with custom input)
```
/**
 * Definition for binary tree
 * class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) {this.val = x; this.left = this.right = null;}
 * }
 */
class Solution {
    public int sumNumbers(TreeNode A) {
        var f = ListNumbers(A);
        
        int sum = 0;
        foreach(var item in f){
            sum+=int.Parse(item);
        }
        return sum % 1003;
    }

    public static List<string> ListNumbers(TreeNode a){
        if(a == null)
            return null;
            
        var leftNode = a.left == null ? "" : a.left.val.ToString();
        var rightNode = a.right == null ? "" : a.right.val.ToString();
        //Console.WriteLine(a.val + "-" + leftNode + "-" + rightNode); 
        
        List<string> numbers = new List<string>();
        
        if(a.left == null && a.right == null){
            numbers.Add(a.val.ToString());
            return numbers;
        }
        
        if(a.left != null){
            numbers.AddRange(ListNumbers(a.left));
        }
        
        if(a.right != null){
            numbers.AddRange(ListNumbers(a.right));
        }
        
        List<string> result = new List<string>();
        foreach(var item in numbers){
            result.Add(a.val.ToString() + item.ToString());
        }
        
        //Console.Write(a.val + " has ");
        foreach(var item in result){
            //Console.Write(item + ",");
        }
        //Console.WriteLine();
        return result;
    }
}
```

## Postorder Traversal (Without recursion, with stack)

https://www.interviewbit.com/problems/postorder-traversal/

Given a binary tree, return the postorder traversal of its nodes’ values.

Example :

Given binary tree
```
   1
    \
     2
    /
   3
```
return [3,2,1].

**Using recursion is not allowed**.

Решение: код из Википедии переведён на C#
```
/**
 * Definition for binary tree
 * class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) {this.val = x; this.left = this.right = null;}
 * }
 */
class Solution {
    public List<int> postorderTraversal(TreeNode A) {
        Stack<TreeNode> s = new Stack<TreeNode>();
        List<int> result = new List<int>();
        TreeNode lastNodeVisited = null;
        while(s.Count > 0 || A != null){
            if(A != null){
                s.Push(A);
                A = A.left;
            }
            else{
                TreeNode peekNode = s.Peek();
                if(peekNode.right != null && lastNodeVisited != peekNode.right)
                    A = peekNode.right;
                else{
                    result.Add(peekNode.val);
                    lastNodeVisited = s.Pop();
                }
                    
            }
        }
        
        return result;
    }
}
```

## ZigZag level Order Traversal BT
https://www.interviewbit.com/problems/zigzag-level-order-traversal-bt/

Нужно пройтись по каждому уровню дерева, чередуя направления: слева направо потом справа налево.

Given a binary tree, return the zigzag level order traversal of its nodes’ values. (ie, from left to right, then right to left for the next level and alternate between).

Example :
Given binary tree
```
    3
   / \
  9  20
    /  \
   15   7
```
return
```
[
         [3],
         [20, 9],
         [15, 7]
]
```

Решение: 
1. Пройтись обходом в ширину с двумя очередями
1. Перед тем, как положить очередной уровень в результат, реверснуть уровень (потом реверснуть обратно).

```
/**
 * Definition for binary tree
 * class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) {this.val = x; this.left = this.right = null;}
 * }
 */
class Solution {
    public List<List<int>> zigzagLevelOrder(TreeNode A)
        {
            List<List<int>> result = new List<List<int>>();

            result.Add(new List<int> { A.val });

            Queue<TreeNode> list = new Queue<TreeNode>();

            list.Enqueue(A);

            bool left = false;
            while (list.Count > 0)
            {

                Queue<TreeNode> list2 = new Queue<TreeNode>();

                while (list.Count > 0)
                {
                    var g = list.Dequeue();

                    if (g.left != null)
                        list2.Enqueue(g.left);
                    if (g.right != null)
                        list2.Enqueue(g.right);
                }

                Swap(ref list, ref list2);

                if (!left)
                    list = new Queue<TreeNode>(list.Reverse());

                List<int> level = new List<int>();
                foreach (var item in list)
                    level.Add(item.val);

                if (!left)
                    list = new Queue<TreeNode>(list.Reverse());

                if (level.Count > 0)
                    result.Add(level);

                left = !left;
            }
            return result;
        }

        public static void Swap(ref Queue<TreeNode> x, ref Queue<TreeNode> y)
        {
            var t = x;
            x = y;
            y = t;
        }
}
```

## АВЛ и красно-черные деревья. B-деревья
Асимптотические сложности одинаковые, но константы разные для разных операций. АВЛ быстрее поиск, но удаление и добавление дольше, т.к. поворот на каждой вершине.

В-деревья для индексов в БД.

Поиск log t (n) * log 2 (t) = log 2 (n), т.е. такой же как и в обычном дереве поиска, но чтение в медленной памяти просиходит за время log t (n)

Удаление O(t*log t (n)), добавление также. Если бы была быстрая память, то можно было бы реализовать двоичный поиск и было бы быстрее

## Графы. Хранение. Поиск в ширину

### Графы
Матрица смежности (Adjacency matrix)
- есть ли ребро O(1)
- получить соседей у вершины O(n)
- получить все вершины и всех соседей O(n^2)
- память M(n^2)

Список рёбер List of edges
|E| = m, |V| = n
- есть ли ребро O(m)
- получить соседей у вершины O(n)
- получить все вершины и всех соседей O(n^2)
- удалить добавить ребро
- память M(n)

Можно отсортировать по

Adjacency list

### Алгоритм дейкстры это тот же BFS, только во взвешенном графе
Дейкстру можно улучшить, используя красно-черное дерево O(n*log(n) + m*log(n)). Это будет эффективно при разреженных графах

Если граф плотный, то не нужно этого делать, тогда скорость будет O(n^2)

Фиббоначиева куча позволяет сократить скорость O(n + m), но структура сложная и вроде как мало где используется
