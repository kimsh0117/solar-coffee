select * from "Products";
insert into "Products" ("CreatedOn", "UpdatedOn","Name","Description", "Price", "IsTaxable", "IsArchived")
values
(now(), now(), '10 LB Dark Roast', '10 LB bag of dark roast coffee beans', 100, true, false),
(now(), now(), '30 LB Dark Roast', '30 LB bag of dark roast coffee beans', 280, true, false),
(now(), now(), '50 LB Dark Roast', '50 LB bag of dark roast coffee beans', 450, true, false),
(now(), now(), '10 LB Light Roast', '10 LB bag of light roast coffee beans', 100, true, false),
(now(), now(), '30 LB Light Roast', '30 LB bag of light roast coffee beans', 280, true, false),
(now(), now(), '50 LB Light Roast', '50 LB bag of light roast coffee beans', 450, true, false);

select * from "Customers";

select c."FirstName", c."LastName", ca."City", ca."State" 
from "Customers" c 
	inner join "CustomersAddresses" ca 
	On c."PrimaryAddressId" = ca."Id";
	
select * from "ProductInventories";

insert into "ProductInventories" ("CreatedOn", "UpdatedOn", "QuantityOnHand", "IdealQuantity", "ProductId")
values
(now(), now(), 20, 24, 1),
(now(), now(), 12, 20, 2),
(now(), now(), 16, 20, 3),
(now(), now(), 9, 12, 4),
(now(), now(), 24, 12, 5),
(now(), now(), 0, 8, 6);