namespace MGK.Acceptance;

/// <summary>
/// Ensures that values or objects complies with what is expected.
/// </summary>
public static partial class Ensure
{
	/// <summary>
	/// Ensures that values complies with what is expected.
	/// </summary>
	public static class Value
	{
		/// <summary>
		/// Ensure that a value is not empty, otherwise throws an exception.
		/// </summary>
		/// <param name="value">The value.</param>
		public static void IsNotEmpty(Guid value)
			=> IsNotEmpty<Exception>(value, AcceptanceResources.AcceptanceMessagesResources.ErrorEmpty);

		/// <summary>
		/// Ensure that a value is not empty, otherwise throws an exception with a specific message.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="errorMessage">The error message to throw.</param>
		public static void IsNotEmpty(Guid value, string errorMessage)
			=> IsNotEmpty<Exception>(value, errorMessage);

		/// <summary>
		/// Ensure that a value is not empty, otherwise throws a specific exception.
		/// </summary>
		/// <typeparam name="T">The type of the specific exception.</typeparam>
		/// <param name="value">The value.</param>
		public static void IsNotEmpty<T>(Guid value)
			where T : Exception
				=> IsNotEmpty<T>(value, AcceptanceResources.AcceptanceMessagesResources.ErrorEmpty);

		/// <summary>
		/// Ensure that a value is not empty, otherwise throws an exception with a specific message.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="errorMessage">The error message to throw.</param>
		public static void IsNotEmpty<T>(Guid value, string errorMessage)
			where T : Exception
				=> EvaluateValue<T>(value.IsEmpty(), errorMessage);

		/// <summary>
		/// Ensure that a value is not null, otherwise throws an exception.
		/// </summary>
		/// <param name="value">The value.</param>
		public static void IsNotNull(object value)
			=> IsNotNull<Exception>(value, AcceptanceResources.AcceptanceMessagesResources.ErrorNull);

		/// <summary>
		/// Ensure that a value is not null, otherwise throws an exception with a specific message.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="errorMessage">The error message to throw.</param>
		public static void IsNotNull(object value, string errorMessage)
			=> IsNotNull<Exception>(value, errorMessage);

		/// <summary>
		/// Ensure that a value is not null, otherwise throws a specific exception.
		/// </summary>
		/// <typeparam name="T">The type of the specific exception.</typeparam>
		/// <param name="value">The value.</param>
		public static void IsNotNull<T>(object value)
			where T : Exception
				=> IsNotNull<T>(value, AcceptanceResources.AcceptanceMessagesResources.ErrorNull);

		/// <summary>
		/// Ensure that a value is not null, otherwise throws a specific exception with a specific message.
		/// </summary>
		/// <typeparam name="T">The type of the specific exception.</typeparam>
		/// <param name="value">The value.</param>
		/// <param name="errorMessage">The error message to throw.</param>
		public static void IsNotNull<T>(object value, string errorMessage)
			where T : Exception
				=> EvaluateValue<T>(value == null, errorMessage);

		/// <summary>
		/// Ensure that a value is not null nor empty, otherwise throws an exception.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="errorMessage">The error message to throw.</param>
		public static void IsNotNullNorEmpty(string value)
			=> IsNotNullNorEmpty<Exception>(value, AcceptanceResources.AcceptanceMessagesResources.ErrorNullNorEmpty);

		/// <summary>
		/// Ensure that a value is not null nor empty, otherwise throws an exception with a specific message.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="errorMessage">The error message to throw.</param>
		public static void IsNotNullNorEmpty(string value, string errorMessage)
			=> IsNotNullNorEmpty<Exception>(value, errorMessage);

		/// <summary>
		/// Ensure that a value is not null nor empty, otherwise throws a specific exception.
		/// </summary>
		/// <typeparam name="T">The type of the specific exception.</typeparam>
		/// <param name="value">The value.</param>
		public static void IsNotNullNorEmpty<T>(string value)
			where T : Exception
				=> IsNotNullNorEmpty<T>(value, AcceptanceResources.AcceptanceMessagesResources.ErrorNullNorEmpty);

		/// <summary>
		/// Ensure that a value is not null nor empty, otherwise throws a specific exception with a specific message.
		/// </summary>
		/// <typeparam name="T">The type of the specific exception.</typeparam>
		/// <param name="value">The value.</param>
		/// <param name="errorMessage">The error message to throw.</param>
		public static void IsNotNullNorEmpty<T>(string value, string errorMessage)
			where T : Exception
				=> EvaluateValue<T>(value.IsNullOrEmpty(), errorMessage);

