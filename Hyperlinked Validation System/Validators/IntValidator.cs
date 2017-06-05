using System.Reflection;
using HyperlinkedValidationSystem.Parameters;

namespace HyperlinkedValidationSystem.Validators
{
    /// <summary> An int (Int32) validator. </summary>
    public static class IntValidator
    {
        /// <summary> Values that represent int validation modes. </summary>
        public enum IntValidationMode
        {
            HigherThan,
            HigherOrEqual,
            Equal,
            Unequal,
            LowerOrEqual,
            LowerThan
        }

        public static ParameterCollection DefaultParameters =
            new ParameterCollection(new StaticParameter(
                "IntValidator:Mode", IntValidationMode.Equal));

        /// =================================================================================================
        /// <summary>
        ///     Required parameters: Base (typeof object), BaseValue (typeof int), ReferenceValue (typeof int),
        ///     IntValidator:Mode (typeof IntValidationMode).
        /// </summary>
        /// <param name="obj"> The <see cref="ValidationObject" /> to validate. </param>
        /// <returns> True if it succeeds, false if it fails. </returns>
        /// =================================================================================================
        public static bool Validate(ValidationObject obj)
        {
            var mode = (IntValidationMode) obj.Parameters["IntValidator:Mode"];
            var referenceValue = (int) obj.Parameters["ReferenceValue"];

            var propertyInfo = obj.Parameters["BaseValue"] as PropertyInfo;
            if (propertyInfo != null)
            {
                var baseValue = (int) propertyInfo.GetValue(obj.Parameters["Base"], null);

                if (mode == IntValidationMode.Equal)
                    return baseValue == referenceValue;
                if (mode == IntValidationMode.Unequal)
                    return baseValue != referenceValue;
                if (mode == IntValidationMode.HigherThan)
                    return baseValue > referenceValue;
                if (mode == IntValidationMode.HigherOrEqual)
                    return baseValue >= referenceValue;
                if (mode == IntValidationMode.LowerThan)
                    return baseValue < referenceValue;
                if (mode == IntValidationMode.LowerOrEqual)
                    return baseValue <= referenceValue;
            }
            return false;
        }
    }
}