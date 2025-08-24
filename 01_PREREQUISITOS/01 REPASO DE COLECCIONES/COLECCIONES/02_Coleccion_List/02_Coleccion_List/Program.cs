using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<string> Names = new List<string>();

        Names.Add("JOSE");
        Names.Add("ANA");
        Names.Add("PABLO");
        Names.Add("LUIS");

        List<string> Birds = new List<string> {"Canario","Paloma","Azulejo","Mirlo"};

        List<Fruit> fruits = new List<Fruit>
        { 
            new Fruit{Name="Manzana", Color="Roja"},
            new Fruit{Name="Pera", Color="Amarilla"},
            new Fruit{Name="Papaya", Color="Amarilla"},
            new Fruit{Name="Mango", Color="Rojo"}
        };

        Console.WriteLine("Lista de frutas");
        Console.WriteLine("====================");
        foreach (var fruit in fruits) 
        { 
            Console.WriteLine($"Fruta: {fruit.Name}, Color: {fruit.Color}");
        }

        Console.WriteLine("Lista de nombres");
        Console.WriteLine("===================");
        foreach (var name in Names)
        {
            Console.WriteLine($"Nombre: {name}");
        }

        Console.WriteLine("Lista de pajaros");
        Console.WriteLine("===================");
        foreach (var bird in Birds)
        {
            Console.WriteLine(bird);
        }

        // Adicionar más frutas
        Fruit fruit1 = new Fruit();
        fruit1.Name = "Aguacate";
        fruit1.Color = "Verde";
        fruits.Add(fruit1);

        fruits.Insert(2, new Fruit {Name="Uva",Color="Morado"});

        // Quita la primera fruta de la lista
        fruits.RemoveAt(0);

        Console.WriteLine("\n\n");
        foreach (var fruit in fruits)
        {
            //Console.WriteLine($"Fruta: {fruit.Name}, Color: {fruit.Color}");
            Console.WriteLine(fruit.ToString());
        }

        Console.WriteLine($"Cantidad de frutas: {fruits.Count}");
    }
}

class Fruit
{
    public string Name { get; set; }
    public string Color { get; set; }

    public override string ToString()
    {
        return $"Fruta: {Name}, Color: {Color}";
    }
}
