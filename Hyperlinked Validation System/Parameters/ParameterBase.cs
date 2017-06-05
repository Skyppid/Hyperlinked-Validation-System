namespace HyperlinkedValidationSystem.Parameters
{
    /// <summary> A base class for parameters. </summary>
    public abstract class ParameterBase
    {
        /// =================================================================================================
        /// <summary> Specialised constructor for use only by derived class. </summary>
        /// <param name="identifier">  The identifier. </param>
        /// <param name="reflectionTarget"> The object. </param>
        /// =================================================================================================
        protected ParameterBase(string identifier, object reflectionTarget)
        {
            Identifier = identifier;
            Base = reflectionTarget;
        }

        /// =================================================================================================
        /// <summary> Gets or sets the identifier. </summary>
        /// <value> The identifier. </value>
        /// =================================================================================================
        public string Identifier { get; private set; }

        /// =================================================================================================
        /// <summary> Gets or sets the base. </summary>
        /// <value> The base. </value>
        /// =================================================================================================
        public object Base { get; set; }

        /// =================================================================================================
        /// <summary> Gets or sets the value. </summary>
        /// <value> The value. </value>
        /// =================================================================================================
        public virtual object Value { get; set; }
    }
}