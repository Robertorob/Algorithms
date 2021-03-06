# A. Биржевые заявки
**ограничение по времени на тест** 2 секунды

**ограничение по памяти на тест** 256 мегабайт

**ввод** стандартный ввод

**вывод** стандартный вывод

В данной задаче вам потребуется обработать набор заявок на торгах и сформировать по ним биржевой стакан.

Заявка — это желание какого-то участника торгов купить или продать акции. Для каждой заявки i известна ее цена pi, направление заявки di — покупка или продажа, а также количество акций qi, которые участник готов купить или продать по цене pi за акцию. Значение qi называется объемом заявки.

Все заявки с одинаковой ценой p и направлением d объединяются в так называемую аггрегированную заявку, цена которой также равна p, направление — d, а объём складывается из исходных заявок.

Биржевой стакан — это таблица из аггрегированных заявок, в которой сначала идут предложения продажи, отсортированные по убыванию цены, а затем предложения покупки, тоже отсортированные по убыванию цены.

Стакан с глубиной s содержит s лучших аггрегированных заявок по каждому направлению. Заявка на покупку тем лучше, чем у неё цена больше, заявка на продажу тем лучше, чем у неё цена меньше. Если аггрегированных заявок в данном направлении меньше s, то они все попадают в итоговый стакан.

Дано n биржевых заявок на покупку и продажу акций, требуется распечатать биржевой стакан глубины s для этих заявок.

## Входные данные
В первой строке записаны два целых числа n и s (1≤n≤1000,1≤s≤50) — количество заявок и глубина стакана соответственно.

В каждой из следующих n строк следуют символ di (либо 'B', либо 'S'), целое число pi (0≤pi≤10^5), а также целое число qi (1≤qi≤10^4) — направление, цена и объем заявки соответственно. Символ 'B' означает покупку, 'S' — продажу. Цена любой заявки на продажу больше цены любой заявки на покупку.

## Выходные данные
Выведите не больше чем 2s строк, в которых содержатся аггрегированные заявки биржевого стакана глубины s. Заявки требуется выводить в том же формате что и во входных данных.

## Примеры
### Пример 1
#### Вход
```
6 2
B 10 3
S 50 2
S 40 1
S 50 6
B 20 4
B 25 10
```
#### Выход
```
S 50 8
S 40 1
B 25 10
B 20 4
```

