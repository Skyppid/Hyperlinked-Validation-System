using System;
using System.Collections.Generic;
using System.ComponentModel;
using HyperlinkedValidationSystem.Actions;
using HyperlinkedValidationSystem.Parameters;

namespace HyperlinkedValidationSystem
{
    /// <summary> An abstract base class for validation objects. </summary>
    public abstract class ValidationObject
    {
        /// <summary> Specialised default constructor for use only by derived class. </summary>
        protected ValidationObject()
        {
            Actions = new ActionCollection();
        }

        /// =================================================================================================
        /// <summary> An unique identifier. </summary>
        /// <value> The identifier. </value>
        /// =================================================================================================
        [Category("Identification")]
        [Description("Required by the HVS to get the correct ValidationObject. Must be a unique name.")]
        public string Identifier { get; set; }

        /// =================================================================================================
        /// <summary> A collection of parameters which are needed for the validation. </summary>
        /// <value> The parameters. </value>
        /// =================================================================================================
        [Browsable(false)]
        public ParameterCollection Parameters { get; set; }

        /// =================================================================================================
        /// <summary> A function which validates this ValidationObject. </summary>
        /// <value> The validation method. </value>
        /// =================================================================================================
        public Func<ValidationObject, bool> ValidationMethod { get; set; }

        /// =================================================================================================
        /// <summary> Sets or gets whether this ValidationObject is optional. </summary>
        /// <value> True if this ValidationObject is optional, false if not. </value>
        /// =================================================================================================
        [Category("Validation")]
        [Description("Marks this object as optional. It gets ignored.")]
        public bool IsOptional { get; set; }

        /// =================================================================================================
        /// <summary> A list of conditions which must succeed validation as well. </summary>
        /// <value> The conditions. </value>
        /// =================================================================================================
        [Browsable(false)]
        public List<LinkCondition> Conditions { get; set; }

        /// =================================================================================================
        /// <summary> A collection of actions which gets executed after some events. </summary>
        /// <value> The actions. </value>
        /// =================================================================================================
        [Browsable(false)]
        public ActionCollection Actions { get; set; }

        /// =================================================================================================
        /// <summary> Validates the ValidationObject manually. </summary>
        /// <returns> The result of validation. </returns>
        /// =================================================================================================
        public bool Validate()
        {
            Actions.ExecuteAll(ActionTrigger.BeforeValidation);
            if (IsOptional) return true;

            var conditionFlag = false;
            if (Conditions.Count > 0)
                foreach (var condition in Conditions)
                {
                    conditionFlag = condition.IsOptional || condition.ValidationMethod.Invoke(condition);

                    if (!conditionFlag)
                        if (!condition.IsOptional)
                            if (!condition.TemporaryOptional)
                            {
                                break;
                            }
                            else
                            {
                                conditionFlag = true;
                                condition.TemporaryOptional = false;
                            }
                }
            else
                conditionFlag = true;

            if (conditionFlag)
                if (ValidationMethod.Invoke(this) || IsOptional)
                {
                    Actions.ExecuteAll(ActionTrigger.AfterValidationSucceed);
                    return true;
                }

            Actions.ExecuteAll(ActionTrigger.AfterValidationFailed);
            return false;
        }
    }
}