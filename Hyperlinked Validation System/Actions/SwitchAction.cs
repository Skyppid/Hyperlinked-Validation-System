using System;
using System.Reflection;

namespace HyperlinkedValidationSystem.Actions
{
    /// =================================================================================================
    /// <summary>
    ///     An action which is similiar to <see cref="PropertyChangeAction" /> which switches values
    ///     depending on the validation success. This action is bound to the "AfterValidationSucceed"
    ///     and "AfterValidationFailed" <see cref="" />!
    /// </summary>
    /// <seealso cref="T:HyperlinkedValidationSystem.Actions.ActionBase" />
    /// =================================================================================================
    public class SwitchAction : ActionBase
    {
        /// =================================================================================================
        /// <summary> Constructor. </summary>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when one or more required arguments are null.
        /// </exception>
        /// <exception cref="ArgumentException">     Thrown when the property does not exist. </exception>
        /// <param name="identifier">       The identifier. </param>
        /// <param name="reflectionTarget"> The reflection target. </param>
        /// <param name="property">         The property. </param>
        /// <param name="succeedValue">     The succeed value. </param>
        /// <param name="failValue">        The fail value. </param>
        /// =================================================================================================
        public SwitchAction(string identifier, object reflectionTarget, string property, object succeedValue,
            object failValue)
            : base(identifier, ActionTrigger.AfterValidationSucceed | ActionTrigger.AfterValidationFailed)
        {
            if (identifier == null) throw new ArgumentNullException("identifier");
            if (reflectionTarget == null) throw new ArgumentNullException("reflectionTarget");
            if (succeedValue == null) throw new ArgumentNullException("succeedValue");
            if (failValue == null) throw new ArgumentNullException("failValue");

            ReflectionTarget = reflectionTarget;
            Property = reflectionTarget.GetType().GetProperty(property);
            if (Property == null)
                throw new ArgumentException("Property '" + property + "' was not found in this object!");
            SucceedValue = succeedValue;
            FailValue = failValue;
        }

        /// =================================================================================================
        /// <summary> Constructor. </summary>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when one or more required arguments are null.
        /// </exception>
        /// <param name="identifier">       The identifier. </param>
        /// <param name="reflectionTarget"> The reflection target. </param>
        /// <param name="property">         The property. </param>
        /// <param name="succeedValue">     The succeed value. </param>
        /// <param name="failValue">        The fail value. </param>
        /// =================================================================================================
        public SwitchAction(string identifier, object reflectionTarget, PropertyInfo property, object succeedValue,
            object failValue)
            : base(identifier, ActionTrigger.AfterValidationSucceed | ActionTrigger.AfterValidationFailed)
        {
            if (identifier == null) throw new ArgumentNullException("identifier");
            if (reflectionTarget == null) throw new ArgumentNullException("reflectionTarget");
            if (property == null) throw new ArgumentNullException("property");
            if (succeedValue == null) throw new ArgumentNullException("succeedValue");
            if (failValue == null) throw new ArgumentNullException("failValue");

            ReflectionTarget = reflectionTarget;
            Property = property;
            SucceedValue = succeedValue;
            FailValue = failValue;
        }

        /// =================================================================================================
        /// <summary> Gets or sets the reflection target. </summary>
        /// <value> The reflection target. </value>
        /// =================================================================================================
        public object ReflectionTarget { get; set; }

        /// =================================================================================================
        /// <summary> Gets or sets the property. </summary>
        /// <value> The property. </value>
        /// =================================================================================================
        public PropertyInfo Property { get; set; }

        /// =================================================================================================
        /// <summary> Gets or sets the succeed value. </summary>
        /// <value> The succeed value. </value>
        /// =================================================================================================
        public object SucceedValue { get; set; }

        /// =================================================================================================
        /// <summary> Gets or sets the fail value. </summary>
        /// <value> The fail value. </value>
        /// =================================================================================================
        public object FailValue { get; set; }

        /// =================================================================================================
        /// <summary> Executes this action using the given trigger. </summary>
        /// <param name="trigger"> The trigger. </param>
        /// <seealso cref="M:HyperlinkedValidationSystem.Actions.ActionBase.Execute(ActionTrigger)" />
        /// =================================================================================================
        internal override void Execute(ActionTrigger trigger)
        {
            if (!Trigger.Has(trigger))
                return;

            switch (trigger)
            {
                case ActionTrigger.AfterValidationSucceed:
                    Property.SetValue(ReflectionTarget, SucceedValue, null);
                    break;
                case ActionTrigger.AfterValidationFailed:
                    Property.SetValue(ReflectionTarget, FailValue, null);
                    break;
            }

            base.Execute(trigger);
        }
    }
}