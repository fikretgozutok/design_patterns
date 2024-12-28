using System.Text;

namespace Builder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create Margherita Pizza
            var margheritaBuilder = new MargherittaPizzaBuilder();
            var margheritaDirector = new PizzaDirector(margheritaBuilder);

            margheritaDirector.MakePizza();
            Console.WriteLine("Margherita Pizza:");
            Console.WriteLine(margheritaDirector.GetPizza());

            // Create Pepperoni Pizza
            var pepperoniBuilder = new PepperoniPizzaBuilder();
            var pepperoniDirector = new PizzaDirector(pepperoniBuilder);
            pepperoniDirector.MakePizza();
            Console.WriteLine("Pepperoni Pizza:");
            Console.WriteLine(pepperoniDirector.GetPizza());
        }
    }

    //Product
    class Pizza
    {
        public string Dough { get; set; } = string.Empty;
        public string Sauce { get; set; } = string.Empty;
        public string Toppings { get; set; } = string.Empty;

        public override string ToString()
        {
            var description = new StringBuilder();
            description.AppendLine($"Dough: {Dough}");
            description.AppendLine($"Sauce: {Sauce}");
            description.AppendLine($"Toppings: {Toppings}");

            return description.ToString();
        }
    }

    //Builder Interface
    interface IPizzaBuilder
    {
        void SetDough();
        void SetSauce();
        void SetToppings();
        Pizza Get();
    }

    //Concrete Builders
    class MargherittaPizzaBuilder : IPizzaBuilder
    {
        private Pizza _pizza = new Pizza();
        public Pizza Get()
        {
            return _pizza;
        }

        public void SetDough()
        {
            _pizza.Dough = "Thin Crust";
        }

        public void SetSauce()
        {
            _pizza.Sauce = "Tomato Sauce";
        }

        public void SetToppings()
        {
            _pizza.Toppings = "Mozzarella Cheese";
        }
    }

    class PepperoniPizzaBuilder : IPizzaBuilder
    {
        private Pizza _pizza = new Pizza();
        public Pizza Get()
        {
            return _pizza;
        }

        public void SetDough()
        {
            _pizza.Dough = "Thick Crust";
        }

        public void SetSauce()
        {
            _pizza.Sauce = "Barbecue Sauce";
        }

        public void SetToppings()
        {
            _pizza.Toppings = "Pepperoni, Mozzarella Cheese";
        }
    }

    //Director
    class PizzaDirector
    {
        private readonly IPizzaBuilder _builder;

        public PizzaDirector(IPizzaBuilder builder)
        {
            _builder = builder;
        }

        public void MakePizza()
        {
            _builder.SetDough();
            _builder.SetSauce();
            _builder.SetToppings();
        }

        public Pizza GetPizza()
        {
            return _builder.Get();
        }

    }


}
