# `Functional.Primitives.FluentAssertions`

This library extends [FluentAssertions](https://fluentassertions.com/) to provide assertion clauses for types defined by the [`Functional.Primitives`](https://github.com/JohannesMoersch/Functional) NuGet package: `Option<T>` and `Result<TSuccess, TFailure>`.

## Upgrading from v2.x to v3.x

Prior to upgrading to v3.x, upgrade to v2.2 first and replace all `Obsolete` methods if you have not already done so.  Each `Obsolete` method has instructions for what assertion method to use instead.

After upgrading to v3.x, you may encounter one or more of the following compilation errors:
- `ObjectAssertions` does not contain a definition for `HaveValue` and no accessible extension method `HaveValue` accepting a first argument of type `ObjectAssertions` could be found (are you missing a using directive or an assembly reference?)
- `ObjectAssertions` does not contain a definition for `NotHaveValue` and no accessible extension method `NotHaveValue` accepting a first argument of type `ObjectAssertions` could be found (are you missing a using directive or an assembly reference?)
- `ObjectAssertions` does not contain a definition for `BeSuccessful` and no accessible extension method `BeSuccessful` accepting a first argument of type `ObjectAssertions` could be found (are you missing a using directive or an assembly reference?)
- `ObjectAssertions` does not contain a definition for `BeFaulted` and no accessible extension method `BeFaulted` accepting a first argument of type `ObjectAssertions` could be found (are you missing a using directive or an assembly reference?)

In the affected files, add the `using Functional` declaration.  You may delete the existing `using Functional.Primitives.FluentAssertions` declaration in those files after doing so, assuming the `Functional.Primitives.FluentAssertions` namespace is not otherwise used.

## `Option<T>`

### `HaveValue`

``` csharp
var option = Option.Some(1337);

// verify that the option contains a value
option.Should().HaveValue();

// verify that the option contains a value and that the contained value matches some condition(s)
option.Should().HaveValue().AndValue.Should().Be(1337);
option.Should().HaveValue().AndValue.Should().BeGreaterThanOrEqualTo(0);
option.Should().HaveValue().AndValue.Should().BeGreaterThanOrEqualTo(0).And.LessThanOrEqualTo(2000);
```

### `NotHaveValue`

``` csharp
var option = Option.None<int>();

// verify that the option does not have a value
option.Should().NotHaveValue();
```

### `Be`

``` csharp
var option = Option.Some(1337);
var otherOption = Option.Some(1337);

// verify that the option is equal to another option
option.Should().Be(otherOption);
```

## `Task<Option<T>>`

### `HaveValue`

``` csharp
var optionTask = Task.FromResult(Option.Some(1337));

// await the task and verify that the resulting option contains a value
await optionTask.Should().HaveValue();

// await the task and verify that the resulting option contains a value and that the contained value matches some condition(s)
await optionTask.Should().HaveValue().AndValue(v => v.Should().Be(1337));
await optionTask.Should().HaveValue().AndValue(v => v.Should().BeGreaterThanOrEqualTo(0));
await optionTask.Should().HaveValue().AndValue(v => v.Should().BeGreaterThanOrEqualTo(0).And.LessThanOrEqualTo(2000));
```

### `NotHaveValue`

``` csharp
var optionTask = Task.FromResult(Option.None<int>());

// await the task and verify that the resulting option does not have a value
await optionTask.Should().NotHaveValue();
```

### `Be`

``` csharp
var optionTask = Task.FromResult(Option.Some(1337));
var otherOption = Task.FromResult(Option.Some(1337));

// await the task and verify that the resulting option is equal to another option
await optionTask.Should().Be(otherOption);
```

## `Result<TSuccess, TFailure>`

### `BeSuccessful`

``` csharp
var result = Result.Success<int, string>(1337);

// verify that the result represents a successful value
result.Should().BeSuccessful();

// verify that the result represents a successful value and that the contained value matches some condition(s)
result.Should().BeSuccessful().AndSuccessValue.Should().Be(1337);
result.Should().BeSuccessful().AndSuccessValue.Should().BeGreaterThanOrEqualTo(0);
result.Should().BeSuccessful().AndSuccessValue.Should().BeGreaterThanOrEqualTo(0).And.BeLessThanOrEqualTo(2000);
```

### `BeFaulted`

``` csharp
var result = Result.Failure<int, string>(string.Empty);

// verify that the result represents a faulted value
result.Should().BeFaulted();

// verify that the result represents a faulted value and that the contained value matches some condition(s)
result.Should().BeFaulted().AndFailureValue.Should().Be(string.Empty);
result.Should().BeFaulted().AndFailureValue.Should().BeNullOrWhiteSpace();
```

### `Be`

``` csharp
var result = Result.Success<int, string>(1337);
var otherResult = Result.Success<int, string>(1337);

// verify that the result is equal to another result
result.Should().Be(otherResult);
```

## `Task<Result<TSuccess, TFailure>>`

### `BeSuccessful`

``` csharp
var resultTask = Task.FromResult(Result.Success<int, string>(1337));

// await the Task and verify that the result represents a successful value
await resultTask.Should().BeSuccessful();

// await the Task and verify that the result represents a successful value and that the contained value matches some condition(s)
await resultTask.Should().BeSuccessful().AndSuccessValue(s => s.Should().Be(1337));
await resultTask.Should().BeSuccessful().AndSuccessValue(s => s.Should().BeGreaterThanOrEqualTo(0));
await resultTask.Should().BeSuccessful().AndSuccessValue(s => s.Should().BeGreaterThanOrEqualTo(0).And.BeLessThanOrEqualTo(2000));
```

### `BeFaulted`

``` csharp
var resultTask = Task.FromResult(Result.Failure<int, string>(string.Empty));

// await the Task and verify that the result represents a faulted value
await resultTask.Should().BeFaulted();

// await the Task and verify that the result represents a faulted value and that the contained value matches some condition(s)
await resultTask.Should().BeFaulted().AndFailureValue(f => f.Should().Be(string.Empty));
await resultTask.Should().BeFaulted().AndFailureValue(f => f.Should().BeNullOrWhiteSpace());
```

### `Be`

``` csharp
var resultTask = Task.FromResult(Result.Success<int, string>(1337));
var otherResult = Result.Success<int, string>(1337);

// await the Task and verify that the result is equal to another result
await resultTask.Should().Be(otherResult);
```
