namespace MGK.Acceptance.Test;

public class EnsureValueTests
{
	private const string SpecificErrorMessage = "Specific message";

	#region IsNotEmpty

	[Test]
	public void EnsureValue_IsNotEmpty_WhenValidValue_EndsOk()
		=> Assert.DoesNotThrow(() => Ensure.Value.IsNotEmpty(Guid.NewGuid()));

	[Test]
	public void EnsureValue_IsNotEmpty_WhenInvalidValue_ThrowsAnException()
	{
		var exception = Assert.Throws<Exception>(() => Ensure.Value.IsNotEmpty(Guid.Empty));
		Assert.That(exception.Message, Is.EqualTo(AcceptanceResources.AcceptanceMessagesResources.ErrorEmpty));
	}

	[Test]
	public void EnsureValue_IsNotEmpty_WithSpecificMessage_WhenValidValue_EndsOk()
		=> Assert.DoesNotThrow(() => Ensure.Value.IsNotEmpty(Guid.NewGuid(), SpecificErrorMessage));

	[Test]
	public void EnsureValue_IsNotEmpty_WithSpecificMessage_WhenInvalidValue_ThrowsAnException()
	{
		var exception = Assert.Throws<Exception>(() => Ensure.Value.IsNotEmpty(Guid.Empty, SpecificErrorMessage));
		Assert.That(exception.Message, Is.EqualTo(SpecificErrorMessage));
	}

	[TestCase(null)]
	[TestCase("")]
	[TestCase("          ")]
	public void EnsureValue_IsNotEmpty_WithSpecificMessage_WhenInvalidMessage_ThrowsAnException(string errorMessage)
	{
		var exception = Assert.Throws<ArgumentException>(() => Ensure.Value.IsNotEmpty(Guid.Empty, errorMessage));
		Assert.That(exception.Message.StartsWith(AcceptanceResources.AcceptanceMessagesResources.ErrorMessageNotProvided, StringComparison.InvariantCultureIgnoreCase), Is.True);
	}

	[Test]
	public void EnsureValue_IsNotEmpty_WithSpecificException_WhenValidValue_EndsOk()
		=> Assert.DoesNotThrow(() => Ensure.Value.IsNotEmpty<TestException>(Guid.NewGuid()));

	[Test]
	public void EnsureValue_IsNotEmpty_WithSpecificException_WhenInvalidValue_ThrowsAnException()
	{
		var exception = Assert.Throws<TestException>(() => Ensure.Value.IsNotEmpty<TestException>(Guid.Empty));
		Assert.That(exception.Message, Is.EqualTo(AcceptanceResources.AcceptanceMessagesResources.ErrorEmpty));
	}

	[Test]
	public void EnsureValue_IsNotEmpty_WithSpecificExceptionAndSpecificMessage_WhenValidValue_EndsOk()
		=> Assert.DoesNotThrow(() => Ensure.Value.IsNotEmpty<TestException>(Guid.NewGuid(), SpecificErrorMessage));

	[Test]
	public void EnsureValue_IsNotEmpty_WithSpecificExceptionAndSpecificMessage_WhenInvalidValue_ThrowsAnException()
	{
		var exception = Assert.Throws<TestException>(() => Ensure.Value.IsNotEmpty<TestException>(Guid.Empty, SpecificErrorMessage));
		Assert.That(exception.Message, Is.EqualTo(SpecificErrorMessage));
	}

	[TestCase(null)]
	[TestCase("")]
	[TestCase("          ")]
	public void EnsureValue_IsNotEmpty_WithSpecificExceptionAndSpecificMessage_WhenInvalidMessage_ThrowsAnException(string errorMessage)
	{
		var exception = Assert.Throws<ArgumentException>(() => Ensure.Value.IsNotEmpty<TestException>(Guid.Empty, errorMessage));
		Assert.That(exception.Message.StartsWith(AcceptanceResources.AcceptanceMessagesResources.ErrorMessageNotProvided, StringComparison.InvariantCultureIgnoreCase), Is.True);
	}

	#endregion

	#region IsNotNull

	[Test]
	public void EnsureValue_IsNotNull_WhenValidValue_EndsOk()
		=> Assert.DoesNotThrow(() => Ensure.Value.IsNotNull(1));

