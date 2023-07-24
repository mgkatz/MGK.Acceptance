using static MGK.Acceptance.Ensure;

namespace MGK.Acceptance;

/// <summary>
/// Ensures that values or objects complies with what is expected.
/// </summary>
public static partial class Ensure
{
	/// <summary>
	/// Ensures that parameters values complies with what is expected.
	/// </summary>
	public static class Parameter
	{
		/// <summary>
		/// Ensure that a parameter is not empty, otherwise throws an argument exception.
		/// </summary>
		/// <param name="value">The parameter value.</param>
		/// <param name="paramName">The parameter's name.</param>
		public static Guid IsNotEmpty(Guid value, string paramName)
			=> IsNotEmpty(value, paramName, AcceptanceResources.AcceptanceMessagesResources.ErrorParamEmpty);

        /// <summary>
        /// Ensure that a parameter is not empty, otherwise throws an argument exception with a specific message.
        /// </summary>
        /// <param name="value">The parameter value.</param>
        /// <param name="paramName">The parameter's name.</param>
        /// <param name="errorMessage">The specific error message.</param>
        public static Guid IsNotEmpty(Guid value, string paramName, string errorMessage)
        {
            EvaluateParameter(value.IsEmpty(), paramName, errorMessage);
			return value;
        }

        /// <summary>
        /// Ensure that a parameter is not null, otherwise throws an argument null exception.
        /// </summary>
        /// <param name="value">The parameter value.</param>
        /// <param name="paramName">The parameter's name.</param>
        public static object IsNotNullObj(object value, string paramName)
			=> IsNotNullObj(value, paramName, AcceptanceResources.AcceptanceMessagesResources.ErrorParamNull);

        /// <summary>
        /// Ensure that a parameter is not null, otherwise throws an argument null exception with a specific message.
        /// </summary>
        /// <param name="value">The parameter value.</param>
        /// <param name="paramName">The parameter's name.</param>
        /// <param name="errorMessage">The specific error message.</param>
        public static object IsNotNullObj(object value, string paramName, string errorMessage)
        {
            EvaluateParameter(value is null, paramName, errorMessage, ParameterErrorType.Null);
			return value;
        }

        /// <summary>
        /// Ensure that a parameter is not null, otherwise throws an argument null exception.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="value">The parameter value.</param>
        /// <param name="paramName">The parameter's name.</param>
        public static TValue IsNotNull<TValue>(TValue value, string paramName)
            => IsNotNull(value, paramName, AcceptanceResources.AcceptanceMessagesResources.ErrorParamNull);

        /// <summary>
        /// Ensure that a parameter is not null, otherwise throws an argument null exception with a specific message.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="value">The parameter value.</param>
        /// <param name="paramName">The parameter's name.</param>
        /// <param name="errorMessage">The specific error message.</param>
        public static TValue IsNotNull<TValue>(TValue value, string paramName, string errorMessage)
        {
            EvaluateParameter(value is null, paramName, errorMessage, ParameterErrorType.Null);
            return value;
        }

        /// <summary>
        /// Ensure that a parameter is not null nor empty, otherwise throws an argument exception.
        /// </summary>
        /// <param name="value">The parameter value.</param>
        /// <param name="paramName">The parameter's name.</param>
        public static string IsNotNullNorEmpty(string value, string paramName)
			=> IsNotNullNorEmpty(value, paramName, AcceptanceResources.AcceptanceMessagesResources.ErrorParamNullNorEmpty);

        /// <summary>
        /// Ensure that a parameter is not null nor empty, otherwise throws an argument exception with a specific message.
        /// </summary>
        /// <param name="value">The parameter value.</param>
        /// <param name="paramName">The parameter's name.</param>
        /// <param name="errorMessage">The specific error message.</param>
        public static string IsNotNullNorEmpty(string value, string paramName, string errorMessage)
        {
            EvaluateParameter(value.IsNullOrEmpty(), paramName, errorMessage, ParameterErrorType.NullOrEmpty);
			return value;
        }

        /// <summary>
        /// Ensure that a parameter is not null nor empty, otherwise throws an argument exception.
        /// </summary>
        /// <param name="value">The parameter value.</param>
        /// <param name="paramName">The parameter's name.</param>
        public static IEnumerable<T> IsNotNullNorEmpty<T>(IEnumerable<T> value, string paramName)
			=> IsNotNullNorEmpty(value, paramName, AcceptanceResources.AcceptanceMessagesResources.ErrorParamNullNorEmpty);

