using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HyperlinkedValidationSystem.DesignTime
{
    public class ControlTypeConverter : StringConverter
    {
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return
                new StandardValuesCollection(
                    LinkStructUITypeEditor.CurrentSite.Container.Components.OfType<Control>().Select(
                        control => (control).Name).ToArray());
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
    }
}
