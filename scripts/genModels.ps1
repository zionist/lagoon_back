dotnet ef dbcontext scaffold "Host=127.0.0.1;Database=lagoon;Username=lagoon;Password=lagoon" Npgsql.EntityFrameworkCore.PostgreSQL -o DAL\App\  -v --schema=app -f -c AppDbContext