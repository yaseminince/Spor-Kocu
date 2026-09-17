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
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepository _repository;
        public AnswerService(IAnswerRepository repository)
        {
            _repository = repository;
        }
        public AnswerResponse Add(AnswerRequest request)
        {
            var response = new AnswerResponse
            { Entity = new Domain.Entities.Answer(), Error = new DTO.Base.Error() };
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

        public async Task<AnswerResponse> AddAsync(AnswerRequest request)
        {
            var response = new AnswerResponse
            { Entity = new Domain.Entities.Answer(), Error = new DTO.Base.Error() };
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

        public void Delete(AnswerRequest request)
        {
            request.Entity.Status = (int)Status.Deleted;
            Update(request);
        }

        public async Task DeleteAsync(AnswerRequest request)
        {
            request.Entity.Status = (int)Status.Deleted;
            await UpdateAsync(request);
        }

        public AnswerResponse GetByFilter(AnswerRequest request)
        {
            throw new NotImplementedException();
        }

        public AnswerResponse GetById(int id)
        {
            var response = new AnswerResponse { Error = new DTO.Base.Error(), Entity = new Domain.Entities.Answer() };
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

        public AnswerResponse GetList()
        {
            var response = new AnswerResponse { Error = new DTO.Base.Error(), EntityList = new List<Domain.Entities.Answer>() };
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

        public AnswerResponse Update(AnswerRequest request)
        {
            var response = new AnswerResponse { Error = new DTO.Base.Error(), Entity = new Domain.Entities.Answer() };
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

        public async Task<AnswerResponse> UpdateAsync(AnswerRequest request)
        {
            var response = new AnswerResponse { Error = new DTO.Base.Error(), Entity = new Domain.Entities.Answer() };
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

