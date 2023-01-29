using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Operation.Valid;
using Tech_sell_user.Application.Services.DTOs;
using Tech_sell_user.Application.Services.Utils;
using Tech_sell_user.Database.Interface;
using Tech_sell_user.Domain.Entities;
using Tech_sell_user.Domain.Entities.Base;

namespace Tech_sell_user.Api.Controllers
{
    [Route("api/[controller]"),ApiController]
    public class UserController: ControllerBase
    {
        public IUnitOfWork UnitOfWork { get; set; }

        public UserController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        private void SetSalt(User entity)
        {
            var (salt, passwordEncrypted) = tokensGenerator.GenerateHashPassword(entity.Password);
            entity.Salt = salt;
            entity.Password = passwordEncrypted;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(UserDto user)
        {
            try
            {
                var entity = Mapper.Map<User>(user);

                if (ValidarEmailJaExistente(entity.Email))
                    return BadRequest(new
                    {
                        Success = false,
                        Message = "Email já registrado"
                    });

                await PacientService.InsertAsync(entity);
            }
            catch (Exception e)
            {
                throw;
            }

            return null;
        }
    }
}
