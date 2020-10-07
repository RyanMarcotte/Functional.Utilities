# `Functional.SerilogExtensions`

This library extends [`Serilog`](https://github.com/serilog/serilog) to make logging `Option<T>` and `Result<TSuccess, TFailure>` data payloads easier.  This is done using *destructuring policies*; specifically [`OptionDestructurePolicy`](Functional.SerilogExtensions/OptionDestructurePolicy.cs) and [`ResultDestructurePolicy`](Functional.SerilogExtensions/ResultDestructurePolicy.cs).  Both policies apply recursively, as demonstrated below.

``` csharp
using Serilog.Configuration;

// create the Serilog logger with destructuring policies for both Option<T> and Result<TSuccess, TFailure>
// the delegate specifies what object to produce when Option.None<T> exists in the payload data
_logger = new LoggerConfiguration()
    .WriteTo.Sink(/* YOUR DESIRED SINK(S) HERE */)
    .Destructure.FunctionalOptionAndResultTypes(
        () => "NONE",
        success => new { IsSuccessful = true, Data = success },
        failure => new { IsSuccessful = false, Data = failure })
    .CreateLogger();

class ClassContainingOption { public Option<int> Value { get; } }

// log destructured payloads containing Option<T> with '@' operator
_logger.Information("{@PAYLOAD}", Option.Some(1337)); // payload logged is '1337'
_logger.Information("{@PAYLOAD}", Option.None<int>()); // payload logged is 'NONE'
_logger.Information("{@PAYLOAD}", new ClassContainingOption(Option.Some(1337))); // payload logged is '{ Value: 1337 }'
_logger.Information("{@PAYLOAD}", new ClassContainingOption(Option.None<int>())); // payload logged is '{ Value: "NONE" }'

class ClassContainingResult { public Result<int, string> Value { get; } }

// log destructured payloads containing Result<TSuccess, TFailure> with '@' operator
_logger.Information("{@PAYLOAD}", Result.Success<int, string>(1337)); // payload logged is '{ IsSuccessful: true, Data: 1337 }'
_logger.Information("{@PAYLOAD}", Result.Failure<int, string>("ERROR")); // payload logged is '{ IsSuccessful: false, Data: 1337 }'
_logger.Information("{@PAYLOAD}", new ClassContainingResult(Result.Success<int, string>(1337))); // payload logged is '{ Value: { IsSuccessful: true, Data: 1337 } }'
_logger.Information("{@PAYLOAD}", new ClassContainingResult(Result.Failure<int, string>("ERROR"))); // payload logged is '{ Value: { IsSuccessful: false, Data: "ERROR" } }'
```

Consult the [Serilog documentation](https://github.com/serilog/serilog/wiki/Structured-Data#preserving-object-structure) for more information about object destructuring and destructuring policies.
