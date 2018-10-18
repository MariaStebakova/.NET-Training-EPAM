# .NET-Training-EPAM

Day #1
1. Реализовать методы быстрой сортировки и сортировки слиянием для целочисленного массива (тип проекта Class Library). Протестировать работу методов с использованием тестовых фреймворков NUnit и MS Tests. Рассмотреть вариант тестирования массивов большой размерности, элементы которых сгенерированны случайным образом.

Day #2
1. Даны два целых знаковых четырех байтовых числа и две позиции битов i и j (i<j). Реализовать алгоритм InsertNumber вставки битов с j-ого по i-ый бит одного числа в другое так, чтобы биты второго числа занимали позиции с бита j по бит i (биты нумеруются справа налево). Разработать модульные тесты (NUnit и(!) MS Unit Test) для тестирования метода. 

Day #3
1. Реализовать алгоритм FindNthRoot, позволяющий вычислять корень n-ой степени ( n ∈ N ) из вещественного числа а методом Ньютона с заданной точностью.
Разработать модульные тесты (NUnit и MS Unit Test (используя подход DDT)) для тестирования метода. Примерные тест кейсы:
[TestCase(1, 5, 0.0001,ExpectedResult =1)]
[TestCase(8, 3, 0.0001,ExpectedResult = 2)]
[TestCase(0.001, 3, 0.0001,ExpectedResult = 0.1)]
[TestCase(0.04100625,4 , 0.0001, ExpectedResult =0.45)]
[TestCase(8, 3, 0.0001, ExpectedResult =2)]
[TestCase(0.0279936, 7, 0.0001, ExpectedResult =0.6)]
[TestCase(0.0081, 4, 0.1, ExpectedResult =0.3)]
[TestCase(-0.008, 3, 0.1, ExpectedResult =-0.2)]
[TestCase(0.004241979, 9, 0.00000001, ExpectedResult =0.545)]
[a = -0.01, n = 2, accurancy = 0.0001] <- ArgumentException
[a = 0.001, n = -2, accurancy = 0.0001] <- ArgumentException
[a = 0.01, n = 2, accurancy = -1] <- ArgumentException	...
2. Реализовать метод FindNextBiggerNumber, который принимает положительное целое число и возвращает ближайшее наибольшее целое, состоящее из цифр исходного числа, и null (или -1), если такого числа не существует.
Разработать модульные тесты (NUnit или MS Unit Test) для тестирования метода. Примерные тест-кейсы
[TestCase(12, ExpectedResult = 21)]
[TestCase(513, ExpectedResult = 531)]
[TestCase(2017, ExpectedResult = 2071)]
[TestCase(414, ExpectedResult = 441)]
[TestCase(144, ExpectedResult = 414)]
[TestCase(1234321, ExpectedResult = 1241233)]
[TestCase(1234126, ExpectedResult = 1234162)]
[TestCase(3456432, ExpectedResult = 3462345)]
[TestCase(10, ExpectedResult = -1)]
[TestCase(20, ExpectedResult = -1)]

Day #4
1. Реализовать метод TransformToWords который принимает массив вещественных чисел и трансформирует его в массив строк таким образом, чтобы каждое вещественное число преобразовывалось в его "словестный формат" (LINQ-запросы не использовать!). Например, FilterDigit (-23.809, 0.295, 15.17) -> {"minus two three point eight zero nine", "zero point two nine five", "one five point one seven"}. Разработать модульные тесты (NUnit или MS Unit Test) для тестирования метода.