using System;
using System.Reflection;

namespace HyperlinkedValidationSystem.Actions
{
    /// =================================================================================================
    /// <summary> An action which changes a property once executed. </summary>
    /// <seealso cref="T:HyperlinkedValidationSystem.Actions.ActionBase" />
    /// =================================================================================================
    public class PropertyChangeAction : ActionBase
    {
        /// =================================================================================================
        /// <summary> Constructor. </summary>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when one or more required arguments are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     Thrown when the property does not exist.
        /// </exception>
        /// <param name="identifier">       The identifier. </param>
        /// <param name="trigger">          The trigger. </param>
        /// <param name="reflectionTarget"> The reflection target. </param>
        /// <param name="propertyName">     Name of the property. </param>
        /// <param name="value">            The value. </param>
        /// <param name="index">            The index. </param>
        /// =================================================================================================
        public PropertyChangeAction(string identifier, ActionTrigger trigger, object reflectionTarget,
            string propertyName, object value, object[] index) :
            base(identifier, trigger)
        {
            if (identifier == null) throw new ArgumentNullException("identifier");
            if (reflectionTarget == null) throw new ArgumentNullException("reflectionTarget");
            if (propertyName == null) throw new ArgumentNullException("propertyName");
            if (value == null) throw new ArgumentNullException("value");
            if (index == null) throw new ArgumentNullException("index");

            ReflectionTarget = reflectionTarget;
            Property = reflectionTarget.GetType().GetProperty(propertyName);

            if (Property == null)
                throw new ArgumentException("Property '" + propertyName + "' was not found in this object!");

            Value = value;
            Index = index;
        }

        /// =================================================================================================
        /// <summary> Constructor. </summary>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when one or more required arguments are null.
        /// </exception>
        /// <param name="identifier">       The identifier. </param>
        /// <param name="trigger">          The trigger. </param>
        /// <param name="reflectionTarget"> The reflection target. </param>
        /// <param name="property">         The property. </param>
        /// <param name="value">            The value. </param>
        /// <param name="index">            The index. </param>
        /// =================================================================================================
        public PropertyChangeAction(string identifier, ActionTrigger trigger, object reflectionTarget,
            PropertyInfo property, object value, object[] index) :
            base(identifier, trigger)
        {
            if (identifier == null) throw new ArgumentNullException("identifier");
            if (reflectionTarget == null) throw new ArgumentNullException("reflectionTarget");
            if (property == null) throw new ArgumentNullException("property");
            if (value == null) throw new ArgumentNullException("value");
            if (index == null) throw new ArgumentNullException("index");

            ReflectionTarget = reflectionTarget;
            Property = property;
            Value = value;
            Index = index;
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
        /// <summary> Gets or sets the value. </summary>
        /// <value> The value. </value>
        /// =================================================================================================
        public object Value { get; set; }

        /// =================================================================================================
        /// <summary>
        ///     Gets or sets the zero-based index at which the property should be changed (if property is
        ///     an array type).
        /// </summary>
        /// <value> The index. </value>
        /// =================================================================================================
        public object[] Index { get; set; }

        /// =================================================================================================
        /// <summary> Executes this action using the given trigger. </summary>
        /// <param name="trigger"> The trigger. </param>
        /// <seealso cref="M:HyperlinkedValidationSystem.Actions.ActionBase.Execute(ActionTrigger)" />
        /// =================================================================================================
        internal override void Execute(ActionTrigger trigger)
        {
            if (!Trigger.Has(trigger))
                return;

            Property.SetValue(ReflectionTarget, Value, Index);
            base.Execute(trigger);
        }
    }
}