using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MGK.Acceptance.Test
{
	public class EnsureParameterTests
	{
		private const string SpecificErrorMessage = "Specific message";
		private const string ParamTestName = "ParamTest";

		#region IsNotEmpty

		[Test]
		public void EnsureParameter_IsNotEmpty_WhenValidParameter_EndsOk()
			=> Assert.DoesNotThrow(() => Ensure.Parameter.IsNotEmpty(Guid.NewGuid(), ParamTestName));

		[Test]
		public void EnsureParameter_IsNotEmpty_WhenInvalidParameter_ThrowsAnException()
		{
			var exception = Assert.Throws<ArgumentException>(() => Ensure.Parameter.IsNotEmpty(Guid.Empty, ParamTestName));
			Assert.True(exception.Message.StartsWith(Resources.AppMessages.ErrorParamEmpty, StringComparison.InvariantCultureIgnoreCase));
		}

		[TestCase(null)]
		[TestCase("")]
		[TestCase("          ")]
		public void EnsureParameter_IsNotEmpty_WhenInvalidParameterName_ThrowsAnException(string paramName)
		{
			var exception = Assert.Throws<ArgumentException>(() => Ensure.Parameter.IsNotEmpty(Guid.Empty, paramName));
			Assert.True(exception.Message.StartsWith(Resources.AppMessages.ErrorParamNameNotProvided, StringComparison.InvariantCultureIgnoreCase));
		}

		[Test]
		public void EnsureParameter_IsNotEmpty_WithSpecificMessage_WhenValidParameter_EndsOk()
			=> Assert.DoesNotThrow(() => Ensure.Parameter.IsNotEmpty(Guid.NewGuid(), ParamTestName, SpecificErrorMessage));

		[Test]
		public void EnsureParameter_IsNotEmpty_WithSpecificMessage_WhenInvalidParameter_ThrowsAnException()
		{
			var exception = Assert.Throws<ArgumentException>(() => Ensure.Parameter.IsNotEmpty(Guid.Empty, ParamTestName, SpecificErrorMessage));
			Assert.True(exception.Message.StartsWith(SpecificErrorMessage, StringComparison.InvariantCultureIgnoreCase));
		}

		[TestCase(null)]
		[TestCase("")]
		[TestCase("          ")]
		public void EnsureParameter_IsNotEmpty_WithSpecificMessage_WhenInvalidParameterName_ThrowsAnException(string paramName)
		{
			var exception = Assert.Throws<ArgumentException>(() => Ensure.Parameter.IsNotEmpty(Guid.Empty, paramName, SpecificErrorMessage));
			Assert.True(exception.Message.StartsWith(Resources.AppMessages.ErrorParamNameNotProvided, StringComparison.InvariantCultureIgnoreCase));
		}

		[TestCase(null)]
		[TestCase("")]
		[TestCase("          ")]
		public void EnsureParameter_IsNotEmpty_WithSpecificMessage_WhenInvalidMessage_ThrowsAnException(string errorMessage)
		{
			var exception = Assert.Throws<ArgumentException>(() => Ensure.Parameter.IsNotEmpty(Guid.Empty, ParamTestName, errorMessage));
			Assert.True(exception.Message.StartsWith(Resources.AppMessages.ErrorMessageNotProvided, StringComparison.InvariantCultureIgnoreCase));
		}

		#endregion

		#region IsNotNull

		[Test]
		public void EnsureParameter_IsNotNull_WhenValidParameter_EndsOk()
			=> Assert.DoesNotThrow(() => Ensure.Parameter.IsNotNull(1, ParamTestName));

		[Test]
		public void EnsureParameter_IsNotNull_WhenInvalidParameter_ThrowsAnException()
		{
			var exception = Assert.Throws<ArgumentNullException>(() => Ensure.Parameter.IsNotNull(null, ParamTestName));
			Assert.True(exception.Message.StartsWith(Resources.AppMessages.ErrorParamNull, StringComparison.InvariantCultureIgnoreCase));
		}

		[TestCase(null)]
		[TestCase("")]
		[TestCase("          ")]
		public void EnsureParameter_IsNotNull_WhenInvalidParameterName_ThrowsAnException(string paramName)
		{
			var exception = Assert.Throws<ArgumentException>(() => Ensure.Parameter.IsNotNull(null, paramName));
			Assert.True(exception.Message.StartsWith(Resources.AppMessages.ErrorParamNameNotProvided, StringComparison.InvariantCultureIgnoreCase));
		}

		[Test]
		public void EnsureParameter_IsNotNull_WithSpecificMessage_WhenValidParameter_EndsOk()
			=> Assert.DoesNotThrow(() => Ensure.Parameter.IsNotNull(1, ParamTestName, SpecificErrorMessage));

		[Test]
		public void EnsureParameter_IsNotNull_WithSpecificMessage_WhenInvalidParameter_ThrowsAnException()
		{
			var exception = Assert.Throws<ArgumentNullException>(() => Ensure.Parameter.IsNotNull(null, ParamTestName, SpecificErrorMessage));
			Assert.True(exception.Message.StartsWith(SpecificErrorMessage, StringComparison.InvariantCultureIgnoreCase));
		}

		[TestCase(null)]
		[TestCase("")]
		[TestCase("          ")]
		public void EnsureParameter_IsNotNull_WithSpecificMessage_WhenInvalidParameterName_ThrowsAnException(string paramName)
		{
			var exception = Assert.Throws<ArgumentException>(() => Ensure.Parameter.IsNotNull(null, paramName, SpecificErrorMessage));
			Assert.True(exception.Message.StartsWith(Resources.AppMessages.ErrorParamNameNotProvided, StringComparison.InvariantCultureIgnoreCase));
		}

		[TestCase(null)]
		[TestCase("")]
		[TestCase("          ")]
		public void EnsureParameter_IsNotNull_WithSpecificMessage_WhenInvalidMessage_ThrowsAnException(string errorMessage)
		{
			var exception = Assert.Throws<ArgumentException>(() => Ensure.Parameter.IsNotNull(null, ParamTestName, errorMessage));
			Assert.True(exception.Message.StartsWith(Resources.AppMessages.ErrorMessageNotProvided, StringComparison.InvariantCultureIgnoreCase));
		}

		#endregion

		#region IsNotNullNorEmpty

		[Test]
		public void EnsureParameter_IsNotNullNorEmpty_WhenValidParameter_EndsOk()
		{
			Assert.DoesNotThrow(() => Ensure.Parameter.IsNotNullNorEmpty("qwerty", ParamTestName));
			Assert.DoesNotThrow(() => Ensure.Parameter.IsNotNullNorEmpty(new int[] { 1, 2, 3 }, ParamTestName));
		}

		[TestCase(null, null)]
		[TestCase("", new int[0])]
		public void EnsureParameter_IsNotNullNorEmpty_WhenInvalidParameter_ThrowsAnException(string text, IEnumerable<int> enumerable)
		{
			var exception = Assert.Throws<ArgumentException>(() => Ensure.Parameter.IsNotNullNorEmpty(text, ParamTestName));
			Assert.True(exception.Message.StartsWith(Resources.AppMessages.ErrorParamNullNorEmpty, StringComparison.InvariantCultureIgnoreCase));

			exception = Assert.Throws<ArgumentException>(() => Ensure.Parameter.IsNotNullNorEmpty(enumerable, ParamTestName));
			Assert.True(exception.Message.StartsWith(Resources.AppMessages.ErrorParamNullNorEmpty, StringComparison.InvariantCultureIgnoreCase));
		}

		[TestCase(null)]
		[TestCase("")]
		[TestCase("          ")]
		public void EnsureParameter_IsNotNullNorEmpty_WhenInvalidParameterName_ThrowsAnException(string paramName)
		{
			var exception = Assert.Throws<ArgumentException>(() => Ensure.Parameter.IsNotNullNorEmpty(null, paramName));
			Assert.True(exception.Message.StartsWith(Resources.AppMessages.ErrorParamNameNotProvided, StringComparison.InvariantCultureIgnoreCase));

			exception = Assert.Throws<ArgumentException>(() => Ensure.Parameter.IsNotNullNorEmpty(new int[0], paramName));
			Assert.True(exception.Message.StartsWith(Resources.AppMessages.ErrorParamNameNotProvided, StringComparison.InvariantCultureIgnoreCase));
		}

		[Test]
		public void EnsureParameter_IsNotNullNorEmpty_WithSpecificMessage_WhenValidParameter_EndsOk()
		{
			Assert.DoesNotThrow(() => Ensure.Parameter.IsNotNullNorEmpty("qwerty", ParamTestName, SpecificErrorMessage));
			Assert.DoesNotThrow(() => Ensure.Parameter.IsNotNullNorEmpty(new int[] { 1, 2, 3 }, ParamTestName, SpecificErrorMessage));
		}

		[TestCase(null, null)]
		[TestCase("", new int[0])]
		public void EnsureParameter_IsNotNullNorEmpty_WithSpecificMessage_WhenInvalidParameter_ThrowsAnException(string text, IEnumerable<int> enumerable)
		{
			var exception = Assert.Throws<ArgumentException>(() => Ensure.Parameter.IsNotNullNorEmpty(text, ParamTestName, SpecificErrorMessage));
			Assert.True(exception.Message.StartsWith(SpecificErrorMessage, StringComparison.InvariantCultureIgnoreCase));

			exception = Assert.Throws<ArgumentException>(() => Ensure.Parameter.IsNotNullNorEmpty(enumerable, ParamTestName, SpecificErrorMessage));
			Assert.True(exception.Message.StartsWith(SpecificErrorMessage, StringComparison.InvariantCultureIgnoreCase));
		}

		[TestCase(null)]
		[TestCase("")]
		[TestCase("          ")]
		public void EnsureParameter_IsNotNullNorEmpty_WithSpecificMessage_WhenInvalidParameterName_ThrowsAnException(string paramName)
		{
			var exception = Assert.Throws<ArgumentException>(() => Ensure.Parameter.IsNotNullNorEmpty(null, paramName, SpecificErrorMessage));
			Assert.True(exception.Message.StartsWith(Resources.AppMessages.ErrorParamNameNotProvided, StringComparison.InvariantCultureIgnoreCase));

			exception = Assert.Throws<ArgumentException>(() => Ensure.Parameter.IsNotNullNorEmpty(new int[0], paramName, SpecificErrorMessage));
			Assert.True(exception.Message.StartsWith(Resources.AppMessages.ErrorParamNameNotProvided, StringComparison.InvariantCultureIgnoreCase));
		}

		[TestCase(null)]
		[TestCase("")]
		[TestCase("          ")]
		public void EnsureParameter_IsNotNullNorEmpty_WithSpecificMessage_WhenInvalidMessage_ThrowsAnException(string errorMessage)
		{
			var exception = Assert.Throws<ArgumentException>(() => Ensure.Parameter.IsNotNullNorEmpty(null, ParamTestName, errorMessage));
			Assert.True(exception.Message.StartsWith(Resources.AppMessages.ErrorMessageNotProvided, StringComparison.InvariantCultureIgnoreCase));

			exception = Assert.Throws<ArgumentException>(() => Ensure.Parameter.IsNotNullNorEmpty(new int[0], ParamTestName, errorMessage));
			Assert.True(exception.Message.StartsWith(Resources.AppMessages.ErrorMessageNotProvided, StringComparison.InvariantCultureIgnoreCase));
		}

		#endregion

		#region IsNotNullNorEmptyNorWhiteSpace

		[Test]
		public void EnsureParameter_IsNotNullNorEmptyNorWhiteSpace_WhenValidParameter_EndsOk()
			=> Assert.DoesNotThrow(() => Ensure.Parameter.IsNotNullNorEmptyNorWhiteSpace("qwerty", ParamTestName));

		[TestCase(null)]
		[TestCase("")]
		[TestCase("          ")]
		public void EnsureParameter_IsNotNullNorEmptyNorWhiteSpace_WhenInvalidParameter_ThrowsAnException(string text)
		{
			var exception = Assert.Throws<ArgumentException>(() => Ensure.Parameter.IsNotNullNorEmptyNorWhiteSpace(text, ParamTestName));
			Assert.True(exception.Message.StartsWith(Resources.AppMessages.ErrorParamNullNorEmptyNorWhiteSpace, StringComparison.InvariantCultureIgnoreCase));
		}

		[TestCase(null)]
		[TestCase("")]
		[TestCase("          ")]
		public void EnsureParameter_IsNotNullNorEmptyNorWhiteSpace_WhenInvalidParameterName_ThrowsAnException(string paramName)
		{
			var exception = Assert.Throws<ArgumentException>(() => Ensure.Parameter.IsNotNullNorEmptyNorWhiteSpace(null, paramName));
			Assert.True(exception.Message.StartsWith(Resources.AppMessages.ErrorParamNameNotProvided, StringComparison.InvariantCultureIgnoreCase));
		}

		[Test]
		public void EnsureParameter_IsNotNullNorEmptyNorWhiteSpace_WithSpecificMessage_WhenValidParameter_EndsOk()
			=> Assert.DoesNotThrow(() => Ensure.Parameter.IsNotNullNorEmptyNorWhiteSpace("qwerty", ParamTestName, SpecificErrorMessage));

		[Test]
		public void EnsureParameter_IsNotNullNorEmptyNorWhiteSpace_WithSpecificMessage_WhenInvalidParameter_ThrowsAnException()
		{
			var exception = Assert.Throws<ArgumentException>(() => Ensure.Parameter.IsNotNullNorEmptyNorWhiteSpace(null, ParamTestName, SpecificErrorMessage));
			Assert.True(exception.Message.StartsWith(SpecificErrorMessage, StringComparison.InvariantCultureIgnoreCase));
		}

		[TestCase(null)]
		[TestCase("")]
		[TestCase("          ")]
		public void EnsureParameter_IsNotNullNorEmptyNorWhiteSpace_WithSpecificMessage_WhenInvalidParameterName_ThrowsAnException(string paramName)
		{
			var exception = Assert.Throws<ArgumentException>(() => Ensure.Parameter.IsNotNullNorEmptyNorWhiteSpace(null, paramName, SpecificErrorMessage));
			Assert.True(exception.Message.StartsWith(Resources.AppMessages.ErrorParamNameNotProvided, StringComparison.InvariantCultureIgnoreCase));
		}

		[TestCase(null)]
		[TestCase("")]
		[TestCase("          ")]
		public void EnsureParameter_IsNotNullNorEmptyNorWhiteSpace_WithSpecificMessage_WhenInvalidMessage_ThrowsAnException(string errorMessage)
		{
			var exception = Assert.Throws<ArgumentException>(() => Ensure.Parameter.IsNotNullNorEmptyNorWhiteSpace(null, ParamTestName, errorMessage));
			Assert.True(exception.Message.StartsWith(Resources.AppMessages.ErrorMessageNotProvided, StringComparison.InvariantCultureIgnoreCase));
		}

		#endregion
	}
}
