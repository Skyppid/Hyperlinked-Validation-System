using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace HyperlinkedValidationSystem.DesignTime
{
    public partial class LinkStructUIEditor : Form
    {
        public LinkStructUIEditor()
        {
            InitializeComponent();
        }

        private List<LinkStruct> Structure;
        public static List<Type> PossibleValidatorTypes { get; set; }
        private LinkStruct _selectedStruct;
        private IServiceProvider _provider;

        public List<LinkStruct> ShowEditor(List<LinkStruct> baseValue, ISite site, IServiceProvider provider)
        {
            //Setup
            lsv_structs.Items.Clear();
            Structure = baseValue;
            _provider = provider;

            if (baseValue != null)
            {
                foreach (LinkStruct @struct in baseValue)
                {
                    ListViewItem item = new ListViewItem(@struct.Name);
                    item.SubItems.Add(@struct.Links.Count.ToString());
                    item.SubItems.Add((!@struct.DisableValidating).ToString());

                    lsv_structs.Items.Add(item);
                }
            }

            //Show
            if (ShowDialog() == DialogResult.OK)
                return Structure;
            return null;
        }

        private void lsv_structs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsv_structs.SelectedItems.Count > 0)
            {
                btn_removeStruct.Enabled = true;
                _selectedStruct = Structure[lsv_structs.SelectedIndices[0]];
                propGrid.SelectedObject = _selectedStruct;

                SetupTree(_selectedStruct);
            }
            else
            {
                btn_removeStruct.Enabled = false;
                if (propGrid.SelectedObject.GetType() == typeof(LinkStruct))
                    propGrid.SelectedObject = null;
            }
        }

        private void btn_addStruct_Click(object sender, EventArgs e)
        {
            LinkStruct newStruct = new LinkStruct();
            Structure.Add(newStruct);
            ListViewItem item = new ListViewItem();
            item.SubItems.Add("0");
            item.SubItems.Add("False");
            lsv_structs.Items.Add(item);
        }

        private void SetupTree(LinkStruct @struct)
        {
            tree_objs.Nodes.Clear();
            foreach (LinkObject obj in @struct.Links)
            {
                TreeNode objNode = new TreeNode(obj.Identifier) {Tag = true};
                tree_objs.Nodes.Add(objNode);

                foreach (LinkCondition condition in obj.Conditions)
                {
                    TreeNode condNode = new TreeNode(condition.Identifier) {Tag = false};
                    if (condition.Conditions.Count > 0)
                        SetupCondition(condition, condNode);
                }
            }
        }

        private void SetupCondition(LinkCondition condition, TreeNode node)
        {
            foreach (LinkCondition cond in condition.Conditions)
            {
                TreeNode condNode = new TreeNode(cond.Identifier) {Tag = false};
                node.Nodes.Add(condNode);

                if (cond.Conditions.Count > 0)
                    SetupCondition(cond, condNode);
            }
        }

        private void tree_objs_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null)
                if (propGrid.SelectedObject.GetType() != typeof(LinkStruct))
                    propGrid.SelectedObject = null;

            if ((bool)e.Node.Tag)
                propGrid.SelectedObject = _selectedStruct.GetLinkObjectByIdentifier(e.Node.Text);
            else
                propGrid.SelectedObject = _selectedStruct.GetConditionByIdentifier(e.Node.Text);
        }

        private void LinkStructUIEditor_Load(object sender, EventArgs e)
        {
            //Search available Validators
            PossibleValidatorTypes = new List<Type>();




            propGrid.PropertyValueChanged += propGrid_PropertyValueChanged;
        }

        private void propGrid_PropertyValueChanged(object sender, PropertyValueChangedEventArgs e)
        {
            if (propGrid.SelectedObject.GetType() == typeof(LinkStruct))
            {
                if (lsv_structs.SelectedItems.Count > 0)
                {
                    ListViewItem item = lsv_structs.SelectedItems[0];
                    item.Text = (string)e.ChangedItem.Value;
                    item.SubItems[1].Text = _selectedStruct.Links.Count.ToString();
                    item.SubItems[2].Text = (!_selectedStruct.DisableValidating).ToString();
                }
            }
            else
                if (e.ChangedItem.Label == "Identifier" & e.ChangedItem.PropertyDescriptor.PropertyType == typeof(string))
                    tree_objs.SelectedNode.Text = (string) e.ChangedItem.Value;
        }

        private void btn_removeStruct_Click(object sender, EventArgs e)
        {
            if (!(_selectedStruct != null & lsv_structs.SelectedItems[0] != null)) return;
            Structure.Remove(_selectedStruct);
            lsv_structs.SelectedItems[0].Remove();
            _selectedStruct = null;
        }

        private void btn_addObj_Click(object sender, EventArgs e)
        {
            if (_selectedStruct == null) return;

            LinkObject obj = new LinkObject() {Identifier = "NewLinkObject"};
            _selectedStruct.RenameObject(obj);
            _selectedStruct.Add(obj);
            tree_objs.Nodes.Add(new TreeNode(obj.Identifier) {Tag = true});
        }

        private void btn_addCond_Click(object sender, EventArgs e)
        {
            if (_selectedStruct != null & tree_objs.SelectedNode != null)
            {
                if ((bool)tree_objs.SelectedNode.Tag)
                {
                    LinkObject obj = _selectedStruct.GetLinkObjectByIdentifier(tree_objs.SelectedNode.Text);
                    LinkCondition cond = new LinkCondition() {Identifier = "NewCondition"};
                    _selectedStruct.RenameObject(cond);
                    obj.Conditions.Add(cond);
                    tree_objs.SelectedNode.Nodes.Add(new TreeNode(cond.Identifier) {Tag = false});
                }
                else
                {
                    LinkCondition obj = _selectedStruct.GetConditionByIdentifier(tree_objs.SelectedNode.Text);
                    LinkCondition cond = new LinkCondition() { Identifier = "NewCondition" };
                    _selectedStruct.RenameObject(cond);
                    obj.Conditions.Add(cond);
                    tree_objs.SelectedNode.Nodes.Add(new TreeNode(cond.Identifier) { Tag = false });
                }
            }
        }
    }
}
