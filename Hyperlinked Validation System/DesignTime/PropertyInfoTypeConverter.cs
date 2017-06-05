using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace HyperlinkedValidationSystem.DesignTime
{
    public class PropertyInfoTypeConverter : StringConverter
    {
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            ValidationObject instance = (ValidationObject) context.Instance;
            if (instance == null || instance.Base == null) return null;

            return
                new StandardValuesCollection(
                    instance.Base.GetType().GetProperties().Select(prop => (prop).Name).ToArray());
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof (PropertyInfo) || sourceType == typeof(string);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof (string) || destinationType == typeof (PropertyInfo);
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (value.GetType() == typeof (string))
                return (context.Instance as ValidationObject).Base.GetProperty((string) value);
            if (value.GetType() == typeof (PropertyInfo))
                return (value as PropertyInfo).Name;

            return null;
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value.GetType() == typeof(string))
                return (context.Instance as ValidationObject).Base.GetProperty((string)value);
            if (value.GetType() == typeof(PropertyInfo))
                return (value as PropertyInfo).Name;

            return null;
        }
    }
}
