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
    public class RightService : IRightService
    {
        private readonly IRightRepository _repository;
        public RightService(IRightRepository repository)
        {
            _repository = repository;
        }
        public RightResponse Add(RightRequest request)
        {
            var response = new RightResponse
            { Entity = new Domain.Entities.Right(), Error = new DTO.Base.Error() };
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

        public async Task<RightResponse> AddAsync(RightRequest request)
        {
            var response = new RightResponse
            { Entity = new Domain.Entities.Right(), Error = new DTO.Base.Error() };
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

        public void Delete(RightRequest request)
        {
            request.Entity.Status = (int)Status.Deleted;
            Update(request);
        }

        public async Task DeleteAsync(RightRequest request)
        {
            request.Entity.Status = (int)Status.Deleted;
            await UpdateAsync(request);
        }

        public RightResponse GetByFilter(RightRequest request)
        {
            throw new NotImplementedException();
        }

        public RightResponse GetById(int id)
        {
            var response = new RightResponse { Error = new DTO.Base.Error(), Entity = new Domain.Entities.Right() };
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

        public RightResponse GetList()
        {
            var response = new RightResponse { Error = new DTO.Base.Error(), EntityList = new List<Domain.Entities.Right>() };
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

        public RightResponse Update(RightRequest request)
        {
            var response = new RightResponse { Error = new DTO.Base.Error(), Entity = new Domain.Entities.Right() };
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

        public async Task<RightResponse> UpdateAsync(RightRequest request)
        {
            var response = new RightResponse { Error = new DTO.Base.Error(), Entity = new Domain.Entities.Right() };
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
