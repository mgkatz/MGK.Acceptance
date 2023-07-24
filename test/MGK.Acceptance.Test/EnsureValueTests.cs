using System.Linq;

namespace MGK.Acceptance.Test;

public class EnsureValueTests
{
	private const string SpecificErrorMessage = "Specific message";

    #region IsNotEmpty

    [Test]
    public void EnsureValue_IsNotEmpty_WhenValidValue_EndsOk()
    {
        Assert.DoesNotThrow(() =>
        {
            var testValue = Guid.NewGuid();
            Guid returnedValue = Ensure.Value.IsNotEmpty(testValue);
            Assert.That(returnedValue, Is.EqualTo(testValue));
        });
    }

    [Test]
	public void EnsureValue_IsNotEmpty_WhenInvalidValue_ThrowsAnException()
	{
		var exception = Assert.Throws<Exception>(() => Ensure.Value.IsNotEmpty(Guid.Empty));
		Assert.That(exception.Message, Is.EqualTo(AcceptanceResources.AcceptanceMessagesResources.ErrorEmpty));
	}

    [Test]
    public void EnsureValue_IsNotEmpty_WithSpecificMessage_WhenValidValue_EndsOk()
    {
        Assert.DoesNotThrow(() =>
        {
            var testValue = Guid.NewGuid();
            Guid returnedValue = Ensure.Value.IsNotEmpty(testValue, SpecificErrorMessage);
            Assert.That(returnedValue, Is.EqualTo(testValue));
        });
    }

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
    {
        Assert.DoesNotThrow(() =>
        {
            var testValue = Guid.NewGuid();
            Guid returnedValue = Ensure.Value.IsNotEmpty<TestException>(testValue);
            Assert.That(returnedValue, Is.EqualTo(testValue));
        });
    }

    [Test]
	public void EnsureValue_IsNotEmpty_WithSpecificException_WhenInvalidValue_ThrowsAnException()
	{
		var exception = Assert.Throws<TestException>(() => Ensure.Value.IsNotEmpty<TestException>(Guid.Empty));
		Assert.That(exception.Message, Is.EqualTo(AcceptanceResources.AcceptanceMessagesResources.ErrorEmpty));
	}

    [Test]
    public void EnsureValue_IsNotEmpty_WithSpecificExceptionAndSpecificMessage_WhenValidValue_EndsOk()
    {
        Assert.DoesNotThrow(() =>
        {
            var testValue = Guid.NewGuid();
            Guid returnedValue = Ensure.Value.IsNotEmpty<TestException>(testValue, SpecificErrorMessage);
            Assert.That(returnedValue, Is.EqualTo(testValue));
        });
    }

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
    {
        Assert.DoesNotThrow(() =>
        {
            object testValue = 1;
            object returnedValue = Ensure.Value.IsNotNullObj(testValue);
            Assert.That(returnedValue, Is.EqualTo(testValue));

            DateTime? genericRestValue = DateTime.Now;
            DateTime? genericReturnedValue = Ensure.Value.IsNotNull(genericRestValue);
            Assert.That(genericReturnedValue, Is.EqualTo(genericRestValue));
        });
    }

    [Test]
	public void EnsureValue_IsNotNull_WhenInvalidValue_ThrowsAnException()
	{
		var exception = Assert.Throws<Exception>(() => Ensure.Value.IsNotNullObj(null));
		Assert.That(exception.Message, Is.EqualTo(AcceptanceResources.AcceptanceMessagesResources.ErrorNull));

        exception = Assert.Throws<Exception>(() => Ensure.Value.IsNotNull<DateTime?>(null));
        Assert.That(exception.Message, Is.EqualTo(AcceptanceResources.AcceptanceMessagesResources.ErrorNull));
    }

