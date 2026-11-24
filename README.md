## Scaffold command EF Core
`dotnet ef dbcontext scaffold "Data Source=127.0.0.1,1433;Initial Catalog=EFCoreOptimizationLab;User ID=<your-db-id>;Password=<your-password>;Pooling=False;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Authentication=SqlPassword;" Microsoft.EntityFrameworkCore.SqlServer`

## AsNoTracking() function
- Improves data retrieval speed, in this project 3x speed improvement is observed for 500,000 records of Order table