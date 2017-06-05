namespace HyperlinkedValidationSystem.Validators
{
    /// <summary> A text validator. </summary>
    public static class TextValidator
    {
        /// =================================================================================================
        /// <summary>
        ///     Validates single text on emptyness. Required parameters: BaseValue (typeof Property-
        ///     /FieldInfo), MustBeEmpty (typeof bool)
        /// </summary>
        /// <param name="obj"> . </param>
        /// <returns> True if it succeeds, false if it fails. </returns>
        /// =================================================================================================
        public static bool Validate(ValidationObject obj)
        {
            var pi = (string) obj.Parameters["BaseValue"];

            if ((bool) obj.Parameters["MustBeEmpty", false])
                return string.IsNullOrEmpty(pi);

            if (pi == null)
                return false;
            return pi.Length > 0;
        }

        /// =================================================================================================
        /// <summary>
        ///     Validates the equality or inequality (if parameter is set) of base and reference-text.
        ///     Required parameters: BaseValue (typeof Property-/FieldInfo), ReferenceValue (typeof
        ///     Property-/FieldInfo), TextValidator:Invert (typeof bool).
        /// </summary>
        /// <param name="obj"> . </param>
        /// <returns> True if it succeeds, false if it fails. </returns>
        /// =================================================================================================
        public static bool ValidateEquality(ValidationObject obj)
        {
            var baseVal = (string) obj.Parameters["BaseValue"];
            var refVal = (string) obj.Parameters["ReferenceValue"];
            var invert = (bool) obj.Parameters["TextValidator:Invert", false];

            return invert ? baseVal != refVal : baseVal == refVal;
        }
    }
}