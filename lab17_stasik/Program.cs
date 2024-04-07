Fazzynumber fazzynumber1 = new(3.5, 2.5);
Fazzynumber fazzynumber2 = new(1.5, 1.0);
Pair<double> fazzynumberSum = fazzynumber1.Add(fazzynumber2);
Console.WriteLine($"Sum of fazzy numbers: {fazzynumberSum}");

Complex complex1 = new(2, 3);
Complex complex2 = new(1, -2);
Pair<double> complexProduct = complex1.Multiply(complex2);
Console.WriteLine($"Product of complex numbers: {complexProduct}");

public abstract class Pair<T>(T first, T second)
{
    public T first = first, second = second;

    public abstract Pair<T> Add(Pair<T> other);
    public abstract Pair<T> Subtract(Pair<T> other);
    public abstract Pair<T> Multiply(Pair<T> other);
    public abstract Pair<T> Divide(Pair<T> other);
}

public class Fazzynumber(double first, double second) : Pair<double>(first, second)
{
    public override Pair<double> Add(Pair<double> other)
    {
        return new Fazzynumber(first + other.first, second + other.second);
    }

    public override Pair<double> Subtract(Pair<double> other)
    {
        return new Fazzynumber(first - other.first, second - other.second);
    }

    public override Pair<double> Multiply(Pair<double> other)
    {
        return new Fazzynumber(first * other.first, second * other.second);
    }

    public override Pair<double> Divide(Pair<double> other)
    {
        if (other.first == 0 || other.second == 0)
        {
            throw new ArgumentException("Division by zero");
        }

        return new Fazzynumber(first / other.first, second / other.second);
    }

    public override string ToString()
    {
        return $"{first}, {second}";
    }
}

public class Complex(double real, double imaginary) : Pair<double>(real, imaginary)
{
    public override Pair<double> Add(Pair<double> other)
    {
        return new Complex(first + other.first, second + other.second);
    }

    public override Pair<double> Subtract(Pair<double> other)
    {
        return new Complex(first - other.first, second - other.second);
    }

    public override Pair<double> Multiply(Pair<double> other)
    {
        double real = (first * other.first) - (second * other.second);
        double imaginary = (first * other.second) + (second * other.first);
        return new Complex(real, imaginary);
    }

    public override Pair<double> Divide(Pair<double> other)
    {
        if (other.first == 0 && other.second == 0)
        {
            throw new ArgumentException("Division by zero");
        }

        double divisor = (other.first * other.first) + (other.second * other.second);
        double real = ((first * other.first) + (second * other.second)) / divisor;
        double imaginary = ((second * other.first) - (first * other.second)) / divisor;
        return new Complex(real, imaginary);
    }

    public override string ToString()
    {
        return $"{first}{(second < 0 ? "" : "+")}{second}i";
    }
}
