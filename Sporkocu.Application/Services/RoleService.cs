using Sporkocu.Application.DTO.Request;
using Sporkocu.Application.DTO.Response;
using Sporkocu.Application.Interfaces;
using Sporkocu.Application.Interfaces.Repository;
using Sporkocu.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sporkocu.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repository;
        public RoleService(IRoleRepository repository)
        {
            _repository = repository;
        }
        public RoleResponse Add(RoleRequest request)
        {
            var response = new RoleResponse
            { Entity = new Domain.Entities.Role(), Error = new DTO.Base.Error() };
            try
            {
                request.Entity.Status = (int)Status.Active;
                request.Entity.CreatedDate = DateTime.Now;
                response.Entity = _repository.Add(request.Entity);
            }
            catch (Exception ex)
            {
                response.Error.HasException = true;
                response.Error.Message = ex.Message;

            }

            return response;
        }

        public async Task<RoleResponse> AddAsync(RoleRequest request)
        {
            var response = new RoleResponse
            { Entity = new Domain.Entities.Role(), Error = new DTO.Base.Error() };
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

        public void Delete(RoleRequest request)
        {
            request.Entity.Status = (int)Status.Deleted;
            Update(request);
        }

        public async Task DeleteAsync(RoleRequest request)
        {
            request.Entity.Status = (int)Status.Deleted;
            await UpdateAsync(request);
        }

        public RoleResponse GetByFilter(RoleRequest request)
        {
            throw new NotImplementedException();
        }

        public RoleResponse GetById(int id)
        {
            var response = new RoleResponse { Error = new DTO.Base.Error(), Entity = new Domain.Entities.Role() };
            try
            {
                response.Entity = _repository.Get(x => x.Status == (int)Status.Active && x.Id == id);
            }
            catch (Exception ex)
            {
                response.Error.HasException = true;
                response.Error.Message = ex.Message;
            }
            return response;


        }

        public RoleResponse GetList()
        {
            var response = new RoleResponse { Error = new DTO.Base.Error(), EntityList = new List<Domain.Entities.Role>() };
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

        public RoleResponse Update(RoleRequest request)
        {
            var response = new RoleResponse { Error = new DTO.Base.Error(), Entity = new Domain.Entities.Role() };
            try
            {
                request.Entity.UpdatedDate = DateTime.Now;
                response.Entity = _repository.Update(request.Entity);
            }
            catch (Exception ex)
            {
                response.Error.HasException = true;
                response.Error.Message = ex.Message;
            }
            return response;
        }

        public async Task<RoleResponse> UpdateAsync(RoleRequest request)
        {
            var response = new RoleResponse { Error = new DTO.Base.Error(), Entity = new Domain.Entities.Role() };
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
