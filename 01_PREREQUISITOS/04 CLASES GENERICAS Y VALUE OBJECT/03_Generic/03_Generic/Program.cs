using _03_Generic;

class Program
{
    static void Main(string[] args)
    {
        Empleado empleado1 = new Empleado(1, "Jose", 12000000.00);
        Empleado empleado2 = new Empleado(2, "Anibal", 25000000.00);
        Empleado empleado3 = new Empleado(3, "Ivan", 32000000.00);

        Product producto1 = new Product(1, "Cafe", 12);
        Product producto2 = new Product(2, "Azucar", 15);
        Product producto3 = new Product(3, "Cacao", 5);

        Repository<Empleado> repository = new Repository<Empleado>();

        repository.Add(empleado1);
        repository.Add(empleado2);
        repository.Add(empleado3);


        List<Empleado> miList = repository.GetList();


        foreach (Empleado mi in miList)
        {
            Console.WriteLine(mi.Name);
        }

        Repository<Product> repositoryProduct = new Repository<Product>();

        repositoryProduct.Add(producto1);
        repositoryProduct.Add(producto2);
        repositoryProduct.Add(producto3);

        List<Product> misProducts = repositoryProduct.GetList();

        foreach (Product miProduct in misProducts)
        {
            Console.WriteLine(miProduct.ProductName);
        }

    }
}