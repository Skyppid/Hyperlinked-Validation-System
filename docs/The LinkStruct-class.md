The **LinkStruct** is a list of _ValidationObjects_. It has no greater function, but it´s used to seperate different validations from each other.
Since **3.0** the struct has some methods which returns a ValidationObject by searching known information.

**Information you can search to find your ValidationObject:**
* Control (System.Windows.Forms.Control): A control it has as **Base**.
	* **Note**: This only works when the control is set as **Base**.
* Identifier: The ID of the ValidationObject.