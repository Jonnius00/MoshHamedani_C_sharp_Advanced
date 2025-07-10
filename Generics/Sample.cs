using System;

namespace Generics
{
    /// <summary>
    /// This class demonstrates various generic concepts and constraints in C#.
    /// It shows how generics provide type safety, code reusability, and performance benefits.
    /// </summary>
    class Sample
    {
        /// <summary>
        /// Traditional non-generic method that only works with integers.
        /// This is type-safe but not reusable for other types.
        /// </summary>
        /// <param name="a">First integer to compare</param>
        /// <param name="b">Second integer to compare</param>
        /// <returns>The larger of the two integers</returns>
        static int Max(int a, int b)
        {
            return a > b ? a : b;
        }

        // Generic Constraints Reference:
        // where T : IComparable    - T must implement IComparable interface
        // where T : Product        - T must be Product class or inherit from it
        // where T : struct         - T must be a value type (int, double, custom struct, etc.)
        // where T : class          - T must be a reference type (string, object, custom class, etc.)
        // where T : new()          - T must have a parameterless constructor

        /// <summary>
        /// Generic method with interface constraint.
        /// The 'where T : IComparable' constraint ensures that type T implements IComparable,
        /// allowing us to call the CompareTo method safely.
        /// </summary>
        /// <typeparam name="T">Type parameter that must implement IComparable</typeparam>
        /// <param name="a">First value to compare</param>
        /// <param name="b">Second value to compare</param>
        /// <returns>The larger of the two values</returns>
        /// <example>
        /// Usage examples:
        /// int maxInt = Max(5, 10);        // Returns 10
        /// string maxStr = Max("apple", "banana"); // Returns "banana" (alphabetically later)
        /// DateTime maxDate = Max(DateTime.Now, DateTime.Today); // Works with any IComparable type
        /// </example>
        static T Max<T>(T a, T b) where T : IComparable
        {
            // CompareTo returns: negative if a < b, zero if a == b, positive if a > b
            return a.CompareTo(b) > 0 ? a : b;
        }

        /// <summary>
        /// Generic method with class constraint.
        /// The 'where TProduct : Product' constraint ensures TProduct is Product or inherits from Product,
        /// allowing access to Product properties like Price.
        /// </summary>
        /// <typeparam name="TProduct">Type parameter that must be or inherit from Product</typeparam>
        /// <param name="product">Product instance to calculate discount for</param>
        /// <returns>Discount amount (currently returns 0 - placeholder implementation)</returns>
        /// <example>
        /// Usage examples:
        /// Product product = new Product { Price = 100 };
        /// Book book = new Book { Price = 50, Isbn = "123" };
        /// float discount1 = CalculateDiscount(product); // Works with Product
        /// float discount2 = CalculateDiscount(book);    // Works with Book (inherits from Product)
        /// </example>
        static float CalculateDiscount<TProduct>(TProduct product) where TProduct : Product
        {
            // With the constraint, we can safely access Product properties
            // Uncommented line below shows we have access to product.Price
            //return product.Price * 0.1f; // 10% discount
            return 0; // Placeholder implementation
        }

        /// <summary>
        /// Generic struct with value type constraint.
        /// The 'where T : struct' constraint ensures T is a value type,
        /// making this suitable for creating nullable value types.
        /// This is similar to System.Nullable&lt;T&gt; but implemented as a learning example.
        /// </summary>
        /// <typeparam name="T">Value type parameter</typeparam>
        struct Nullable<T> where T : struct
        {
            /// <summary>
            /// Internal storage using object to allow null representation.
            /// Value types are boxed when stored as object, unboxed when retrieved.
            /// </summary>
            private object _value;

            /// <summary>
            /// Constructor that creates a Nullable with a specific value.
            /// The ': this()' calls the default constructor first.
            /// </summary>
            /// <param name="value">The value to store</param>
            public Nullable(T value)
                : this()
            {
                _value = value; // Boxing: value type T is converted to object
            }

            /// <summary>
            /// Gets a value indicating whether the Nullable has a value.
            /// Since value types can't normally be null, we check if the boxed object is null.
            /// </summary>
            public bool HasValue
            {
                get { return _value != null; }
            }

            /// <summary>
            /// Gets the value if present, otherwise returns the default value for type T.
            /// Demonstrates unboxing and use of default(T) for generic types.
            /// </summary>
            /// <returns>The stored value or default(T)</returns>
            public T GetValueOrDefault()
            {
                if (HasValue)
                    return (T)_value; // Unboxing: object is cast back to value type T

                // default(T) returns:
                // - 0 for numeric types (int, double, etc.)
                // - false for bool
                // - DateTime.MinValue for DateTime
                // - All fields set to their defaults for custom structs
                return default(T);
            }
        }

        /// <summary>
        /// Generic method with constructor constraint.
        /// The 'where T : new()' constraint ensures T has a parameterless constructor,
        /// allowing us to create new instances using 'new T()'.
        /// </summary>
        /// <typeparam name="T">Type that must have a parameterless constructor</typeparam>
        /// <param name="value">Parameter of type T (not used in this example)</param>
        /// <example>
        /// Usage examples:
        /// DoSomething(new Product());  // Works - Product has parameterless constructor
        /// DoSomething("hello");        // Works - string has parameterless constructor
        /// DoSomething(42);             // Works - int has default constructor
        /// </example>
        static void DoSomething<T>(T value) where T : new()
        {
            // We can create a new instance of T because of the new() constraint
            var obj = new T();
            
            // This is useful for:
            // - Factory patterns
            // - Creating default instances
            // - Initialization scenarios
        }
    }
}