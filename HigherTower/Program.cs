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

        container.Register(Component.For<ICache>().ImplementedBy<Cache>());
        container.Register(Component.For<IStorage>().ImplementedBy<Pantry>());
        container.Register(Component.For<IStorage>().ImplementedBy<Table>());
        container.Register(Component.For<IChef>()
                        .ImplementedBy<Chef>().DependsOn(Dependency.OnComponent(typeof(IStorage), typeof(Table))));

        var service = container.Resolve<IChef>();

        service?.MakeSandwiches();
    }
}