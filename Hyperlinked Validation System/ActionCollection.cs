using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace HyperlinkedValidationSystem
{
    /// <summary>
    /// A collection of actions.
    /// </summary>
    public sealed class ActionCollection : ICollection<AAction>
    {
        private List<AAction> _actions;

        public ActionCollection()
        {
            _actions = new List<AAction>();
        }

        public ActionCollection(params AAction[] actions)
        {
            _actions = new List<AAction>();
            AddRange(actions);
        }

        public void ExecuteAll(ActionTrigger trigger)
        {
            List<AAction> executeActions = _actions.Where(action => action.Trigger.Has(trigger)).ToList();
            foreach (AAction action in executeActions)
                action.Execute(trigger);
        }

        public AAction[] GetByTrigger(ActionTrigger trigger)
        {
            return _actions.Where(action => action.Trigger.Has(trigger)).ToArray();
        }

        #region ICollection
        public IEnumerator<AAction> GetEnumerator()
        {
            return _actions.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(AAction item)
        {
            if (!Contains(item))
                _actions.Add(item);
        }

        public void AddRange(AAction[] actions)
        {
            foreach (AAction action in actions)
                if (!Contains(action))
                    _actions.Add(action);
        }

        public void Clear()
        {
            _actions.Clear();
        }

        public bool Contains(AAction item)
        {
            if (_actions.Contains(item))
                return true;

            foreach (AAction action in _actions)
                if (action.ID == item.ID)
                    return true;

            return false;
        }

        public void CopyTo(AAction[] array, int arrayIndex)
        {
            _actions.CopyTo(array, arrayIndex);
        }

        public bool Remove(AAction item)
        {
            return _actions.Remove(item);
        }

        public bool Remove(string id)
        {
            AAction act = _actions.Where(action => action.ID == id).FirstOrDefault();
            if (act != null)
                return _actions.Remove(act);
            return false;
        }

        public int Count { get { return _actions.Count; } }
        public bool IsReadOnly { get { return false; } }
        #endregion
    }

    /// <summary>
    /// The base-class for new actions you must inherit.
    /// </summary>
    public abstract class AAction
    {
        public string ID { get; private set; }
        public ActionTrigger Trigger { get; set; }

        protected AAction(string id)
        {
            ID = id;
        }

        protected AAction(string id, ActionTrigger trigger)
        {
            ID = id;
            Trigger = trigger;
        }

        internal virtual void Execute(ActionTrigger trigger)
        {
        }
    }

    /// <summary>
    /// Some triggers for actions.
    /// </summary>
    [Flags]
    public enum ActionTrigger
    {
        BeforeValidation = 1,
        AfterValidationSucceed = 2,
        AfterValidationFailed = 4,
    }

    /// <summary>
    /// This action changes a property if triggered.
    /// </summary>
    public class PropertyChangeAction : AAction
    {
        public object Obj { get; set; }
        public PropertyInfo Property { get; set; }
        public object Value { get; set; }
        public object[] Index { get; set; }

        public PropertyChangeAction(string id, ActionTrigger trigger, object obj, string propertyName, object value, object[] index) :
            base(id, trigger)
        {
            Obj = obj;
            Property = obj.GetType().GetProperty(propertyName);

            if (Property == null)
                throw new InvalidOperationException("Property '" + propertyName + "' was not found in this object!");

            Value = value;
            Index = index;
        }

        public PropertyChangeAction(string id, ActionTrigger trigger, object obj, PropertyInfo property, object value, object[] index) :
            base(id, trigger)
        {
            Obj = obj;
            Property = property;
            Value = value;
            Index = index;
        }

        internal override void Execute(ActionTrigger trigger)
        {
            if (!Trigger.Has(trigger))
                return;

            Property.SetValue(Obj, Value, Index);
            base.Execute(trigger);
        }
    }

    /// <summary>
    /// This action invokes a method if triggered.
    /// </summary>
    public class InvokeAction : AAction
    {
        public MethodInfo Method { get; set; }
        public object Obj { get; set; }
        public object[] Parameters { get; set; }

        public InvokeAction(string id, ActionTrigger trigger, object obj, string methodName, params object[] parameters) :
            base(id, trigger)
        {
            Obj = obj;
            Method = obj.GetType().GetMethod(methodName);

            if (Method == null)
                throw new InvalidOperationException("Method '" + methodName + "' was not found in this object!");

            Parameters = parameters;
        }

        public InvokeAction(string id, ActionTrigger trigger, object obj, MethodInfo method, params object[] parameters)
            : base(id, trigger)
        {
            Obj = obj;
            Method = method;
            Parameters = parameters;
        }

        internal override void Execute(ActionTrigger trigger)
        {
            if (!Trigger.Has(trigger))
                return;

            Method.Invoke(Obj, Parameters);
            base.Execute(trigger);
        }
    }

    /// <summary>
    /// This action switches between two values (like PropertyChangeAction) if triggered.
    /// This action is bound to the "AfterValidationSucceed" and "AfterValidationFailed" TriggerActions!
    /// </summary>
    public class SwitchAction : AAction
    {
        public object Obj { get; set; }
        public PropertyInfo Property { get; set; }
        public object SucceedValue { get; set; }
        public object[] SucceedIndex { get; set; }
        public object FailValue { get; set; }
        public object[] FailIndex { get; set; }

        public SwitchAction(string id, object obj, string property, object succeedValue, object failValue,
            object[] succedIndex = null, object[] failIndex = null)
            : base(id, ActionTrigger.AfterValidationSucceed | ActionTrigger.AfterValidationFailed)
        {
            Obj = obj;
            Property = obj.GetType().GetProperty(property);
            if (Property == null)
                throw new InvalidOperationException("Property '" + property + "' was not found in this object!");
            SucceedValue = succeedValue;
            SucceedIndex = succedIndex;
            FailValue = failValue;
            FailIndex = failIndex;
        }

        public SwitchAction(string id, object obj, PropertyInfo property, object succeedValue, object failValue,
    object[] succedIndex = null, object[] failIndex = null)
            : base(id, ActionTrigger.AfterValidationSucceed | ActionTrigger.AfterValidationFailed)
        {
            Obj = obj;
            Property = property;
            SucceedValue = succeedValue;
            SucceedIndex = succedIndex;
            FailValue = failValue;
            FailIndex = failIndex;
        }

        internal override void Execute(ActionTrigger trigger)
        {
            if (!Trigger.Has(trigger))
                return;

            switch (trigger)
            {
                case ActionTrigger.AfterValidationSucceed:
                    Property.SetValue(Obj, SucceedValue, SucceedIndex);
                    break;
                case ActionTrigger.AfterValidationFailed:
                    Property.SetValue(Obj, FailValue, FailIndex);
                    break;
            }

            base.Execute(trigger);
        }
    }
}
