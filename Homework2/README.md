# Homework 2

## ExchangeRequests
Даны заявки на покупки акций. В заявке указано направление(покупка/продажа), цена и количество. Нужно вывести себе самые выгодные s штук заявок для каждого направления. Заявки о продаже брать самые дешевые, а заявки о покупке брать самые дорогие.

Решение: фильтруем отдельно покупки, отдельно продажу, группируем их по цене. Обе коллекции сортируем по цене. Продажу выводим последние s штук. Покупки выводим первые s штук
```
var asdf = requests.AsQueryable();
var buy = asdf
	.Where(f => f.d == 'B')
	.GroupBy(f => new { f.p })
	.Select(f => new Request { p = f.Key.p, q = f.Sum(sum => sum.q) })
	.ToArray();
var sell = asdf
	.Where(f => f.d == 'S')
	.GroupBy(f => new { f.p })
	.Select(f => new Request { p = f.Key.p, q = f.Sum(sum => sum.q) })
	.ToArray();

// Сортируем по цене
Array.Sort(buy, new Comparison<Request>(
				(i1, i2) => i2.CompareTo(i1)));

Array.Sort(sell, new Comparison<Request>(
				(i1, i2) => i2.CompareTo(i1)));

int sellCount = sell.Count();
sellCount = s > sellCount ? sellCount : s;
for (int i = sell.Count() - sellCount; i < sell.Count(); i++)
{
	Console.WriteLine("S " + sell[i].p + " " + sell[i].q);
}

int buyCount = buy.Count();
buyCount = s > buyCount ? buyCount : s;
for (int i = 0; i < buyCount; i++)
{
	Console.WriteLine("B " + buy[i].p + " " + buy[i].q);
}
```

## Reposts
Даны репосты
```
tourist reposted Polycarp
Petr reposted Tourist
```

Найти самую длинную цепочку

Решение: сначала кладем поликарпа с длиной 1. Далее Каждое левое имя кладем с длиной правого + 1 (правое имя гарантированно уже лежит в словаре)

```
Dictionary<string, int> names = new Dictionary<string, int>(n + 1);
names.Add("polycarp", 1);
int maxLength = 1;

for (int i = 0; i < n; i++)
{
	string[] massive = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
	string who = massive[0].ToLower();
	string whom = massive[2].ToLower();

	int currentLength = names[whom] + 1;
	names.Add(who, currentLength);
	maxLength = Max(maxLength, currentLength);
}
Console.WriteLine(maxLength);
```

## HostelBath
Дана очередь из пяти студентов 12345
Они общаются 1-2, 3-4, 5 - не общается

Потом 1 уходит, остаются 2345

Общаются 2-3, 4-5 и так далее

Есть матрица счасться g[5][5] для каждого с каждым, она не симметричная (Вася больше счастлив от общения с Дашей, чем Даша от общения с Васей)

Найти максимальную сумму счастья

Решение: перебрать **все перестановки** и найти ту, которая имеет максимальную сумму

```
static void Main(string[] args)
{
	for (int i = 0; i < n; i++)
	{
		string[] line = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
		for (int j = 0; j < n; j++)
		{
			g[i, j] = int.Parse(line[j]);
		}
	}

	ChooseValueForPermutation(0);
	Console.WriteLine(max);
}

public static void ChooseValueForPermutation(int index)
{
	for (int i = 0; i < n; i++)
	{
		bool checkDesk = CheckDesk(index, i);
		massive[index] = i;
		if (checkDesk && index == n - 1)
		{
			int temp = SumOfHappiness();
			if (temp > max)
				max = temp;
			return;
		}

		if (checkDesk)
		{                  
			ChooseValueForPermutation(index + 1);
		}

	}
}
```
## Guard
Find minimum amount of steps from start point 'P' to final point. On your way you have to find all '1's.

Пройти от стартовой точки 'P' и захватить все единички. Наверх можно подняться только по боковым нулям. Найти минимальное число шагов
```
010000
001000
P00100
```
Решение: падает на 43 тесте

## ZerosAndOnes
Задача о перестановке ферзей, только для произвольной доски и произвольного количества ферзей. 

Решение: такое же, но на i-й столбец ещё можно поставить -1 (ничего не поставить)

При проверке расстановки учитываем количество доступных пустых мест и количество доступных ферзей.

После обработки столбца мы не идём сразу на следующий столбец. На одном столбце у нас теперь несколько вариантов (из-за наличия пустот)
```
static void Main(string[] args)
{
	...
	PutQueen(0);
	Console.WriteLine(count);
}

public static void PutQueen(int index)
{
	for (int i = -1; i < n; i++)
	{
		massive[index] = i;
		bool checkDesk = CheckDesk(index, i);
		if (checkDesk && index == n - 1)
		{
			count++;
			continue;
		}

		if (checkDesk)
		{
			PutQueen(index + 1);
		}

	}
}
```
## Cesurity
задача о черепашке (о марсоходе)

решается динамическим программированием
