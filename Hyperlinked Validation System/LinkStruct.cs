/*
 * Autor: Manuel E. (Twisted Arts)
 * Homepage: http://twistedarts.bplaced.net/ 
 */

using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace HyperlinkedValidationSystem
{
    [DefaultProperty("Name")]
    public class LinkStruct
    {
        public LinkStruct()
        {
            Links = new List<LinkObject>();
            Actions = new ActionCollection();
        }

        public LinkStruct(params LinkObject[] links)
        {
            Links = new List<LinkObject>();
            Links.AddRange(links);
            Actions = new ActionCollection();
        }

        public LinkStruct(params AAction[] actions)
        {
            Links = new List<LinkObject>();
            Actions = new ActionCollection();
            Actions.AddRange(actions);
        }

        /// <summary>
        /// A name for this structure. Is required by the HVS to get the correct instance.
        /// </summary>
        [Category("Identification")]
        [Description("The name of this structure. Required by the HVS management-system to get the correct LinkStruct. Must be a unique name.")]
        public string Name { get; set; }

        /// <summary>
        /// A list of linked objects to validate.
        /// </summary>
        [Category("Validation")]
        [Description("A list of LinkObjects which have to be validated.")]
        [Browsable(false)]
        public List<LinkObject> Links { get; set; }

        /// <summary>
        /// A collection of actions which gets executed after some events.
        /// </summary>
        [Category("Validation")]
        [Description("A collection of actions which gets executed after some events.")]
        [Browsable(false)]
        public ActionCollection Actions { get; set; }

        /// <summary>
        /// If true, the HVS doesn´t validate this struct.
        /// </summary>
        [Category("Validation")]
        [Description("Disables validation on this structure.")]
        public bool DisableValidating { get; set; }

        public void Add(LinkObject obj)
        {
            Links.Add(obj);
        }

        public LinkObject GetLinkObjectByControl(Control searchedControl)
        {
            foreach (LinkObject obj in Links)
            {
                if (obj.Parameters["Base"] == searchedControl)
                        return obj;
            }

            return null;
        }

        public LinkObject GetLinkObjectByIdentifier(string identifier)
        {
            foreach (LinkObject obj in Links)
                if (obj.Identifier == identifier)
                    return obj;
            return null;
        }

        public LinkCondition GetConditionByObject(object searchedObject)
        {
            foreach (LinkObject obj in Links)
            {
                foreach (LinkCondition condition in obj.Conditions)
                    if (condition.Parameters["Base"] == searchedObject)
                        return condition;
            }

            return null;
        }

        public LinkCondition GetConditionByIdentifier(string identifier)
        {
            foreach (LinkObject obj in Links)
                foreach (LinkCondition cond in obj.Conditions)
                    if (cond.Identifier == identifier)
                        return cond;
            return null;
        }

        public LinkCondition GetConditionByIdentifier(string identifier, LinkObject parent)
        {
            foreach (LinkCondition cond in parent.Conditions)
                if (cond.Identifier == identifier)
                    return cond;
            return null;
        }

        public ValidationObject GetByIdentifier(string identifier)
        {
            foreach (LinkObject obj in Links)
            {
                if (obj.Identifier == identifier)
                    return obj;

                foreach (LinkCondition condition in obj.Conditions)
                    if (condition.Identifier == identifier)
                        return condition;
            }

            return null;
        }

        internal void RenameObject(ValidationObject obj)
        {
            int counter = 0;
            if (obj is LinkObject)
            {
                string normalIdentifier = obj.Identifier;
                while (GetLinkObjectByIdentifier(obj.Identifier) != null)
                {
                    obj.Identifier = normalIdentifier + counter;
                    counter++;
                }
            }
            else
            {
                string normalIdentifier = obj.Identifier;
                while (GetConditionByIdentifier(obj.Identifier) != null)
                {
                    obj.Identifier = normalIdentifier + counter;
                    counter++;
                }
            }
        }
    }
}
