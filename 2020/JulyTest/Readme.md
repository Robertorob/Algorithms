## A. Аня и минимизация (AnyaAndMinimization)
Простая задача

## B. Миша и смена хэндлов (MishaAndHandleChange)
Первое число - количество строк. Далее идёт смена имен в хронологическом порядке
#### Вход
```
6
1 2	(1 перешёл в 2)
2 3	(2 перешёл в 3)
3 4	(3 перешёл 4)
5 6	(5 перешёл 6)
6 7	(и т.д.)
f g
```
#### Выход
```
3
1 4	(В конечном итоге: 1 - самое первое имя, 4 - самое последнее)
5 7	
f g
```
Решение: тот же пример. Кладём в словарь 1 2, но наоборот: 2 1. Чтобы новое имя стало ключом. 

Далее мы смотрим запись 2 3. Смотрим, есть ли в словаре смена на 2. Да она уже была. Поэтому первую запись 2 1 убираем. Вместо неё кладём 3 1 (1 3, вконце выводится в правильном порядке)
```
static void Main(string[] args)
{
	int q = int.Parse(Console.ReadLine());

	if (q == 1)
	{
		var asdf = Console.ReadLine();
		Console.WriteLine("1");
		Console.WriteLine(asdf);
		return;
	}

	Dictionary<string, string> list = new Dictionary<string, string>();

	for (int i = 0; i < q; i++)
	{
		string value;
		var line = Console.ReadLine().Split(new char[] { ' ' });
		if (list.TryGetValue(line[0], out value))
		{
			list.Remove(line[0]);
			list.Add(line[1], value);
		}
		else
			list.Add(line[1], line[0]);
	}

	Console.WriteLine(list.Count);
	foreach (var item in list)
	{
		Console.WriteLine(item.Value + " " + item.Key);
	}
}
```
