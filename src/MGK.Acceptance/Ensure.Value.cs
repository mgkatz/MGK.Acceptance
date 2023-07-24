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
        public static T Test<T>(T value) where T : class
        {
            return value;
        }

		/// <summary>
		/// Ensure that a value is not empty, otherwise throws an exception.
		/// </summary>
		/// <param name="value">The value.</param>
		public static Guid IsNotEmpty(Guid value)
			=> IsNotEmpty<Exception>(value, AcceptanceResources.AcceptanceMessagesResources.ErrorEmpty);

		/// <summary>
		/// Ensure that a value is not empty, otherwise throws an exception with a specific message.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="errorMessage">The error message to throw.</param>
		public static Guid IsNotEmpty(Guid value, string errorMessage)
			=> IsNotEmpty<Exception>(value, errorMessage);

        /// <summary>
        /// Ensure that a value is not empty, otherwise throws a specific exception.
        /// </summary>
        /// <typeparam name="TException">The type of the specific exception.</typeparam>
        /// <param name="value">The value.</param>
        public static Guid IsNotEmpty<TException>(Guid value)
			where TException : Exception
				=> IsNotEmpty<TException>(value, AcceptanceResources.AcceptanceMessagesResources.ErrorEmpty);

        /// <summary>
        /// Ensure that a value is not empty, otherwise throws an exception with a specific message.
        /// </summary>
        /// <typeparam name="TException">The type of the specific exception.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="errorMessage">The error message to throw.</param>
        public static Guid IsNotEmpty<TException>(Guid value, string errorMessage)
            where TException : Exception
        {
            EvaluateValue<TException>(value.IsEmpty(), errorMessage);
            return value;
        }

        /// <summary>
        /// Ensure that a value is not null, otherwise throws an exception.
        /// </summary>
        /// <param name="value">The value.</param>
        public static object IsNotNullObj(object value)
			=> IsNotNullObj<Exception>(value, AcceptanceResources.AcceptanceMessagesResources.ErrorNull);

		/// <summary>
		/// Ensure that a value is not null, otherwise throws an exception with a specific message.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="errorMessage">The error message to throw.</param>
		public static object IsNotNullObj(object value, string errorMessage)
			=> IsNotNullObj<Exception>(value, errorMessage);

        /// <summary>
        /// Ensure that a value is not null, otherwise throws a specific exception.
        /// </summary>
        /// <typeparam name="TException">The type of the specific exception.</typeparam>
        /// <param name="value">The value.</param>
        public static object IsNotNullObj<TException>(object value)
			where TException : Exception
				=> IsNotNullObj<TException>(value, AcceptanceResources.AcceptanceMessagesResources.ErrorNull);

        /// <summary>
        /// Ensure that a value is not null, otherwise throws a specific exception with a specific message.
        /// </summary>
        /// <typeparam name="TException">The type of the specific exception.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="errorMessage">The error message to throw.</param>
        public static object IsNotNullObj<TException>(object value, string errorMessage)
            where TException : Exception
        {
            EvaluateValue<TException>(value is null, errorMessage);
			return value;
        }

        /// <summary>
        /// Ensure that a value is not null, otherwise throws an exception.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="value">The value.</param>
        public static TValue IsNotNull<TValue>(TValue value)
            => IsNotNull<Exception, TValue>(value, AcceptanceResources.AcceptanceMessagesResources.ErrorNull);

        /// <summary>
        /// Ensure that a value is not null, otherwise throws an exception with a specific message.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="errorMessage">The error message to throw.</param>
        public static TValue IsNotNull<TValue>(TValue value, string errorMessage)
            => IsNotNull<Exception, TValue>(value, errorMessage);

        /// <summary>
        /// Ensure that a value is not null, otherwise throws a specific exception.
        /// </summary>
        /// <typeparam name="TException">The type of the specific exception.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="value">The value.</param>
        public static TValue IsNotNull<TException, TValue>(TValue value)
            where TException : Exception
                => IsNotNull<TException, TValue>(value, AcceptanceResources.AcceptanceMessagesResources.ErrorNull);

        /// <summary>
        /// Ensure that a value is not null, otherwise throws a specific exception with a specific message.
        /// </summary>
        /// <typeparam name="TException">The type of the specific exception.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="errorMessage">The error message to throw.</param>
        public static TValue IsNotNull<TException, TValue>(TValue value, string errorMessage)
            where TException : Exception
        {
            EvaluateValue<TException>(value is null, errorMessage);
            return value;
        }

        /// <summary>
        /// Ensure that a value is not null nor empty, otherwise throws an exception.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="errorMessage">The error message to throw.</param>
        public static string IsNotNullNorEmpty(string value)
			=> IsNotNullNorEmpty<Exception>(value, AcceptanceResources.AcceptanceMessagesResources.ErrorNullNorEmpty);

		/// <summary>
		/// Ensure that a value is not null nor empty, otherwise throws an exception with a specific message.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="errorMessage">The error message to throw.</param>
		public static string IsNotNullNorEmpty(string value, string errorMessage)
			=> IsNotNullNorEmpty<Exception>(value, errorMessage);

        /// <summary>
        /// Ensure that a value is not null nor empty, otherwise throws a specific exception.
        /// </summary>
        /// <typeparam name="TException">The type of the specific exception.</typeparam>
        /// <param name="value">The value.</param>
        public static string IsNotNullNorEmpty<TException>(string value)
			where TException : Exception
				=> IsNotNullNorEmpty<TException>(value, AcceptanceResources.AcceptanceMessagesResources.ErrorNullNorEmpty);

        /// <summary>
        /// Ensure that a value is not null nor empty, otherwise throws a specific exception with a specific message.
        /// </summary>
        /// <typeparam name="TException">The type of the specific exception.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="errorMessage">The error message to throw.</param>
        public static string IsNotNullNorEmpty<TException>(string value, string errorMessage)
            where TException : Exception
        {
            EvaluateValue<TException>(value.IsNullOrEmpty(), errorMessage);
			return value;
        }

        /// <summary>
        /// Ensure that a list of values is not null nor empty, otherwise throws a specific exception.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="value">The value.</param>
        public static IEnumerable<TValue> IsNotNullNorEmpty<TValue>(IEnumerable<TValue> value)
			=> IsNotNullNorEmpty<Exception, TValue>(value, AcceptanceResources.AcceptanceMessagesResources.ErrorNullNorEmpty);

		/// <summary>
		/// Ensure that a list of values is not null nor empty, otherwise throws a specific exception with a specific message.
		/// </summary>
		/// <typeparam name="TValue">The type of the value.</typeparam>
		/// <param name="value">The value.</param>
		/// <param name="errorMessage">The error message to throw.</param>
		public static IEnumerable<TValue> IsNotNullNorEmpty<TValue>(IEnumerable<TValue> value, string errorMessage)
			=> IsNotNullNorEmpty<Exception, TValue>(value, errorMessage);

        /// <summary>
        /// Ensure that a list of values is not null nor empty, otherwise throws a specific exception.
        /// </summary>
        /// <typeparam name="TException">The type of the specific exception.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="value">The value.</param>
		public static IEnumerable<TValue> IsNotNullNorEmpty<TException, TValue>(IEnumerable<TValue> value)
			where TException : Exception
				=> IsNotNullNorEmpty<TException, TValue>(value, AcceptanceResources.AcceptanceMessagesResources.ErrorNullNorEmpty);

        /// <summary>
        /// Ensure that a list of values is not null nor empty, otherwise throws a specific exception with a specific message.
        /// </summary>
        /// <typeparam name="TException">The type of the specific exception.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="errorMessage">The error message to throw.</param>
        public static IEnumerable<TValue> IsNotNullNorEmpty<TException, TValue>(IEnumerable<TValue> value, string errorMessage)
            where TException : Exception
        {
            EvaluateValue<TException>(value.IsNullOrEmpty(), errorMessage);
			return value;
        }

        /// <summary>
        /// Ensure that a value is not null nor empty nor only white spaces, otherwise throws a specific exception.
        /// </summary>
        /// <param name="value">The value.</param>
        public static string IsNotNullNorEmptyNorWhiteSpace(string value)
			=> IsNotNullNorEmptyNorWhiteSpace<Exception>(value, AcceptanceResources.AcceptanceMessagesResources.ErrorNullNorEmptyNorWhiteSpace);

		/// <summary>
		/// Ensure that a value is not null nor empty nor only white spaces, otherwise throws a specific exception with a specific message.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="errorMessage">The error message to throw.</param>
		public static string IsNotNullNorEmptyNorWhiteSpace(string value, string errorMessage)
			=> IsNotNullNorEmptyNorWhiteSpace<Exception>(value, errorMessage);

        /// <summary>
        /// Ensure that a value is not null nor empty nor only white spaces, otherwise throws a specific exception.
        /// </summary>
        /// <typeparam name="TException">The type of the specific exception.</typeparam>
        /// <param name="value">The value.</param>
        public static string IsNotNullNorEmptyNorWhiteSpace<TException>(string value)
			where TException : Exception
				=> IsNotNullNorEmptyNorWhiteSpace<TException>(value, AcceptanceResources.AcceptanceMessagesResources.ErrorNullNorEmptyNorWhiteSpace);

        /// <summary>
        /// Ensure that a value is not null nor empty nor only white spaces, otherwise throws a specific exception with a specific message.
        /// </summary>
        /// <typeparam name="TException">The type of the specific exception.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="errorMessage">The error message to throw.</param>
        public static string IsNotNullNorEmptyNorWhiteSpace<TException>(string value, string errorMessage)
            where TException : Exception
        {
            EvaluateValue<TException>(value.IsNullOrEmptyOrWhiteSpace(), errorMessage);
			return value;
        }

        /// <summary>
        /// A custom validation can be implemented through a simple function that returns a boolean value. If the function returns false it will throw an exception.
        /// </summary>
        /// <param name="predicate">The function to evaluate.</param>
        /// <param name="errorMessage">The error message to show in case the function returns false.</param>
        public static void HasToComplyWith(Func<bool> predicate, string errorMessage)
			=> HasToComplyWith<Exception>(predicate, errorMessage);

        /// <summary>
        /// A custom validation can be implemented through a simple function that returns a boolean value. If the function returns false it will throw the expected exception.
        /// </summary>
        /// <typeparam name="TException">The expected exception.</typeparam>
        /// <param name="predicate">The function to evaluate.</param>
        /// <param name="errorMessage">The error message to show in case the function returns false.</param>
        public static void HasToComplyWith<TException>(Func<bool> predicate, string errorMessage)
            where TException : Exception
        {
            if (predicate is null)
			{
				Raise.Error.Parameter(
					nameof(predicate),
					AcceptanceResources.AcceptanceMessagesResources.ErrorCustomEvaluationPredicate,
					ParameterErrorType.Null);
			}

            ValidateErrorMessage(errorMessage);

			if (predicate()) return;

            Raise.Error.Specific<TException>(errorMessage);
        }

        /// <summary>
        /// Validate and evaluate a value and raise the proper exception if applicable.
        /// </summary>
        /// <typeparam name="TException">The expected exception.</typeparam>
        /// <param name="isValueObjectNotValid">True if the value of an object does not comply with the conditions.</param>
        /// <param name="errorMessage">The error message in case of an error.</param>
        private static void EvaluateValue<TException>(bool isValueObjectNotValid, string errorMessage)
			where TException : Exception
		{
			if (isValueObjectNotValid)
			{
				ValidateErrorMessage(errorMessage);
				Raise.Error.Specific<TException>(errorMessage);
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
