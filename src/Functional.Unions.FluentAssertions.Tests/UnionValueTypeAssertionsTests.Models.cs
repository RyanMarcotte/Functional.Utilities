namespace Functional.Unions.FluentAssertions.Tests
{
	public partial class UnionValueTypeAssertionsTests
	{
		public class ClassOne { }
		public static ClassOne ModelOne = new ClassOne();
		public class ClassTwo { }
		public static ClassTwo ModelTwo = new ClassTwo();
		public class ClassThree { }
		public static ClassThree ModelThree = new ClassThree();
		public class ClassFour { }
		public static ClassFour ModelFour = new ClassFour();
		public class ClassFive { }
		public static ClassFive ModelFive = new ClassFive();
		public class ClassSix { }
		public static ClassSix ModelSix = new ClassSix();
		public class ClassSeven { }
		public static ClassSeven ModelSeven = new ClassSeven();
		public class ClassEight { }
		public static ClassEight ModelEight = new ClassEight();

		public class TwoDefinition : UnionDefinition<TwoDefinition, ClassOne, ClassTwo> { }
		public class ThreeDefinition : UnionDefinition<ThreeDefinition, ClassOne, ClassTwo, ClassThree> { }
		public class FourDefinition : UnionDefinition<FourDefinition, ClassOne, ClassTwo, ClassThree, ClassFour> { }
		public class FiveDefinition : UnionDefinition<FiveDefinition, ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive> { }
		public class SixDefinition : UnionDefinition<SixDefinition, ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix> { }
		public class SevenDefinition : UnionDefinition<SevenDefinition, ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven> { }
		public class EightDefinition : UnionDefinition<EightDefinition, ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven, ClassEight> { }
	}
}
