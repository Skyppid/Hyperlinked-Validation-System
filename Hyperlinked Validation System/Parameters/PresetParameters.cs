namespace HyperlinkedValidationSystem.Parameters
{
    /// =================================================================================================
    /// <summary> A static parameter with a constant identifier 'Base'. </summary>
    /// <seealso cref="T:HyperlinkedValidationSystem.Parameters.StaticParameter" />
    /// =================================================================================================
    public class BaseParameter : StaticParameter
    {
        public BaseParameter(object value) : base("Base", value)
        {
        }
    }

    /// =================================================================================================
    /// <summary> A static parameter with a constant identifier 'Reference'. </summary>
    /// <seealso cref="T:HyperlinkedValidationSystem.Parameters.StaticParameter" />
    /// =================================================================================================
    public class ReferenceParameter : StaticParameter
    {
        public ReferenceParameter(object value) : base("Reference", value)
        {
        }
    }

    /// =================================================================================================
    /// <summary> A static parameter with a constant identifier 'ReferenceValue'. </summary>
    /// <seealso cref="T:HyperlinkedValidationSystem.Parameters.StaticParameter" />
    /// =================================================================================================
    public class ReferenceValueParameter : StaticParameter
    {
        public ReferenceValueParameter(object value) : base("ReferenceValue", value)
        {
        }
    }
}