    [Test]
    public void EnsureValue_IsNotNull_WithSpecificMessage_WhenValidValue_EndsOk()
    {
        Assert.DoesNotThrow(() =>
        {
            object testValue = 1;
            object returnedValue = Ensure.Value.IsNotNullObj(testValue, SpecificErrorMessage);
            Assert.That(returnedValue, Is.EqualTo(testValue));

            DateTime? genericRestValue = DateTime.Now;
            DateTime? genericReturnedValue = Ensure.Value.IsNotNull(genericRestValue, SpecificErrorMessage);
            Assert.That(genericReturnedValue, Is.EqualTo(genericRestValue));
        });
    }

    [Test]
	public void EnsureValue_IsNotNull_WithSpecificMessage_WhenInvalidValue_ThrowsAnException()
	{
		var exception = Assert.Throws<Exception>(() => Ensure.Value.IsNotNullObj(null, SpecificErrorMessage));
		Assert.That(exception.Message, Is.EqualTo(SpecificErrorMessage));

        exception = Assert.Throws<Exception>(() => Ensure.Value.IsNotNull<DateTime?>(null, SpecificErrorMessage));
        Assert.That(exception.Message, Is.EqualTo(SpecificErrorMessage));
    }

    [TestCase(null)]
	[TestCase("")]
	[TestCase("          ")]
	public void EnsureValue_IsNotNull_WithSpecificMessage_WhenInvalidMessage_ThrowsAnException(string errorMessage)
	{
		var exception = Assert.Throws<ArgumentException>(() => Ensure.Value.IsNotNullObj(null, errorMessage));
		Assert.That(exception.Message.StartsWith(AcceptanceResources.AcceptanceMessagesResources.ErrorMessageNotProvided, StringComparison.InvariantCultureIgnoreCase), Is.True);

        exception = Assert.Throws<ArgumentException>(() => Ensure.Value.IsNotNull<DateTime?>(null, errorMessage));
        Assert.That(exception.Message.StartsWith(AcceptanceResources.AcceptanceMessagesResources.ErrorMessageNotProvided, StringComparison.InvariantCultureIgnoreCase), Is.True);
    }

    [Test]
    public void EnsureValue_IsNotNull_WithSpecificException_WhenValidValue_EndsOk()
    {
        Assert.DoesNotThrow(() =>
        {
            object testValue = 1;
            object returnedValue = Ensure.Value.IsNotNullObj<TestException>(testValue);
            Assert.That(returnedValue, Is.EqualTo(testValue));

            DateTime? genericRestValue = DateTime.Now;
            DateTime? genericReturnedValue = Ensure.Value.IsNotNull<TestException, DateTime?>(genericRestValue);
            Assert.That(genericReturnedValue, Is.EqualTo(genericRestValue));
        });
    }

    [Test]
	public void EnsureValue_IsNotNull_WithSpecificException_WhenInvalidValue_ThrowsAnException()
	{
		var exception = Assert.Throws<TestException>(() => Ensure.Value.IsNotNullObj<TestException>(null));
		Assert.That(exception.Message, Is.EqualTo(AcceptanceResources.AcceptanceMessagesResources.ErrorNull));

        exception = Assert.Throws<TestException>(() => Ensure.Value.IsNotNull<TestException, DateTime?>(null));
        Assert.That(exception.Message, Is.EqualTo(AcceptanceResources.AcceptanceMessagesResources.ErrorNull));
    }

    [Test]
    public void EnsureValue_IsNotNull_WithSpecificExceptionAndSpecificMessage_WhenValidValue_EndsOk()
    {
        Assert.DoesNotThrow(() =>
        {
            object testValue = 1;
            object returnedValue = Ensure.Value.IsNotNullObj<TestException>(testValue, SpecificErrorMessage);
            Assert.That(returnedValue, Is.EqualTo(testValue));

            DateTime? genericRestValue = DateTime.Now;
            DateTime? genericReturnedValue = Ensure.Value.IsNotNull<TestException, DateTime?>(genericRestValue, SpecificErrorMessage);
            Assert.That(genericReturnedValue, Is.EqualTo(genericRestValue));
        });
    }

