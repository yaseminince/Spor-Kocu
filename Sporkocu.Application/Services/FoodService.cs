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
    public class FoodService : IFoodService
    {
        private readonly IFoodRepository _repository;
        public FoodService(IFoodRepository repository)
        {
            _repository = repository;
        }
        public FoodResponse Add(FoodRequest request)
        {
            var response = new FoodResponse
            { Entity = new Domain.Entities.Food(), Error = new DTO.Base.Error() };
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

        public async Task<FoodResponse> AddAsync(FoodRequest request)
        {
            var response = new FoodResponse
            { Entity = new Domain.Entities.Food(), Error = new DTO.Base.Error() };
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

        public void Delete(FoodRequest request)
        {
            request.Entity.Status = (int)Status.Deleted;
            Update(request);
        }

        public async Task DeleteAsync(FoodRequest request)
        {
            request.Entity.Status = (int)Status.Deleted;
            await UpdateAsync(request);
        }

        public FoodResponse GetByFilter(FoodRequest request)
        {
            throw new NotImplementedException();
        }

        public FoodResponse GetById(int id)
        {
            var response = new FoodResponse { Error = new DTO.Base.Error(), Entity = new Domain.Entities.Food() };
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

        public FoodResponse GetList()
        {
            var response = new FoodResponse { Error = new DTO.Base.Error(), EntityList = new List<Domain.Entities.Food>() };
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

        public FoodResponse Update(FoodRequest request)
        {
            var response = new FoodResponse { Error = new DTO.Base.Error(), Entity = new Domain.Entities.Food() };
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

        public async Task<FoodResponse> UpdateAsync(FoodRequest request)
        {
            var response = new FoodResponse { Error = new DTO.Base.Error(), Entity = new Domain.Entities.Food() };
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

