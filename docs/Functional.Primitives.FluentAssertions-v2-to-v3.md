# Upgrading from v2.x to v3.x

Prior to upgrading to v3.x, upgrade to v2.2 first and replace all `Obsolete` methods if you have not already done so.  Each `Obsolete` method has instructions for what assertion method to use instead.

After upgrading to v3.x, you may encounter one or more of the following compilation errors:

- `ObjectAssertions` does not contain a definition for `HaveValue` and no accessible extension method `HaveValue` accepting a first argument of type `ObjectAssertions` could be found (are you missing a using directive or an assembly reference?)
- `ObjectAssertions` does not contain a definition for `NotHaveValue` and no accessible extension method `NotHaveValue` accepting a first argument of type `ObjectAssertions` could be found (are you missing a using directive or an assembly reference?)
- `ObjectAssertions` does not contain a definition for `BeSuccessful` and no accessible extension method `BeSuccessful` accepting a first argument of type `ObjectAssertions` could be found (are you missing a using directive or an assembly reference?)
- `ObjectAssertions` does not contain a definition for `BeFaulted` and no accessible extension method `BeFaulted` accepting a first argument of type `ObjectAssertions` could be found (are you missing a using directive or an assembly reference?)

In the affected files, add the `using Functional` declaration.  You may delete the existing `using Functional.Primitives.FluentAssertions` declaration in those files after doing so, assuming the `Functional.Primitives.FluentAssertions` namespace is not otherwise used.