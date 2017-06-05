using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace HyperlinkedValidationSystem.DesignTime
{
    public class ValidatorTypeConverter : StringConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            return value.GetType().Name;
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            try
            {
                return Activator.CreateInstance(Type.GetType(value.ToString()));
            }
            catch
            {
                return null;
            }
        }
    }
}
