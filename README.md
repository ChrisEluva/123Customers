This is .NET sevice (REST) which showcases basic functionalities like Create, Read, Update and delete. 
It uses a SQL server for its DB needs.

The ER diagram attached (ER_Diagram_1.0) shows the DB architecture that is currently implemented, it describes the relationship between customerDetais and AddressDetails tables.
The current relationship would mean that only a one to one relationship is possible. (A customer can only have one address)

See image(ER_Diagram_2.0) for a proposed DB architecture that will support one  to many relationships, i.e a customer can have multiple addresses.

This was manually tested using Postman. Seperate GET and POST requests were made and the resulting JSON data was analysed.

TODO :
Unit Tests
