namespace HyperlinkedValidationSystem.Parameters
{
    /// =================================================================================================
    /// <summary> A static parameter. This class cannot be inherited. </summary>
    /// <seealso cref="T:HyperlinkedValidationSystem.Parameters.ParameterBase" />
    /// =================================================================================================
    public class StaticParameter : ParameterBase
    {
        private readonly object _value;

        /// =================================================================================================
        /// <summary> Creates a new static parameter which always returns the same value. </summary>
        /// <param name="id">    The identifier. </param>
        /// <param name="value"> The value. </param>
        /// =================================================================================================
        public StaticParameter(string id, object value)
            : base(id, null)
        {
            _value = value;
        }

        /// =================================================================================================
        /// <summary> Gets the value. </summary>
        /// <value> The value. </value>
        /// <seealso cref="P:HyperlinkedValidationSystem.Parameters.ParameterBase.Value" />
        /// =================================================================================================
        public sealed override object Value
        {
            get { return _value; }
            set { }
        }
    }
}