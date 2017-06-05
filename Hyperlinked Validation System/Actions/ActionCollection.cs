using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HyperlinkedValidationSystem.Actions
{
    /// =================================================================================================
    /// <summary> A collection of actions. </summary>
    /// <seealso cref="T:System.Collections.Generic.ICollection{HyperlinkedValidationSystem.Actions.ActionBase}" />
    /// =================================================================================================
    public sealed class ActionCollection : ICollection<ActionBase>
    {
        private readonly List<ActionBase> _actions;

        /// <summary> Default constructor. </summary>
        public ActionCollection()
        {
            _actions = new List<ActionBase>();
        }

        /// =================================================================================================
        /// <summary> Constructor. </summary>
        /// <param name="actions"> A variable-length parameters list containing actions. </param>
        /// =================================================================================================
        public ActionCollection(params ActionBase[] actions)
        {
            _actions = new List<ActionBase>();
            AddRange(actions);
        }

        /// =================================================================================================
        /// <summary> Executes all actions which have the given <paramref name="trigger" /> set. </summary>
        /// <param name="trigger"> The trigger. </param>
        /// =================================================================================================
        public void ExecuteAll(ActionTrigger trigger)
        {
            var executeActions = _actions.Where(action => action.Trigger.Has(trigger)).ToList();
            foreach (var action in executeActions)
                action.Execute(trigger);
        }

        /// =================================================================================================
        /// <summary> Returns all actions which have the given <paramref name="trigger" /> set. </summary>
        /// <param name="trigger"> The trigger. </param>
        /// <returns> An array of actions. </returns>
        /// =================================================================================================
        public ActionBase[] GetByTrigger(ActionTrigger trigger)
        {
            return _actions.Where(action => action.Trigger.Has(trigger)).ToArray();
        }

        #region ICollection

        /// =================================================================================================
        /// <summary> Gets the enumerator. </summary>
        /// <returns> The enumerator. </returns>
        /// =================================================================================================
        public IEnumerator<ActionBase> GetEnumerator()
        {
            return _actions.GetEnumerator();
        }

        /// =================================================================================================
        /// <summary> Gets the enumerator. </summary>
        /// <returns> The enumerator. </returns>
        /// =================================================================================================
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// =================================================================================================
        /// <summary> Adds an action. </summary>
        /// <param name="action"> The action to add. </param>
        /// =================================================================================================
        public void Add(ActionBase action)
        {
            if (!Contains(action))
                _actions.Add(action);
        }

        /// =================================================================================================
        /// <summary> Adds a range of actions. </summary>
        /// <param name="actions"> A variable-length parameters list containing actions. </param>
        /// =================================================================================================
        public void AddRange(ActionBase[] actions)
        {
            foreach (var action in actions)
                if (!Contains(action))
                    _actions.Add(action);
        }

        /// <summary> Clears this ActionCollection to its blank/initial state. </summary>
        public void Clear()
        {
            _actions.Clear();
        }

        /// =================================================================================================
        /// <summary> Query if this ActionCollection contains the given action. </summary>
        /// <param name="action"> The ActionBase to test for containment. </param>
        /// <returns> True if the object is in this collection, false if not. </returns>
        /// =================================================================================================
        public bool Contains(ActionBase action)
        {
            return _actions.Contains(action) || _actions.Any(a => action.Identifier == a.Identifier);
        }

        /// =================================================================================================
        /// <summary> Copies this collection to an array. </summary>
        /// <param name="array">      The array. </param>
        /// <param name="arrayIndex"> Zero-based index of the array. </param>
        /// =================================================================================================
        public void CopyTo(ActionBase[] array, int arrayIndex)
        {
            _actions.CopyTo(array, arrayIndex);
        }

        /// =================================================================================================
        /// <summary> Removes the given action. </summary>
        /// <param name="action"> The ActionBase to test for containment. </param>
        /// <returns> True if it succeeds, false if it fails. </returns>
        /// =================================================================================================
        public bool Remove(ActionBase action)
        {
            return _actions.Remove(action);
        }

        /// =================================================================================================
        /// <summary> Removes the given action using it's identifier. </summary>
        /// <param name="id"> The Identifier to remove. </param>
        /// <returns> True if it succeeds, false if it fails. </returns>
        /// =================================================================================================
        public bool Remove(string id)
        {
            var act = _actions.FirstOrDefault(action => action.Identifier == id);
            return act != null && _actions.Remove(act);
        }

        /// =================================================================================================
        /// <summary> Gets the number of actions.  </summary>
        /// <value> The count. </value>
        /// =================================================================================================
        public int Count
        {
            get { return _actions.Count; }
        }

        /// =================================================================================================
        /// <summary> Gets a value indicating whether this ActionCollection is read only. </summary>
        /// <value> True if this ActionCollection is read only, false if not. </value>
        /// =================================================================================================
        public bool IsReadOnly
        {
            get { return false; }
        }

        #endregion
    }
}