	[Test]
	public void EnsureValue_IsNotNull_WhenInvalidValue_ThrowsAnException()
	{
		var exception = Assert.Throws<Exception>(() => Ensure.Value.IsNotNull(null));
		Assert.That(exception.Message, Is.EqualTo(AcceptanceResources.AcceptanceMessagesResources.ErrorNull));
	}

	[Test]
	public void EnsureValue_IsNotNull_WithSpecificMessage_WhenValidValue_EndsOk()
		=> Assert.DoesNotThrow(() => Ensure.Value.IsNotNull(1, SpecificErrorMessage));

	[Test]
	public void EnsureValue_IsNotNull_WithSpecificMessage_WhenInvalidValue_ThrowsAnException()
	{
		var exception = Assert.Throws<Exception>(() => Ensure.Value.IsNotNull(null, SpecificErrorMessage));
		Assert.That(exception.Message, Is.EqualTo(SpecificErrorMessage));
	}

	[TestCase(null)]
	[TestCase("")]
	[TestCase("          ")]
	public void EnsureValue_IsNotNull_WithSpecificMessage_WhenInvalidMessage_ThrowsAnException(string errorMessage)
	{
		var exception = Assert.Throws<ArgumentException>(() => Ensure.Value.IsNotNull(null, errorMessage));
		Assert.That(exception.Message.StartsWith(AcceptanceResources.AcceptanceMessagesResources.ErrorMessageNotProvided, StringComparison.InvariantCultureIgnoreCase), Is.True);
	}

	[Test]
	public void EnsureValue_IsNotNull_WithSpecificException_WhenValidValue_EndsOk()
		=> Assert.DoesNotThrow(() => Ensure.Value.IsNotNull<TestException>(1));

	[Test]
	public void EnsureValue_IsNotNull_WithSpecificException_WhenInvalidValue_ThrowsAnException()
	{
		var exception = Assert.Throws<TestException>(() => Ensure.Value.IsNotNull<TestException>(null));
		Assert.That(exception.Message, Is.EqualTo(AcceptanceResources.AcceptanceMessagesResources.ErrorNull));
	}

	[Test]
	public void EnsureValue_IsNotNull_WithSpecificExceptionAndSpecificMessage_WhenValidValue_EndsOk()
		=> Assert.DoesNotThrow(() => Ensure.Value.IsNotNull<TestException>(1, SpecificErrorMessage));

	[Test]
	public void EnsureValue_IsNotNull_WithSpecificExceptionAndSpecificMessage_WhenInvalidValue_ThrowsAnException()
	{
		var exception = Assert.Throws<TestException>(() => Ensure.Value.IsNotNull<TestException>(null, SpecificErrorMessage));
		Assert.That(exception.Message, Is.EqualTo(SpecificErrorMessage));
	}

	[TestCase(null)]
	[TestCase("")]
	[TestCase("          ")]
	public void EnsureValue_IsNotNull_WithSpecificExceptionAndSpecificMessage_WhenInvalidMessage_ThrowsAnException(string errorMessage)
	{
		var exception = Assert.Throws<ArgumentException>(() => Ensure.Value.IsNotNull<TestException>(null, errorMessage));
		Assert.That(exception.Message.StartsWith(AcceptanceResources.AcceptanceMessagesResources.ErrorMessageNotProvided, StringComparison.InvariantCultureIgnoreCase), Is.True);
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
		Assert.That(exception.Message, Is.EqualTo(AcceptanceResources.AcceptanceMessagesResources.ErrorNullNorEmpty));

		exception = Assert.Throws<Exception>(() => Ensure.Value.IsNotNullNorEmpty(enumerable));
		Assert.That(exception.Message, Is.EqualTo(AcceptanceResources.AcceptanceMessagesResources.ErrorNullNorEmpty));
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
		Assert.That(exception.Message, Is.EqualTo(SpecificErrorMessage));

		exception = Assert.Throws<Exception>(() => Ensure.Value.IsNotNullNorEmpty(enumerable, SpecificErrorMessage));
		Assert.That(exception.Message, Is.EqualTo(SpecificErrorMessage));
	}

