Консольный калькулятор
---
***
Консольный калькулятор, вычисляющий выражения, состоящие из простейших арифметических операций (+, -, *, /, скобки)

Написано с использованием фреймворка .net Core, для тестирования используется фреймворк NUnit 

Калькулятор основан на нисходящем парсере. Используется метод рекурсивного спуска.

В арифметическом выражении допускаются десятичные числа (пожалуйста, используйте '.')

Допускаются числа с незначащими нулями

Допускается несколько итерации “ввод / ответ”, для заверешния введите "STOP"

[JetBrains_Calculator](https://github.com/FadeevSergey/ARITHMETIC_EXPRESSION_SOLVER/tree/master/JetBrains_Calculator "Rider project") - Rider project

[JetBrains_Calculator/Calculator](https://github.com/FadeevSergey/ARITHMETIC_EXPRESSION_SOLVER/tree/master/JetBrains_Calculator/Calculator "Код приложения") - Приложение

[JetBrains_Calculator/Calculator.Tests](https://github.com/FadeevSergey/ARITHMETIC_EXPRESSION_SOLVER/tree/master/JetBrains_Calculator/Calculator "Код тестов") - Тесты

### Пример работы:
#### Выражение является валидным
```sh
1. (20/5/2/2/2/2)*2*(1+1)-(1-2)/(1-2) = 0
2. ((((3 - ((( 4 ) )) / 6 ) / 7 * (0.5 + 0.05 * 50 + 0 + 0 + 0 + 0 + 0 + 0.001 - 0.0001 * ((0.5 + 1.5) * 1 / 0.0002) - 0.001)))) = 0.(6)
3. 0.001*1000/0000000001  + 0000/0.1 = 1
4. (((((((((((((-0))))))))))))) = 0
```
![Image alt](https://sun9-53.userapi.com/c858416/v858416202/1ef986/cJWE1hj1aKQ.jpg)
```sh
1. (1.1 + (3.3 * (5.5 - (7.7 / (9.9 + (11.11 - (13.13 * (15.15 / (17.17) - 16.16) + 14.14) / 12.12) * 10.1) * 8.8) + 6.6) / 4.4) - 2.2) = 7.791859
2. -(-(-(-(-(-(-(-(-1)))))))) = -1
```
![Image alt](https://sun9-10.userapi.com/c858416/v858416202/1ef9a0/cmR1IIQ8Ufk.jpg)

#### Выражение не является валидным
```sh
1. (((Hello))
```
![Image alt](https://sun9-50.userapi.com/c858416/v858416119/1eec1e/_LUU2uri70E.jpg)
```sh
 1.
 2. 1000 + 1 / 8 * ()
```
![Image alt](https://sun9-56.userapi.com/c858416/v858416119/1eec14/6JXXqA2b1YM.jpg)
```sh
 1. 1 + 2 + 3 4
```
![Image alt](https://sun9-68.userapi.com/c856520/v856520119/199056/U6Eo_svHW2A.jpg)
```sh
1. ((((((((((((((((((((((((((((((1 + 2) * 5) / 0) * 188) - 12) - 12) - 13) - 7777))))))))) - 4.5 * (3.4 / (222 + (-222)))) - 1.234))))) + 1.2340.001))))))
```
![Image alt](https://psv4.userapi.com/c856416/u2000038421/docs/d4/a38ab8a6062e/file.jpg?extra=DRxme0ZtLt7A_MYiZk-Xr3upa7n1TjNDWCxSkwlNmSzuU1uCzuNsk_OEfdfal4yELikBad35t8pklLQU7B9dGi5whm80-IPwy8iLSwix0krZaE4OjtfPG-iDuYKNZZfM4K6keIeXad1IT_s1zy4hdlqdKac)
