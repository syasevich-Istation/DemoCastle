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

        public void MakeSandwiches()
        {
            var timer = new Stopwatch();

            _productStore.Open();

            Console.WriteLine("Time to make sandwiches");

            Console.WriteLine("Please wait...");
            timer.Start();
            var sandwitch1 = MakeASandwich("white_bread", "chunky_peanut_butter", "strawberry_jelly");
            timer.Stop();

            Console.WriteLine($"Great sandwich: {sandwitch1.GetDescription()}");
            Console.WriteLine($"Made it in {timer.ElapsedMilliseconds} ms");

            Console.WriteLine("Please wait...");
            timer.Restart();
            var sandwitch2 = MakeASandwich("white_bread", "salty_peanut_butter", "strawberry_jelly");
            timer.Stop();

            Console.WriteLine($"Pretty tasty: {sandwitch2.GetDescription()}");
            Console.WriteLine($"Made it in {timer.ElapsedMilliseconds} ms");

            _productStore.Close();

        }

        private Sandwich MakeASandwich(string breadName, string peanatButterName, string jellyName)
        {
            var breadLoaf = _productStore.GetBread(breadName);
            var peanatButterJur = _productStore.GetAJur(peanatButterName);
            var jellyJar = _productStore.GetAJur(jellyName);

            return new Sandwich()
                .On(breadLoaf.GetBreadSlice(2))
                .WithTopping(peanatButterJur.GetPortion(2))
                .WithTopping(jellyJar.GetPortion(2))
                .CoverWith(breadLoaf.GetBreadSlice(2));
        }
    }
}
