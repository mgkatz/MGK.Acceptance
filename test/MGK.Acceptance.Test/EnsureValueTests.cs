using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MGK.Acceptance.Test
{
	public class EnsureValueTests
	{
		private const string SpecificErrorMessage = "Specific message";

		#region IsNotNull

		[Test]
		public void EnsureValue_IsNotNull_WhenValidValue_EndsOk()
			=> Assert.DoesNotThrow(() => Ensure.Value.IsNotNull(1));

		[Test]
		public void EnsureValue_IsNotNull_WhenInvalidValue_ThrowsAnException()
		{
			var exception = Assert.Throws<Exception>(() => Ensure.Value.IsNotNull(null));
			Assert.AreEqual(Resources.AppMessages.ErrorNull, exception.Message);
		}

		[Test]
		public void EnsureValue_IsNotNull_WithSpecificMessage_WhenValidValue_EndsOk()
			=> Assert.DoesNotThrow(() => Ensure.Value.IsNotNull(1, SpecificErrorMessage));

		[Test]
		public void EnsureValue_IsNotNull_WithSpecificMessage_WhenInvalidValue_ThrowsAnException()
		{
			var exception = Assert.Throws<Exception>(() => Ensure.Value.IsNotNull(null, SpecificErrorMessage));
			Assert.AreEqual(SpecificErrorMessage, exception.Message);
		}

		[TestCase(null)]
		[TestCase("")]
		[TestCase("          ")]
		public void EnsureValue_IsNotNull_WithSpecificMessage_WhenInvalidMessage_ThrowsAnException(string errorMessage)
		{
			var exception = Assert.Throws<ArgumentException>(() => Ensure.Value.IsNotNull(null, errorMessage));
			Assert.True(exception.Message.StartsWith(Resources.AppMessages.ErrorMessageNotProvided, StringComparison.InvariantCultureIgnoreCase));
		}

		[Test]
		public void EnsureValue_IsNotNull_WithSpecificException_WhenValidValue_EndsOk()
			=> Assert.DoesNotThrow(() => Ensure.Value.IsNotNull<TestException>(1));

		[Test]
		public void EnsureValue_IsNotNull_WithSpecificException_WhenInvalidValue_ThrowsAnException()
		{
			var exception = Assert.Throws<TestException>(() => Ensure.Value.IsNotNull<TestException>(null));
			Assert.AreEqual(Resources.AppMessages.ErrorNull, exception.Message);
		}

		[Test]
		public void EnsureValue_IsNotNull_WithSpecificExceptionAndSpecificMessage_WhenValidValue_EndsOk()
			=> Assert.DoesNotThrow(() => Ensure.Value.IsNotNull<TestException>(1, SpecificErrorMessage));

		[Test]
		public void EnsureValue_IsNotNull_WithSpecificExceptionAndSpecificMessage_WhenInvalidValue_ThrowsAnException()
		{
			var exception = Assert.Throws<TestException>(() => Ensure.Value.IsNotNull<TestException>(null, SpecificErrorMessage));
			Assert.AreEqual(SpecificErrorMessage, exception.Message);
		}

		[TestCase(null)]
		[TestCase("")]
		[TestCase("          ")]
		public void EnsureValue_IsNotNull_WithSpecificExceptionAndSpecificMessage_WhenInvalidMessage_ThrowsAnException(string errorMessage)
		{
			var exception = Assert.Throws<ArgumentException>(() => Ensure.Value.IsNotNull<TestException>(null, errorMessage));
			Assert.True(exception.Message.StartsWith(Resources.AppMessages.ErrorMessageNotProvided, StringComparison.InvariantCultureIgnoreCase));
		}

		#endregion

		#region IsNotNullNorEmpty

		[Test]
		public void EnsureValue_IsNotNullNorEmpty_WhenValidValue_EndsOk()
		{
			Assert.DoesNotThrow(() => Ensure.Value.IsNotNullNorEmpty("qwerty"));
			Assert.DoesNotThrow(() => Ensure.Value.IsNotNullNorEmpty(new int[] { 1, 2, 3 }));
		}

		[TestCase(null, null)]
		[TestCase("", new int[0])]
		public void EnsureValue_IsNotNullNorEmpty_WhenInvalidValue_ThrowsAnException(string text, IEnumerable<int> enumerable)
		{
			var exception = Assert.Throws<Exception>(() => Ensure.Value.IsNotNullNorEmpty(text));
			Assert.AreEqual(Resources.AppMessages.ErrorNullNorEmpty, exception.Message);

			exception = Assert.Throws<Exception>(() => Ensure.Value.IsNotNullNorEmpty(enumerable));
			Assert.AreEqual(Resources.AppMessages.ErrorNullNorEmpty, exception.Message);
		}

		[Test]
		public void EnsureValue_IsNotNullNorEmpty_WithSpecificMessage_WhenValidValue_EndsOk()
		{
			Assert.DoesNotThrow(() => Ensure.Value.IsNotNullNorEmpty("qwerty", SpecificErrorMessage));
			Assert.DoesNotThrow(() => Ensure.Value.IsNotNullNorEmpty(new int[] { 1, 2, 3 }, SpecificErrorMessage));
		}

		[TestCase(null, null)]
		[TestCase("", new int[0])]
		public void EnsureValue_IsNotNullNorEmpty_WithSpecificMessage_WhenInvalidValue_ThrowsAnException(string text, IEnumerable<int> enumerable)
		{
			var exception = Assert.Throws<Exception>(() => Ensure.Value.IsNotNullNorEmpty(text, SpecificErrorMessage));
			Assert.AreEqual(SpecificErrorMessage, exception.Message);

			exception = Assert.Throws<Exception>(() => Ensure.Value.IsNotNullNorEmpty(enumerable, SpecificErrorMessage));
			Assert.AreEqual(SpecificErrorMessage, exception.Message);
		}

		[TestCase(null)]
		[TestCase("")]
		[TestCase("          ")]
		public void EnsureValue_IsNotNullNorEmpty_WithSpecificMessage_WhenInvalidMessage_ThrowsAnException(string errorMessage)
		{
			var exception = Assert.Throws<ArgumentException>(() => Ensure.Value.IsNotNullNorEmpty("", errorMessage));
			Assert.True(exception.Message.StartsWith(Resources.AppMessages.ErrorMessageNotProvided, StringComparison.InvariantCultureIgnoreCase));

			exception = Assert.Throws<ArgumentException>(() => Ensure.Value.IsNotNullNorEmpty(new int[0], errorMessage));
			Assert.True(exception.Message.StartsWith(Resources.AppMessages.ErrorMessageNotProvided, StringComparison.InvariantCultureIgnoreCase));
		}

		[Test]
		public void EnsureValue_IsNotNullNorEmpty_WithSpecificException_WhenValidValue_EndsOk()
		{
			Assert.DoesNotThrow(() => Ensure.Value.IsNotNullNorEmpty<TestException>("qwerty"));
			Assert.DoesNotThrow(() => Ensure.Value.IsNotNullNorEmpty<TestException, int>(new int[] { 1, 2, 3 }));
		}

		[TestCase(null, null)]
		[TestCase("", new int[0])]
		public void EnsureValue_IsNotNullNorEmpty_WithSpecificException_WhenInvalidValue_ThrowsAnException(string text, IEnumerable<int> enumerable)
		{
			var exception = Assert.Throws<TestException>(() => Ensure.Value.IsNotNullNorEmpty<TestException>(text));
			Assert.AreEqual(Resources.AppMessages.ErrorNullNorEmpty, exception.Message);

			exception = Assert.Throws<TestException>(() => Ensure.Value.IsNotNullNorEmpty<TestException, int>(enumerable));
			Assert.AreEqual(Resources.AppMessages.ErrorNullNorEmpty, exception.Message);
		}

		[Test]
		public void EnsureValue_IsNotNullNorEmpty_WithSpecificExceptionAndSpecificMessage_WhenValidValue_EndsOk()
		{
			Assert.DoesNotThrow(() => Ensure.Value.IsNotNullNorEmpty<TestException>("qwerty", SpecificErrorMessage));
			Assert.DoesNotThrow(() => Ensure.Value.IsNotNullNorEmpty<TestException, int>(new int[] { 1, 2, 3 }, SpecificErrorMessage));
		}

		[TestCase(null, null)]
		[TestCase("", new int[0])]
		public void EnsureValue_IsNotNullNorEmpty_WithSpecificExceptionAndSpecificMessage_WhenInvalidValue_ThrowsAnException(string text, IEnumerable<int> enumerable)
		{
			var exception = Assert.Throws<TestException>(() => Ensure.Value.IsNotNullNorEmpty<TestException>(text, SpecificErrorMessage));
			Assert.AreEqual(SpecificErrorMessage, exception.Message);

			exception = Assert.Throws<TestException>(() => Ensure.Value.IsNotNullNorEmpty<TestException, int>(enumerable, SpecificErrorMessage));
			Assert.AreEqual(SpecificErrorMessage, exception.Message);
		}

		[TestCase(null)]
		[TestCase("")]
		[TestCase("          ")]
		public void EnsureValue_IsNotNullNorEmpty_WithSpecificExceptionAndSpecificMessage_WhenInvalidMessage_ThrowsAnException(string errorMessage)
		{
			var exception = Assert.Throws<ArgumentException>(() => Ensure.Value.IsNotNullNorEmpty<TestException>("", errorMessage));
			Assert.True(exception.Message.StartsWith(Resources.AppMessages.ErrorMessageNotProvided, StringComparison.InvariantCultureIgnoreCase));

			exception = Assert.Throws<ArgumentException>(() => Ensure.Value.IsNotNullNorEmpty<TestException, int>(new int[0], errorMessage));
			Assert.True(exception.Message.StartsWith(Resources.AppMessages.ErrorMessageNotProvided, StringComparison.InvariantCultureIgnoreCase));
		}

		#endregion

		#region IsNotNullNorEmptyNorWhiteSpace

		[Test]
		public void EnsureValue_IsNotNullNorEmptyNorWhiteSpace_WhenValidValue_EndsOk()
			=> Assert.DoesNotThrow(() => Ensure.Value.IsNotNullNorEmptyNorWhiteSpace("qwerty"));

		[TestCase(null)]
		[TestCase("")]
		[TestCase("          ")]
		public void EnsureValue_IsNotNullNorEmptyNorWhiteSpace_WhenInvalidValue_ThrowsAnException(string text)
		{
			var exception = Assert.Throws<Exception>(() => Ensure.Value.IsNotNullNorEmptyNorWhiteSpace(text));
			Assert.AreEqual(Resources.AppMessages.ErrorNullNorEmptyNorWhiteSpace, exception.Message);
		}

		[Test]
		public void EnsureValue_IsNotNullNorEmptyNorWhiteSpace_WithSpecificMessage_WhenValidValue_EndsOk()
			=> Assert.DoesNotThrow(() => Ensure.Value.IsNotNullNorEmptyNorWhiteSpace("qwerty", SpecificErrorMessage));

		[TestCase(null)]
		[TestCase("")]
		[TestCase("          ")]
		public void EnsureValue_IsNotNullNorEmptyNorWhiteSpace_WithSpecificMessage_WhenInvalidValue_ThrowsAnException(string text)
		{
			var exception = Assert.Throws<Exception>(() => Ensure.Value.IsNotNullNorEmptyNorWhiteSpace(text, SpecificErrorMessage));
			Assert.AreEqual(SpecificErrorMessage, exception.Message);
		}

		[TestCase(null)]
		[TestCase("")]
		[TestCase("          ")]
		public void EnsureValue_IsNotNullNorEmptyNorWhiteSpace_WithSpecificMessage_WhenInvalidMessage_ThrowsAnException(string errorMessage)
		{
			var exception = Assert.Throws<ArgumentException>(() => Ensure.Value.IsNotNullNorEmptyNorWhiteSpace(null, errorMessage));
			Assert.True(exception.Message.StartsWith(Resources.AppMessages.ErrorMessageNotProvided, StringComparison.InvariantCultureIgnoreCase));
		}

		[Test]
		public void EnsureValue_IsNotNullNorEmptyNorWhiteSpace_WithSpecificException_WhenValidValue_EndsOk()
			=> Assert.DoesNotThrow(() => Ensure.Value.IsNotNullNorEmptyNorWhiteSpace<TestException>("qwerty"));

		[TestCase(null)]
		[TestCase("")]
		[TestCase("          ")]
		public void EnsureValue_IsNotNullNorEmptyNorWhiteSpace_WithSpecificException_WhenInvalidValue_ThrowsAnException(string text)
		{
			var exception = Assert.Throws<TestException>(() => Ensure.Value.IsNotNullNorEmptyNorWhiteSpace<TestException>(text));
			Assert.AreEqual(Resources.AppMessages.ErrorNullNorEmptyNorWhiteSpace, exception.Message);
		}

		[Test]
		public void EnsureValue_IsNotNullNorEmptyNorWhiteSpace_WithSpecificExceptionAndSpecificMessage_WhenValidValue_EndsOk()
			=> Assert.DoesNotThrow(() => Ensure.Value.IsNotNullNorEmptyNorWhiteSpace<TestException>("qwerty", SpecificErrorMessage));

		[TestCase(null)]
		[TestCase("")]
		[TestCase("          ")]
		public void EnsureValue_IsNotNullNorEmptyNorWhiteSpace_WithSpecificExceptionAndSpecificMessage_WhenInvalidValue_ThrowsAnException(string text)
		{
			var exception = Assert.Throws<TestException>(() => Ensure.Value.IsNotNullNorEmptyNorWhiteSpace<TestException>(text, SpecificErrorMessage));
			Assert.AreEqual(SpecificErrorMessage, exception.Message);
		}

		[TestCase(null)]
		[TestCase("")]
		[TestCase("          ")]
		public void EnsureValue_IsNotNullNorEmptyNorWhiteSpace_WithSpecificExceptionAndSpecificMessage_WhenInvalidMessage_ThrowsAnException(string errorMessage)
		{
			var exception = Assert.Throws<ArgumentException>(() => Ensure.Value.IsNotNullNorEmptyNorWhiteSpace<TestException>(null, errorMessage));
			Assert.True(exception.Message.StartsWith(Resources.AppMessages.ErrorMessageNotProvided, StringComparison.InvariantCultureIgnoreCase));
		}

		#endregion
	}
}