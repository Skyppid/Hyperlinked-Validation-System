/*
 * Autor: Manuel E. (Twisted Arts)
 * Homepage: http://twistedarts.bplaced.net/ 
 */

using System;
using System.Collections.Generic;
using System.Reflection;

namespace HyperlinkedValidationSystem
{
    public class LinkCondition : ValidationObject
    {
        /// <summary>
        /// Makes the condition temporary optional. This means, it is optional for one validation cycle.
        /// </summary>
        public bool TemporaryOptional { get; set; }

        public LinkCondition()
        {
            Parameters = new ParameterCollection();
            Conditions = new List<LinkCondition>();
            Actions = new ActionCollection();
        }

        public LinkCondition(string identifier, Func<ValidationObject, bool> validationMethod,
            bool isOptional = false, ParameterCollection parameters = null, ActionCollection actions = null,
            bool makeParentTemporaryOptional = false, params LinkCondition[] conditions)
        {
            Identifier = identifier;
            ValidationMethod = validationMethod;
            Parameters = parameters ?? new ParameterCollection();
            Actions = actions ?? new ActionCollection();
            IsOptional = isOptional;
            TemporaryOptional = makeParentTemporaryOptional;
            Conditions = new List<LinkCondition>();
            if (conditions.Length > 0)
                Conditions.AddRange(conditions);
        }
    }
}
