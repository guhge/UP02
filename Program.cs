class ComplexNumber
{
    // Поля для действительной и мнимой частей
    private readonly double real;
    private readonly double imaginary;

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
        if (real == 0 && imaginary == 0)
        {
            return double.NaN;
        }
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
    public static ComplexNumber FromString(string input)
    {
        try
        {
            string[] parts = input.Split('+');
            double realPart = double.Parse(parts[0].Trim());
            double imaginaryPart = double.Parse(parts[1].Trim().TrimEnd('i'));
            return new ComplexNumber(realPart, imaginaryPart);
        }
        catch (Exception)
        {
            throw new FormatException("Неверный формат строки. Ожидаемый формат: 'a + bi'");
        }
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
        try
        {
            ComplexNumber parsedNumber = ComplexNumber.FromString(input);
            Console.WriteLine($"Парсинг строки: {parsedNumber}");
        }
        catch (FormatException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
