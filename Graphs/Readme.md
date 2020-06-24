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

