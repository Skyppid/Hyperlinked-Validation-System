/*
 * Autor: Manuel E. (Twisted Arts)
 * Homepage: http://twistedarts.bplaced.net/ 
 */

using System.Reflection;

namespace HyperlinkedValidationSystem.Validators
{
    public static class IntValidator
    {
        public static ParameterCollection DefaultParameters =
            new ParameterCollection(new StaticParameter(
                                        "IntValidator:Mode", IntValidationMode.Equal));

        /// <summary>
        /// Required parameters: Base, BaseValue (typeof int), ReferenceValue (typeof int), IntValidator:Mode (typeof IntValidationMode).
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool Validate(ValidationObject obj)
        {
            IntValidationMode mode = (IntValidationMode)obj.Parameters["IntValidator:Mode"];
            int referenceValue = (int) obj.Parameters["ReferenceValue"];

            int baseValue = (int) (obj.Parameters["BaseValue"] as PropertyInfo).GetValue(obj.Parameters["Base"], null);

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
            return false;
        }

        public enum IntValidationMode
        {
            HigherThan,
            HigherOrEqual,
            Equal,
            Unequal,
            LowerOrEqual,
            LowerThan
        }
    }
}