        /// <summary>
        /// Ensure that a parameter is not null nor empty, otherwise throws an argument exception with a specific message.
        /// </summary>
        /// <param name="value">The parameter value.</param>
        /// <param name="paramName">The parameter's name.</param>
        /// <param name="errorMessage">The specific error message.</param>
        public static IEnumerable<T> IsNotNullNorEmpty<T>(IEnumerable<T> value, string paramName, string errorMessage)
        {
            EvaluateParameter(value.IsNullOrEmpty(), paramName, errorMessage);
            return value;
        }

        /// <summary>
        /// Ensure that a parameter is not null nor empty nor only white spaces, otherwise throws an argument exception.
        /// </summary>
        /// <param name="value">The parameter value.</param>
        /// <param name="paramName">The parameter's name.</param>
        public static string IsNotNullNorEmptyNorWhiteSpace(string value, string paramName)
			=> IsNotNullNorEmptyNorWhiteSpace(value, paramName, AcceptanceResources.AcceptanceMessagesResources.ErrorParamNullNorEmptyNorWhiteSpace);

        /// <summary>
        /// Ensure that a parameter is not null nor empty nor only white spaces, otherwise throws an argument exception with a specific message.
        /// </summary>
        /// <param name="value">The parameter value.</param>
        /// <param name="paramName">The parameter's name.</param>
        /// <param name="errorMessage">The specific error message.</param>
        public static string IsNotNullNorEmptyNorWhiteSpace(string value, string paramName, string errorMessage)
        {
            EvaluateParameter(value.IsNullOrEmptyOrWhiteSpace(), paramName, errorMessage);
            return value;
        }

        /// <summary>
        /// A custom validation can be implemented through a simple function that returns a boolean value. If the function returns false it will throw an exception.
        /// </summary>
        /// <param name="predicate">The function to evaluate.</param>
        /// <param name="errorMessage">The error message to show in case the function returns false.</param>
        public static void HasToComplyWith(Func<bool> predicate, string paramName, string errorMessage)
            => HasToComplyWith<ArgumentException>(predicate, paramName, errorMessage);

        /// <summary>
        /// A custom validation can be implemented through a simple function that returns a boolean value. If the function returns false it will throw the expected exception.
        /// </summary>
        /// <typeparam name="T">The expected exception.</typeparam>
        /// <param name="predicate">The function to evaluate.</param>
        /// <param name="errorMessage">The error message to show in case the function returns false.</param>
        public static void HasToComplyWith<TException>(Func<bool> predicate, string paramName, string errorMessage)
            where TException : ArgumentException
		{
			if (predicate is null)
			{
				Raise.Error.Parameter(
					nameof(predicate),
					AcceptanceResources.AcceptanceMessagesResources.ErrorCustomEvaluationPredicate,
					ParameterErrorType.Null);
			}

            ValidateErrorMessage(errorMessage);
            ValidateParamName(paramName);

			if (predicate()) return;

			Raise.Error.Parameter<TException>(paramName, errorMessage);
		}

		/// <summary>
		/// Validate and evaluate a parameter and raise the proper exception if applicable.
		/// </summary>
		/// <param name="isValueObjectNotValid">True if the value of an object does not comply with the conditions.</param>
		/// <param name="paramName">The name of the parameter that is being evaluated.</param>
		/// <param name="errorMessage">The error message in case of an error.</param>
		/// <param name="parameterErrorType">The type of the parameter error.</param>
		private static void EvaluateParameter(
			bool isValueObjectNotValid,
			string paramName,
			string errorMessage,
			ParameterErrorType parameterErrorType = ParameterErrorType.Generic)
		{
			if (isValueObjectNotValid)
			{
				ValidateErrorMessage(errorMessage);
				ValidateParamName(paramName);
				Raise.Error.Parameter(paramName, errorMessage, parameterErrorType);
			}
		}

		/// <summary>
		/// Validates that the parameter name has a value.
		/// </summary>
		/// <param name="paramName">The parameter name.</param>
		private static void ValidateParamName(string paramName)
		{
			if (paramName.IsNullOrEmptyOrWhiteSpace())
				Raise.Error.Parameter(nameof(paramName), AcceptanceResources.AcceptanceMessagesResources.ErrorParamNameNotProvided);
		}
	}
}
