The **BoolValidator** has just one function.
It checks whether a value is equal or unequal to the reference-value.

# Parameters
_Note that basic parameters are described in the main article "Validators"!_

BaseValue (must be of type _bool_ - should be a **reflected parameter**)
ReferenceValue (must be of type _bool_ - should be a **static parameter**)

**BoolValidator:Invert** (must be of type _bool_ - should be a **static parameter**)
This parameter states if the validator validates _base_ and _reference_ with **!=** or **==**.
**Default Value:** +false+.
**Options:** _false_ = **==**, _true_ = **!=**

# Example
Your _BaseValue_ is +true+.
Your _ReferenceValue_ is +false+.
Your _BoolValidator:Invert_ is +false+.

The Validator validates this link as **invalid** because _BaseValue_ != _ReferenceValue_.