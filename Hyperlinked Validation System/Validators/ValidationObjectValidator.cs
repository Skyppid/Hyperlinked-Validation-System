using System;

namespace HyperlinkedValidationSystem.Validators
{
    public static class ValidationObjectValidator
    {
        /// <summary>
        /// Required parameters: Reference.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool Validate(ValidationObject obj)
        {
            object valueA = obj;
            object valueB = obj.Parameters["Reference"];

            bool result;

            IComparable selfValueComparer = valueA as IComparable;

            if (valueA == null && valueB != null || valueA != null && valueB == null)
                result = false; // one of the values is null
            else if (selfValueComparer != null && selfValueComparer.CompareTo(valueB) != 0)
                result = false; // the comparison using IComparable failed
            else if (!Equals(valueA, valueB))
                result = false; // the comparison using Equals failed
            else
                result = true; // match

            return result;
        }
    }
}