using System;
using System.Collections.Generic;
using System.Windows.Forms;
using HyperlinkedValidationSystem;
using HyperlinkedValidationSystem.Validators;

namespace HVS_Sample
{
    public partial class mainFrm : Form
    {
        private LinkStruct validStruct;

        public mainFrm()
        {
            InitializeComponent();
        }

        private void mainFrm_Load(object sender, EventArgs e)
        {
            //Since 3.0, HVS is a component you can add to your forms (but not yet with design-time support, this should come with 4.0).
            //So HVS now supports auto-validation. It automatically validates each 200ms all LinkStructs which are not "ValidationDisabled".

            //First we create a new struct and add it to the HVS.
            //As example for the new added actions (in 3.0), this struct has two actions.
            //Both change the Text of the WinForm, but only if executed. The first gets executed after a successfull validation.
            //The second gets executed after a unsuccessfull validation. You´re fully able to create own actions and add as much as
            //you want (but don´t use the same ID twice!).

            //And of course we add a "SwitchAction" which automatically changes the buttons "enabled"-state.
            validStruct = new LinkStruct(new SwitchAction("FormText", this, "Text", "Validation Succeed!", "Validation Failed!"),
                    new SwitchAction("TriggerButton", btn_activate, "Enabled", true, false));
            hvs.Structs.Add(validStruct);

            //No were going to add some LinkObjects to the struct. The first parameter is the ID 
            //(never add two items with equal ID to one and the same struct!).
            //The second is a method you want to use as validator. The third parameter makes the LinkObject optional.
            //The fourth is one of the most important parameters. It´s a collection of parameters for the validation-method
            //which contains important things like the "BaseValue" (for more information take a look into the documentation
            //http://hvs.codeplex.com/wikipage?title=ParameterCollection%2c%20Parameters%20and%20Validators)
            //The fifth is a collection of actions. Those actions get mentioned later. And the last parameter is a list
            //of conditions this LinkObject has (also mentioned later).
            validStruct.Add(new LinkObject("Name", TextValidator.Validate, false, new ParameterCollection(
                                                   new ReflectedParameter("BaseValue", txb_name, "Text", true))));

            validStruct.Add(new LinkObject("LastName", TextValidator.Validate, false, new ParameterCollection(
                new ReflectedParameter("BaseValue", txb_lastname,"Text", true))));

            validStruct.Add(new LinkObject("EMail", EmailValidator.Validate, false, new ParameterCollection(
                new ReflectedParameter("BaseValue", txb_email, "Text", true))));

            validStruct.Add(new LinkObject("Password", TextValidator.Validate, false, new ParameterCollection(
                new ReflectedParameter("BaseValue", txb_password, "Text"))));

            //Now were going to add something mentioned before. Some conditions.
            //Because the "Repeat Password"-Box must contain the same password as the "Password"-Box
            //we need to check if their text is equal. We´re doing this by adding the following condition:
            validStruct.Add(new LinkObject("PasswordRepeat", TextValidator.Validate, false, new ParameterCollection(
                new ReflectedParameter("BaseValue", txb_repeatPassword, "Text")), null,
                new LinkCondition("PasswordEquality", TextValidator.ValidateTextOfTwo, false, new ParameterCollection(
                    new ReflectedParameter("BaseValue", txb_password, "Text", true),
                    new ReflectedParameter("ReferenceValue", txb_repeatPassword, "Text", true)))));
            //This condition uses the "ValidateTextOfTwo"-Validation method. This method validates two equal texts.

            //Last but not least we add a LinkObject for the Checkbox by using the BoolValidation.
            validStruct.Add(new LinkObject("TermsAccepted", BoolValidator.Validate, false, new ParameterCollection(
                new ReflectedParameter("BaseValue", chb_tou, "Checked", true),
                new StaticParameter("ReferenceValue", true))));
            //This method uses a static parameter as ReferenceValue. Of course you can use a ReflectedParameter, too.
        }

        #region Optional Checkboxes (Events)
        private void chb_optionalName_CheckedChanged(object sender, EventArgs e)
        {
            validStruct.GetLinkObjectByIdentifier("Name").IsOptional = chb_optionalName.Checked;
        }

        private void chb_optionalLastname_CheckedChanged(object sender, EventArgs e)
        {
            validStruct.GetLinkObjectByIdentifier("LastName").IsOptional = chb_optionalLastname.Checked;
        }

        private void chb_optionalEmail_CheckedChanged(object sender, EventArgs e)
        {
            validStruct.GetLinkObjectByIdentifier("EMail").IsOptional = chb_optionalEmail.Checked;
        }

        private void chb_optionalPass_CheckedChanged(object sender, EventArgs e)
        {
            validStruct.GetLinkObjectByIdentifier("Password").IsOptional = chb_optionalPass.Checked;
        }

        private void chb_optionalRepPass_CheckedChanged(object sender, EventArgs e)
        {
            validStruct.GetLinkObjectByIdentifier("PasswordRepeat").IsOptional = chb_optionalRepPass.Checked;
        }

        private void chb_optionalCondition_CheckedChanged(object sender, EventArgs e)
        {
            validStruct.GetConditionByIdentifier("PasswordEquality").IsOptional = chb_optionalCondition.Checked;
        }
        #endregion
    }
}
