using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Linq;
using System.Text;

namespace HyperlinkedValidationSystem.DesignTime
{
    public class ValidatorUITypeEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            List<IPropertyValidator> validators = new List<IPropertyValidator>();

            if (provider != null)
            {
                ITypeDiscoveryService disover =
                    provider.GetService(typeof(ITypeDiscoveryService)) as ITypeDiscoveryService;
                if (disover != null)
                {
                    foreach (Type t in disover.GetTypes(typeof(IPropertyValidator), true))
                    {
                        if (t.IsSubclassOf(typeof(IPropertyValidator)))
                            return (IPropertyValidator) Activator.CreateInstance(t, null);
                    }
                }
            }

            return null;
        }
    }
}
