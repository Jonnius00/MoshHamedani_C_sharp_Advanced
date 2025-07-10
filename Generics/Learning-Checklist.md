# C# Generics - Learning Checklist

## ?? Study Resources Created
- [x] README.md - Comprehensive text guide
- [x] Generics-Visual-Guide.html - Interactive visual guide
- [x] Enhanced code files with detailed comments
- [x] Program.cs with practical demonstrations

## ?? Recommended Study Order
1. Read README.md for comprehensive overview
2. Open Generics-Visual-Guide.html in browser for visual learning
3. Study enhanced code files in this order:
   - Product.cs & Book.cs (inheritance foundation)
   - BookList.cs (generic vs non-generic comparison)
   - Sample.cs (all constraint types)
   - Nullable.cs (boxing/unboxing concepts)
   - DiscountCalculator.cs (practical constraint usage)
   - Utilities.cs (multiple constraints)
   - Program.cs (everything in action)
4. Run the program and trace through execution
5. Complete hands-on exercises
6. Check off mastery concepts

---

## ?? Basic Concepts
- [ ] Understand what generics are and why they're useful
- [ ] Know the difference between generic and non-generic code
- [ ] Understand type parameters (`<T>`, `<TKey, TValue>`)
- [ ] Recognize generic syntax in classes, methods, and interfaces

## ?? Generic Constraints
- [ ] **Interface Constraint** (`where T : IComparable`)
  - [ ] Understand when to use interface constraints
  - [ ] Know how to call interface methods on constrained types
  - [ ] Practice with IComparable, IDisposable, IEnumerable examples

- [ ] **Class Constraint** (`where T : Product`)
  - [ ] Understand inheritance with generic constraints
  - [ ] Know how to access base class properties/methods
  - [ ] Practice with polymorphism in generic contexts

- [ ] **Value Type Constraint** (`where T : struct`)
  - [ ] Understand difference between value and reference types
  - [ ] Know when to use struct constraint
  - [ ] Understand `default(T)` behavior with value types

- [ ] **Reference Type Constraint** (`where T : class`)
  - [ ] Understand when to use class constraint
  - [ ] Know null-checking implications
  - [ ] Practice with reference type scenarios

- [ ] **Constructor Constraint** (`where T : new()`)
  - [ ] Understand parameterless constructor requirement
  - [ ] Know how to create instances with `new T()`
  - [ ] Practice factory pattern implementations

- [ ] **Multiple Constraints** (`where T : IComparable, new()`)
  - [ ] Understand constraint combination rules
  - [ ] Know the correct order of constraints
  - [ ] Practice combining different constraint types

## ?? Boxing and Unboxing
- [ ] Understand what boxing means (value type ? object)
- [ ] Understand what unboxing means (object ? value type)
- [ ] Know when boxing/unboxing occurs
- [ ] Understand performance implications
- [ ] See how Nullable<T> demonstrates these concepts

## ??? Generic Collections
- [ ] Compare BookList vs GenericList<T>
- [ ] Understand type safety benefits
- [ ] Know how to use GenericDictionary<TKey, TValue>
- [ ] Practice creating custom generic collections

## ??? Practical Applications
- [ ] Run and understand the Program.cs demonstrations
- [ ] Trace through Nullable<T> implementation
- [ ] Understand DiscountCalculator<T> constraint usage
- [ ] Explore Utilities<T> multiple constraints

## ?? Hands-On Exercises

### Beginner Level
- [ ] Create a generic Stack<T> class
- [ ] Implement a generic Queue<T> class
- [ ] Write a generic SwapValues<T> method

### Intermediate Level
- [ ] Create a generic Repository<T> with class constraint
- [ ] Implement a generic Calculator<T> with IComparable constraint
- [ ] Build a generic Factory<T> with new() constraint

### Advanced Level
- [ ] Combine multiple constraints in a single class
- [ ] Create nested generic types
- [ ] Implement generic extension methods

## ?? Concept Mastery Checks

### Type Safety
- [ ] Can explain why `List<int>` is better than `ArrayList`
- [ ] Understand compile-time vs runtime type checking
- [ ] Know how generics prevent `InvalidCastException`

### Performance
- [ ] Can explain boxing/unboxing performance impact
- [ ] Understand memory allocation differences
- [ ] Know when generics provide performance benefits

### Code Reusability
- [ ] Can convert non-generic code to generic
- [ ] Understand DRY principle application
- [ ] Know when to use generics vs regular classes

## ?? Further Learning
- [ ] Study System.Collections.Generic namespace
- [ ] Learn about covariance and contravariance (`in`, `out`)
- [ ] Explore generic delegates (Func<T>, Action<T>)
- [ ] Investigate LINQ and generic extension methods
- [ ] Practice with reflection and generic types

## ?? Project Understanding
- [ ] Can explain every line in Sample.cs
- [ ] Understand the evolution from BookList to GenericList<T>
- [ ] Know how Product/Book inheritance works with constraints
- [ ] Can trace through Nullable<T> boxing/unboxing
- [ ] Understand DiscountCalculator<T> constraint benefits

## ? Completion Goals
- [ ] Can write generic classes with appropriate constraints
- [ ] Can explain generics benefits to another developer
- [ ] Can debug generic-related compile errors
- [ ] Can choose between generic and non-generic approaches
- [ ] Can design reusable generic components

**Good luck with your C# Generics journey! ??**