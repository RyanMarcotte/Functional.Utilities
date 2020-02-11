# Functional.Primitives.FluentAssertions

This library extends [FluentAssertions](https://fluentassertions.com/) to provide assertion clauses for types defined by the [`Functional.Primitives`](https://github.com/JohannesMoersch/Functional) NuGet package.

## `Option<T>`

``` csharp
var option = Option.Some(1337);

// verify that the option contains a value
option.Should().HaveValue();

// verify that the option contains a value and that the contained value matches some condition(s)
option.Should().HaveValue().AndValue.Should().Be(1337);
option.Should().HaveValue().AndValue.Should().BeGreaterThanOrEqualTo(0);
option.Should().HaveValue().AndValue.Should().BeGreaterThanOrEqualTo(0).And.LessThanOrEqualTo(2000);
```

``` csharp
var option = Option.None<int>();

// verify that the option does not have a value
option.Should().NotHaveValue();
```

## `Result<TSuccess, TFailure>`

``` csharp
var result = Result.Success<int, string>(1337);

// verify that the result represents a successful value
result.Should().BeSuccessful();

// verify that the result represents a successful value and that the contained value matches some condition(s)
result.Should().BeSuccessful().AndValue.Should().Be(1337);
result.Should().BeSuccessful().AndValue.Should().BeGreaterThanOrEqualTo(0);
result.Should().BeSuccessful().AndValue.Should().BeGreaterThanOrEqualTo(0).And.BeLessThanOrEqualTo(2000);
```

``` csharp
var result = Result.Failure<int, string>(string.Empty);

// verify that the result represents a faulted value
result.Should().BeFaulted();

// verify that the result represents a faulted value and that the contained value matches some condition(s)
result.Should().BeFaulted().AndValue.Should().Be(string.Empty);
result.Should().BeFaulted().AndValue.Should().BeNullOrWhiteSpace();
```
