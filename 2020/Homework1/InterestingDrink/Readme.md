B. Интересный напиток

ограничение по времени на тест: 2 секунды

ограничение по памяти на тест: 256 мегабайт

Рабочий Василий очень любит отдыхать после работы, поэтому его часто можно встретить в каком-нибудь баре. Как и все программисты, Василий очень любит напиток «Пикола», который продаётся в n различных магазинах города. Известно, что в i-м магазине бутылка напитка стоит xi монет.

Василий планирует покупать одну бутылку своего любимого напитка на протяжении q дней. Он знает, что в i-й день у него с собой будет mi монет, и теперь он хочет для каждого из дней узнать, в каком количестве магазинов он сможет купить одну бутылочку Пиколы.

Входные данные
В первой строке входных данных содержится целое число n (1≤n≤100000) —количество магазинов в городе, продающих любимый напиток Василия.

Во второй строке входных данных содержится n чисел xi (1≤xi≤100000) — цена за одну бутылку напитка в i-м магазине.

В третьей строке входных данных содержится число q (1≤q≤100000) —количество дней, в течение которых Василий планирует покупать напиток.

В следующих q строках входных данных содержатся целые числа mi (1≤mi≤10^9) — количество денег, которое есть у Василия в i-й день.

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
