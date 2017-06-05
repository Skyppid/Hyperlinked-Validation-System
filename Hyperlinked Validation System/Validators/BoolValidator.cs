/*
 * Autor: Manuel E. (Twisted Arts)
 * Homepage: http://twistedarts.bplaced.net/ 
 */

namespace HyperlinkedValidationSystem.Validators
{
    public static class BoolValidator
    {
        public static ParameterCollection Default =
            new ParameterCollection(new StaticParameter("BoolValidator:Invert", false));

        /// <summary>
        /// Required parameters: BaseValue (typeof bool), ReferenceValue (typeof bool), BoolValidator:Invert (typeof bool).
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool Validate(ValidationObject obj)
        {
            bool invert = (bool) obj.Parameters["BoolValidator:Invert", false];
            bool baseValue = (bool)obj.Parameters["BaseValue"];
            bool referenceValue = (bool)obj.Parameters["ReferenceValue"];

            return invert ? baseValue != referenceValue : baseValue == referenceValue;
        }
    }
}
