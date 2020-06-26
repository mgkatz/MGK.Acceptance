using MGK.Acceptance.Enums;
using MGK.Extensions;
using System;
using System.Collections.Generic;

namespace MGK.Acceptance
{
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
			public static void IsNotEmpty(Guid value, string paramName)
				=> IsNotEmpty(value, paramName, Resources.AppMessages.ErrorParamEmpty);

			/// <summary>
			/// Ensure that a parameter is not empty, otherwise throws an argument exception with a specific message.
			/// </summary>
			/// <param name="value">The parameter value.</param>
			/// <param name="paramName">The parameter's name.</param>
			/// <param name="errorMessage">The specific error message.</param>
			public static void IsNotEmpty(Guid value, string paramName, string errorMessage)
				=> EvaluateParameter(value.IsEmpty(), paramName, errorMessage);

			/// <summary>
			/// Ensure that a parameter is not null, otherwise throws an argument null exception.
			/// </summary>
			/// <param name="value">The parameter value.</param>
			/// <param name="paramName">The parameter's name.</param>
			public static void IsNotNull(object value, string paramName)
				=> IsNotNull(value, paramName, Resources.AppMessages.ErrorParamNull);

			/// <summary>
			/// Ensure that a parameter is not null, otherwise throws an argument null exception with a specific message.
			/// </summary>
			/// <param name="value">The parameter value.</param>
			/// <param name="paramName">The parameter's name.</param>
			/// <param name="errorMessage">The specific error message.</param>
			public static void IsNotNull(object value, string paramName, string errorMessage)
				=> EvaluateParameter(value == null, paramName, errorMessage, ParameterErrorType.Null);

			/// <summary>
			/// Ensure that a parameter is not null nor empty, otherwise throws an argument exception.
			/// </summary>
			/// <param name="value">The parameter value.</param>
			/// <param name="paramName">The parameter's name.</param>
			public static void IsNotNullNorEmpty(string value, string paramName)
				=> IsNotNullNorEmpty(value, paramName, Resources.AppMessages.ErrorParamNullNorEmpty);

			/// <summary>
			/// Ensure that a parameter is not null nor empty, otherwise throws an argument exception with a specific message.
			/// </summary>
			/// <param name="value">The parameter value.</param>
			/// <param name="paramName">The parameter's name.</param>
			/// <param name="errorMessage">The specific error message.</param>
			public static void IsNotNullNorEmpty(string value, string paramName, string errorMessage)
				=> EvaluateParameter(value.IsNullOrEmpty(), paramName, errorMessage);

			/// <summary>
			/// Ensure that a parameter is not null nor empty, otherwise throws an argument exception.
			/// </summary>
			/// <param name="value">The parameter value.</param>
			/// <param name="paramName">The parameter's name.</param>
			public static void IsNotNullNorEmpty<T>(IEnumerable<T> value, string paramName)
				=> IsNotNullNorEmpty(value, paramName, Resources.AppMessages.ErrorParamNullNorEmpty);

			/// <summary>
			/// Ensure that a parameter is not null nor empty, otherwise throws an argument exception with a specific message.
			/// </summary>
			/// <param name="value">The parameter value.</param>
			/// <param name="paramName">The parameter's name.</param>
			/// <param name="errorMessage">The specific error message.</param>
			public static void IsNotNullNorEmpty<T>(IEnumerable<T> value, string paramName, string errorMessage)
				=> EvaluateParameter(value.IsNullOrEmpty(), paramName, errorMessage);

			/// <summary>
			/// Ensure that a parameter is not null nor empty nor only white spaces, otherwise throws an argument exception.
			/// </summary>
			/// <param name="value">The parameter value.</param>
			/// <param name="paramName">The parameter's name.</param>
			public static void IsNotNullNorEmptyNorWhiteSpace(string value, string paramName)
				=> IsNotNullNorEmptyNorWhiteSpace(value, paramName, Resources.AppMessages.ErrorParamNullNorEmptyNorWhiteSpace);

			/// <summary>
			/// Ensure that a parameter is not null nor empty nor only white spaces, otherwise throws an argument exception with a specific message.
			/// </summary>
			/// <param name="value">The parameter value.</param>
			/// <param name="paramName">The parameter's name.</param>
			/// <param name="errorMessage">The specific error message.</param>
			public static void IsNotNullNorEmptyNorWhiteSpace(string value, string paramName, string errorMessage)
				=> EvaluateParameter(value.IsNullOrEmptyOrWhiteSpace(), paramName, errorMessage);

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
					Raise.Error.Parameter(nameof(paramName), Resources.AppMessages.ErrorParamNameNotProvided);
			}
		}
	}
}
