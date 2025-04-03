using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite.Storage.Internal;

namespace Api.Data;

public class AppDbContext : DbContext
{
    private  ISqliteRelationalConnection _connection
}