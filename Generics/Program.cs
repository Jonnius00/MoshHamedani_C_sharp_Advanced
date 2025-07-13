using System;

namespace Generics
{
    /// <summary>
    /// Main program demonstrating various generic concepts in action.
    /// This class shows practical usage of the generic types defined in this project.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== C# Generics Demonstration ===\n");
            
            // Demonstrate custom Nullable<T>
            DemonstrateNullable();
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();

            // Demonstrate generic collections
            DemonstrateGenericCollections();
            
            // Demonstrate generic constraints
            DemonstrateConstraints();
            
            // Demonstrate generic utilities
            DemonstrateUtilities();
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        /// <summary>
        /// Demonstrates the custom Nullable<T> implementation.
        /// Shows boxing/unboxing, value type constraints, and default values.
        /// </summary>
        static void DemonstrateNullable()
        {
            Console.WriteLine("--- Custom Nullable<T> Demonstration ---");
            
            // Create a nullable int without a value
            var number = new Nullable<int>();
            Console.WriteLine($"Empty Nullable<int> - Has Value: {number.HasValue}");
            Console.WriteLine($"Empty Nullable<int> - Value: {number.GetValueOrDefault()}");
            
            // Create a nullable int with a value
            var numberWithValue = new Nullable<int>(42);
            Console.WriteLine($"Nullable<int>(42) - Has Value: {numberWithValue.HasValue}");
            Console.WriteLine($"Nullable<int>(42) - Value: {numberWithValue.GetValueOrDefault()}");
            
            // Demonstrate with other value types
            var nullableBool = new Nullable<bool>(true);
            Console.WriteLine($"Nullable<bool>(true) - Value: {nullableBool.GetValueOrDefault()}");
            
            var emptyDate = new Nullable<DateTime>();
            Console.WriteLine($"Empty Nullable<DateTime> - Default: {emptyDate.GetValueOrDefault()}");
            
            Console.WriteLine();
        }

        /// <summary>
        /// Demonstrates generic collections vs non-generic collections.
        /// Shows type safety and reusability benefits.
        /// </summary>
        static void DemonstrateGenericCollections()
        {
            Console.WriteLine("--- Generic Collections Demonstration ---");
            
            // Generic list - type safe and reusable
            var books = new GenericList<Book>();
            var numbers = new GenericList<int>();
            var names = new GenericList<string>();
            
            Console.WriteLine("Created GenericList<Book>, GenericList<int>, and GenericList<string>");
            Console.WriteLine("Same generic class works with different types!");
            
            // Generic dictionary - multiple type parameters
            var bookPrices = new GenericDictionary<string, decimal>();
            var studentGrades = new GenericDictionary<int, char>();
            
            Console.WriteLine("Created GenericDictionary<string, decimal> and GenericDictionary<int, char>");
            Console.WriteLine("Multiple type parameters allow flexible key-value combinations!");
            
            Console.WriteLine();
        }

        /// <summary>
        /// Demonstrates various generic constraints in action.
        /// Shows how constraints enable specific functionality.
        /// </summary>
        static void DemonstrateConstraints()
        {
            Console.WriteLine("--- Generic Constraints Demonstration ---");
            
            // Interface constraint (IComparable)
            Console.WriteLine("Interface Constraint - Max with IComparable:");
            int maxInt = Sample.Max(5, 10);
            string maxString = Sample.Max("apple", "banana");
            DateTime maxDate = Sample.Max(DateTime.Today, DateTime.Now);
            
            Console.WriteLine($"Max(5, 10) = {maxInt}");
            Console.WriteLine($"Max(\"apple\", \"banana\") = {maxString}");
            Console.WriteLine($"Max(Today, Now) = {maxDate}");
            
            // Class constraint
            Console.WriteLine("\nClass Constraint - DiscountCalculator:");
            var discountCalc = new DiscountCalculator<Product>();
            var product = new Product { Title = "Sample Product", Price = 100.0f };
            var book = new Book { Title = "C# Guide", Price = 50.0f, Isbn = "123-456" };
            
            Console.WriteLine($"Product discount: {discountCalc.CalculateDiscount(product)}");
            Console.WriteLine($"Book discount: {discountCalc.CalculateDiscount(book)}");
            
            Console.WriteLine();
        }

        /// <summary>
        /// Demonstrates the Utilities class with multiple constraints.
        /// Shows how combining constraints provides more functionality.
        /// </summary>
        static void DemonstrateUtilities()
        {
            Console.WriteLine("--- Multiple Constraints Demonstration ---");
            
            // Utilities<T> requires IComparable and new() constraints
            var intUtils = new Utilities<int>();
            var stringUtils = new Utilities<string>();
            var dateUtils = new Utilities<DateTime>();
            
            Console.WriteLine("Multiple Constraints (IComparable + new()):");
            Console.WriteLine($"intUtils.Max(15, 7) = {intUtils.Max(15, 7)}");
            Console.WriteLine($"stringUtils.Max(\"zebra\", \"alpha\") = {stringUtils.Max("zebra", "alpha")}");
            
            var today = DateTime.Today;
            var tomorrow = DateTime.Today.AddDays(1);
            Console.WriteLine($"dateUtils.Max(Today, Tomorrow) = {dateUtils.Max(today, tomorrow)}");
            
            // Demonstrate DoSomething method (uses new() constraint)
            Console.WriteLine("\nUsing new() constraint in DoSomething method:");
            intUtils.DoSomething(42);
            stringUtils.DoSomething("test");
            dateUtils.DoSomething(DateTime.Now);
            Console.WriteLine("DoSomething methods executed (they create new instances internally)");
            
            Console.WriteLine();
        }
    }
    
    /// <summary>
    /// Helper class to demonstrate generic methods with interface constraints.
    /// This shows how static generic methods can be created with constraints.
    /// </summary>
    public static class Sample
    {
        /// <summary>
        /// Generic Max method with interface constraint.
        /// Made public static to be callable from Program.Main for demonstration.
        /// </summary>
        public static T Max<T>(T a, T b) where T : IComparable
        {
            return a.CompareTo(b) > 0 ? a : b;
        }
    }
}