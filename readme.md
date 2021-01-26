Консольный калькулятор
---
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
![Image alt](https://sun9-72.userapi.com/c858416/v858416119/1eec47/nQXj3ZHs_UU.jpg)
```sh
 1.
 2. 1000 + 1 / 8 * ()
```
![Image alt](https://sun9-59.userapi.com/c858416/v858416119/1eec4f/z-ChwJISwFY.jpg)
```sh
 1. 1 + 2 + 3 4
```
![Image alt](https://sun9-64.userapi.com/c858416/v858416119/1eec56/d5C_JFIdI50.jpg)
```sh
1. ((((((((((((((((((((((((((((((1 + 2) * 5) / 0) * 188) - 12) - 12) - 13) - 7777))))))))) - 4.5 * (3.4 / (222 + (-222)))) - 1.234))))) + 1.2340.001))))))
```
![Image alt](https://sun9-28.userapi.com/impg/c858416/v858416202/1ef997/vvFJsfDEPqk.jpg?size=2170x510&quality=96&proxy=1&sign=4b0b6a47700e8969bd2cf605c775520a&type=album)
```sh
 1. )))((
```
![Image alt](https://sun9-66.userapi.com/c858416/v858416202/1ef98d/1taLpX6byas.jpg)

