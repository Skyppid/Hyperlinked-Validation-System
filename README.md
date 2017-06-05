# Hyperlinked Validation System
An alternative powerful input validation system for Windows Forms.

This project was migrated from Codeplex to keep it available. HVS was initially created back in 2011 when Windows Forms were still in use. The project has been abandoned ever since. While there is some code for the for 4.0 planned design time support, it has not ever been implemented correctly.

Anyone who's willing to work on this project may do so. The source has been updated and refactored to be more clear and understandable and has been fully documented. A branch was added for the new 4.0 feature but is in unstable shape.

Feel free to use HVS as you like.

![HVS Sample](http://www.abload.de/img/hvs3-samplescreen5qgl.png)

This small form can be fully automatically validated with the following code snippet:
```csharp
_validStruct = new LinkStruct(new SwitchAction("FormText", this, "Text", "Validation Succeed!", "Validation Failed!"),
        new SwitchAction("TriggerButton", btn_activate, "Enabled", true, false));
hvs.Structs.Add(_validStruct);

_validStruct.Add(new LinkObject("Name", TextValidator.Validate, false, new ParameterCollection(
                                        new ReflectedParameter("BaseValue", txb_name, "Text", true))));

_validStruct.Add(new LinkObject("LastName", TextValidator.Validate, false, new ParameterCollection(
    new ReflectedParameter("BaseValue", txb_lastname,"Text", true))));

_validStruct.Add(new LinkObject("EMail", EmailValidator.Validate, false, new ParameterCollection(
    new ReflectedParameter("BaseValue", txb_email, "Text", true))));

_validStruct.Add(new LinkObject("Password", TextValidator.Validate, false, new ParameterCollection(
    new ReflectedParameter("BaseValue", txb_password, "Text"))));

_validStruct.Add(new LinkObject("PasswordRepeat", TextValidator.Validate, false, new ParameterCollection(
    new ReflectedParameter("BaseValue", txb_repeatPassword, "Text")), null,
    new LinkCondition("PasswordEquality", TextValidator.ValidateEquality, false, new ParameterCollection(
        new ReflectedParameter("BaseValue", txb_password, "Text", true),
        new ReflectedParameter("ReferenceValue", txb_repeatPassword, "Text", true)))));

_validStruct.Add(new LinkObject("TermsAccepted", BoolValidator.Validate, false, new ParameterCollection(
    new ReflectedParameter("BaseValue", chb_tou, "Checked", true),
    new StaticParameter("ReferenceValue", true))));
```
