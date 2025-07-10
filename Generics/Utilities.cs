using System;

namespace Generics
{
    /// <summary>
    /// Generic utility class demonstrating multiple constraints.
    /// This class shows how to combine different constraints on a single type parameter.
    /// 
    /// Constraints Applied:
    /// - where T : IComparable  -> T must implement IComparable interface
    /// - where T : new()        -> T must have a parameterless constructor
    /// 
    /// This combination allows the class to:
    /// 1. Compare instances of T (using IComparable.CompareTo)
    /// 2. Create new instances of T (using new T())
    /// 
    /// Multiple constraints are separated by commas and all must be satisfied.
    /// </summary>
    /// <typeparam name="T">Type that must implement IComparable and have a parameterless constructor</typeparam>
    /// <example>
    /// Valid usage examples:
    /// var intUtilities = new Utilities&lt;int&gt;();        // int implements IComparable and has default constructor
    /// var stringUtilities = new Utilities&lt;string&gt;();  // string implements IComparable and has parameterless constructor
    /// var dateUtilities = new Utilities&lt;DateTime&gt;(); // DateTime implements IComparable and has default constructor
    /// 
    /// Invalid usage (won't compile):
    /// // var objectUtilities = new Utilities&lt;object&gt;(); // object doesn't implement IComparable
    /// 
    /// Usage of methods:
    /// var intUtils = new Utilities&lt;int&gt;();
    /// int max = intUtils.Max(5, 10);                 // Returns 10
    /// intUtils.DoSomething(42);                      // Creates new int instance
    /// </example>
    public class Utilities<T> where T : IComparable, new()
    {
        /// <summary>
        /// Non-generic Max method for integers.
        /// This method is included to contrast with the generic Max method below.
        /// Notice how this only works with int types, limiting reusability.
        /// </summary>
        /// <param name="a">First integer to compare</param>
        /// <param name="b">Second integer to compare</param>
        /// <returns>The larger of the two integers</returns>
        public int Max(int a, int b)
        {
            return a > b ? a : b;
        }

        /// <summary>
        /// Demonstrates the constructor constraint (new()).
        /// The new() constraint allows us to create instances of type T,
        /// which is useful for factory patterns, initialization, and object creation scenarios.
        /// </summary>
        /// <param name="value">A parameter of type T (demonstrates type usage)</param>
        /// <example>
        /// var utils = new Utilities&lt;DateTime&gt;();
        /// utils.DoSomething(DateTime.Now);  // Creates a new DateTime instance internally
        /// 
        /// var stringUtils = new Utilities&lt;string&gt;();
        /// stringUtils.DoSomething("hello"); // Creates a new string instance internally
        /// </example>
        public void DoSomething(T value)
        {
            // The new() constraint guarantees that T has a parameterless constructor
            // This allows us to create new instances of T without knowing the specific type
            var obj = new T();
            
            // Real-world uses for this pattern:
            // - Factory methods that create default instances
            // - Resetting objects to default state
            // - Creating containers or collections of T
            // - Dependency injection scenarios
        }

        /// <summary>
        /// Generic Max method that works with any type T that implements IComparable.
        /// This demonstrates the power of interface constraints - we can call methods
        /// defined in the interface on our generic type parameter.
        /// 
        /// The IComparable constraint guarantees that T has a CompareTo method,
        /// allowing us to compare instances safely at compile time.
        /// </summary>
        /// <param name="a">First value of type T to compare</param>
        /// <param name="b">Second value of type T to compare</param>
        /// <returns>The larger of the two values based on their CompareTo implementation</returns>
        /// <example>
        /// var utils = new Utilities&lt;int&gt;();
        /// int maxInt = utils.Max(5, 10);              // Returns 10
        /// 
        /// var stringUtils = new Utilities&lt;string&gt;();
        /// string maxString = stringUtils.Max("apple", "banana"); // Returns "banana" (alphabetically later)
        /// 
        /// var dateUtils = new Utilities&lt;DateTime&gt;();
        /// DateTime maxDate = dateUtils.Max(DateTime.Today, DateTime.Now); // Returns the later date
        /// 
        /// How CompareTo works:
        /// - Returns negative value if 'a' is less than 'b'
        /// - Returns zero if 'a' equals 'b'  
        /// - Returns positive value if 'a' is greater than 'b'
        /// </example>
        public T Max(T a, T b)
        {
            // We can safely call CompareTo because of the IComparable constraint
            // CompareTo returns > 0 when a is greater than b
            return a.CompareTo(b) > 0 ? a : b;
        }
    }
    
    // Additional educational notes:
    //
    // Constraint Order Matters:
    // The order of constraints follows this pattern:
    // 1. Base class constraint (where T : BaseClass)
    // 2. Interface constraints (where T : IInterface1, IInterface2)  
    // 3. struct or class constraint (where T : struct OR where T : class)
    // 4. new() constraint (where T : new()) - must be last
    //
    // Example of all constraint types:
    // public class Example<T> where T : BaseClass, IComparable, IDisposable, new()
    //
    // Benefits of Multiple Constraints:
    // - More specific type requirements
    // - Access to multiple interfaces/base class members
    // - Compile-time safety guarantees
    // - Better IntelliSense support
    //
    // Trade-offs:
    // - More constraints = fewer types can be used
    // - Balance specificity with reusability
    // - Only add constraints you actually need
}