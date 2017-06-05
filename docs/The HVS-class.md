The **HVS** is the main-class of the whole system. It manages _LinkStructs_ and has a pre-implemented, automatic validation-cycle.
From 3.0 the HVS is a component with which you´re able to design your form-validations at Design-Time.

# Auto-Validation
You´re able to activate the automatic validation-cycles by setting **AutoValidate** to true.
This mode automatically validates all structs whose **DisableValidating**-property is set to false - in 200ms steps.

# Events
## ValidationBegin
This event is fired before starting a new validation of an ValidationObject. So this is called for each ValidationObject in a struct.
The peculiarity of this event is that it´s able to abort the process using the **CancelEventArgs**-inheritance.

## ValidationDone
This event gets fired after a successful validation of a ValidationObject.