    [Test]
	public void EnsureValue_IsNotNull_WithSpecificExceptionAndSpecificMessage_WhenInvalidValue_ThrowsAnException()
	{
		var exception = Assert.Throws<TestException>(() => Ensure.Value.IsNotNullObj<TestException>(null, SpecificErrorMessage));
		Assert.That(exception.Message, Is.EqualTo(SpecificErrorMessage));

        exception = Assert.Throws<TestException>(() => Ensure.Value.IsNotNull<TestException, DateTime?>(null, SpecificErrorMessage));
        Assert.That(exception.Message, Is.EqualTo(SpecificErrorMessage));
    }

    [TestCase(null)]
	[TestCase("")]
	[TestCase("          ")]
	public void EnsureValue_IsNotNull_WithSpecificExceptionAndSpecificMessage_WhenInvalidMessage_ThrowsAnException(string errorMessage)
	{
		var exception = Assert.Throws<ArgumentException>(() => Ensure.Value.IsNotNullObj<TestException>(null, errorMessage));
		Assert.That(exception.Message.StartsWith(AcceptanceResources.AcceptanceMessagesResources.ErrorMessageNotProvided, StringComparison.InvariantCultureIgnoreCase), Is.True);

        exception = Assert.Throws<ArgumentException>(() => Ensure.Value.IsNotNull<TestException, DateTime?>(null, errorMessage));
        Assert.That(exception.Message.StartsWith(AcceptanceResources.AcceptanceMessagesResources.ErrorMessageNotProvided, StringComparison.InvariantCultureIgnoreCase), Is.True);
    }

    #endregion

    #region IsNotNullNorEmpty

