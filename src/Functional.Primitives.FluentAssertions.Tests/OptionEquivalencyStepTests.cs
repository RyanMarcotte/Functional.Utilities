using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Sdk;

namespace Functional.Primitives.FluentAssertions.Tests
{
    public class OptionEquivalencyStepTests
    {
        public class WhenInClass
        {
            [Fact]
            public void BeEquivalentTo()
            {
                var parentA = new ParentA(new ChildA("TEST"));
                var parentB = new ParentB(new ChildB("TEST"));

                parentA.Should().BeEquivalentTo(parentB, options => options.Using(new OptionEquivalencyStep<BaseChild>()));
            }

            [Fact]
            public void BeEquivalentTo2()
            {
                var parentA = new ParentA(new ChildA("TEST"));
                var parentB = new ParentB(new ChildB("test"));

                parentA.Should().BeEquivalentTo(parentB, options => options.Using(new OptionEquivalencyStep<BaseChild>()));
            }

            [Fact]
            public void BeEquivalentTo3()
            {
                var parentA = new Parent1(new ChildA("TEST"));
                var parentB = new Parent2(new ChildB("TEST"));

                parentA.Should().BeEquivalentTo(parentB, options => options.Using(new OptionEquivalencyStep<BaseChild>()));
            }

            private class Parent1
            {
                public Parent1(ChildA child)
                {
                    Child = child;
                }

                public ChildA Child { get; }
            }

            private class Parent2
            {
                public Parent2(ChildB child)
                {
                    Child = child;
                }

                public ChildB Child { get; }
            }

            private class ParentA
            {
                public ParentA(Option<ChildA> child)
                {
                    Child = child;
                }

                public Option<ChildA> Child { get; }
            }

            private class ParentB
            {
                public ParentB(Option<ChildB> child)
                {
                    Child = child;
                }

                public Option<ChildB> Child { get; }
            }

            private abstract class BaseChild
            {
                protected BaseChild(string value)
                {
                    Value = value;
                }

                public string Value { get; }
            }

            private class ChildA : BaseChild
            {
                public ChildA(string value)
                    : base(value)
                {
                }
            }

            private class ChildB : BaseChild
            {
                public ChildB(string value)
                    : base(value)
                {
                }
            }
        }

        public class WhenInCollection
        {
            [Fact]
            public void SampleTest()
            {
                var optionList1 = new[] { Option.Some(new SimpleClass(1)), Option.None(), Option.Some(new SimpleClass(2)) };
                var optionList2 = new[] { Option.Some(new SimpleClass(1)), Option.None(), Option.Some(new SimpleClass(2)) };

                optionList1.Should().BeEquivalentTo(optionList2, options => options.Using(new OptionEquivalencyStep<SimpleClass>()));
            }

            [Fact]
            public void SampleTest2()
            {
                var optionList1 = new[] { Option.Some(new SimpleClass(1)), Option.None(), Option.Some(new SimpleClass(2)) };
                var optionList2 = new[] { Option.Some(new SimpleClass(1)), Option.None(), Option.None() };

                optionList1.Should().BeEquivalentTo(optionList2, options => options.Using(new OptionEquivalencyStep<SimpleClass>()));
            }

            [Fact]
            public void SampleTest3()
            {
                var optionList1 = new[] { Option.Some(new SimpleClass(1)), Option.None(), Option.None() };
                var optionList2 = new[] { Option.Some(new SimpleClass(1)), Option.None(), Option.Some(new SimpleClass(2)) };

                optionList1.Should().BeEquivalentTo(optionList2, options => options.Using(new OptionEquivalencyStep<SimpleClass>()).WithTracing());
            }

            [Fact]
            public void SampleTest4()
            {
                var optionList1 = new[] { Option.Some(new SimpleClass(1)), Option.None(), Option.Some(new SimpleClass(3)) };
                var optionList2 = new[] { Option.Some(new SimpleClass(1)), Option.None(), Option.Some(new SimpleClass(2)) };

                optionList1.Should().BeEquivalentTo(optionList2, options => options.Using(new OptionEquivalencyStep<SimpleClass>()).WithTracing());
            }

            private class SimpleClass
            {
                public SimpleClass(int value)
                {
                    Value = value;
                }

                public int Value { get; }
            }
        }
    }
}
