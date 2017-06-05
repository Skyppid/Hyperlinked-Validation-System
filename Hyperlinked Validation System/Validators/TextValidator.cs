using System;
using System.Reflection;

namespace HyperlinkedValidationSystem.Validators
{
    public static class TextValidator
    {
        /// <summary>
        /// Validates single text on emptyness.
        /// Required parameters: BaseValue (typeof Property-/FieldInfo), MustBeEmpty (typeof bool)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool Validate(ValidationObject obj)
        {
            string pi = (string) obj.Parameters["BaseValue"];

            if ((bool)obj.Parameters["MustBeEmpty", false])
                return string.IsNullOrEmpty(pi);

            if (pi == null)
                return false;
            return pi.Length > 0;
        }


        /// <summary>
        /// Validates the equality of base and reference-text.
        /// Required parameters: BaseValue (typeof Property-/FieldInfo), ReferenceValue (typeof Property-/FieldInfo),
        /// TextValidator:Invert (typeof bool).
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool ValidateTextOfTwo(ValidationObject obj)
        {
            string baseVal = (string)obj.Parameters["BaseValue"];
            string refVal = (string) obj.Parameters["ReferenceValue"];
            bool invert = (bool) obj.Parameters["TextValidator:Invert", false];

            return invert ? baseVal != refVal : baseVal == refVal;
        }
    }
}
