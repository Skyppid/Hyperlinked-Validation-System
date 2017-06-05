/*
 * Autor: Manuel E. (Twisted Arts)
 * Homepage: http://twistedarts.bplaced.net/ 
 */

using System;
using System.Collections.Generic;
using System.Reflection;

namespace HyperlinkedValidationSystem
{
    public class LinkObject : ValidationObject
    {
        public LinkObject()
        {
            Parameters = new ParameterCollection();
            Conditions = new List<LinkCondition>();
            Actions = new ActionCollection();
        }

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
