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
    public class UnitService : IUnitService
    {
        private readonly IUnitRepository _repository;
        public UnitService(IUnitRepository repository)
        {
            _repository = repository;
        }
        public UnitResponse Add(UnitRequest request)
        {
            var response = new UnitResponse
            { Entity = new Domain.Entities.Unit(), Error = new DTO.Base.Error() };
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

        public async Task<UnitResponse> AddAsync(UnitRequest request)
        {
            var response = new UnitResponse
            { Entity = new Domain.Entities.Unit(), Error = new DTO.Base.Error() };
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

        public void Delete(UnitRequest request)
        {
            request.Entity.Status = (int)Status.Deleted;
            Update(request);
        }

        public async Task DeleteAsync(UnitRequest request)
        {
            request.Entity.Status = (int)Status.Deleted;
            await UpdateAsync(request);
        }

        public UnitResponse GetByFilter(UnitRequest request)
        {
            throw new NotImplementedException();
        }

        public UnitResponse GetById(int id)
        {
            var response = new UnitResponse { Error = new DTO.Base.Error(), Entity = new Domain.Entities.Unit() };
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

        public UnitResponse GetList()
        {
            var response = new UnitResponse { Error = new DTO.Base.Error(), EntityList = new List<Domain.Entities.Unit>() };
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

        public UnitResponse Update(UnitRequest request)
        {
            var response = new UnitResponse { Error = new DTO.Base.Error(), Entity = new Domain.Entities.Unit() };
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

        public async Task<UnitResponse> UpdateAsync(UnitRequest request)
        {
            var response = new UnitResponse { Error = new DTO.Base.Error(), Entity = new Domain.Entities.Unit() };
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
