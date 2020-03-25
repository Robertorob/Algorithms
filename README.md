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

