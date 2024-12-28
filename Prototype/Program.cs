namespace Prototype
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create original Circle
            Metadata metadata = new Metadata { Author = "Alice", Description = "Original Circle" };
            Circle circle = new Circle(5, "Red", metadata);

            // Create Shallow Copy
            Circle shallowCopy = (Circle)circle.ShallowCopy();

            // Create Deep Copy
            Circle deepCopy = (Circle)circle.DeepCopy();

            // Modify the metadata of the original circle
            circle.Metadata!.Author = "Bob";
            circle.Metadata!.Description = "Modified Circle";

            // Draw all shapes
            Console.WriteLine("Original Circle:");
            Console.WriteLine(circle.ToString());

            Console.WriteLine("\nShallow Copy:");
            Console.WriteLine(shallowCopy.ToString());

            Console.WriteLine("\nDeep Copy:");
            Console.WriteLine(deepCopy.ToString());

            //Test

            Console.WriteLine(Object.ReferenceEquals(circle.Metadata, shallowCopy.Metadata));
            Console.WriteLine(Object.ReferenceEquals(circle.Metadata, deepCopy.Metadata));

        }
    }

    // Metadata Class
    public class Metadata
    {
        public string Author { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

    //Step 1: Abstract Prototype
    public abstract class Shape
    {
        public string Color { get; set; } = string.Empty;
        public Metadata? Metadata { get; set; }
        public abstract Shape ShallowCopy();
        public abstract Shape DeepCopy();
    }

    //Step 2: Concrete Prototype
    public class Circle : Shape
    {
        public int Radius { get; set; }

        public Circle(int radius, string color, Metadata metadata)
        {
            Radius = radius;
            Color = color;
            Metadata = metadata;
        }

        public override Shape ShallowCopy()
        {
            return (Shape)this.MemberwiseClone(); // Shallow copy
        }

        public override Shape DeepCopy()
        {
            // Deep copy: Clone properties and create new instances for referenced objects
            Circle clone = (Circle)this.MemberwiseClone();
            clone.Metadata = new Metadata
            {
                Author = this.Metadata!.Author,
                Description = this.Metadata.Description
            };
            return clone;
        }

        public override string ToString()
        {
            return $"Circle: {Radius}cm, Color: {Color}, Author: {Metadata!.Author}, Description: {Metadata.Description}";
        }
    }


    class Rectangle : Shape
    {
        public int SideLength { get; set; }
        public override Shape ShallowCopy()
        {
            return (Shape)MemberwiseClone();
        }

        public override Shape DeepCopy()
        {
            Rectangle clone = (Rectangle)MemberwiseClone();
            clone.Metadata = new Metadata
            {
                Author = Metadata!.Author,
                Description = Metadata!.Description
            };

            return clone;
        }

        public override string ToString()
        {
            return $"Rectangle: {SideLength}cm, Color: {Color}, Author: {Metadata!.Author}, Description: {Metadata.Description}";
        }
    }
}
