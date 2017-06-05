using System;
using System.Reflection;

namespace HyperlinkedValidationSystem.Parameters
{
    /// =================================================================================================
    /// <summary>
    ///     A dynamic parameter which polls the latest value by reflection.
    /// </summary>
    /// <seealso cref="T:HyperlinkedValidationSystem.Parameters.ParameterBase" />
    /// =================================================================================================
    public sealed class ReflectedParameter : ParameterBase
    {
        private readonly FieldInfo _finfo;
        private readonly bool _mode;
        private readonly PropertyInfo _pinfo;

        private readonly object _reflectionTarget;

        /// =================================================================================================
        /// <summary> Constructor. </summary>
        /// <exception cref="Exception"> Thrown when an exception error condition occurs. </exception>
        /// <param name="id">               The identifier. </param>
        /// <param name="reflectionTarget"> The reflection target. </param>
        /// <param name="name">             The name of the field or property. </param>
        /// <param name="ignoreFields">     (Optional) True to ignore fields. </param>
        /// =================================================================================================
        public ReflectedParameter(string id, object reflectionTarget, string name, bool ignoreFields = false)
            : base(id, reflectionTarget)
        {
            if (ignoreFields)
            {
                _mode = true;
                _pinfo = reflectionTarget.GetType().GetProperty(name);
            }
            else
            {
                _finfo = reflectionTarget.GetType().GetField(name);
                if (_finfo == null)
                {
                    _mode = true;
                    _pinfo = reflectionTarget.GetType().GetProperty(name);

                    if (_pinfo == null)
                        throw new Exception(
                            "Cannot create reflected parameter. The property or field couldn´t be found!");
                }
            }

            _reflectionTarget = reflectionTarget;
        }

        #region Overrides of ParameterBase

        /// =================================================================================================
        /// <summary> Gets the value. </summary>
        /// <value> The value. </value>
        /// <seealso cref="P:HyperlinkedValidationSystem.Parameters.ParameterBase.Value" />
        /// =================================================================================================
        public override object Value
        {
            get { return _mode ? _pinfo.GetValue(_reflectionTarget, null) : _finfo.GetValue(_reflectionTarget); }
        }

        #endregion
    }
}