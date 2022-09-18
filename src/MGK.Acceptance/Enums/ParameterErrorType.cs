namespace MGK.Acceptance.Enums;

/// <summary>
/// Represent parameter error types.
/// </summary>
public enum ParameterErrorType
{
    /// <summary>
    /// Represent the parameter error type when the value is empty.
    /// </summary>
    Empty,

	/// <summary>
	/// Represent the general parameter error type.
	/// </summary>
	Generic,

	/// <summary>
	/// Represent the parameter error type when the value is null.
	/// </summary>
	Null,

    /// <summary>
    /// Represent the parameter error type when the value is null or empty.
    /// </summary>
    NullOrEmpty,

	/// <summary>
	/// Represent the parameter error type when the value is out of range.
	/// </summary>
	OutOfRange
}
