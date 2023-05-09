using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FinanceManagerAPI.Data;
using FinanceManagerAPI.DTO;
using FinanceManagerAPI.Models;
using Microsoft.EntityFrameworkCore;

public interface IUserAccountService {
    Task<UserAccount> GetUserByEmail(string email);
    Task<UserAccount> GetUserById(long id);
    Task<UserAccount> CreateUser(UserAccountCreateDto userAccountDto);
    Task UpdateUser(long id, UserAccountUpdateDto userAccount);
    Task<UserAccount> DeleteUser(long id);
}

public class UserAccountService : IUserAccountService {
    private readonly FinanceManagerDbContext _context;
    private readonly IMapper _mapper;

    public UserAccountService(FinanceManagerDbContext context, IMapper mapper) {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UserAccount> GetUserByEmail(string email) {
        var user = await _context.UserAccounts.FirstOrDefaultAsync(u => u.Email == email);
        if (user == null) {
            throw new ArgumentException("User not found.");
        }
        return user;
    }
    public async Task<UserAccount> GetUserById(long id) {
        var userAccount = await _context.UserAccounts.FindAsync(id);
        if (userAccount == null) {
            throw new ArgumentException("User not found.");
        }

        return userAccount;
    }

    public async Task<UserAccount> CreateUser(UserAccountCreateDto userAccountDto) {
        if (string.IsNullOrEmpty(userAccountDto.Email) || string.IsNullOrEmpty(userAccountDto.Password)) {
            throw new ArgumentException("Invalid user account data.");
        }

        var userAccount = _mapper.Map<UserAccount>(userAccountDto);

        _context.UserAccounts.Add(userAccount);
        await _context.SaveChangesAsync();

        return userAccount;
    }

    public async Task UpdateUser(long id, UserAccountUpdateDto userAccount) {
        var user = await _context.UserAccounts.FindAsync(id);

        if (user == null) {
            throw new ArgumentException("User not found.");
        }

        _mapper.Map(userAccount, user);

        await _context.SaveChangesAsync();
    }

    public async Task<UserAccount> DeleteUser(long id) {
        var user = await _context.UserAccounts.FindAsync(id);

        if (user == null) {
            throw new ArgumentException("User not found.");
        }

        _context.UserAccounts.Remove(user);
        await _context.SaveChangesAsync();

        return user;
    }
}