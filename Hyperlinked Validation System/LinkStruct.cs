using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using HyperlinkedValidationSystem.Actions;

namespace HyperlinkedValidationSystem
{
    /// =================================================================================================
    /// <summary>
    ///     A structure which keeps track of all related <see cref="LinkObject" />. This class cannot
    ///     be inherited.
    /// </summary>
    /// <remarks> Use one LinkStruct for each input group that belongs together. </remarks>
    /// =================================================================================================
    [DefaultProperty("Name")]
    public sealed class LinkStruct
    {
        /// <summary> Default constructor. </summary>
        public LinkStruct()
        {
            Links = new List<LinkObject>();
            Actions = new ActionCollection();
        }

        /// =================================================================================================
        /// <summary> Constructor. </summary>
        /// <param name="links"> A list of linked objects to validate. </param>
        /// =================================================================================================
        public LinkStruct(params LinkObject[] links)
        {
            Links = new List<LinkObject>();
            Links.AddRange(links);
            Actions = new ActionCollection();
        }

        /// =================================================================================================
        /// <summary> Constructor. </summary>
        /// <param name="actions"> A collection of actions which gets executed after some events. </param>
        /// =================================================================================================
        public LinkStruct(params ActionBase[] actions)
        {
            Links = new List<LinkObject>();
            Actions = new ActionCollection();
            Actions.AddRange(actions);
        }

        /// =================================================================================================
        /// <summary>
        ///     A name for this structure. Is required by the HVS to get the correct instance.
        /// </summary>
        /// <value> The name of this structure. </value>
        /// =================================================================================================
        [Category("Identification")]
        [Description(
            "The name of this structure. Required by the HVS management-system to get the correct LinkStruct. Must be a unique name.")]
        public string Name { get; set; }

        /// =================================================================================================
        /// <summary> A list of linked objects to validate. </summary>
        /// <value> The links. </value>
        /// =================================================================================================
        [Category("Validation")]
        [Description("A list of LinkObjects which have to be validated.")]
        [Browsable(false)]
        public List<LinkObject> Links { get; set; }

        /// =================================================================================================
        /// <summary> A collection of actions which gets executed after some events. </summary>
        /// <value> The actions. </value>
        /// =================================================================================================
        [Category("Validation")]
        [Description("A collection of actions which gets executed after some events.")]
        [Browsable(false)]
        public ActionCollection Actions { get; set; }

        /// =================================================================================================
        /// <summary> Set to <c>true</c> to disable validation of this LinkStruct, false to activate it. </summary>
        /// <value> A boolean value which disables or enables validation. </value>
        /// =================================================================================================
        [Category("Validation")]
        [Description("Disables validation on this structure.")]
        public bool DisableValidating { get; set; }

        /// =================================================================================================
        /// <summary> Adds a new LinkObject to this structure. </summary>
        /// <param name="obj"> The LinkObject to add. </param>
        /// =================================================================================================
        public void Add(LinkObject obj)
        {
            Links.Add(obj);
        }

        /// =================================================================================================
        /// <summary> Returns a LinkObject which is associated with <paramref name="control" />. </summary>
        /// <param name="control"> The associated control. </param>
        /// <returns> A LinkObject which is associated with <paramref name="control" />. </returns>
        /// =================================================================================================
        public LinkObject GetLinkObjectByControl(Control control)
        {
            return Links.FirstOrDefault(obj => obj.Parameters["Base"] == control);
        }

        /// =================================================================================================
        /// <summary> Returns a LinkObject which has the given <paramref name="identifier" />. </summary>
        /// <param name="identifier"> The identifier. </param>
        /// <returns> A LinkObject which has the given <paramref name="identifier" />. </returns>
        /// =================================================================================================
        public LinkObject GetLinkObjectByIdentifier(string identifier)
        {
            return Links.FirstOrDefault(obj => obj.Identifier == identifier);
        }

        /// =================================================================================================
        /// <summary> Returns a LinkCondition which is associated with object <paramref name="associatedObject" />. </summary>
        /// <param name="associatedObject"> The associated object. </param>
        /// <returns> A LinkCondition which is associated with <paramref name="associatedObject" />. </returns>
        /// =================================================================================================
        public LinkCondition GetConditionByObject(object associatedObject)
        {
            return Links.SelectMany(obj => obj.Conditions)
                .FirstOrDefault(condition => condition.Parameters["Base"] == associatedObject);
        }

        /// =================================================================================================
        /// <summary> Returns a LinkCondition which has the given <paramref name="identifier" />. </summary>
        /// <param name="identifier"> The identifier. </param>
        /// <returns> A LinkCondition which has the given <paramref name="identifier" />. </returns>
        /// =================================================================================================
        public LinkCondition GetConditionByIdentifier(string identifier)
        {
            foreach (var obj in Links)
            foreach (var cond in obj.Conditions)
                if (cond.Identifier == identifier)
                    return cond;
            return null;
        }

        /// =================================================================================================
        /// <summary>
        ///     Returns a LinkCondition which has the given <paramref name="identifier" /> and is child of
        ///     <paramref name="parent" />.
        /// </summary>
        /// <param name="identifier"> The identifier. </param>
        /// <param name="parent">     The parent LinkObject. </param>
        /// <returns>
        ///     A LinkCondition which has the given <paramref name="identifier" /> and is child of
        ///     <paramref name="parent" />.
        /// </returns>
        /// =================================================================================================
        public LinkCondition GetConditionByIdentifier(string identifier, LinkObject parent)
        {
            foreach (var cond in parent.Conditions)
                if (cond.Identifier == identifier)
                    return cond;
            return null;
        }

        /// =================================================================================================
        /// <summary>
        ///     Returns a ValidationObject which has the given <paramref name="identifier" />.
        /// </summary>
        /// <param name="identifier"> The identifier. </param>
        /// <returns> A ValidationObject which has the given <paramref name="identifier" />. </returns>
        /// =================================================================================================
        public ValidationObject GetByIdentifier(string identifier)
        {
            foreach (var obj in Links)
            {
                if (obj.Identifier == identifier)
                    return obj;

                foreach (var condition in obj.Conditions)
                    if (condition.Identifier == identifier)
                        return condition;
            }

            return null;
        }
    }
}