/*
 * Autor: Manuel E. (Twisted Arts)
 * Homepage: http://twistedarts.bplaced.net/ 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;

namespace HyperlinkedValidationSystem
{
    [DefaultEvent("ValidationDone")]
    public class HVS : Component
    {
        public HVS()
        {
            Structs = new List<LinkStruct>();
            _validationTimer = new Timer {Interval = 200};
            _validationTimer.Tick += _validationTimer_Tick;
            if (_autoValidate)
                _validationTimer.Start();
        }

        private Timer _validationTimer;

        //NOT IMPLEMENTED IN EXPERIMENTAL RELEASE! [Editor(typeof(DesignTime.LinkStructUITypeEditor), typeof(UITypeEditor))]
        public List<LinkStruct> Structs { get; private set; }

        private bool _autoValidate = true;
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
            foreach (LinkStruct structure in Structs)
            {
                structure.Actions.ExecuteAll(ActionTrigger.BeforeValidation);

                if (structure.DisableValidating)
                    continue;

                ValidationBeginEventArgs vbEventArgs = new ValidationBeginEventArgs(structure);
                Invoke_ValidationBegin(vbEventArgs);
                if (vbEventArgs.Cancel) continue;

                bool valid = ValidateStruct(structure);
                Invoke_ValidationDone(new ValidationDoneEventArgs(structure, valid));

                structure.Actions.ExecuteAll(valid
                                                 ? ActionTrigger.AfterValidationSucceed
                                                 : ActionTrigger.AfterValidationFailed);
            }
        }

        /// <summary>
        /// Validates a structure of validation-objects.
        /// </summary>
        public bool ValidateStruct(LinkStruct structure)
        {
            foreach (LinkObject linkedObject in structure.Links)
            {
                structure.Actions.ExecuteAll(ActionTrigger.BeforeValidation);
                if (!ValidateObject(linkedObject))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Validates a ValidationObject.
        /// </summary>
        public bool ValidateObject(ValidationObject obj)
        {
            obj.Actions.ExecuteAll(ActionTrigger.BeforeValidation);
            if (obj.IsOptional) return true;

            bool conditionFlag = false;
            if (obj.Conditions.Count > 0)
            {
                foreach (LinkCondition condition in obj.Conditions)
                {
                    conditionFlag = condition.IsOptional || condition.ValidationMethod.Invoke(condition);

                    if (!conditionFlag)
                    {
                        if (!condition.IsOptional)
                            if (!condition.TemporaryOptional)
                                break;
                            else
                            {
                                conditionFlag = true;
                                condition.TemporaryOptional = false;
                            }
                    }
                }
            }
            else
                conditionFlag = true;

            if (conditionFlag)
            {
                if (obj.ValidationMethod.Invoke(obj) || obj.IsOptional)
                {
                    obj.Actions.ExecuteAll(ActionTrigger.AfterValidationSucceed);
                    return true;
                }
            }

            obj.Actions.ExecuteAll(ActionTrigger.AfterValidationFailed);
            return false;
        }

        #region Events
        #region EventArgs
        public class ValidationDoneEventArgs : EventArgs
        {
            public LinkStruct ValidatedStruct { get; private set; }
            public bool Result { get; private set; }

            public ValidationDoneEventArgs(LinkStruct structure, bool result)
            {
                ValidatedStruct = structure;
                Result = result;
            }
        }

        public class ValidationBeginEventArgs : CancelEventArgs
        {
            public LinkStruct ValidatingStruct { get; private set; }
            
            public ValidationBeginEventArgs(LinkStruct structure)
            {
                ValidatingStruct = structure;
            }
        }
        #endregion

        public delegate void ValidationDoneEventHandler(object sender, ValidationDoneEventArgs e);

        public event ValidationDoneEventHandler ValidationDone;

        public delegate void ValidationBeginEventHandler(object sender, ValidationBeginEventArgs e);

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
