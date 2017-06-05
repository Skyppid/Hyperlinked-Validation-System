using System;
using System.Reflection;

namespace HyperlinkedValidationSystem.Validators
{
    public static class EmailValidator
    {
        /// <summary>
        /// Required parameters: BaseValue (typeof string).
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool Validate(ValidationObject obj)
        {
            string baseValue = (string) obj.Parameters["BaseValue"];
            return System.Text.RegularExpressions.Regex.IsMatch(baseValue, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
        }
    }
}
