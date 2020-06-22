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





## delete

# Updating NuGet package
To  update any NuGet package you should:

1. Put source files (*.7z files) to the corresponding folder 
    - src\AXPSDemoData
    - src\DemoData
    - src\DemoVolumeData


1. Change the .nuspec files if you want to change the package's metadata.

1. Create a PR.

1. After PR is merged your changes will be automatically applied to the new NuGet packages and published to the BuildTeamTesting feed