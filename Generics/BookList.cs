using System;

namespace Generics
{
     /* Non-generic collection that ONLY works with Book objects.
     This demonstrates the limitations of non-generic collections:
     - Type-specific: only works with Book
     - Code duplication: need separate class for each type
     - Limited reusability
     Compare this with GenericList<T> below to see the benefits of generics. */
    public class BookList
    {
        /// <summary>
        /// Adds a Book to the collection. Notice this only accepts Book objects.
        /// </summary>
        /// <param name="book">The book to add</param>
        public void Add(Book book)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Indexer that returns a Book at the specified index.
        /// Notice the return type is specifically Book, not a generic type.
        /// </summary>
        /// <param name="index">The zero-based index</param>
        /// <returns>The Book at the specified index</returns>
        public Book this[int index]
        {
            get { throw new NotImplementedException(); }
        }
    }

    /// <summary>
    /// Generic dictionary with two type parameters.
    /// This demonstrates:
    /// - Multiple type parameters (TKey, TValue)
    /// - Meaningful parameter names (not just T)
    /// - Flexibility to store any key-value pair combination
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the dictionary</typeparam>
    /// <example>
    /// Usage examples:
    /// var stringToInt = new GenericDictionary<string, int>();  // Maps string to int
    /// var intToBook = new GenericDictionary<int, Book>();      // Maps int to Book
    /// var bookToPrice = new GenericDictionary<Book, decimal>();// Maps Book to decimal
    /// </example>
    public class GenericDictionary<TKey, TValue>
    {
        /// <summary>
        /// Adds a key-value pair to the dictionary.
        /// The beauty of generics: this single method works with any TKey and TValue combination.
        /// </summary>
        /// <param name="key">The key of type TKey</param>
        /// <param name="value">The value of type TValue</param>
        public void Add(TKey key, TValue value)
        {
            // Implementation would store the key-value pair
            // This demonstrates type safety: key must be TKey, value must be TValue
        }
    }

    /// <summary>
    /// Generic list that can store any type T.
    /// This demonstrates the power of generics:
    /// - Type safety: T is known at compile time
    /// - Reusability: one class works for all types
    /// - Performance: no boxing/unboxing for value types
    /// - IntelliSense: full type information available
    /// 
    /// Compare this with BookList above:
    /// - BookList: only works with Book objects
    /// - GenericList<T>: works with any type you specify
    /// </summary>
    /// 
    /// <typeparam name="T">The type of elements in the list </typeparam>
    /// 
    /// <example>
    /// var books = new GenericList<Book>();       // List of books
    /// var numbers = new GenericList<int>();      // List of integers  
    /// var names = new GenericList<string>();     // List of strings
    /// var products = new GenericList<Product>(); // List of products
    /// 
    /// // Type safety in action:
    /// books.Add(new Book());     // ? Correct: Book expected
    /// books.Add("not a book");   // ? Compile error: string not allowed
    /// numbers.Add(42);           // ? Correct: int expected
    /// numbers.Add(3.14);         // ? Compile error: double not allowed in int list
    /// </example>
    public class GenericList<T>
    {
        /// <summary>
        /// Adds an item of type T to the list.
        /// The compiler ensures only type T can be passed to this method.
        /// </summary>
        /// <param name="value">The value to add, must be of type T</param>
        public void Add(T value)
        {
            // Implementation would add the value to internal storage
            // The type T provides compile-time type safety
        }

        /// <summary>
        /// Indexer that returns an item of type T at the specified index.
        /// Notice how the return type is T, not object - this provides type safety.
        /// No casting required when retrieving items!
        /// </summary>
        /// 
        /// <param name="index">The zero-based index</param>
        /// <returns> The item of type T at the specified index </returns>
        /// 
        /// <example>
        /// var books = new GenericList<Book>();
        /// books.Add(new Book { Title = "C# Programming" });
        /// Book book = books[0];  // No casting needed! Type is known to be Book
        /// 
        /// // Compare with non-generic approach:
        /// // object obj = nonGenericList[0];
        /// // Book book = (Book)obj;  // Casting REQUIRED, runtime error possible
        /// </example>
        public T this[int index]
        {
            get { throw new NotImplementedException(); }
        }
    }
}