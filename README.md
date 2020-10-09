# Functional.Utilities

This repository contains a set of libraries that make working with [`Functional` types](https://github.com/JohannesMoersch/Functional) easier.

## `Functional.Primitives.FluentAssertions`

This library extends [FluentAssertions](https://fluentassertions.com/) to provide assertion clauses for types defined by the [`Functional.Primitives`](https://github.com/JohannesMoersch/Functional) NuGet package: `Option<T>` and `Result<TSuccess, TFailure>`.

[View the ReadMe](docs/Functional.Primitives.FluentAssertions.md)

## `Functional.Unions.FluentAssertions`

This library extends [FluentAssertions](https://fluentassertions.com/) to provide assertion clauses for types defined by the [`Functional.Unions`](https://github.com/JohannesMoersch/Functional) NuGet package: `IUnionValue<TUnionDefinition>`.

[View the ReadMe](docs/Functional.Unions.FluentAssertions.md)

## `Functional.SerilogExtensions`

This library extends [`Serilog`](https://github.com/serilog/serilog) to make logging `Option<T>` and `Result<TSuccess, TFailure>` data payloads easier.

[View the ReadMe](docs/Functional.SerilogExtensions.md)
