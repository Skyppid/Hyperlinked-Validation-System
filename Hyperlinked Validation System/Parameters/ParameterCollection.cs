using System;
using System.Collections.Generic;
using System.Linq;

namespace HyperlinkedValidationSystem.Parameters
{
    /// =================================================================================================
    /// <summary>
    ///     A collection of parametersBase (with various types) representing a collection of dynamic or
    ///     static values.
    /// </summary>
    /// =================================================================================================
    public sealed class ParameterCollection
    {
        private readonly List<ParameterBase> _params;

        /// =================================================================================================
        /// <summary> Constructor. </summary>
        /// <param name="parametersBase"> A variable-length parametersBase list containing parametersBase. </param>
        /// =================================================================================================
        public ParameterCollection(params ParameterBase[] parametersBase)
        {
            _params = new List<ParameterBase>();
            if (parametersBase.Length > 0)
                foreach (var t in parametersBase)
                    _params.Add(t);
        }

        /// =================================================================================================
        /// <summary> Returns the given parametersBase value. </summary>
        /// <param name="id">                 The identifier. </param>
        /// <param name="defaultReturnValue"> (Optional) The default return value. </param>
        /// <param name="targetType">         (Optional) The target type. </param>
        /// <returns> The indexed item. </returns>
        /// =================================================================================================
        public object this[string id, object defaultReturnValue = null, Type targetType = null]
        {
            get
            {
                var retVal = (from param in _params where param.Identifier == id select param.Value).FirstOrDefault();

                if (retVal == null)
                    return defaultReturnValue;

                if (targetType != null)
                {
                    if (retVal.GetType() != targetType)
                        return defaultReturnValue;
                    return retVal;
                }

                return retVal;
            }
            set
            {
                var obj = (from param in _params where param.Identifier == id select param).FirstOrDefault();
                if (obj != null)
                    obj.Value = value;
            }
        }

        /// =================================================================================================
        /// <summary> Adds a new dynamic parameter to the parameter-collection. </summary>
        /// <param name="id">               An unique id for the parameter. </param>
        /// <param name="reflectionTarget"> A reflection target. </param>
        /// <param name="param">
        ///     The param object (a string which is used as property-name for a new PropertyInfo-
        ///     instance).
        /// </param>
        /// <param name="ignoreFields">     True to ignore fields. </param>
        /// =================================================================================================
        public void AddDynamic(string id, object reflectionTarget, string param, bool ignoreFields)
        {
            _params.Add(new ReflectedParameter(id, reflectionTarget, param, ignoreFields));
        }

        /// =================================================================================================
        /// <summary> Adds a new dynamic parameter to the parameter-collection. </summary>
        /// <param name="id">               An unique id for the parameter. </param>
        /// <param name="reflectionTarget"> A reflection target. </param>
        /// <param name="param">
        ///     The param object (typeof "FieldInfo" or "PropertyInfo").
        /// </param>
        /// =================================================================================================
        public void AddDynamic(string id, object reflectionTarget, string param)
        {
            _params.Add(new ReflectedParameter(id, reflectionTarget, param));
        }

        /// =================================================================================================
        /// <summary> Adds a new static parameter to the parameter-collection. </summary>
        /// <param name="id">    The identifier. </param>
        /// <param name="value"> The value. </param>
        /// =================================================================================================
        public void AddStatic(string id, object value)
        {
            _params.Add(new StaticParameter(id, value));
        }

        /// =================================================================================================
        /// <summary> Removes the parameter with the given id. </summary>
        /// <param name="id"> The identifier. </param>
        /// =================================================================================================
        public void Remove(string id)
        {
            _params.Remove(_params.FirstOrDefault(param => param.Identifier == id));
        }

        /// =================================================================================================
        /// <summary> Combines this collection with <paramref name="collection" />. </summary>
        /// <param name="collection"> The collection to combine. </param>
        /// =================================================================================================
        public void Combine(ParameterCollection collection)
        {
            foreach (var param in collection._params)
                if (!_params.Contains(param))
                    _params.Add(param);
        }
    }
}