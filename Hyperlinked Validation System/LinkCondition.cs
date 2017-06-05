using System;
using System.Collections.Generic;
using HyperlinkedValidationSystem.Actions;
using HyperlinkedValidationSystem.Parameters;

namespace HyperlinkedValidationSystem
{
    /// =================================================================================================
    /// <summary> A condition which can be attached to <see cref="LinkObject" />. </summary>
    /// <seealso cref="T:HyperlinkedValidationSystem.ValidationObject" />
    /// =================================================================================================
    public class LinkCondition : ValidationObject
    {
        /// <summary> Default constructor. </summary>
        public LinkCondition()
        {
            Parameters = new ParameterCollection();
            Conditions = new List<LinkCondition>();
            Actions = new ActionCollection();
        }

        /// =================================================================================================
        /// <summary> Constructor. </summary>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when one or more required arguments are null.
        /// </exception>
        /// <param name="identifier">                  The identifier. </param>
        /// <param name="validationMethod">            The validation method. </param>
        /// <param name="isOptional">
        ///     (Optional) True if this LinkCondition is optional.
        /// </param>
        /// <param name="parameters">
        ///     (Optional) A collection of parameters.
        /// </param>
        /// <param name="actions">                     (Optional) A collection of actions. </param>
        /// <param name="temporaryOptional">
        ///     (Optional) True to make this LinkCondition temporary optional.
        /// </param>
        /// <param name="conditions">
        ///     A variable-length parameters list containing conditions.
        /// </param>
        /// =================================================================================================
        public LinkCondition(string identifier, Func<ValidationObject, bool> validationMethod,
            bool isOptional = false, ParameterCollection parameters = null, ActionCollection actions = null,
            bool temporaryOptional = false, params LinkCondition[] conditions)
        {
            if (identifier == null) throw new ArgumentNullException("identifier");
            if (validationMethod == null) throw new ArgumentNullException("validationMethod");

            Identifier = identifier;
            ValidationMethod = validationMethod;
            Parameters = parameters ?? new ParameterCollection();
            Actions = actions ?? new ActionCollection();
            IsOptional = isOptional;
            TemporaryOptional = temporaryOptional;
            Conditions = new List<LinkCondition>();
            if (conditions.Length > 0)
                Conditions.AddRange(conditions);
        }

        /// =================================================================================================
        /// <summary>
        ///     Makes the condition temporary optional. This means, it is optional for one validation
        ///     cycle.
        /// </summary>
        /// <value> True if temporary optional, false if not. </value>
        /// =================================================================================================
        public bool TemporaryOptional { get; set; }
    }
}