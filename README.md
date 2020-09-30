# `Functional.Primitives.FluentAssertions`

This library extends [FluentAssertions](https://fluentassertions.com/) to provide assertion clauses for types defined by the [`Functional.Primitives`](https://github.com/JohannesMoersch/Functional) NuGet package: `Option<T>` and `Result<TSuccess, TFailure>`.

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
