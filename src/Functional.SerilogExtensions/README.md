# `Functional.SerilogExtensions`

This library extends [`Serilog`](https://github.com/serilog/serilog) to make logging `Option<T>` and `Result<TSuccess, TFailure>` data payloads easier.  This is done using *destructuring policies*; specifically [`OptionDestructurePolicy`](Functional.SerilogExtensions/OptionDestructurePolicy.cs) and [`ResultDestructurePolicy`](Functional.SerilogExtensions/ResultDestructurePolicy.cs).

``` csharp
// configure the payloads to generate for Option.None<T>
// treats Option<T> like a nullable object (T?)
var optionConfiguration = new OptionDestructurePolicyConfiguration(data => data, () => null);

// configure the payloads to generate for Result<TSuccess, TFailure>
// uses anonymous objects to include state information
var resultConfiguration = new ResultDestructurePolicyConfiguration(
    success => new { IsSuccessful = true, Data = success },
    failure => new { IsSuccessful = false, Data = failure });

// create the Serilog logger with destructuring policies for both Option<T> and Result<TSuccess, TFailure>
_logger = new LoggerConfiguration()
    .WriteTo.Sink(/* YOUR DESIRED SINK(S) HERE */)
    .Destructure.FunctionalOptionAndResultTypes(optionConfiguration, resultConfiguration)
    .CreateLogger();

class ClassContainingOption { public Option<int> Value { get; } }

// log destructured payloads containing Option<T> with '@' operator
_logger.Information("{@PAYLOAD}", Option.Some(1337)); // payload logged is '1337'
_logger.Information("{@PAYLOAD}", Option.None<int>()); // payload logged is 'null'
_logger.Information("{@PAYLOAD}", new ClassContainingOption(Option.Some(1337))); // payload logged is '{ Value: 1337 }'
_logger.Information("{@PAYLOAD}", new ClassContainingOption(Option.None<int>())); // payload logged is '{ Value: null }'

class ClassContainingResult { public Result<int, string> Value { get; } }

// log destructured payloads containing Result<TSuccess, TFailure> with '@' operator
_logger.Information("{@PAYLOAD}", Result.Success<int, string>(1337)); // payload logged is '{ IsSuccessful: True, Data: 1337 }'
_logger.Information("{@PAYLOAD}", Result.Failure<int, string>("ERROR")); // payload logged is '{ IsSuccessful: False, Data: 1337 }'
_logger.Information("{@PAYLOAD}", new ClassContainingResult(Result.Success<int, string>(1337))); // payload logged is '{ Value: { IsSuccessful: True, Data: 1337 } }'
_logger.Information("{@PAYLOAD}", new ClassContainingResult(Result.Failure<int, string>("ERROR"))); // payload logged is '{ Value: { IsSuccessful: False, Data: "ERROR" } }'

// log destructured payloads containing Result<Option<T>, TFailure> with '@' operator
// other cases omitted for brevity...  the destructure policies apply recursively
_logger.Information("{@PAYLOAD}", Result.Success<Option<int>, string>(Option.Some(1337)); // payload logged is '{ IsSuccessful: True, Data: { Value: 1337 } }'
_logger.Information("{@PAYLOAD}", Result.Success<Option<int>, string>(Option.Some(1337)); // payload logged is '{ IsSuccessful: True, Data: { Value: null } }'
```

Consult the [Serilog documentation](https://github.com/serilog/serilog/wiki/Structured-Data#preserving-object-structure) for more information about object destructuring and destructuring policies.
