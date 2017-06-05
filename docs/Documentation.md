# The Classes of HVS
The classes contained in HVS, what they do and what their properties are.
[ValidationObject-class](http://hvs.codeplex.com/wikipage?title=The ValidationObject)
LinkObject-class (identical to _ValidationObject_)
[LinkCondition-class](http://hvs.codeplex.com/wikipage?title=The%20LinkCondition-class)
[LinkStruct-class](http://hvs.codeplex.com/wikipage?title=The LinkStruct-class)
[HVS](http://hvs.codeplex.com/wikipage?title=The HVS-class)

# Validators
[Validators - What are they?](http://hvs.codeplex.com/wikipage?title=Validators)
[ParameterCollection and it´s parameters](http://hvs.codeplex.com/wikipage?title=ParameterCollection%2c Parameters and Validators)

Those validators a basically implemented into HVS. You can extend HVS by custom validators using the IPropertyValidator interface.
[BoolValidator](http://hvs.codeplex.com/wikipage?title=The Bool-Validator)
[EmailValidator](http://hvs.codeplex.com/wikipage?title=The Email-Validator)
[IntValidator](http://hvs.codeplex.com/wikipage?title=The Int-Validator)
[ValidationObjectValidator](http://hvs.codeplex.com/wikipage?title=The LinkObject-Validator)
[TextValidator](http://hvs.codeplex.com/wikipage?title=The Text-Validator)

# Actions
[ActionCollection and Actions](http://hvs.codeplex.com/wikipage?title=ActionCollection and Actions)
* **PropertyChangeAction**: Changes the property of an object.
* **InvokeAction**: Invokes a method.
* **SwitchAction**: Like the _PropertyChangeAction_ with the difference that it´s bound to the TriggerActions _AfterValidationSucceed_ and _AfterValidationFailed_ and changes the property-value according to whether the validation was successfull or not.

# Samples
Everything is shown in the downloadable sample.