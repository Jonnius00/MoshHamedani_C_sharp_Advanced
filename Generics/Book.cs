namespace Generics
{
    /// <summary>
    /// Book class that inherits from Product.
    /// Key concepts demonstrated:
    /// - Inheritance: Book IS-A Product
    /// - Generic constraint compatibility: Can be used where T : Product is required
    /// - Polymorphism: Book can be treated as Product in generic contexts
    /// 
    /// Class shows that generic constraints work with inheritance hierarchies,
    /// allowing DERIVED types to be used wherever the BASE type constraint is specified.
    /// </summary>
    /// 
    /// <example>
    /// Generic constraint usage:
    /// public void ProcessProduct<T>(T product) where T : Product
    /// {
    ///     // Both of these calls work:
    ///     ProcessProduct(new Product { Title = "Generic Product", Price = 10 });
    ///     ProcessProduct(new Book { Title = "C# Book", Price = 25, Isbn = "123" });
    ///     
    ///     // Book can be used because it inherits from Product
    /// }
    /// </example>
    public class Book : Product
    {
        // Gets or sets the ISBN (International Standard Book Number) of the book.
        public string Isbn { get; set; }
    }
}