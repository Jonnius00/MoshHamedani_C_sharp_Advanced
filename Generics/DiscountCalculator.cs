namespace Generics
{
    /// <summary>
    /// Generic discount calculator demonstrating CLASS CONSTRAINT usage.
    /// A practical example of how generic constraints enable
    /// type-safe operations on constrained types.
    /// 
    /// Key Concepts:
    /// 1. Class Constraint: where TProduct : Product
    ///    - Ensures TProduct IS type Product or INHERITS from Product
    ///    - Allows access to class Product properties (Title, Price)
    ///    - Maintains type safety while enabling polymorphism
    /// 
    /// 2. Real-world Application:
    ///    - Can work with Product and all its derived types (Book, ...)
    ///    - Type-safe: compiler prevents non-Product types
    ///    - Reusable: single class works for entire Product hierarchy
    /// 
    /// 3. Polymorphic Behavior:
    ///    - Can be instantiated for specific product types
    ///    - Maintains strong typing throughout the calculation
    /// </summary>
    /// 
    /// <typeparam name="TProduct">Product type that must inherit from Product</typeparam>
    /// 
    /// <example>
    /// 
    /// // Generic - works with any Product-derived type
    /// var productCalc = new DiscountCalculator<Product>();
    /// var bookCalc = new DiscountCalculator<Book>();
    /// 
    /// // Type safety in action
    /// var product = new Product { Title = "Widget", Price = 100.0f };
    /// var book = new Book { Title = "C# Guide", Price = 50.0f, Isbn = "123" };
    /// 
    /// float productDiscount = productCalc.CalculateDiscount(product); // Returns 100.0f
    /// float bookDiscount = bookCalc.CalculateDiscount(book);           // Returns 50.0f
    /// 
    /// // This won't compile due to constraint:
    /// // var stringCalc = new DiscountCalculator<string>(); // Error: string doesn't inherit from Product
    /// </example>
    public class DiscountCalculator<TProduct> where TProduct : Product
    {
        /// <summary>
        /// Calculates discount based on the product's price.
        /// The class constraint (where TProduct : Product) allows us to safely
        /// access the Price property without casting or runtime type checking.
        /// 
        /// This method demonstrates:
        /// - Safe property access through constraints
        /// - No casting required (compile-time type safety)
        /// - Works with Product and all derived types
        /// - Returns the actual price (could be modified to return actual discount)
        /// </summary>
        /// <param name="product">Product instance to calculate discount for</param>
        /// <returns>The product's price (placeholder for actual discount calculation)</returns>
        /// <example>
        /// var calculator = new DiscountCalculator<Book>();
        /// var book = new Book 
        /// { 
        ///     Title = "Learning C#", 
        ///     Price = 29.99f, 
        ///     Isbn = "978-0123456789" 
        /// };
        /// 
        /// float discount = calculator.CalculateDiscount(book);
        /// Console.WriteLine($"Discount for {book.Title}: ${discount}");
        /// // Output: Discount for Learning C#: $29.99
        /// 
        /// // The beauty of generics: same method works for any Product-derived type
        /// var productCalc = new DiscountCalculator<Product>();
        /// var widget = new Product { Title = "Widget", Price = 15.50f };
        /// float widgetDiscount = productCalc.CalculateDiscount(widget); // Returns 15.50f
        /// </example>
        public float CalculateDiscount(TProduct product)
        {
            // Thanks to the constraint, we can safely access Product properties
            // without any casting or runtime type checking
            // 
            // The constraint guarantees that:
            // - product will never be null (reference type constraint implicit)
            // - product.Price is always available
            // - No InvalidCastException possible
            // - Full IntelliSense support for Product members
            
            return product.Price;
            
            // In a real implementation, this might be:
            // return product.Price * discountPercentage;
            // 
            // Or more complex calculations based on:
            // - Product type (using is/as operators)
            // - Price ranges
            // - Business rules
            // - Customer categories
        }
    }
    
    // Educational Notes:
    //
    // Benefits of Generic Constraint Approach vs Alternatives:
    //
    // 1. Without Generics (object parameter):
    //    public float CalculateDiscount(object product)
    //    {
    //        var p = (Product)product; // Runtime casting required
    //        return p.Price;           // Risk of InvalidCastException
    //    }
    //
    // 2. Without Generics (Product parameter):
    //    public float CalculateDiscount(Product product)
    //    {
    //        return product.Price;     // Works, but less flexible
    //    }
    //    // Limitation: can't create specialized versions for Book, etc.
    //
    // 3. With Generics + Constraint (current approach):
    //    public float CalculateDiscount(TProduct product) where TProduct : Product
    //    {
    //        return product.Price;     // Best of both worlds:
    //    }                            // - Type safety (compile-time)
    //                                 // - Flexibility (works with derived types)
    //                                 // - Performance (no casting)
    //                                 // - Specialization possible
}