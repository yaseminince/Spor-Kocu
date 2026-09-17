using Sporkocu.Application.DTO.Request;
using Sporkocu.Application.DTO.Response;
using Sporkocu.Application.Interfaces;
using Sporkocu.Application.Interfaces.Repository;
using Sporkocu.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Sporkocu.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        public UserResponse Add(UserRequest request)
        {
            var response = new UserResponse
            { Entity = new Domain.Entities.User(),Error = new DTO.Base.Error()};
            try
            {
                request.Entity.Status = (int)Status.Active;
                request.Entity.CreatedDate = DateTime.Now;
                response.Entity = _repository.Add(request.Entity);
            }
            catch (Exception ex) {
                response.Error.HasException = true;
                response.Error.Message = ex.Message;
            
            }

            return response;
        }

        public async Task<UserResponse> AddAsync(UserRequest request)
        {
            var response = new UserResponse
            { Entity = new Domain.Entities.User(), Error = new DTO.Base.Error() };
            try
            {
                request.Entity.Status = (int)Status.Active;
                request.Entity.CreatedDate = DateTime.Now;
                response.Entity = await _repository.AddAsync(request.Entity);
            }
            catch (Exception ex)
            {
                response.Error.HasException = true;
                response.Error.Message = ex.Message;

            }

            return response;
        }

        public bool AnyUser(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(UserRequest request)
        {
            request.Entity.Status = (int)Status.Deleted;
            Update(request);
        }

        public async Task DeleteAsync(UserRequest request)
        {
            request.Entity.Status = (int)Status.Deleted;
            await UpdateAsync(request);
        }

        public UserResponse GetByFilter(UserRequest request)
        {
            var response = new UserResponse
            {
                Error = new DTO.Base.Error(),
                Entity = null
            };

            try
            {
                response.Entity = _repository.Get(x =>
                    x.Email == request.Entity.Email &&
                    x.Password == request.Entity.Password &&
                    x.Status == (int)Status.Active
                );
            }
            catch (Exception ex)
            {
                response.Error.HasException = true;
                response.Error.Message = ex.Message;
            }

            return response;
        }

        public UserResponse GetById(int id)
        {
            var response = new UserResponse { Error = new DTO.Base.Error(), Entity = new Domain.Entities.User() };
            try
            {
                response.Entity = _repository.Get(x => x.Status == (int)Status.Active && x.Id == id);
            }
            catch(Exception ex)
            {
                response.Error.HasException = true;
                response.Error.Message = ex.Message;
            }
            return response;
        
        
        }

        public UserResponse GetList()
        {
            var response = new UserResponse { Error = new DTO.Base.Error(), EntityList = new List<Domain.Entities.User>() };
            try
            {
                response.EntityList = _repository.GetList(x => x.Status == (int)Status.Active);
            }
            catch (Exception ex)
            {
                response.Error.HasException = true;
                response.Error.Message = ex.Message;
            }
            return response;
        }

        public UserResponse Update(UserRequest request)
        {
            var response = new UserResponse { Error = new DTO.Base.Error(), Entity = new Domain.Entities.User() };
            try
            {
                request.Entity.UpdatedDate= DateTime.Now;
                response.Entity = _repository.Update(request.Entity);
            }
            catch (Exception ex)
            {
                response.Error.HasException = true;
                response.Error.Message = ex.Message;
            }
            return response;
        }

        public async Task<UserResponse> UpdateAsync(UserRequest request)
        {
            var response = new UserResponse { Error = new DTO.Base.Error(), Entity = new Domain.Entities.User() };
            try
            {
                request.Entity.UpdatedDate = DateTime.Now;
                response.Entity = await _repository.UpdateAsync(request.Entity);
            }
            catch (Exception ex)
            {
                response.Error.HasException = true;
                response.Error.Message = ex.Message;
            }
            return response;
        }
    }
}
