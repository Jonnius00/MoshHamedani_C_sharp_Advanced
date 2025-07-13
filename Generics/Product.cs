namespace Generics
{
    /// <summary>
    /// BASE CLASS Product used to demonstrate CLASS CONSTRAINTS in generics.
    /// Serves as a base type for generic constraint examples.
    /// 
    /// In generic constraints, this class demonstrates:
    /// - where T : Product (T must be Product or inherit from Product)
    /// - Allows access to Product properties in generic methods
    /// - Enables polymorphic behavior with generics
    /// </summary>
    /// 
    /// <example>
    /// Usage in generic constraints:
    /// public class Calculator<T> where T : Product
    /// {
    ///     public decimal CalculateDiscount(T product)
    ///     {
    ///         return product.Price * 0.1m; 
    ///         // Can access Price because T : Product
    ///     }
    /// }
    /// </example>
    public class Product
    {
        public string Title { get; set; }
        
        public float Price { get; set; }
    }
}