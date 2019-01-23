# Functional.Primitives.FluentAssertions

This library extends [FluentAssertions](https://fluentassertions.com/) to provide assertion clauses for types defined by the `Functional.Primitives` NuGet package.

## `Option<T>`

```
var option = Option.Some(1337);

// verify that the option contains a value
option.Should().HaveValue();

// verify that the option contains a value that is an exact match
option.Should().HaveExpectedValue(1337);

// verify that the option contains a value that satisfies some condition(s)
option.Should().HaveValue(value => value.Should().BeGreaterThanOrEqualTo(0));
```

```
var option = Option.None<int>();

// verify that the option does not have a value
option.Should().NotHaveValue();
```

## `Result<TSuccess, TFailure>`

```
var result = Result.Success<int, string>(1337);

// verify that the result represents a successful value
result.Should().BeSuccessful();

// verify that the result represents a successful value, and that value is an exact match
result.Should().BeSuccessfulWithExpectedValue(1337);

// verify that the result represents a successful value, and that value satisfies some condition(s)
result.Should().BeSuccessful(value => value.Should().BeGreaterThanOrEqualTo(0));
```

```
var result = Result.Failure<int, string>(string.Empty);

// verify that the result represents a faulted value
result.Should().BeFaulted();

// verify that the result represents a faulted value, and that value is an exact match
result.Should().BeFaultedWithExpectedValue(string.Empty);

// verify that the result represents a faulted value, and that value satisfies some condition(s)
result.Should().BeFaulted(value => value.Should().BeNullOrWhiteSpace());
```