# C# Generics - Complete Learning Guide

## Table of Contents
1. [Introduction to Generics](#introduction-to-generics)
2. [Why Use Generics?](#why-use-generics)
3. [Generic Constraints](#generic-constraints)
4. [Generic Collections](#generic-collections)
5. [Custom Generic Types](#custom-generic-types)
6. [Advanced Examples](#advanced-examples)
7. [Best Practices](#best-practices)

## Introduction to Generics

Generics in C# allow you to define classes, interfaces, and methods with placeholder types (type parameters). These type parameters are specified when the generic type is instantiated or the generic method is called.

### Basic Syntax
```csharp
// Generic method
public T MethodName<T>(T parameter) { }

// Generic class
public class ClassName<T> { }

// Generic interface
public interface InterfaceName<T> { }
```

## Why Use Generics?

### 1. Type Safety
Without generics, you might use `object` type which loses compile-time type checking:

```csharp
// Non-generic approach (from List.cs)
public class List
{
    public void Add(int number) { } // Only works with integers
    public int this[int index] { get; } // Only returns integers
}
```

With generics, you get compile-time type safety:

```csharp
// Generic approach (from BookList.cs)
public class GenericList<T>
{
    public void Add(T value) { } // Works with any type T
    public T this[int index] { get; } // Returns type T
}
```

### 2. Performance
- No boxing/unboxing for value types
- No runtime type casting
- Better memory usage

### 3. Code Reusability
One generic class can work with multiple types instead of creating separate classes for each type.

## Generic Constraints

Constraints limit the types that can be used as type arguments. Your project demonstrates all major constraint types:

### 1. Interface Constraint (`where T : IInterface`)

**Example from Sample.cs:**
```csharp
// Constraint to an interface
static T Max<T>(T a, T b) where T : IComparable
{
    return a.CompareTo(b) > 0 ? a : b; // Can use IComparable methods
}
```

**What this means:**
- `T` must implement `IComparable` interface
- You can call `CompareTo()` method on parameters of type `T`
- Provides compile-time guarantee that the type supports comparison

**Usage:**
```csharp
int maxInt = Max(5, 10);        // Works - int implements IComparable
string maxStr = Max("a", "b");  // Works - string implements IComparable
// Max(new object(), new object()); // Won't compile - object doesn't implement IComparable
```

### 2. Class Constraint (`where T : BaseClass`)

**Example from Sample.cs:**
```csharp
// Constraint to a class
static float CalculateDiscount<TProduct>(TProduct product) where TProduct : Product
{
    // Can access Product properties like Price
    return product.Price * 0.1f; // 10% discount
}
```

**What this means:**
- `TProduct` must be `Product` or inherit from `Product`
- You can access all `Product` properties and methods
- Ensures type safety while allowing polymorphism

**Usage:**
```csharp
Product product = new Product { Price = 100 };
Book book = new Book { Price = 25, Isbn = "123" };

float discount1 = CalculateDiscount(product); // Works
float discount2 = CalculateDiscount(book);    // Works - Book inherits from Product
// CalculateDiscount("string");               // Won't compile
```

### 3. Value Type Constraint (`where T : struct`)

**Example from Nullable.cs:**
```csharp
public class Nullable<T> where T : struct
{
    private object _value;
    
    public Nullable(T value)
    {
        _value = value; // T is guaranteed to be a value type
    }
    
    public T GetValueOrDefault()
    {
        if (HasValue)
            return (T)_value;
        return default(T); // default(T) works for value types
    }
}
```

**What this means:**
- `T` must be a value type (int, double, struct, enum, etc.)
- Cannot be a reference type (string, class instances, etc.)
- Allows use of `default(T)` which gives meaningful default values

**Usage:**
```csharp
var nullableInt = new Nullable<int>(42);     // Works
var nullableBool = new Nullable<bool>(true); // Works
// var nullableString = new Nullable<string>("test"); // Won't compile
```

### 4. Reference Type Constraint (`where T : class`)

```csharp
public class Repository<T> where T : class
{
    public void Save(T entity)
    {
        if (entity == null) // Can check for null since T is reference type
            throw new ArgumentNullException();
    }
}
```

### 5. Constructor Constraint (`where T : new()`)

**Example from Sample.cs and Utilities.cs:**
```csharp
static void DoSomething<T>(T value) where T : new()
{
    var obj = new T(); // Can create new instance of T
}
```

**What this means:**
- `T` must have a parameterless constructor
- Allows you to create new instances of `T`

### 6. Multiple Constraints

**Example from Utilities.cs:**
```csharp
public class Utilities<T> where T : IComparable, new()
{
    public T Max(T a, T b)
    {
        return a.CompareTo(b) > 0 ? a : b; // Uses IComparable
    }
    
    public void DoSomething(T value)
    {
        var obj = new T(); // Uses new() constraint
    }
}
```

## Generic Collections

Your project shows the evolution from specific to generic collections:

### Non-Generic Collection (BookList.cs)
```csharp
public class BookList
{
    public void Add(Book book) { } // Only works with Book
    public Book this[int index] { get; } // Only returns Book
}
```

**Problems:**
- Only works with one type
- Need separate class for each type
- Code duplication

### Generic Collection (BookList.cs)
```csharp
public class GenericList<T>
{
    public void Add(T value) { } // Works with any type
    public T this[int index] { get; } // Returns the same type
}

public class GenericDictionary<TKey, TValue>
{
    public void Add(TKey key, TValue value) { } // Two type parameters
}
```

**Benefits:**
- One class works with all types
- Type safety maintained
- No code duplication

**Usage:**
```csharp
var bookList = new GenericList<Book>();
var intList = new GenericList<int>();
var stringToIntDict = new GenericDictionary<string, int>();
```

## Custom Generic Types

### Custom Nullable Implementation

Your project includes a custom `Nullable<T>` implementation that demonstrates several key concepts:

```csharp
public class Nullable<T> where T : struct
{
    private object _value; // Stores the value as object
    
    public Nullable() { } // Default constructor - value is null
    
    public Nullable(T value)
    {
        _value = value; // Boxing occurs here (value type ? object)
    }
    
    public bool HasValue
    {
        get { return _value != null; }
    }
    
    public T GetValueOrDefault()
    {
        if (HasValue)
            return (T)_value; // Unboxing occurs here (object ? value type)
        
        return default(T); // Returns default value for type T
    }
}
```

**Key Concepts Demonstrated:**
1. **Boxing/Unboxing**: Value types are boxed when stored as `object`, unboxed when retrieved
2. **Default Values**: `default(T)` returns appropriate default (0 for int, false for bool, etc.)
3. **Null Checking**: Can check if boxed value type is null
4. **Type Safety**: Constraint ensures only value types can be used

## Program.cs - Putting It All Together

```csharp
static void Main(string[] args)
{
    var number = new Nullable<int>(); // Create nullable int without value
    Console.WriteLine("Has Value ?" + number.HasValue); // False
    Console.WriteLine("Value: " + number.GetValueOrDefault()); // 0 (default for int)
}
```

## Visual Representation

```
???????????????????????????????????????
?           Generic Type              ?
?  ????????????????????????????????????
?  ?     Type Parameter <T>          ??
?  ?                                 ??
?  ?  ??????????? ?????????????????????
?  ?  ? Methods ? ?   Properties    ???
?  ?  ?         ? ?                 ???
?  ?  ? Add(T)  ? ? T this[index]   ???
?  ?  ??????????? ?????????????????????
?  ????????????????????????????????????
???????????????????????????????????????
         ?
         ? Instantiation
         ?
???????????????????????????????????????
?        Concrete Type                ?
?  ????????????????????????????????????
?  ?    GenericList<string>          ??
?  ?                                 ??
?  ?  ??????????? ?????????????????????
?  ?  ? Methods ? ?   Properties    ???
?  ?  ?         ? ?                 ???
?  ?  ?Add(str) ? ?string this[i]   ???
?  ?  ??????????? ?????????????????????
?  ????????????????????????????????????
???????????????????????????????????????
```

## Best Practices

1. **Use Meaningful Names**: `TKey`, `TValue` instead of just `T`
2. **Apply Appropriate Constraints**: Only add constraints you actually need
3. **Prefer Generic Collections**: Use `List<T>` instead of `ArrayList`
4. **Consider Performance**: Generics eliminate boxing for value types
5. **Use `default(T)`**: For getting default values in generic code

## Common Pitfalls

1. **Forgetting Constraints**: If you need to call methods on `T`, add appropriate constraints
2. **Boxing in Generic Code**: Be careful when using `object` with value types
3. **Null Reference with Value Types**: Remember value types can't be null (unless nullable)

## Advanced Topics for Further Study

1. **Covariance and Contravariance** (`in` and `out` keywords)
2. **Generic Delegates** (`Func<T>`, `Action<T>`)
3. **Generic Attributes**
4. **Reflection with Generics**

This project provides an excellent foundation for understanding generics in C#. Each file demonstrates different aspects of generic programming, from basic type parameters to complex constraints and custom implementations.