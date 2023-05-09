using AutoMapper;
using FinanceManagerAPI.Data;
using Microsoft.AspNetCore.Mvc;
using FinanceManagerAPI.DTO;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FinanceManagerAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserAccessController : ControllerBase {
        private readonly FinanceManagerDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserAccountService _UserAccountService;

        public UserAccessController(FinanceManagerDbContext context, IMapper mapper, UserAccountService UserAccountService) {
            _context = context;
            _mapper = mapper;
            _UserAccountService = UserAccountService;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(UserLoginDto userLoginDto) {
            try {
                var result = await _UserAccountService.GetUserByEmail(userLoginDto.Email);
                Debug.WriteLine("result: " + result);

                if (result == null) {
                    return BadRequest("User not found " + result);
                }

                var user = result;

                if (!(userLoginDto.Password == user.Password)) {
                    return BadRequest("Invalid password");
                }

                return Ok("successful login");
            } catch (ArgumentException ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("signup")]
        public async Task<ActionResult> Signup(UserSignupDto userSignupDto) {
            return Ok(await _context.UserAccounts.ToListAsync());

        }
    }
}
