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
    public class NutritionPlanService : INutritionPlanService
    {
        private readonly INutritionPlanRepository _repository;
        public NutritionPlanService(INutritionPlanRepository repository)
        {
            _repository = repository;
        }
        public NutritionPlanResponse Add(NutritionPlanRequest request)
        {
            var response = new NutritionPlanResponse
            { Entity = new Domain.Entities.NutritionPlan(), Error = new DTO.Base.Error() };
            try
            {
                request.Entity.Status = (int)Status.Active;
                request.Entity.CreatedDate = DateTime.Now;
                response.Entity = _repository.Add(request.Entity);
            }
            catch (Exception ex)
            {
                response.Error.HasException = true;
                response.Error.Message =
                    ex.InnerException?.Message ?? ex.Message;
            }

            return response;
        }

        public async Task<NutritionPlanResponse> AddAsync(NutritionPlanRequest request)
        {
            var response = new NutritionPlanResponse
            { Entity = new Domain.Entities.NutritionPlan(), Error = new DTO.Base.Error() };
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

        public void Delete(NutritionPlanRequest request)
        {
            request.Entity.Status = (int)Status.Deleted;
            Update(request);
        }

        public async Task DeleteAsync(NutritionPlanRequest request)
        {
            request.Entity.Status = (int)Status.Deleted;
            await UpdateAsync(request);
        }

        public NutritionPlanResponse GetByFilter(NutritionPlanRequest request)
        {
            throw new NotImplementedException();
        }

        public NutritionPlanResponse GetById(int id)
        {
            var response = new NutritionPlanResponse { Error = new DTO.Base.Error(), Entity = new Domain.Entities.NutritionPlan() };
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

        public NutritionPlanResponse GetList()
        {
            var response = new NutritionPlanResponse { Error = new DTO.Base.Error(), EntityList = new List<Domain.Entities.NutritionPlan>() };
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

        public NutritionPlanResponse Update(NutritionPlanRequest request)
        {
            var response = new NutritionPlanResponse { Error = new DTO.Base.Error(), Entity = new Domain.Entities.NutritionPlan() };
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

        public async Task<NutritionPlanResponse> UpdateAsync(NutritionPlanRequest request)
        {
            var response = new NutritionPlanResponse { Error = new DTO.Base.Error(), Entity = new Domain.Entities.NutritionPlan() };
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

