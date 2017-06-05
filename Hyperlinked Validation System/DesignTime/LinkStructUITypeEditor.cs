using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace HyperlinkedValidationSystem.DesignTime
{
    class LinkStructUITypeEditor : UITypeEditor
    {
        public static ISite CurrentSite { get; private set; }

        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            List<LinkStruct> baseValue = (List<LinkStruct>) value;

            CurrentSite = ((HVS) context.Instance).Site;
            using (LinkStructUIEditor editor = new LinkStructUIEditor())
                return editor.ShowEditor(baseValue, ((HVS) context.Instance).Site, provider) ?? baseValue;
        }
    }
}
