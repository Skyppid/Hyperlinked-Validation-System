using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Reflection;
using System.Text;

namespace HyperlinkedValidationSystem
{
    public abstract class ValidationObject
    {
        protected ValidationObject()
        {
            Actions = new ActionCollection();
        }

        /// <summary>
        /// An unique identifier for searches.
        /// </summary>
        [Category("Identification")]
        [Description("Required by the HVS to get the correct ValidationObject. Must be a unique name.")]
        public string Identifier { get; set; }

        /// <summary>
        /// A collection of parameters which are needed for the validation.
        /// </summary>
        [Browsable(false)]
        public ParameterCollection Parameters { get; set; }

        /// <summary>
        /// A function which validates this object.
        /// </summary>
        public Func<ValidationObject, bool> ValidationMethod { get; set; }

        /// <summary>
        /// Sets or gets whether this object is optional.
        /// </summary>
        [Category("Validation")]
        [Description("Marks this object as optional. It gets ignored.")]
        public bool IsOptional { get; set; }

        /// <summary>
        /// A list of conditions which have to be validated too for an final result.
        /// </summary>
        [Browsable(false)]
        public List<LinkCondition> Conditions { get; set; }

        /// <summary>
        /// A collection of actions which gets executed after some events.
        /// </summary>
        [Browsable(false)]
        public ActionCollection Actions { get; set; }

        /// <summary>
        /// Validates the object manually.
        /// </summary>
        /// <returns>The result of validation.</returns>
        public bool Validate()
        {
            Actions.ExecuteAll(ActionTrigger.BeforeValidation);
            if (IsOptional) return true;

            bool conditionFlag = false;
            if (Conditions.Count > 0)
            {
                foreach (LinkCondition condition in Conditions)
                {
                    conditionFlag = condition.IsOptional || condition.ValidationMethod.Invoke(condition);

                    if (!conditionFlag)
                    {
                        if (!condition.IsOptional)
                            if (!condition.TemporaryOptional)
                                break;
                            else
                            {
                                conditionFlag = true;
                                condition.TemporaryOptional = false;
                            }
                    }
                }
            }
            else
                conditionFlag = true;

            if (conditionFlag)
            {
                if (ValidationMethod.Invoke(this) || IsOptional)
                {
                    Actions.ExecuteAll(ActionTrigger.AfterValidationSucceed);
                    return true;
                }
            }

            Actions.ExecuteAll(ActionTrigger.AfterValidationFailed);
            return false;
        }
    }
}
