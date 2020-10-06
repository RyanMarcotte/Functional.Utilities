# `Functional.Unions.FluentAssertions`

This library extends [FluentAssertions](https://fluentassertions.com/) to provide assertion clauses for types defined by the [`Functional.Unions`](https://github.com/JohannesMoersch/Functional) NuGet package: `IUnionValue<TUnionDefinition>`.

## `IUnionValue<TUnionDefinition>`

### `BeOfType{One, Two, Three, Four, Five, Six, Seven, Eight}`

``` csharp
public class MyDefinition : UnionDefinition<MyDefinition, string, int, bool> { }
var definedUnion = Union.FromDefinition<MyDefinition>().Create(1337);
var typeUnion = Union.FromTypes<string, int, bool>().Create(1337);

// verify that union value is of a particular type
definedUnion.Value().Should().BeOfTypeTwo();
typeUnion.Value().Should().BeOfTypeTwo();

// verify that union value is of a particular type and matches some condition(s)
definedUnion.Value().Should().BeOfTypeTwo().AndValue.Should().Be(1337);
typeUnion.Value().Should().BeOfTypeTwo().AndValue.Should().Be(1337);
definedUnion.Value().Should().BeOfTypeTwo().AndValue.Should().BeGreaterOrEqualTo(0);
typeUnion.Value().Should().BeOfTypeTwo().AndValue.Should().BeGreaterOrEqualTo(0).And.BeLessOrEqualTo(2000);
```

### `Be`

``` csharp
public class MyDefinition : UnionDefinition<MyDefinition, string, int, bool> { }
var definedUnion = Union.FromDefinition<MyDefinition>().Create(1337);
var typeUnion = Union.FromTypes<string, int, bool>().Create(1337);

// verify that union value is equal to some other union value
definedUnion.Value().Should().Be(Union.FromDefinition<MyDefinition>().Create(1337).Value());
typeUnion.Value().Should().Be(Union.FromTypes<string, int, bool>().Create(1337).Value());
```

## `IUnionTask<IUnionValue<TUnionDefinition>>`

### `BeOfType{One, Two, Three, Four, Five, Six, Seven, Eight}`

``` csharp
public class MyDefinition : UnionDefinition<MyDefinition, string, int, bool> { }
var definedUnion = Task.FromResult(Union.FromDefinition<MyDefinition>().Create(1337));
var typeUnion = Task.FromResult(Union.FromTypes<string, int, bool>().Create(1337));

// awaits and verifies that union value is of a particular type
await typeUnion.Value().Should().BeOfTypeTwo();

// awaits and verifies that union value is of a particular type and matches some condition(s)
await definedUnion.Value().Should().BeOfTypeTwo().AndValue(value => value.Should().Be(1337));
await typeUnion.Value().Should().BeOfTypeTwo().AndValue(value => value.Should().Be(1337));
await definedUnion.Value().Should().BeOfTypeTwo().AndValue(value => value.Should().BeGreaterOrEqualTo(0));
await typeUnion.Value().Should().BeOfTypeTwo().AndValue(value => value.Should().BeGreaterOrEqualTo(0).And.BeLessOrEqualTo(2000));
```

### `Be`

``` csharp
public class MyDefinition : UnionDefinition<MyDefinition, string, int, bool> { }
var definedUnion = Task.FromResult(Union.FromDefinition<MyDefinition>().Create(1337));
var typeUnion = Task.FromResult(Union.FromTypes<string, int, bool>().Create(1337));

// awaits and verifies that union value is equal to some other union value
await definedUnion.Value().Should().Be(Union.FromDefinition<MyDefinition>().Create(1337).Value());
await typeUnion.Value().Should().Be(Union.FromTypes<string, int, bool>().Create(1337).Value());
```