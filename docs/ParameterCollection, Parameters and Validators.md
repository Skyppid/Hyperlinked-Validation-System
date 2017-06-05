A **ParameterCollection** is a collection of KeyValue-Pairs which contains all required data for _ValidationMethods_.
The thing you must know is, that there are some _Keynames_ that you must know, because they are needed by each validator of HVS.

# Parameters
Parameters inherit the abstract class "AParameter". They have a identifier-key (string) and a **Value**-property which is marked as abstract.
Depending on the type of parameter it returns the value in different ways (see [#Parameter-Types](#Parameter-Types))

**Note**: Validator-specific parameters are named in this way: **{[ValidatorName](ValidatorName):[ParameterName](ParameterName)}**. Example: _**"IntValidator:Mode"**_

# Global Parameters
## Base
The parameter called "Base" is the object which contains the data. For example a control of type "TextBox".
Base is needed by: **IntValidator**.

## BaseValue
The BaseValue is a reflected parameter. It´s a dynamic value which can change all time. Using the **ReflectedParameter** this can be read out simply.
BaseValue is needed by: **IntValidator**, **BoolValidator**, **EmailValidator**, **TextValidator**.

## Reference
The _Reference_ is the equivalent to _Base_. It´s a second object which serves as a comparative object.
Reference is needed by: **ValidationObjectValidator**.

## ReferenceValue
This is a second value which serves as a comparative value like Reference for Base. In most cases this value is static.
For this case use the **StaticParameter**.

Which parameters are required by the default-validators of HVS is mentioned in the comments of the validation methods.
For more detail take a look to the articles about the respective validator.
The comments always look like this one (from IntValidator):
{{        /// <summary>
        /// Required parameters: Base, BaseValue (typeof int), ReferenceValue (typeof int), IntValidator:Mode (typeof IntValidationMode).
        /// </summary>}}

{anchor:Parameter-Types}
# Parameter-Types
In 3.0 there are two types of parameters. Static and Reflected.
## Static Parameter
The static parameter only has an identifier-key and a static value. It´s used as comparative value to dynamic values.
## Reflected Parameter
The reflected parameter has an identifier-key, a base-object and a reflection-element (either PropertyInfo or FieldInfo).
This parameter returns always the current value of the base-object´s property.

# Combining ParameterCollections
You´re able to combine two or more collections using the **Combine**-method. So you´re able to combine your collection with some of the default collections of the validators.