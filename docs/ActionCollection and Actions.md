**Actions** are "things" which are triggered after a previously defined event. But it´s not an event like you know it from .Net´s events.
Actions have IDs like ValidationObjects. Actions can be added to ValidationObjects (LinkObject, LinkCondition) and to LinkStructs.

# ActionTrigger-Enum
This enum contains all available triggers for actions. In 3.0 there are only 3, but those are enough for the beginning.
**Note**: The ActionTrigger-enum is a Flags-enum. You can use more than one trigger per action.

**BeforeValidation**
Actions with this trigger get executed before the belonging object gets validated.
**AfterValidationSucceed**
Actions get triggered after a successfull validation.
**AfterValidationFail**
Actions get triggered after a unsucessfull validation.