namespace Generics
{
    /// <summary>
    /// Custom implementation of a nullable value type wrapper.
    /// This class demonstrates several important generic concepts:
    /// 
    /// 1. Value Type Constraint (where T : struct):
    ///    - Ensures T can only be value types (int, double, bool, DateTime, custom structs)
    ///    - Prevents reference types (string, object, classes) from being used
    ///    - Enables meaningful use of default(T)
    /// 
    /// 2. Boxing and Unboxing:
    ///    - Value types are "boxed" when stored as object
    ///    - "Unboxed" when cast back to the value type
    ///    - Allows null representation for value types
    /// 
    /// 3. Generic Type Safetymo:
    ///    - Compile-time guarantee that only compatible types are used
    ///    - No runtime type checking needed
    /// 
    /// This is similar to System.Nullable<T> but serves as an educational example.
    /// </summary>
    /// 
    /// <typeparam name="T">Must be a value type (struct constraint)</typeparam>
    /// 
    /// <example>
    /// Usage examples:
    /// 
    /// // Creating nullable values
    /// var nullableInt = new Nullable<int>();       // No value (null state)
    /// var valueInt = new Nullable<int>(42);        // Has value: 42
    /// var nullableBool = new Nullable<bool>(true); // Has value: true
    /// var nullableDate = new Nullable<DateTime>(); // No value (null state)
    /// 
    /// // Checking for values
    /// if (valueInt.HasValue)
    /// {
    ///     int actualValue = valueInt.GetValueOrDefault(); // Returns 42
    /// }
    /// 
    /// int defaultValue = nullableInt.GetValueOrDefault(); // Returns 0 (default for int)
    /// 
    /// // This won't compile due to struct constraint:
    /// // var nullableString = new Nullable<string>("test"); // Error: string is reference type
    /// </example>
    public class Nullable<T> where T : struct
    {
        /// <summary>
        /// Internal storage for the value.
        /// Uses object type to enable null representation for value types.
        /// 
        /// Key Concept - Boxing:
        /// When a value type (like int, bool, DateTime) is assigned to an object variable,
        /// it gets "boxed" - wrapped in an object on the heap.
        /// This allows value types to be treated as reference types and enables null checking.
        /// </summary>
        private object _value;

        /// <summary>
        /// Default constructor creates a Nullable with no value (null state).
        /// _value remains null, indicating no value is present.
        /// </summary>
        /// <example>
        /// var empty = new Nullable<int>();
        /// Console.WriteLine(empty.HasValue);           // Output: False
        /// Console.WriteLine(empty.GetValueOrDefault()); // Output: 0
        /// </example>
        public Nullable()
        {
            // _value is implicitly null (default for reference types)
            // This represents the "no value" state
        }

        /// <summary>
        /// Constructor that creates a Nullable with a specific value.
        /// The value gets boxed (converted from value type to object).
        /// </summary>
        /// <param name="value">The value to store</param>
        /// <example>
        /// var withValue = new Nullable<int>(100);
        /// Console.WriteLine(withValue.HasValue);           // Output: True
        /// Console.WriteLine(withValue.GetValueOrDefault()); // Output: 100
        /// </example>
        public Nullable(T value)
        {
            // Boxing occurs here: VALUE type T is converted to OBJECT
            // For example: int 42 becomes a boxed object containing 42
            _value = value;
        }

        /// <summary>
        /// Gets a value indicating whether this Nullable contains a value.
        /// 
        /// Key Concept:
        /// Since value types normally can't be null, we use the boxed object's
        /// null state to represent "no value" for the value type.
        /// </summary>
        /// <returns>true if a value is present; false if no value (null state)</returns>
        /// <example>
        /// var empty = new Nullable<int>();
        /// var withValue = new Nullable<int>(42);
        /// 
        /// Console.WriteLine(empty.HasValue);     // Output: False
        /// Console.WriteLine(withValue.HasValue); // Output: True
        /// </example>
        public bool HasValue
        {
            get { return _value != null; }
        }

        /// <summary>
        /// Gets the value if present, otherwise returns the default value for type T.
        /// 
        /// Key Concepts Demonstrated:
        /// 
        /// 1. Unboxing: Converting the object back to the value type T
        /// 2. default(T): Generic way to get the default value for any type
        ///    - For int: 0
        ///    - For bool: false  
        ///    - For DateTime: DateTime.MinValue (January 1, 0001)
        ///    - For custom structs: all fields set to their defaults
        /// </summary>
        /// <returns>The stored value if HasValue is true; otherwise default(T)</returns>
        /// <example>
        /// var empty = new Nullable<int>();
        /// var withValue = new Nullable<int>(42);
        /// var emptyBool = new Nullable<bool>();
        /// var withBool = new Nullable<bool>(true);
        /// 
        /// Console.WriteLine(empty.GetValueOrDefault());     // Output: 0 (default for int)
        /// Console.WriteLine(withValue.GetValueOrDefault()); // Output: 42
        /// Console.WriteLine(emptyBool.GetValueOrDefault()); // Output: False (default for bool)
        /// Console.WriteLine(withBool.GetValueOrDefault());  // Output: True
        /// </example>
        public T GetValueOrDefault()
        {
            if (HasValue)
            // Unboxing occurs here: object is cast back to value type T
            // This is safe because we know _value contains a boxed T
                return (T)_value;

            // default(T) is a generic way to get the "zero" value for T
            // It works for any value type and returns appropriate defaults
            return default(T);
        }
    }
}