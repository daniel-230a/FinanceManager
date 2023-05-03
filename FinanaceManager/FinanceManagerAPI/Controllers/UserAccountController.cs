using AutoMapper;
using FinanceManagerAPI.Data;
using FinanceManagerAPI.Models;
using FinanceManagerAPI.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceManagerAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase {
        private readonly FinanceManagerDbContext _context;
        private readonly IMapper _mapper;

        public UserAccountController(FinanceManagerDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserAccount>>> Get() {
            return await _context.UserAccounts.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserAccount>> Get(long id) {
            var user = await _context.UserAccounts.FindAsync(id);
            if (user == null) {
                return BadRequest("User Not Found");
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserAccount>> Post(UserAccountCreateDto userAccountDto) {

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var userAccount = _mapper.Map<UserAccount>(userAccountDto);

            _context.UserAccounts.Add(userAccount);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = userAccount.UserID }, userAccount);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(long id, UserAccountUpdateDto userAccount) {
            var user = await _context.UserAccounts.FindAsync(id);

            if (user == null) {
                return BadRequest("User Not Found");
            }

            _mapper.Map(userAccount, user);

            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserAccount>> Delete(long id) {
            var user = await _context.UserAccounts.FindAsync(id);
            if (user == null) {
                return BadRequest("User Not Found");
            }

            _context.UserAccounts.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }
    }
}