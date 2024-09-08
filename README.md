# CarRental.Api
Service is built on .Net5 (VS 2019) . This api is using in memory collection.  This can be changed and connected to any database, and can create using Entity Framework Core Code first approach as well but as in memory  is sufficing the need and there was no requirement of fetching records from database I opted to use in memory.

 
1.	To run the Api, run the solution and refer swagger
2.	Api command handler test cases are written using XUnit


## Swagger 

.Net core api is configured with swagger URL 
Run the instance of Car Rental Api and use below link for swagger

https://localhost:44397/swagger/index.html


## List of service api

Action | Method | Route
------------ | ------------- |--------
availability	|GET request. Returns list of vehicles requested based on selected vehicle id and dates.	| /api/CarRental/availability
reserve	|POST request. Creates a reservation and errors out if inventory is not available for dates .	| /api/CarRental/reserve
