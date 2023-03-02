
using Microsoft.Extensions.DependencyInjection;
using TheWorks;
using TheWorks.Caching;

public class Program
{
    public static void Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();

        var serviceProvider = serviceCollection
            .AddSingleton<IStorage, Pantry>()
            .AddSingleton<IChef, Chef>()
            .BuildServiceProvider();


        var service = serviceProvider.GetService<IChef>();


        service?.MakeSandwiches();

        Console.Write("Press <Entr> to exist");
        Console.ReadLine();
    }
}
