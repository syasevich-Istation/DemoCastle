using Castle.MicroKernel.Registration;
using Castle.Windsor;
using TheWorks;
using TheWorks.Caching;

public class Program
{
    static void Main(string[] args)
    {
        //Initialize a new container
        WindsorContainer container = new WindsorContainer();

        container.Register(Component.For<ICache>().ImplementedBy<Cache>().LifestyleSingleton());
        container.Register(Component.For<IStorage>().ImplementedBy<Pantry>().LifestyleSingleton());

        container.Register(Component.For<IChef>().ImplementedBy<Chef>().LifestyleSingleton());

        var service = container.Resolve<IChef>();

        service?.MakeSandwiches();
    }
}
