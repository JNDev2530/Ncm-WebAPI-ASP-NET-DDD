using NcmAPI.Domain.Entities;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using NcmAPI.Domain.Interfaces;
using NcmAPI.Application.Interfaces;
using NcmAPI.Domain.Exceptions;

namespace NcmAPI.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;
        private readonly IUnitOfWork _uow;

        public AuthService(IUserRepository userRepository, IConfiguration config, IUnitOfWork wow)
        {
            _userRepository = userRepository;
            _config = config;
            _uow = wow;
        }

        public async Task RegisterAsync(string username, string password)
        {
            // validar negócio
            if (await _userRepository.GetByUsernameAsync(username) != null)
                throw new DomainException("Usuário já existe.");

            // iniciar transação
            await _uow.BeginTransactionAsync();
            try
            {
                // criar entidade e adicionar
                var hash = HashPassword(password);
                var user = new User
                {
                    Id = Guid.NewGuid(),
                    Username = username,
                    PasswordHash = hash,
                    CreatedAt = DateTime.UtcNow
                };
                await _userRepository.AddAsync(user);

                // commit via UoW
                await _uow.CommitAsync();
            }
            catch
            {
                // rollback em caso de erro
                await _uow.RollbackAsync();
                throw;
            }
        }

            public async Task<string?> AuthenticateAsync(string username, string password)
        {
            var user = await _userRepository.GetByUsernameAsync(username);
            if (user == null || user.PasswordHash != HashPassword(password))
                return null;

            return GenerateJwtToken(user);
        }

        public string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hash);
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
