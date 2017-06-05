namespace HyperlinkedValidationSystem.Actions
{
    /// <summary> A base class for actions. </summary>
    public abstract class ActionBase
    {
        /// =================================================================================================
        /// <summary> Specialised constructor for use only by derived class. </summary>
        /// <param name="identifier"> The identifier. </param>
        /// =================================================================================================
        protected ActionBase(string identifier)
        {
            Identifier = identifier;
        }

        /// =================================================================================================
        /// <summary> Specialised constructor for use only by derived class. </summary>
        /// <param name="identifier">      The identifier. </param>
        /// <param name="trigger"> The trigger. </param>
        /// =================================================================================================
        protected ActionBase(string identifier, ActionTrigger trigger)
        {
            Identifier = identifier;
            Trigger = trigger;
        }

        public string Identifier { get; private set; }

        /// =================================================================================================
        /// <summary> Gets or sets the trigger. </summary>
        /// <value> The trigger. </value>
        /// =================================================================================================
        public ActionTrigger Trigger { get; set; }

        /// =================================================================================================
        /// <summary> Executes this action using the given trigger. </summary>
        /// <param name="trigger"> The trigger. </param>
        /// =================================================================================================
        internal virtual void Execute(ActionTrigger trigger)
        {
        }
    }
}