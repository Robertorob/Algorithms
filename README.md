# Algorithms

This repo contains all solved tasks from Algorithm course in Akvelon

##########################################################################################
##########################################################################################
##########################################################################################

A. Searching
time limit per test: 2 seconds
memory limit per test: 64 megabytes

You are given a sequence of n integers a1, ..., an. You have to answer m queries. The i-th query is given by a number qi, and you should output the number of elements in the sequence that are strictly less than qi.

Input
The first line contains a single integer n, the number of elements in the set (1 ≤ n ≤ 105). The next line contains n numbers a1, ..., an (1 ≤ ai ≤ 109). The third line contains a single integer m, the number of queries (1 ≤ m ≤ 105). The next line contains m numbers q1, ..., qn (1 ≤ qi ≤ 109)

Output
Output m numbers, the answers to the queries in the given order.

Example
input
10
7 4 1 3 9 2 4 5 9 8
4
6 1 9 4
output
6 0 8 3 

##########################################################################################
##########################################################################################
##########################################################################################

B. Интересный напиток
ограничение по времени на тест: 2 секунды
ограничение по памяти на тест: 256 мегабайт

Рабочий Василий очень любит отдыхать после работы, поэтому его часто можно встретить в каком-нибудь баре. Как и все программисты, Василий очень любит напиток «Пикола», который продаётся в n различных магазинах города. Известно, что в i-м магазине бутылка напитка стоит xi монет.

Василий планирует покупать одну бутылку своего любимого напитка на протяжении q дней. Он знает, что в i-й день у него с собой будет mi монет, и теперь он хочет для каждого из дней узнать, в каком количестве магазинов он сможет купить одну бутылочку Пиколы.

Входные данные
В первой строке входных данных содержится целое число n (1 ≤ n ≤ 100 000) —количество магазинов в городе, продающих любимый напиток Василия.

Во второй строке входных данных содержится n чисел xi (1 ≤ xi ≤ 100 000) — цена за одну бутылку напитка в i-м магазине.

В третьей строке входных данных содержится число q (1 ≤ q ≤ 100 000) —количество дней, в течение которых Василий планирует покупать напиток.

В следующих q строках входных данных содержатся целые числа mi (1 ≤ mi ≤ 109) — количество денег, которое есть у Василия в i-й день.

Выходные данные
Выведите q целых чисел, i-е из которых должно равняться количеству магазинов, в которых Василий может купить одну бутылочку любимого напитка в день i.

Пример
входные данные
5
3 10 8 6 11
4
1
10
3
11
выходные данные
0
4
1
5

Примечание
В первом запросе ни в одном магазине Василию не хватит денег.

Во втором запросе Василию хватит денег, чтобы купить напиток в магазинах под номерами 1, 2, 3 и 4.

В третьем запросе Василию хватит денег, чтобы купить напиток в магазине под номером 1.

И в последнем запросе Василий может купить свой напиток в любом магазине.

##########################################################################################
##########################################################################################
##########################################################################################
