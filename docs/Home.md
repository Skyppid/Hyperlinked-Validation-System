# What is HVS?
Do you know creating WinForm-Applications with a big number of textboxes, checkboxes and some optional input fields?
It takes a lot of time to check if the values which where input by the end-user are correct or empty.
It´s quite impossible to check such huge forms.

**Announcement 21/11/11**
Caused by my job and some other reasons I don´t have time anymore. I´m forced to stop HVS developement.
Now the latest source is available for free development. If someone has made a newer version out of it, there´s the possibility of sending it to me.
I will release it here in your´s name.




HVS takes this work. It checks each Control by custom validation schemes. You can combine them with custom Conditions, which can also be optional.
Take a look into the documentation. There are some samples how it works.
It takes a lot of work for you.

# HVS 3.0 released
Now it´s here! **HVS 3.0** comes to you with a bunch of new features and a whole revised system.

**The new system**:
The base-system of HVS was the "IPropertyValidator"-interface from which each Validator inherited it´s function.
But the new system allows more flexible validators and reduces the code you must write for new validators.

The system is based on delegates. You now write only a method which validates everything.
The newly introduced ParameterCollection contains all important data and parameters for the validation-method (the new word for "Validator").
It was never as easy as know. But of course, this system has some unpleasent things, too. So please say which system is better, the old or the new (do this in this [thread](http://hvs.codeplex.com/discussions/268224))

**Other new features**:
* Actions (important new feature)
* Parameters
* HVS component
	* Auto-Validation
* Manual Validation (of LinkStructs or ValidationObjects)
* Completely rewritten sample showing all new features (except manual validation)

For more details look into the documentation.

**Note**: This version doesn´t contain design-time support. This feature may come with 4.0.

# Sample
![](Home_http://www.abload.de/img/hvs3-samplescreen5qgl.png)
Just a few lines of code:
{code:c#}
        private void mainFrm_Load(object sender, EventArgs e)
        {
            validStruct = new LinkStruct(new SwitchAction("FormText", this, "Text", "Validation Succeed!", "Validation Failed!"),
                    new SwitchAction("TriggerButton", btn_activate, "Enabled", true, false));
            hvs.Structs.Add(validStruct);

            validStruct.Add(new LinkObject("Name", TextValidator.Validate, false, new ParameterCollection(
                                                   new ReflectedParameter("BaseValue", txb_name, "Text", true))));
            validStruct.Add(new LinkObject("LastName", TextValidator.Validate, false, new ParameterCollection(
                new ReflectedParameter("BaseValue", txb_lastname,"Text", true))));
            validStruct.Add(new LinkObject("EMail", EmailValidator.Validate, false, new ParameterCollection(
                new ReflectedParameter("BaseValue", txb_email, "Text", true))));
            validStruct.Add(new LinkObject("Password", TextValidator.Validate, false, new ParameterCollection(
                new ReflectedParameter("BaseValue", txb_password, "Text"))));

            validStruct.Add(new LinkObject("PasswordRepeat", TextValidator.Validate, false, new ParameterCollection(
                new ReflectedParameter("BaseValue", txb_repeatPassword, "Text")), null,
                new LinkCondition("PasswordEquality", TextValidator.ValidateTextOfTwo, false, new ParameterCollection(
                    new ReflectedParameter("BaseValue", txb_password, "Text", true),
                    new ReflectedParameter("ReferenceValue", txb_repeatPassword, "Text", true)))));
            validStruct.Add(new LinkObject("TermsAccepted", BoolValidator.Validate, false, new ParameterCollection(
                new ReflectedParameter("BaseValue", chb_tou, "Checked", true),
                new StaticParameter("ReferenceValue", true))));
        }
{code:c#}

* **Make suggestions what i can do to make the system better than it is now - i have some ideas but you can tell me yours too ;)**


# References
[QuoteBase](http://dotnetbase.de/topic/1205-quotebase/page__view__findpost__p__8205)