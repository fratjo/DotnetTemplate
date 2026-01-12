using Domain.Users.Entities;
using Domain.Users.Repositories;

using Infrastructure.Contexts;

namespace Infrastructure.Repositories;

public class UserWriteRepository(AppDbContext context) : IUserWriteRepository
{
    public async Task AddAsync(User entity, CancellationToken cancellationToken = default)
    {
        context.Users.Add(entity);
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(User entity, CancellationToken cancellationToken = default)
    {
        context.Users.Remove(entity);
        await Task.CompletedTask;
    }

    public async Task<bool> ExistsByUsernameAsync(string username, CancellationToken cancellationToken = default)
    {
        return await GetByUsernameAsync(username, cancellationToken) is not null;
    }

    public async Task<IReadOnlyList<User>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await Task.FromResult(context.Users.ToList());
    }

    public async Task<User?> LoadByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await Task.FromResult(context.Users.FirstOrDefault(u => u.Id == id));
    }

    public async Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken = default)
    {
        return await Task.FromResult(context.Users.FirstOrDefault(u => u.Username == username));
    }

    public async Task UpdateAsync(User entity, CancellationToken cancellationToken = default)
    {
        await Task.FromResult(context.Users.Update(entity));
    }
}