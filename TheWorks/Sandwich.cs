using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheWorks
{
    public class Sandwich
    {
        private BreadSlice? Foundation { get; set; } = null;
        private List<ISpreadable> Toppings { get; set; }
        private BreadSlice? Cover { get; set; } = null;

        public Sandwich()
        {
            Toppings= new List<ISpreadable>();
        }

        public Sandwich On(BreadSlice breadSlice)
        {
            // if topping already added we cannot change foundation
            if (Toppings.Count > 0)
            { 
                throw new InvalidOperationException("Cannot change bread when topping already added");
            }

            Foundation = breadSlice;
            return this;
        }

        public Sandwich WithTopping(ISpreadable topping)
        {
            // we can add as many topping as we want, but we cannot remove them
            // we cannot add toppings when the sandwich already covered by a slice of bread
            if (Cover != null)
            {
                throw new InvalidOperationException("The sandwich is already closed");
            }

            Toppings.Add(topping);
            return this;
        }

        public Sandwich CoverWith(BreadSlice breadSlice)
        {
            Cover = breadSlice;
            return this;
        }

        public string GetDescription()
        {
            return $"{string.Join(", ", Toppings.Select(t => t.Description))} on {Foundation.Description}";
        }
    }
}
