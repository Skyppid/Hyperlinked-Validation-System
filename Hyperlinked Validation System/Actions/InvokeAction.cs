using System;
using System.Reflection;

namespace HyperlinkedValidationSystem.Actions
{
    /// =================================================================================================
    /// <summary> An action which invokes a method once executed. </summary>
    /// <seealso cref="T:HyperlinkedValidationSystem.Actions.ActionBase" />
    /// =================================================================================================
    public class InvokeAction : ActionBase
    {
        /// =================================================================================================
        /// <summary> Constructor. </summary>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when one or more required arguments are null.
        /// </exception>
        /// <exception cref="ArgumentException">     Thrown when the method does not exist. </exception>
        /// <param name="identifier">       The identifier. </param>
        /// <param name="trigger">          The trigger. </param>
        /// <param name="reflectionTarget"> The reflection target. </param>
        /// <param name="methodName">       Name of the method. </param>
        /// <param name="parameters">       The parameters. </param>
        /// =================================================================================================
        public InvokeAction(string identifier, ActionTrigger trigger, object reflectionTarget, string methodName,
            params object[] parameters) :
            base(identifier, trigger)
        {
            if (identifier == null) throw new ArgumentNullException("identifier");
            if (reflectionTarget == null) throw new ArgumentNullException("reflectionTarget");
            if (methodName == null) throw new ArgumentNullException("methodName");
            if (parameters == null) throw new ArgumentNullException("parameters");

            ReflectionTarget = reflectionTarget;
            Method = reflectionTarget.GetType().GetMethod(methodName);

            if (Method == null)
                throw new ArgumentException("Method '" + methodName + "' was not found in this object!");

            Parameters = parameters;
        }

        /// =================================================================================================
        /// <summary> Constructor. </summary>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when one or more required arguments are null.
        /// </exception>
        /// <param name="identifier">       The identifier. </param>
        /// <param name="trigger">          The trigger. </param>
        /// <param name="reflectionTarget"> The reflection target. </param>
        /// <param name="method">           The method. </param>
        /// <param name="parameters">       The parameters. </param>
        /// =================================================================================================
        public InvokeAction(string identifier, ActionTrigger trigger, object reflectionTarget, MethodInfo method,
            params object[] parameters)
            : base(identifier, trigger)
        {
            if (identifier == null) throw new ArgumentNullException("identifier");
            if (reflectionTarget == null) throw new ArgumentNullException("reflectionTarget");
            if (method == null) throw new ArgumentNullException("method");
            if (parameters == null) throw new ArgumentNullException("parameters");

            ReflectionTarget = reflectionTarget;
            Method = method;
            Parameters = parameters;
        }

        /// =================================================================================================
        /// <summary> Gets or sets the reflection target. </summary>
        /// <value> The reflection target. </value>
        /// =================================================================================================
        public object ReflectionTarget { get; set; }

        /// =================================================================================================
        /// <summary> Gets or sets the method. </summary>
        /// <value> The method. </value>
        /// =================================================================================================
        public MethodInfo Method { get; set; }

        /// =================================================================================================
        /// <summary> Gets or sets the invoke parameters. </summary>
        /// <value> The parameters. </value>
        /// =================================================================================================
        public object[] Parameters { get; set; }

        /// =================================================================================================
        /// <summary> Executes this action using the given trigger. </summary>
        /// <param name="trigger"> The trigger. </param>
        /// <seealso cref="M:HyperlinkedValidationSystem.Actions.ActionBase.Execute(ActionTrigger)" />
        /// =================================================================================================
        internal override void Execute(ActionTrigger trigger)
        {
            if (!Trigger.Has(trigger))
                return;

            Method.Invoke(ReflectionTarget, Parameters);
            base.Execute(trigger);
        }
    }
}