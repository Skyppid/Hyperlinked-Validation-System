The **IntValidator** validates base-value and reference-value on equality or unequality of their values.

# Parameters
_Note that basic parameters are described in the main article "Validators"!_

BaseValue (must be of type _int_ - should be a **reflected parameter**)
ReferenceValue (must be of type _int_ - should be a **static parameter**)

**IntValidator:Mode** (must be of type _IntValidationMode_ - should be a **static parameter**)
This parameter states which mode should be used to validate the two values (see "IntValidation-Modes" for more detail).
**Default**: _Equal_
**Options:** See "IntValidation-Modes" below.

# Example
**Example 1**:
Your _BaseValue_ is 24.
Your _ReferenceValue_ is 32.
Your _IntValidator:Mode_ is Unequal.

The validator returns **valid** because the values are unequal.

**Example 2**:
Your _BaseValue_ is 22.
Your _ReferenceValue_ is -4.
Your _IntValidator:Mode_ is HiqherOrEqual.

The validator returns **invalid** as -4 is not higher or equal than 22.


# IntValidator-Modes
* HigherThan
* HigherOrEqual
* Equal
* Unequal
* LowerOrEqual
* LowerThan