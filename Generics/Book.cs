namespace Generics
{
    /// <summary>
    /// Book class that inherits from Product.
    /// This class demonstrates inheritance in the context of generic constraints.
    /// 
    /// Key concepts demonstrated:
    /// - Inheritance: Book IS-A Product
    /// - Generic constraint compatibility: Can be used where T : Product is required
    /// - Polymorphism: Can be treated as Product in generic contexts
    /// 
    /// This class shows that generic constraints work with inheritance hierarchies,
    /// allowing derived types to be used wherever the base type constraint is specified.
    /// </summary>
    /// <example>
    /// Generic constraint usage:
    /// public void ProcessProduct&lt;T&gt;(T product) where T : Product
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
        /// <summary>
        /// Gets or sets the ISBN (International Standard Book Number) of the book.
        /// This property is specific to Book and demonstrates how derived classes
        /// can have additional properties while still satisfying base class constraints.
        /// 
        /// In generic contexts with Product constraints, this property shows that:
        /// - The generic method can treat Book as Product (accessing Title, Price)
        /// - Additional Book-specific properties are available when casting is used
        /// - Type safety is maintained throughout the inheritance hierarchy
        /// </summary>
        public string Isbn { get; set; }
    }
}