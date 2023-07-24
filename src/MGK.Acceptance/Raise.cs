namespace MGK.Acceptance;

public static class Raise
{
	public static class Error
	{
		/// <summary>
		/// Throws a basic exception.
		/// </summary>
		/// <param name="errorMessage">The error message to throw.</param>
		public static void Base(string errorMessage)
			=> throw new Exception(errorMessage);

		/// <summary>
		/// Throws a specific exception.
		/// </summary>
		/// <typeparam name="T">The type of the specific exception.</typeparam>
		/// <param name="errorMessage">The error message to throw.</param>
		public static void Specific<T>(string errorMessage) where T : Exception
			=> throw (T)Activator.CreateInstance(typeof(T), new object[] { errorMessage });

        /// <summary>
        /// Throws an exception allowing params.
        /// </summary>
        /// <typeparam name="T">The type of the specific exception.</typeparam>
        /// <param name="exceptionParams">The parameters of the specific exception to throw.</param>
        public static void Generic<T>(params object[] exceptionParams) where T : Exception
			=> throw (T)Activator.CreateInstance(typeof(T), exceptionParams);

		/// <summary>
		/// Throw a parameter exception.
		/// </summary>
		/// <param name="paramName">The name of the parameter.</param>
		/// <param name="errorMessage">The error message to throw.</param>
		/// <param name="parameterErrorType">The type of the parameter exception.</param>
		public static void Parameter(
			string paramName,
			string errorMessage,
			ParameterErrorType parameterErrorType = ParameterErrorType.Generic)
		{
			throw parameterErrorType switch
			{
				ParameterErrorType.Null => new ArgumentNullException(paramName, errorMessage),
				ParameterErrorType.OutOfRange => new ArgumentOutOfRangeException(paramName, errorMessage),
				_ => new ArgumentException(errorMessage, paramName),
			};
		}

		public static void Parameter<T>(string paramName, string errorMessage)
			where T : ArgumentException
			=> throw (T)Activator.CreateInstance(typeof(T), new object[] { paramName, errorMessage });
	}
}
