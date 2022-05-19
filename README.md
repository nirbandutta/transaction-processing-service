# transaction-processing-service
**.NET 5.0 Web Api**

**Open API 3.0 Specification** - /src/TransactionProcessingService.API/ApiContract/v1/OpenApiSpecification.yaml

**Rest API HealthCheck Endpoints** - /src/TransactionProcessingService.API/Controllers/HealthCheckController.cs

**Rest API Endpoints with proper URL Naming** - /src/TransactionProcessingService.API/Controllers/MerchantController.cs 

**Rest API Endpoints which returns composite Response** - /src/TransactionProcessingService.API/Controllers/TransactionController.cs

**Data Layer - Side-by-side EF Core and Dapper used for data access:**
1. Dapper Used for Legacy DB Tables where it provides simplicity and better performance.
2. EF Core is used for new DB tables.

**_Note - API Authentication/Authorization is not used_**
