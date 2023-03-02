using System;
using System.Diagnostics;

namespace TheWorks
{
    public class Chef : IChef
    {
        private readonly IStorage _productStore;

        public Chef(IStorage productStore)
        {
            _productStore = productStore;
        }

        public void DoWork()
        {
            var timer = new Stopwatch();
            timer.Start();

            var sandwitch1 = MakeASandwich("white_bread", "chunky_peanut_butter", "strawberry_jelly");
            timer.Stop();

            Console.WriteLine($"Made a sandwich in {timer.ElapsedMilliseconds} ms");
            Console.WriteLine($"Great sandwich: {sandwitch1.GetDescription()}");

            timer.Restart();
            var sandwitch2 = MakeASandwich("white_bread", "salty_peanut_butter", "strawberry_jelly");
            Console.WriteLine($"Made a sandwich in {timer.ElapsedMilliseconds} ms");
            Console.WriteLine($"Pretty tasty: {sandwitch1.GetDescription()}");

            _productStore.Close();

        }

        private Sandwich MakeASandwich(string breadName, string peanatButterName, string jellyName)
        {
            var breadLoaf = _productStore.GetBread(breadName);
            var peanatButterJur = _productStore.GetAJur(peanatButterName);
            var jellyJar = _productStore.GetAJur(jellyName);

            return new Sandwich()
                .On(breadLoaf.GetBreadSlice(2))
                .WithTopping(peanatButterJur.GetStuff(2))
                .WithTopping(jellyJar.GetStuff(2))
                .CoverWith(breadLoaf.GetBreadSlice(2));
        }
    }
}
