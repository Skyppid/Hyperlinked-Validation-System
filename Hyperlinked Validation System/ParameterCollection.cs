using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace HyperlinkedValidationSystem
{
    /// <summary>
    /// A collection of parameters (with various types) representing a collection of dynamic or static values.
    /// </summary>
    public sealed class ParameterCollection
    {
        private List<AParameter> _params;

        public ParameterCollection(params AParameter[] parameters)
        {
            _params = new List<AParameter>();
            if (parameters.Length > 0)
                foreach (AParameter t in parameters)
                    _params.Add(t);
        }

        /// <summary>
        /// Returns the given parameters value.
        /// </summary>
        public object this[string id, object defaultReturn = null, Type destinationType = null]
        {
            get
            {
                object retVal = (from param in _params where param.ID == id select (param).Value).FirstOrDefault();

                if (retVal == null)
                    return defaultReturn;

                if (destinationType != null)
                {
                    if (retVal.GetType() != destinationType)
                        return defaultReturn;
                    return retVal;
                }

                return retVal;
            }
            set
            {
                AParameter obj = (from param in _params where param.ID == id select param).FirstOrDefault(); 
                if (obj != null)
                    obj.Value = value;
            }
        }

        /// <summary>
        /// Adds a new dynamic parameter to the parameter-collection.
        /// </summary>
        /// <param name="id">An unique id for the parameter.</param>
        /// <param name="obj">A value-object for reflection.</param>
        /// <param name="param">The param object (a string which is used as property-name for a new PropertyInfo-instance).</param>
        public void AddDynamic(string id, object obj, string param, bool ignoreFields = false)
        {
            _params.Add(new ReflectedParameter(id, obj, param, ignoreFields));
        }

        /// <summary>
        /// Adds a new dynamic parameter to the parameter-collection.
        /// </summary>
        /// <param name="id">An unique id for the parameter.</param>
        /// <param name="obj">A value-object for reflection.</param>
        /// <param name="param">The param object (typeof "FieldInfo" or "PropertyInfo").</param>
        public void AddDynamic(string id, object obj, string param)
        {
            _params.Add(new ReflectedParameter(id, obj, param));
        }

        /// <summary>
        /// Adds a new static parameter to the parameter-collection.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        public void AddStatic(string id, object value)
        {
            _params.Add(new StaticParameter(id, value));
        }

        /// <summary>
        /// Removes the parameter with the given id.
        /// </summary>
        /// <param name="id"></param>
        public void Remove(string id)
        {
            _params.Remove(_params.Where(param => (param).ID == id).FirstOrDefault());
        }

        public void Combine(ParameterCollection collection)
        {
            foreach (AParameter param in collection._params)
                if (!_params.Contains(param))
                    _params.Add(param);
        }
    }

    /// <summary>
    /// An abstract class, representing an parameter with it´s basic members.
    /// </summary>
    public abstract class AParameter
    {
        protected AParameter(string id, object obj)
        {
            ID = id;
            Base = obj;
        }

        public string ID { get; private set; }
        public object Base { get; set; }
        public virtual object Value { get; set; }
    }

    /// <summary>
    /// A default parameter without any value-object. Has a static value.
    /// </summary>
    public class StaticParameter : AParameter
    {
        /// <summary>
        /// Creates a new static parameter which always returns the same value.
        /// </summary>
        public StaticParameter(string id, object value)
            : base(id, null)
        {
            Value = value;
        }
    }

    /// <summary>
    /// A dynamic parameter which returns the newest value using a value-object and reflection.
    /// </summary>
    public class ReflectedParameter : AParameter
    {
        /// <summary>
        /// Creates a new dynamic parameter which gets always the latest state of value.
        /// </summary>
        public ReflectedParameter(string id, object obj, string name, bool ignoreFields = false)
            : base(id, obj)
        {
            if (ignoreFields)
            {
                _mode = true;
                _pinfo = obj.GetType().GetProperty(name);
            }
            else
            {
                _finfo = obj.GetType().GetField(name);
                if (_finfo == null)
                {
                    _mode = true;
                    _pinfo = obj.GetType().GetProperty(name);

                    if (_pinfo == null)
                        throw new Exception("Cannot create reflected parameter. The property or field couldn´t be found!");
                }
            }

            _obj = obj;
        }

        private object _obj;
        private bool _mode;
        private PropertyInfo _pinfo;
        private FieldInfo _finfo;

        #region Overrides of AParameter

        public override object Value
        {
            get { return _mode ? _pinfo.GetValue(_obj, null) : _finfo.GetValue(_obj); }
        }

        #endregion
    }

    public class BaseParameter : StaticParameter
    {
        public BaseParameter(object value) : base("Base", value)
        {
        }
    }

    public class ReferenceParameter : StaticParameter
    {
        public ReferenceParameter(object value) : base("Reference", value)
        {
        }
    }

    public class ReferenceValueParameter : StaticParameter
    {
        public ReferenceValueParameter(object value) : base("ReferenceValue", value)
        {
        }
    }
}
