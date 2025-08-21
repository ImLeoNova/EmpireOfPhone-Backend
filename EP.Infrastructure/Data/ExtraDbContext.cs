using EP.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EP.Infrastructure.Data;

public class ExtraDbContext(DbContextOptions<ExtraDbContext> options)
    : IdentityDbContext<User, IdentityRole, string>(options)
;