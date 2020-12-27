### CalculatorConsoleApp
#### Консольное приложение, вычисляющее значение вводимого выражения.

Алгоритм работает следующим образом:
- Считывается введенное пользователем выражение.
- Выражение проходит "починку": в выражениях выставляются пропущенные знаки умножения, точки заменяются запятыми и тд.
- Выражение проходит валидацию: проверяется, нет ли в нем букв и других неудобных символов, и тд. 
- Если находится ошибка, то соответствующее сообщение высвечивается, и приложение снова ждет ввода. 
- Выражение обрабатывается калькулятором:
1. Обработку проходят все скобки -- их содержимое подсчитывается отдельно, и подставляется на места, где были скобки.
2. Проходят обработку все знаки умножения и деления - выполняются в том же порядке, в котором они встречаются в выражении, результат подставляется в выражение.
3. Выражение разбивается на операнды, которые складываются между собой.


![Снимок](https://user-images.githubusercontent.com/65355775/103181141-ca459800-48ae-11eb-8f4e-e668cdb141e1.PNG)






