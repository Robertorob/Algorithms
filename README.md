# Algorithms
This repo contains all solved tasks from Algorithm course in Akvelon

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


## QueensPermutation
How many permutation of 8 queens is there if they do not beat each other?

## NextPermutation
Дана перестановка, найти следующую

Решение: 

1. Идем справа налево
1. Находим убывание
1. Число, на котором убывание произошло, свапаем с числом, которое должно быть следующим
1. Реверсим правый конец

## Задача о выпуклой оболочке (convex hall ??)
1. Выбираем самую левую нижнюю точку
1. Сортируем по углу
1. Строим оболочку для 0..i 
1. Нужно определять провый и левый повороты
1. Для этого нужно знать векторное произведение
1. Берем два вектора. Переносим оба вектора в начало координат
1. 

## Число фибоначчи по модулю p (Fibonacci)
Найти n-ое число фибоначчи по модулю p
Решение: находим повторяющуюся пару - это начало нового цикла. Далее находим индекс начала цикла. 
```
	0:      n = 1       1      (1)   
	1:      n = 2       1      (1)   
	2:      n = 3       2       2
	3:      n = 4       3       0
	4:      n = 5       5       2
	5:      n = 6       8       2
	6:      n = 7       13      1
	7:      n = 8       21      0
	8:      n = 9       34     (1)   
	9:      n = 10      55     (1)   
	10:     n = 11      89      2
	11:     n = 12      144     0
	12:     n = 13      233     2
	13:     n = 14      377     2
	14:     n = 15      610     1
	15:     n = 16      987     0
	16:	n = 17      1597    1
```

