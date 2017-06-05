The **TextValidator** contains methods which validates text-based things.

# Methods
## Validate
This method validates a property of the _Base_-Object on it´s emptyness.

+**Parameters**+
**BaseValue** (must be of type _PropertyInfo_ or _FieldInfo_ - should be a **reflected parameter**)
This is the value which has to be validated - like the "Text"-property of some .Net controls.

**MustBeEmpty** (must be of type _bool_ - should be a **static parameter**)
This parameter states if the _BaseValue_ must be empty/null or not.
**Default**: false
**Options**: _false_ = must not be empty, _true_ must be empty/null


## ValidateTextOfTwo
This method validates two dynamic strings on their equality.

+**Parameters**+
**BaseValue** (must be of type _PropertyInfo_ or _FieldInfo_ - should be a **reflected parameter**)
**ReferenceValue** (must be of type _PropertyInfo_ or _FieldInfo_ **or** _string_ - should be a **reflected/static parameter**)
**TextValidator:Invert** (must be of type _bool_ - should be a **static parameter**)
This parameter states whether the validator should validate using **!=** or **==**.
**Default**: false
**Options**: _false_ = **==**, _true_ = **!=**