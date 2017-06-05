using System;
using System.Collections.Generic;
using HyperlinkedValidationSystem.Actions;
using HyperlinkedValidationSystem.Parameters;

namespace HyperlinkedValidationSystem
{
    /// =================================================================================================
    /// <summary>
    ///     A LinkObject which acts as actual implementation of <see cref="ValidationObject" />. The
    ///     LinkObject represents one single option of your input form which should be validated.
    /// </summary>
    /// <example>
    ///     A LinkObject could be the HVS representive of a text box which requires the user to enter
    ///     his e-mail address. The LinkObject is linked to the textbox's 'Text' property and has a
    ///     validator for e-mail addresses set.
    /// </example>
    /// <seealso cref="T:HyperlinkedValidationSystem.ValidationObject" />
    /// =================================================================================================
    public class LinkObject : ValidationObject
    {
        /// <summary> Default constructor. </summary>
        public LinkObject()
        {
            Parameters = new ParameterCollection();
            Conditions = new List<LinkCondition>();
            Actions = new ActionCollection();
        }

        /// =================================================================================================
        /// <summary> Constructor. </summary>
        /// <param name="identifier">       The identifier for this LinkObject. </param>
        /// <param name="validationMethod"> The validation method. </param>
        /// <param name="isOptional">       (Optional) True if this LinkObject is optional. </param>
        /// <param name="parameters">       (Optional) Additional parameters for this LinkObject. </param>
        /// <param name="actions">
        ///     (Optional) The actions which should be executed on success or failure of validation.
        /// </param>
        /// <param name="conditions">
        ///     A variable-length parameters list containing conditions.
        /// </param>
        /// =================================================================================================
        public LinkObject(string identifier, Func<ValidationObject, bool> validationMethod,
            bool isOptional = false, ParameterCollection parameters = null, ActionCollection actions = null,
            params LinkCondition[] conditions)
        {
            Identifier = identifier;
            ValidationMethod = validationMethod;
            Parameters = parameters ?? new ParameterCollection();
            Actions = actions ?? new ActionCollection();
            Conditions = new List<LinkCondition>();
            if (conditions.Length > 0)
                Conditions.AddRange(conditions);

            IsOptional = isOptional;
        }
    }
}