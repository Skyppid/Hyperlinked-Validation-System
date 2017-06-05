using System;

namespace HyperlinkedValidationSystem.Actions
{
    /// <summary> Triggers for actions. </summary>
    [Flags]
    public enum ActionTrigger
    {
        /// <summary> Executes assigned actions before validation. </summary>
        BeforeValidation = 1,

        /// <summary> Executes assigned actions after successful validations. </summary>
        AfterValidationSucceed = 2,

        /// <summary> Executes assigned actions after failed validations. </summary>
        AfterValidationFailed = 4
    }
}