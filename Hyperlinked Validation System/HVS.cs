using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using HyperlinkedValidationSystem.Actions;

namespace HyperlinkedValidationSystem
{
    /// =================================================================================================
    /// <summary>
    ///     The HVS component which acts as main controller for input validation in forms.
    /// </summary>
    /// <remarks>
    ///     Can be used as single controller for a whole application using the singleton pattern or
    ///     as component for each input form.
    /// </remarks>
    /// <seealso cref="T:System.ComponentModel.Component" />
    /// =================================================================================================
    [DefaultEvent("ValidationDone")]
    public class HVS : Component
    {
        private readonly Timer _validationTimer;

        private bool _autoValidate = true;

        /// <summary> Default constructor. </summary>
        public HVS()
        {
            Structs = new List<LinkStruct>();
            _validationTimer = new Timer {Interval = 200};
            _validationTimer.Tick += _validationTimer_Tick;
            if (_autoValidate)
                _validationTimer.Start();
        }

        //NOT IMPLEMENTED IN EXPERIMENTAL RELEASE! [Editor(typeof(DesignTime.LinkStructUITypeEditor), typeof(UITypeEditor))]
        public List<LinkStruct> Structs { get; private set; }

        /// =================================================================================================
        /// <summary>
        ///     Gets or sets a value indicating whether HVS should automatically validate all
        ///     <see cref="LinkStruct" /> objects.
        /// </summary>
        /// <value> True if automatic validation should be enabled, false if not. </value>
        /// =================================================================================================
        [DefaultValue(true)]
        public bool AutoValidate
        {
            get { return _autoValidate; }
            set
            {
                _autoValidate = value;
                if (value)
                    _validationTimer.Start();
                else
                    _validationTimer.Stop();
            }
        }

        private void _validationTimer_Tick(object sender, EventArgs e)
        {
            foreach (var structure in Structs)
            {
                structure.Actions.ExecuteAll(ActionTrigger.BeforeValidation);

                if (structure.DisableValidating)
                    continue;

                var vbEventArgs = new ValidationBeginEventArgs(structure);
                Invoke_ValidationBegin(vbEventArgs);
                if (vbEventArgs.Cancel) continue;

                bool valid = ValidateStruct(structure);
                Invoke_ValidationDone(new ValidationDoneEventArgs(structure, valid));

                structure.Actions.ExecuteAll(valid
                    ? ActionTrigger.AfterValidationSucceed
                    : ActionTrigger.AfterValidationFailed);
            }
        }

        /// =================================================================================================
        /// <summary> Validates a <see cref="LinkStruct" /> and all it's elements. </summary>
        /// <param name="structure"> The structure. </param>
        /// <returns> True if it succeeds, false if it fails. </returns>
        /// =================================================================================================
        public bool ValidateStruct(LinkStruct structure)
        {
            foreach (var linkedObject in structure.Links)
            {
                structure.Actions.ExecuteAll(ActionTrigger.BeforeValidation);
                if (!ValidateObject(linkedObject))
                    return false;
            }
            return true;
        }

        /// =================================================================================================
        /// <summary> Validates a <see cref="ValidationObject" />. </summary>
        /// <param name="obj"> The object. </param>
        /// <returns> True if it succeeds, false if it fails. </returns>
        /// =================================================================================================
        public bool ValidateObject(ValidationObject obj)
        {
            obj.Actions.ExecuteAll(ActionTrigger.BeforeValidation);
            if (obj.IsOptional) return true;

            var conditionFlag = false;
            if (obj.Conditions.Count > 0)
                foreach (var condition in obj.Conditions)
                {
                    conditionFlag = condition.IsOptional || condition.ValidationMethod.Invoke(condition);

                    if (!conditionFlag)
                        if (!condition.IsOptional)
                            if (!condition.TemporaryOptional)
                            {
                                break;
                            }
                            else
                            {
                                conditionFlag = true;
                                condition.TemporaryOptional = false;
                            }
                }
            else
                conditionFlag = true;

            if (conditionFlag)
                if (obj.ValidationMethod.Invoke(obj) || obj.IsOptional)
                {
                    obj.Actions.ExecuteAll(ActionTrigger.AfterValidationSucceed);
                    return true;
                }

            obj.Actions.ExecuteAll(ActionTrigger.AfterValidationFailed);
            return false;
        }

        #region Events

        #region EventArgs

        /// =================================================================================================
        /// <summary> Additional information for ValidationDone events. </summary>
        /// <seealso cref="T:System.EventArgs" />
        /// =================================================================================================
        public class ValidationDoneEventArgs : EventArgs
        {
            public ValidationDoneEventArgs(LinkStruct structure, bool result)
            {
                ValidatedStruct = structure;
                Result = result;
            }

            public LinkStruct ValidatedStruct { get; private set; }
            public bool Result { get; private set; }
        }

        /// =================================================================================================
        /// <summary> Additional information for ValidationBegin events. </summary>
        /// <seealso cref="T:System.ComponentModel.CancelEventArgs" />
        /// =================================================================================================
        public class ValidationBeginEventArgs : CancelEventArgs
        {
            public ValidationBeginEventArgs(LinkStruct structure)
            {
                ValidatingStruct = structure;
            }

            public LinkStruct ValidatingStruct { get; private set; }
        }

        #endregion

        public delegate void ValidationDoneEventHandler(object sender, ValidationDoneEventArgs e);

        /// <summary> Event queue for all listeners interested in ValidationDone events. </summary>
        public event ValidationDoneEventHandler ValidationDone;

        public delegate void ValidationBeginEventHandler(object sender, ValidationBeginEventArgs e);

        /// <summary> Event queue for all listeners interested in ValidationBegin events. </summary>
        public event ValidationBeginEventHandler ValidationBegin;

        #region Invoker-Methods

        private void Invoke_ValidationBegin(ValidationBeginEventArgs e)
        {
            if (ValidationBegin != null)
                ValidationBegin(this, e);
        }

        private void Invoke_ValidationDone(ValidationDoneEventArgs e)
        {
            if (ValidationDone != null)
                ValidationDone(this, e);
        }

        #endregion

        #endregion
    }
}