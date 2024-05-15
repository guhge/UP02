class ComplexNumber
{
    // Поля для действительной и мнимой частей
    private double real;
    private double imaginary;

    // Конструктор
    public ComplexNumber(double real, double imaginary)
    {
        this.real = real;
        this.imaginary = imaginary;
    }

    // Метод для получения модуля комплексного числа
    public double GetMagnitude()
    {
        return Math.Sqrt(real * real + imaginary * imaginary);
    }

    // Метод для получения аргумента комплексного числа (в радианах)
    public double GetArgument()
    {
        return Math.Atan2(imaginary, real);
    }

    // Перегрузка оператора сложения
    public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
    {
        return new ComplexNumber(a.real + b.real, a.imaginary + b.imaginary);
    }

    // Перегрузка оператора вычитания
    public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b)
    {
        return new ComplexNumber(a.real - b.real, a.imaginary - b.imaginary);
    }

    // Перегрузка метода ToString для вывода комплексного числа в строку
    public override string ToString()
    {
        return $"{real} + {imaginary}i";
    }

    // Статический метод для создания комплексного числа из строки
    public static ComplexNumber Parse(string input)
    {
        // Парсим строку в действительную и мнимую части
        string[] parts = input.Split('+');
        double realPart = double.Parse(parts[0]);
        double imaginaryPart = double.Parse(parts[1].TrimEnd('i'));

        return new ComplexNumber(realPart, imaginaryPart);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Пример использования
        ComplexNumber z1 = new ComplexNumber(3, 4);
        ComplexNumber z2 = new ComplexNumber(1, 2);

        ComplexNumber sum = z1 + z2;
        Console.WriteLine($"Сумма: {sum}");

        ComplexNumber difference = z1 - z2;
        Console.WriteLine($"Разность: {difference}");

        string input = "5 + 2i";
        ComplexNumber parsedNumber = ComplexNumber.Parse(input);
        Console.WriteLine($"Парсинг строки: {parsedNumber}");
    }
}