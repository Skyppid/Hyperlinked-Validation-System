A **ValidationObject** is nothing more than a mother-class for _LinkObjects_ and _LinkConditions_.

# Properties
**Identifier**
This identifier is used as a ID for fast identification in LinkStructs. It´s needed by the "SearchBy..."-methods of _LinkStruct_.

**Parameters**
A _ParameterCollection_ which contains all required parameters for the _ValidationMethod_.

**ValidationMethod**
A method of type _**Func<ValidationObject, bool>**_ (_bool Name(ValidationObject obj)_).
This method validates this ValidationObject.

**IsOptional**
This property sets whether the ValidationObject is optional. Optional objects are ignored and validated as valid.

**Conditions**
A list of conditions (ValidationObjects too, but with some extra things). Those get validated before the ValidationObject.
If one of them is **invalid**, the whole object is invalid, too. See [The LinkCondition-class](The-LinkCondition-class).


# Validate
Last but not least you´re able to validate a ValidationObject manually. You just have to call "Validate()".