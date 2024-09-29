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

### Observable\<T\>

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

### Option \<T\>

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
## Countdown Timer
The CountdownTimer class is a lightweight object for managing time. 
It has a number of read-only properties as well as a method to reset the timer.

```csharp
class CountdownTimer
{
    // Constructor
    public CountdownTimer(float secondsToFinish);
    
    // Public Properties
    public bool IsFinished => { ... }
    public float FractionDone => { ... }
    public float SecondsPassed => { ... }
    public float SecondsLeft => { ... }
    public float TimeOfCompletion => { ... }
    
    // Methods
    public void Reset();
}
```

## IEnumerable to Stack

Convert from an IEnumerable to a Stack<T>.  
Time complexity: O(N)

```csharp
Stack<T> ToStack<T>(this IEnumerable<T> enumerable);
```

Convert from an IEnumerable to a Queue<T>.  
Time complexity: O(N)
## IEnumerable to Queue
```csharp
Queue<T> ToQueue<T>(this IEnumerable<T> enumerable);
```

## Get Enum Values
This method returns all values an enum may evaluate to.
```csharp
public static T[] GetValues<T>() where T : Enum
```

## Random Element

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

## Set Alpha
Change the alpha value of a Color instance.
```csharp
public static Color SetAlpha(this Color color, float alpha);
```


## First Option

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