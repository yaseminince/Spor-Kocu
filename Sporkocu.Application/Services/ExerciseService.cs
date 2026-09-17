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
    public class ExerciseService : IExerciseService
    {
        private readonly IExerciseRepository _repository;
        public ExerciseService(IExerciseRepository repository)
        {
            _repository = repository;
        }
        public ExerciseResponse Add(ExerciseRequest request)
        {
            var response = new ExerciseResponse
            { Entity = new Domain.Entities.Exercise(), Error = new DTO.Base.Error() };
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

        public async Task<ExerciseResponse> AddAsync(ExerciseRequest request)
        {
            var response = new ExerciseResponse
            { Entity = new Domain.Entities.Exercise(), Error = new DTO.Base.Error() };
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

        public void Delete(ExerciseRequest request)
        {
            request.Entity.Status = (int)Status.Deleted;
            Update(request);
        }

        public async Task DeleteAsync(ExerciseRequest request)
        {
            request.Entity.Status = (int)Status.Deleted;
            await UpdateAsync(request);
        }

        public ExerciseResponse GetByFilter(ExerciseRequest request)
        {
            throw new NotImplementedException();
        }

        public ExerciseResponse GetById(int id)
        {
            var response = new ExerciseResponse { Error = new DTO.Base.Error(), Entity = new Domain.Entities.Exercise() };
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

        public ExerciseResponse GetList()
        {
            var response = new ExerciseResponse { Error = new DTO.Base.Error(), EntityList = new List<Domain.Entities.Exercise>() };
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

        public ExerciseResponse Update(ExerciseRequest request)
        {
            var response = new ExerciseResponse { Error = new DTO.Base.Error(), Entity = new Domain.Entities.Exercise() };
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

        public async Task<ExerciseResponse> UpdateAsync(ExerciseRequest request)
        {
            var response = new ExerciseResponse { Error = new DTO.Base.Error(), Entity = new Domain.Entities.Exercise() };
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

