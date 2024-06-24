# Utility Toolkit for Unity Game Development

Utility Toolkit is a C# library that provides algorithms 
and data structures to simplify common tasks.

## Table of Contents
- [Data Wrappers](#data-wrappers)
  - [Observable<T>](#observable)
  - [Option<T>](#option)
- [Data Structure Conversion Methods](#data-structure-conversion-methods)
- [Collection Extension Methods](#collection-extension-methods)
- [Short Hand For-Loops](#short-hand-for-loops)


## Data Wrappers

### Observable

The Observable<T> class is used for reactive programming, where
the change of a variable ripples down to affect many other components
of an application. A typical use case of the Observable<T> class
is binding a UI element to some state variable such that when
the variable changes, it is immediately reflected in the UI. The
benefit to using this class is that the variable or class holding
the variable no longer has to know about all the components that
depend on the variable.

```csharp
class Observable<T>
{
    public Observable(T initialValue = default);
    public T Value;
    public event Action<T> OnValueChanged;
}
```

#### Example usage

```csharp
var myVariable = new Observable<int>(10);
myVariable.OnValueChanged += (i) => Console.WriteLine(i);
myVariable.Value += 10;
```

This code will print out the new value to the console when it changes.

<br>

### Option

This struct is used to store or return optional values. The main purpose of
this is to avoid null-pointer exceptions by forcing the programmer to verify
that a value is really set.

```csharp
struct Option<T>
{
    public static Option<T> Some(T value);
    public static Option<T> None;
    public bool IsSome(out T value);
}
```

#### Example usage

An enemy may or may not contain loot for the player.

```csharp
class Enemy 
{ 
    Option<string> Loot = Option<string>.Some("Big Weapon");
    Option<string> LegendaryLoot = Option<string>.None;
}

// { ... } 

public void Loot(Enemy enemy)
{
    if (enemy.Loot.IsSome(out var loot) 
    {
        // place loot in bag
    }

    if (enemy.LegendaryLoot.IsSome(out var legendaryLoot) 
    {
        // place legendary loot in bag
    }
}
```

<br>

## Data Structure Conversion Methods

Convert from an IEnumerable to a Stack<T> or Queue<T>.  
Time complexity: O(N)

```csharp
Stack<T> ToStack<T>(this IEnumerable<T> enumerable);
Queue<T> ToQueue<T>(this IEnumerable<T> enumerable);
```


## Collection Extension Methods

Shuffle the order of an IList or IEnumerable.  
Time complexity: O(N)

```csharp
IList<T> Shuffle<T>(this IList<T> list);
IEnumerable<T> Shuffle<T>(this IEnumerable<T> enumerable);
```

Query a random element from an IEnumerable.  
Time complexity: O(1)

```csharp
T RandomElement<T>(this IList<T> list);
T RandomElement<T>(this T[] array);
```

Time complexity: O(N)

```csharp
T RandomElement<T>(this IEnumerable<T> enumerable);
```

When querying for the first element of a sequence, 
or the first element that satisfies some condition, 
it is not guaranteed that the sequence has any elements
or that any elements satisfy the condition. Use FirstOption
to return Option.Some element if an element is found, or 
Option.None if no element is found. This is preferable to 
FirstOrDefault when a default value is not useful. 

```csharp
Option<T> FirstOption<T>(this IEnumerable<T> enumerable);
Option<T> FirstOption<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate);
```

## Short Hand For-Loops

The only benefit to using these for-loop is
that they require less syntax, fewer lines of code and reduces
code nesting as compared to the usual C# for-loops. 
They are inspired by Python style for-loops.

```csharp
static class For
{
    static void Range(int i, Action action);
    static void Range(int i, Action<int> action);
    static void NestedRange(int i, int j, Action<int, int> action)
}
```

Write:    

```csharp
For.Range(10, MyMethod);
```

Instead of:

```csharp
for (int i = 0; i < 10; i++)
{
    MyMethod(i);
}
```

And write: 

```csharp
For.NestedRange(height, width, MyMethod);
```

Instead of:

```csharp
for (int i = 0; i < height; i++)
{
    for (int j = 0; j < width; j++)
    {
        MyMethod(i, j);
    }
}
```