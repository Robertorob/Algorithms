## AlphabeticalSubsets 
### Input 
[1, 2, 3] ~ 10 elements in collection

### Output
```
[]
[1]
[1, 2]
[1, 2, 3]
[1, 3]
[2]
[2, 3]
[3]
```

## NextPermutation
Дана перестановка, найти следующую

Решение: 

1. Идем справа налево
1. Находим убывание
1. Число, на котором убывание произошло, свапаем с числом, которое должно быть следующим
1. Реверсим правый конец

## Permutations
Вывести все перестановки используя функцию NextPermutation

## QueensPermutation
How many permutation of 8 queens is there if they do not beat each other? 

Общий случай рассмотрен в задаче Homework2/ZerosAndOnes 

## RecursivePermutations (Вычисление всех перестановок рекурсивно)
Даны перестановки без повторений (ABC)
```
static void Main(string[] args)
{
	char[] a = "ABC".ToCharArray();
	Permute(a, 0);
	Console.ReadKey();
}

public static void Permute(char[] permutation, int index)
{
	if (index == permutation.Length - 1)
		Print(permutation);
	else
	{
		for (int j = index; j < permutation.Length; j++)
		{
			Swap(permutation, index, j);
			Permute(permutation, index + 1);
			Swap(permutation, index, j);
		}
	}
}
```