using System;

public abstract class Decision
{
    public DateTime Date { get; set; }
    public string Author { get; set; }

    public abstract void Justify();
}

public class Justification : Decision
{
    public string Content { get; set; }

    public override void Justify()
    {
        Console.WriteLine($"Обоснование от {Author} ({Date.ToShortDateString()}):");
        Console.WriteLine(Content);
    }

    public void CreateJustification(string text)
    {
        Content = text;
    }
}

public class ProductionOrder : Decision
{
    public string ProductCode { get; set; }

    public override void Justify()
    {
        Console.WriteLine($"Изделие {ProductCode} поставлено на производство ({Date.ToShortDateString()}), автор: {Author}");
    }

    public void CreateOrder(string code)
    {
        ProductCode = code;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Система принятия производственных решений ===");
        
        var justification = new Justification
        {
            Date = DateTime.Now,
            Author = "Инженер Иванов"
        };
        justification.CreateJustification("1. Соответствие ГОСТ\n2. Наличие сырья\n3. Рыночный спрос");
        justification.Justify();

        Console.WriteLine();
        
        var order = new ProductionOrder
        {
            Date = DateTime.Now,
            Author = "Директор Петров"
        };
        order.CreateOrder("PROD-2023-0056");
        order.Justify();
    }
}