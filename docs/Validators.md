# What are validators?
From 1.0 to 2.0 validators were classes which validated values. They had to be created and set with properties.
Since **3.0**, there are no more classes. Your fully able to create faster custom validators. HVS 3.0 uses the **Func<>**-delegates for easier usage.

All in one, validators checks if the "base-value" is in correct condition to the "reference-value". If they are, a validator returns "true" to the HVS. Otherwise it returns "false".

# How does such a validator looks like?
This is the default "BoolValidator":
{code:c#}
    public static class BoolValidator
    {
        public static ParameterCollection Default =
            new ParameterCollection(new StaticParameter("BoolValidator:Invert", false));

        /// <summary>
        /// Required parameters: BaseValue (typeof bool), ReferenceValue (typeof bool), BoolValidator:Invert (typeof bool).
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool Validate(ValidationObject obj)
        {
            bool invert = (bool) obj.Parameters["BoolValidator:Invert", false](_BoolValidator_Invert_,-false);
            bool baseValue = (bool)obj.Parameters["BaseValue"](_BaseValue_);
            bool referenceValue = (bool)obj.Parameters["ReferenceValue"](_ReferenceValue_);

            return invert ? baseValue != referenceValue : baseValue == referenceValue;
        }
    }
{code:c#}

What the "Parameters" are, you can learn reading the "Parameters"-article.