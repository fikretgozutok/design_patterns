namespace AbstractFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Application app = new Application(FactoryLoader.LoadFactory(OS.Mac));

            app.RenderUI();
        }
    }

    //Step 1: Abstract Product Interfaces
    interface IButton
    {
        void Render();
    }

    interface ICheckBox
    {
        void Render();
    }

    //Step 2: Concrete Products
    class WindowsButton : IButton
    {
        public void Render() => Console.WriteLine("Rendered a Windows Button");
    }

    class WindowsCheckBox : ICheckBox
    {
        public void Render() => Console.WriteLine("Rendered a Windows CheckBox");
    }

    class MacButton : IButton
    {
        public void Render() => Console.WriteLine("Rendered a Mac Button");
    }

    class MacCheckBox : ICheckBox
    {
        public void Render() => Console.WriteLine("Rendered a Mac CheckBox");
    }

    //Step 3: Abstract Factory
    interface IUIFactory
    {
        IButton CreateButton();
        ICheckBox CreateCheckBox();
    }

    //Step 4: Concrete Factories

    class WindowsFactory : IUIFactory
    {
        public IButton CreateButton() => new WindowsButton();
        public ICheckBox CreateCheckBox() => new WindowsCheckBox();
    }

    class MacFactory : IUIFactory
    {
        public IButton CreateButton() => new MacButton();
        public ICheckBox CreateCheckBox() => new MacCheckBox();
    }

    //Step 5: Factory instance loader
    static class FactoryLoader
    {
        public static IUIFactory LoadFactory(OS os)
        {
            return os switch
            {
                OS.Mac => new MacFactory(),
                OS.Windows => new WindowsFactory(),
                _ => throw new ArgumentException("Invalid Os type")
            };
        }
    }

    //Step 6: Client Class
    class Application
    {
        private readonly IButton _button;
        private readonly ICheckBox _checkBox;

        public Application(IUIFactory factory)
        {
            _button = factory.CreateButton();
            _checkBox = factory.CreateCheckBox();
        }

        public void RenderUI()
        {
            _button.Render();
            _checkBox.Render();
        }
    }

    //Step 7: Define OS as enum
    enum OS
    {
        Windows, Mac
    }
}
