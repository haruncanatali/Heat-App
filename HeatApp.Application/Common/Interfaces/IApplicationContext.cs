using HeatApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HeatApp.Application.Common.Interfaces;

public interface IApplicationContext
{
    public DbSet<Heat> Heats { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}