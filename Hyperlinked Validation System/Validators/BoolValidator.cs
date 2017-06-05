using HyperlinkedValidationSystem.Parameters;

namespace HyperlinkedValidationSystem.Validators
{
    /// <summary> A boolean validator. </summary>
    public static class BoolValidator
    {
        public static ParameterCollection Default =
            new ParameterCollection(new StaticParameter("BoolValidator:Invert", false));

        /// =================================================================================================
        /// <summary>
        ///     <para>
        ///         Required parameters: BaseValue (typeof bool), ReferenceValue (typeof bool).
        ///     </para>
        ///     <para>
        ///         Optional parameters: BoolValidator:Invert (typeof bool).
        ///     </para>
        /// </summary>
        /// <param name="obj">
        ///     The <see cref="ValidationObject" /> which should be validated.
        /// </param>
        /// <returns> True if it succeeds, false if it fails. </returns>
        /// =================================================================================================
        public static bool Validate(ValidationObject obj)
        {
            var invert = (bool) obj.Parameters["BoolValidator:Invert", false];
            var baseValue = (bool) obj.Parameters["BaseValue"];
            var referenceValue = (bool) obj.Parameters["ReferenceValue"];

            return invert ? baseValue != referenceValue : baseValue == referenceValue;
        }
    }
}