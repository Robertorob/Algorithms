# Algorithms
This repo contains all solved tasks from Algorithm course in Akvelon

## Homework 1

### Searching 
Даны два массива. Для каждого элемента из второго массива найти сколько элементов из 1-го массива строго меньше

Решение: сортируем первый массив, бежим по второму и двоичный поиск

### PolandAndGame
Двое играют в слова. Даны их словари. Выяснить, кто выиграет

Решение: заводим два Dictionary, в цикле имитируем ходы игроков. Выбираем всегда то слово, которое есть у противника, чтобы заблокировать ему это слово

### MillionaireCity
Есть город Томск с координатами (0, 0) и заданным числом жителей. Даны также n других городов с координатами и числом жителей. Определить минимальный радиус для расширения города Томска до миллиона жителей.

Решение: 
```
// Сортируем населенные пункты по радиусу. Радиус вычислили при заполнении данных
Array.Sort(villages);

// Вычисляем бегущую сумму людей
villages[0].PeopleSum = villages[0].PeopleAmount;
for (int i = 0; i < villages.Length - 1; i++)
{
	villages[i + 1].PeopleSum = villages[i + 1].PeopleAmount + villages[i].PeopleSum;
}

Console.WriteLine(BinarySearch(villages, 1000000 - s));
```
### IvanAndLantern
Даны координаты фонарей, выяснить минимальный радиус освещения фонаря, чтобы они осветили всю улицу длины L. 

Решение: просто находим максимальное расстояние между фонарями. Не забыть учесть случаи, когда по краям улицы нет фонарей. В этих случаях нужно считать длину от фонаря до края улицы.

```
Array.Sort(a);

if (a[0] != 0)
	d = a[0];
if (a[n - 1] != l)
	d = Max((int) d, l - a[n - 1]);

for (int i = 0; i < n - 1; i++)
{
	double radius = (a[i + 1] - a[i]) / 2;
	if(radius > d)
	{
		d = radius;
	}
}
Console.WriteLine(d);
```

### InterestingDrink
Дан массив цен на напиток для разных магазинов. Дан массив, где указано количество денег на каждый день. Определить для каждого дня, в скольки магазинах ему хватит денег на напиток

Решение: 
```
Array.Sort(x);

for (int i = 0; i < q; i++)
{
	m[i] = BinarySearch(x, int.Parse(Console.ReadLine()) );
}

for (int i = 0; i < q; i++)
{
	Console.WriteLine(m[i]);
}
```

### EvgeniiAndPlaylist
Дана коллекция песен. Указано время песни и сколько раз Женя её слушал. Далее дан массив отметок, понравившихся моментов. Найти номер песни, для каждой отметки

Решение: считаем бегущую сумму времени для каждой песни. Т.е. сколько всего времени прошло до того, как песня заиграла. Потом бежим по меткам и двоичным поиском находим песни

### ChatsOrder
Дан список людей, которые отсылали сообщения в чат, в порядке отсылки. Т.е. первый списке тот, кто писал давно. Нужно вывести чаты в таком порядке, чтобы наверху были более новые сообщения.

Решение: идем снизу вверх, и не выводим те, которые уже были. Для этого после вывода кладем в словарь. Перед выводом проверяем, нет ли этого человека в словаре
```
string line1 = Console.ReadLine();
int n = int.Parse(line1);

string[] names = new string[n];
for (int i = 0; i < n; i++)
{
	names[i] = Console.ReadLine();
}

Dictionary<string, string> namesSet = new Dictionary<string, string>(n);

for (int i = names.Length - 1; i >= 0; i--)
{
	if (!namesSet.ContainsKey(names[i]))
	{
		Console.WriteLine(names[i]);
		namesSet.Add(names[i], null);
	}                    
}
```

## Homework 2

### ExchangeRequests
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

### Reposts
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

### HostelBath
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
