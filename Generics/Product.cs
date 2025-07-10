namespace Generics
{
    /// <summary>
    /// Base product class used to demonstrate class constraints in generics.
    /// This class serves as a base type for generic constraint examples.
    /// 
    /// In generic constraints, this class demonstrates:
    /// - where T : Product (T must be Product or inherit from Product)
    /// - Allows access to Product properties in generic methods
    /// - Enables polymorphic behavior with generics
    /// </summary>
    /// <example>
    /// Usage in generic constraints:
    /// public class Calculator&lt;T&gt; where T : Product
    /// {
    ///     public decimal CalculateDiscount(T product)
    ///     {
    ///         return product.Price * 0.1m; // Can access Price because T : Product
    ///     }
    /// }
    /// </example>
    public class Product
    {
        /// <summary>
        /// Gets or sets the title of the product.
        /// Demonstrates a string property accessible through generic constraints.
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// Gets or sets the price of the product.
        /// This property is commonly used in generic constraint examples
        /// to show how constrained generic types can access base class members.
        /// </summary>
        public float Price { get; set; }
    }
}