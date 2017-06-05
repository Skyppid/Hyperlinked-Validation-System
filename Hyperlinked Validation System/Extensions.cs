using System;
using System.Reflection;

namespace HyperlinkedValidationSystem
{
    public static class Extensions
    {
        /// =================================================================================================
        /// <summary> An object extension method that gets a property. </summary>
        /// <param name="obj">   The object to act on. </param>
        /// <param name="name"> The name. </param>
        /// <returns> The property. </returns>
        /// =================================================================================================
        public static PropertyInfo GetProperty(this object obj, string name)
        {
            return obj.GetType().GetProperty(name);
        }
    }

    /// <summary> Enumeration extension methods. </summary>
    public static class EnumerationExtensions
    {
        public static bool Has<T>(this Enum type, T value)
        {
            try
            {
                return ((int) (object) type & (int) (object) value) == (int) (object) value;
            }
            catch
            {
                return false;
            }
        }

        public static bool Is<T>(this Enum type, T value)
        {
            try
            {
                return (int) (object) type == (int) (object) value;
            }
            catch
            {
                return false;
            }
        }

        public static T Add<T>(this Enum type, T value)
        {
            try
            {
                return (T) (object) ((int) (object) type | (int) (object) value);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                    string.Format(
                        "Could not append value from enumerated type '{0}'.",
                        typeof(T).Name
                    ), ex);
            }
        }

        public static T Remove<T>(this Enum type, T value)
        {
            try
            {
                return (T) (object) ((int) (object) type & ~(int) (object) value);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                    string.Format(
                        "Could not remove value from enumerated type '{0}'.",
                        typeof(T).Name
                    ), ex);
            }
        }
    }
}