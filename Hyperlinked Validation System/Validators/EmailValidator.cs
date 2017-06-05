using System.Text.RegularExpressions;

namespace HyperlinkedValidationSystem.Validators
{
    /// <summary> A validator for e-mail addresses. </summary>
    public static class EmailValidator
    {
        /// =================================================================================================
        /// <summary> Required parameters: BaseValue (typeof string). </summary>
        /// <param name="obj"> The <see cref="ValidationObject" /> which should be validated. </param>
        /// <returns> True if it succeeds, false if it fails. </returns>
        /// =================================================================================================
        public static bool Validate(ValidationObject obj)
        {
            var baseValue = (string) obj.Parameters["BaseValue"];
            return Regex.IsMatch(baseValue, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
        }
    }
}