    [Test]
	public void EnsureValue_IsNotNullNorEmpty_WhenValidValue_EndsOk()
	{
        Assert.DoesNotThrow(() =>
        {
            const string testValue = "qwerty";
            string returnedValue = Ensure.Value.IsNotNullNorEmpty(testValue);
            Assert.That(returnedValue, Is.EqualTo(testValue));

            var enumerableTestValue = new int[] { 1, 2, 3 };
            IEnumerable<int> enumerableReturnedValue = Ensure.Value.IsNotNullNorEmpty(enumerableTestValue);
            Assert.That(enumerableReturnedValue.SequenceEqual(enumerableTestValue), Is.True);
        });
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
        Assert.DoesNotThrow(() =>
        {
            const string testValue = "qwerty";
            string returnedValue = Ensure.Value.IsNotNullNorEmpty(testValue, SpecificErrorMessage);
            Assert.That(returnedValue, Is.EqualTo(testValue));

            var enumerableTestValue = new int[] { 1, 2, 3 };
            IEnumerable<int> enumerableReturnedValue = Ensure.Value.IsNotNullNorEmpty(enumerableTestValue, SpecificErrorMessage);
            Assert.That(enumerableReturnedValue.SequenceEqual(enumerableTestValue), Is.True);
        });
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
        Assert.DoesNotThrow(() =>
        {
            const string testValue = "qwerty";
            string returnedValue = Ensure.Value.IsNotNullNorEmpty<TestException>(testValue);
            Assert.That(returnedValue, Is.EqualTo(testValue));

            var enumerableTestValue = new int[] { 1, 2, 3 };
            IEnumerable<int> enumerableReturnedValue = Ensure.Value.IsNotNullNorEmpty<TestException, int>(enumerableTestValue);
            Assert.That(enumerableReturnedValue.SequenceEqual(enumerableTestValue), Is.True);
        });
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
        Assert.DoesNotThrow(() =>
        {
            const string testValue = "qwerty";
            string returnedValue = Ensure.Value.IsNotNullNorEmpty<TestException>(testValue, SpecificErrorMessage);
            Assert.That(returnedValue, Is.EqualTo(testValue));

            var enumerableTestValue = new int[] { 1, 2, 3 };
            IEnumerable<int> enumerableReturnedValue = Ensure.Value.IsNotNullNorEmpty<TestException, int>(enumerableTestValue, SpecificErrorMessage);
            Assert.That(enumerableReturnedValue.SequenceEqual(enumerableTestValue), Is.True);
        });
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
    {
        Assert.DoesNotThrow(() =>
        {
            const string testValue = "qwerty";
            string returnedValue = Ensure.Value.IsNotNullNorEmptyNorWhiteSpace(testValue);
            Assert.That(returnedValue, Is.EqualTo(testValue));
        });
    }

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
    {
        Assert.DoesNotThrow(() =>
        {
            const string testValue = "qwerty";
            string returnedValue = Ensure.Value.IsNotNullNorEmptyNorWhiteSpace(testValue, SpecificErrorMessage);
            Assert.That(returnedValue, Is.EqualTo(testValue));
        });
    }

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
    {
        Assert.DoesNotThrow(() =>
        {
            const string testValue = "qwerty";
            string returnedValue = Ensure.Value.IsNotNullNorEmptyNorWhiteSpace<TestException>(testValue);
            Assert.That(returnedValue, Is.EqualTo(testValue));
        });
    }

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
    {
        Assert.DoesNotThrow(() =>
        {
            const string testValue = "qwerty";
            string returnedValue = Ensure.Value.IsNotNullNorEmptyNorWhiteSpace<TestException>(testValue, SpecificErrorMessage);
            Assert.That(returnedValue, Is.EqualTo(testValue));
        });
    }

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

    #region HasToComplyWith
    [Test]
    public void EnsureValue_HasToComplyWith_WhenValidParameters_EndsOk()
        => Assert.DoesNotThrow(() => Ensure.Value.HasToComplyWith(() => 1 == 1, SpecificErrorMessage));

    [Test]
    public void EnsureValue_HasToComplyWith_WithSpecificArgumentException_WhenValidParameters_EndsOk()
        => Assert.DoesNotThrow(() => Ensure.Value.HasToComplyWith<TestException>(() => 1 == 1, SpecificErrorMessage));

    [TestCase(null)]
    [TestCase("")]
    [TestCase("          ")]
    public void EnsureValue_HasToComplyWith_WhenInvalidErrorMessage_ThrowsAnException(string errorMessage)
    {
        var exception = Assert.Throws<ArgumentException>(() => Ensure.Value.HasToComplyWith(() => 1 == 1, errorMessage));
        Assert.That(exception.Message.StartsWith(AcceptanceResources.AcceptanceMessagesResources.ErrorMessageNotProvided, StringComparison.InvariantCultureIgnoreCase), Is.True);
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase("          ")]
    public void EnsureValue_HasToComplyWith_WithSpecificArgumentException_WhenInvalidErrorMessge_ThrowsAnException(string errorMessage)
    {
        var exception = Assert.Throws<ArgumentException>(() => Ensure.Value.HasToComplyWith<TestArgumentException>(() => 1 == 1, errorMessage));
        Assert.That(exception.Message.StartsWith(AcceptanceResources.AcceptanceMessagesResources.ErrorMessageNotProvided, StringComparison.InvariantCultureIgnoreCase), Is.True);
    }

    [Test]
    public void EnsureValue_HasToComplyWith_WhenInvalidPredicate_ThrowsAnException()
    {
        var exception = Assert.Throws<ArgumentNullException>(() => Ensure.Value.HasToComplyWith(null, SpecificErrorMessage));
        Assert.That(exception.Message.StartsWith(AcceptanceResources.AcceptanceMessagesResources.ErrorCustomEvaluationPredicate, StringComparison.InvariantCultureIgnoreCase), Is.True);
    }

    [Test]
    public void EnsureValue_HasToComplyWith_WithSpecificArgumentException_WhenInvalidPredicate_ThrowsAnException()
    {
        var exception = Assert.Throws<ArgumentNullException>(() => Ensure.Value.HasToComplyWith<TestArgumentException>(null, SpecificErrorMessage));
        Assert.That(exception.Message.StartsWith(AcceptanceResources.AcceptanceMessagesResources.ErrorCustomEvaluationPredicate, StringComparison.InvariantCultureIgnoreCase), Is.True);
    }
    #endregion
}
