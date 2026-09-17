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
    public class NutritionPlanDetailService : INutritionPlanDetailService
    {
        private readonly INutritionPlanDetailRepository _repository;
        public NutritionPlanDetailService(INutritionPlanDetailRepository repository)
        {
            _repository = repository;
        }
        public NutritionPlanDetailResponse Add(NutritionPlanDetailRequest request)
        {
            var response = new NutritionPlanDetailResponse
            { Entity = new Domain.Entities.NutritionPlanDetail(), Error = new DTO.Base.Error() };
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

        public async Task<NutritionPlanDetailResponse> AddAsync(NutritionPlanDetailRequest request)
        {
            var response = new NutritionPlanDetailResponse
            { Entity = new Domain.Entities.NutritionPlanDetail(), Error = new DTO.Base.Error() };
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

        public void Delete(NutritionPlanDetailRequest request)
        {
            request.Entity.Status = (int)Status.Deleted;
            Update(request);
        }

        public async Task DeleteAsync(NutritionPlanDetailRequest request)
        {
            request.Entity.Status = (int)Status.Deleted;
            await UpdateAsync(request);
        }

        public NutritionPlanDetailResponse GetByFilter(NutritionPlanDetailRequest request)
        {
            throw new NotImplementedException();
        }

        public NutritionPlanDetailResponse GetById(int id)
        {
            var response = new NutritionPlanDetailResponse { Error = new DTO.Base.Error(), Entity = new Domain.Entities.NutritionPlanDetail() };
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

        public NutritionPlanDetailResponse GetList()
        {
            var response = new NutritionPlanDetailResponse { Error = new DTO.Base.Error(), EntityList = new List<Domain.Entities.NutritionPlanDetail>() };
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

        public NutritionPlanDetailResponse Update(NutritionPlanDetailRequest request)
        {
            var response = new NutritionPlanDetailResponse { Error = new DTO.Base.Error(), Entity = new Domain.Entities.NutritionPlanDetail() };
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

        public async Task<NutritionPlanDetailResponse> UpdateAsync(NutritionPlanDetailRequest request)
        {
            var response = new NutritionPlanDetailResponse { Error = new DTO.Base.Error(), Entity = new Domain.Entities.NutritionPlanDetail() };
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