		/// <summary>
		/// Ensure that a list of values is not null nor empty, otherwise throws a specific exception.
		/// </summary>
		/// <typeparam name="TValue">The type of the value.</typeparam>
		/// <param name="value">The value.</param>
		public static void IsNotNullNorEmpty<TValue>(IEnumerable<TValue> value)
			=> IsNotNullNorEmpty<Exception, TValue>(value, AcceptanceResources.AcceptanceMessagesResources.ErrorNullNorEmpty);

		/// <summary>
		/// Ensure that a list of values is not null nor empty, otherwise throws a specific exception with a specific message.
		/// </summary>
		/// <typeparam name="TValue">The type of the value.</typeparam>
		/// <param name="value">The value.</param>
		/// <param name="errorMessage">The error message to throw.</param>
		public static void IsNotNullNorEmpty<TValue>(IEnumerable<TValue> value, string errorMessage)
			=> IsNotNullNorEmpty<Exception, TValue>(value, errorMessage);

		/// <summary>
		/// Ensure that a list of values is not null nor empty, otherwise throws a specific exception.
		/// </summary>
		/// <typeparam name="T">The type of the specific exception.</typeparam>
		/// <typeparam name="TValue">The type of the value.</typeparam>
		/// <param name="value">The value.</param>
		public static void IsNotNullNorEmpty<T, TValue>(IEnumerable<TValue> value)
			where T : Exception
				=> IsNotNullNorEmpty<T, TValue>(value, AcceptanceResources.AcceptanceMessagesResources.ErrorNullNorEmpty);

		/// <summary>
		/// Ensure that a list of values is not null nor empty, otherwise throws a specific exception with a specific message.
		/// </summary>
		/// <typeparam name="T">The type of the specific exception.</typeparam>
		/// <typeparam name="TValue">The type of the value.</typeparam>
		/// <param name="value">The value.</param>
		/// <param name="errorMessage">The error message to throw.</param>
		public static void IsNotNullNorEmpty<T, TValue>(IEnumerable<TValue> value, string errorMessage)
			where T : Exception
				=> EvaluateValue<T>(value.IsNullOrEmpty(), errorMessage);

		/// <summary>
		/// Ensure that a value is not null nor empty nor only white spaces, otherwise throws a specific exception.
		/// </summary>
		/// <param name="value">The value.</param>
		public static void IsNotNullNorEmptyNorWhiteSpace(string value)
			=> IsNotNullNorEmptyNorWhiteSpace<Exception>(value, AcceptanceResources.AcceptanceMessagesResources.ErrorNullNorEmptyNorWhiteSpace);

		/// <summary>
		/// Ensure that a value is not null nor empty nor only white spaces, otherwise throws a specific exception with a specific message.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="errorMessage">The error message to throw.</param>
		public static void IsNotNullNorEmptyNorWhiteSpace(string value, string errorMessage)
			=> IsNotNullNorEmptyNorWhiteSpace<Exception>(value, errorMessage);

		/// <summary>
		/// Ensure that a value is not null nor empty nor only white spaces, otherwise throws a specific exception.
		/// </summary>
		/// <typeparam name="T">The type of the specific exception.</typeparam>
		/// <param name="value">The value.</param>
		public static void IsNotNullNorEmptyNorWhiteSpace<T>(string value)
			where T : Exception
				=> IsNotNullNorEmptyNorWhiteSpace<T>(value, AcceptanceResources.AcceptanceMessagesResources.ErrorNullNorEmptyNorWhiteSpace);

		/// <summary>
		/// Ensure that a value is not null nor empty nor only white spaces, otherwise throws a specific exception with a specific message.
		/// </summary>
		/// <typeparam name="T">The type of the specific exception.</typeparam>
		/// <param name="value">The value.</param>
		/// <param name="errorMessage">The error message to throw.</param>
		public static void IsNotNullNorEmptyNorWhiteSpace<T>(string value, string errorMessage)
			where T : Exception
				=> EvaluateValue<T>(value.IsNullOrEmptyOrWhiteSpace(), errorMessage);

		/// <summary>
		/// Validate and evaluate a value and raise the proper exception if applicable.
		/// </summary>
		/// <param name="isValueObjectNotValid">True if the value of an object does not comply with the conditions.</param>
		/// <param name="errorMessage">The error message in case of an error.</param>
		private static void EvaluateValue<T>(bool isValueObjectNotValid, string errorMessage)
			where T : Exception
		{
			if (isValueObjectNotValid)
			{
				ValidateErrorMessage(errorMessage);
				Raise.Error.Generic<T>(errorMessage);
			}
		}
	}

	/// <summary>
	/// Validates that the error message has a value.
	/// </summary>
	/// <param name="errorMessage">The error message.</param>
	private static void ValidateErrorMessage(string errorMessage)
	{
		if (errorMessage.IsNullOrEmptyOrWhiteSpace())
			Raise.Error.Parameter(nameof(errorMessage), AcceptanceResources.AcceptanceMessagesResources.ErrorMessageNotProvided);
	}
}