	[TestCase(null)]
	[TestCase("")]
	[TestCase("          ")]
	public void EnsureValue_IsNotNullNorEmpty_WithSpecificMessage_WhenInvalidMessage_ThrowsAnException(string errorMessage)
	{
		var exception = Assert.Throws<ArgumentException>(() => Ensure.Value.IsNotNullNorEmpty("", errorMessage));
		Assert.That(exception.Message.StartsWith(AcceptanceResources.AcceptanceMessagesResources.ErrorMessageNotProvided, StringComparison.InvariantCultureIgnoreCase), Is.True);

		exception = Assert.Throws<ArgumentException>(() => Ensure.Value.IsNotNullNorEmpty(Array.Empty<int>(), errorMessage));
		Assert.That(exception.Message.StartsWith(AcceptanceResources.AcceptanceMessagesResources.ErrorMessageNotProvided, StringComparison.InvariantCultureIgnoreCase), Is.True);
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
		Assert.That(exception.Message, Is.EqualTo(AcceptanceResources.AcceptanceMessagesResources.ErrorNullNorEmpty));

		exception = Assert.Throws<TestException>(() => Ensure.Value.IsNotNullNorEmpty<TestException, int>(enumerable));
		Assert.That(exception.Message, Is.EqualTo(AcceptanceResources.AcceptanceMessagesResources.ErrorNullNorEmpty));
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
		Assert.That(exception.Message, Is.EqualTo(SpecificErrorMessage));

		exception = Assert.Throws<TestException>(() => Ensure.Value.IsNotNullNorEmpty<TestException, int>(enumerable, SpecificErrorMessage));
		Assert.That(exception.Message, Is.EqualTo(SpecificErrorMessage));
	}

	[TestCase(null)]
	[TestCase("")]
	[TestCase("          ")]
	public void EnsureValue_IsNotNullNorEmpty_WithSpecificExceptionAndSpecificMessage_WhenInvalidMessage_ThrowsAnException(string errorMessage)
	{
		var exception = Assert.Throws<ArgumentException>(() => Ensure.Value.IsNotNullNorEmpty<TestException>("", errorMessage));
		Assert.That(exception.Message.StartsWith(AcceptanceResources.AcceptanceMessagesResources.ErrorMessageNotProvided, StringComparison.InvariantCultureIgnoreCase), Is.True);

		exception = Assert.Throws<ArgumentException>(() => Ensure.Value.IsNotNullNorEmpty<TestException, int>(Array.Empty<int>(), errorMessage));
		Assert.That(exception.Message.StartsWith(AcceptanceResources.AcceptanceMessagesResources.ErrorMessageNotProvided, StringComparison.InvariantCultureIgnoreCase), Is.True);
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
		Assert.That(exception.Message, Is.EqualTo(AcceptanceResources.AcceptanceMessagesResources.ErrorNullNorEmptyNorWhiteSpace));
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
		Assert.That(exception.Message, Is.EqualTo(SpecificErrorMessage));
	}

	[TestCase(null)]
	[TestCase("")]
	[TestCase("          ")]
	public void EnsureValue_IsNotNullNorEmptyNorWhiteSpace_WithSpecificMessage_WhenInvalidMessage_ThrowsAnException(string errorMessage)
	{
		var exception = Assert.Throws<ArgumentException>(() => Ensure.Value.IsNotNullNorEmptyNorWhiteSpace(null, errorMessage));
		Assert.That(exception.Message.StartsWith(AcceptanceResources.AcceptanceMessagesResources.ErrorMessageNotProvided, StringComparison.InvariantCultureIgnoreCase), Is.True);
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
		Assert.That(exception.Message, Is.EqualTo(AcceptanceResources.AcceptanceMessagesResources.ErrorNullNorEmptyNorWhiteSpace));
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
		Assert.That(exception.Message, Is.EqualTo(SpecificErrorMessage));
	}

	[TestCase(null)]
	[TestCase("")]
	[TestCase("          ")]
	public void EnsureValue_IsNotNullNorEmptyNorWhiteSpace_WithSpecificExceptionAndSpecificMessage_WhenInvalidMessage_ThrowsAnException(string errorMessage)
	{
		var exception = Assert.Throws<ArgumentException>(() => Ensure.Value.IsNotNullNorEmptyNorWhiteSpace<TestException>(null, errorMessage));
		Assert.That(exception.Message.StartsWith(AcceptanceResources.AcceptanceMessagesResources.ErrorMessageNotProvided, StringComparison.InvariantCultureIgnoreCase), Is.True);
	}

	#endregion
}