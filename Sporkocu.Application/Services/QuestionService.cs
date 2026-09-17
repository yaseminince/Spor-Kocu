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
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _repository;
        public QuestionService(IQuestionRepository repository)
        {
            _repository = repository;
        }
        public QuestionResponse Add(QuestionRequest request)
        {
            var response = new QuestionResponse
            { Entity = new Domain.Entities.Question(), Error = new DTO.Base.Error() };
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

        public async Task<QuestionResponse> AddAsync(QuestionRequest request)
        {
            var response = new QuestionResponse
            { Entity = new Domain.Entities.Question(), Error = new DTO.Base.Error() };
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

        public void Delete(QuestionRequest request)
        {
            request.Entity.Status = (int)Status.Deleted;
            Update(request);
        }

        public async Task DeleteAsync(QuestionRequest request)
        {
            request.Entity.Status = (int)Status.Deleted;
            await UpdateAsync(request);
        }

        public QuestionResponse GetByFilter(QuestionRequest request)
        {
            throw new NotImplementedException();
        }

        public QuestionResponse GetById(int id)
        {
            var response = new QuestionResponse { Error = new DTO.Base.Error(), Entity = new Domain.Entities.Question() };
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

        public QuestionResponse GetList()
        {
            var response = new QuestionResponse { Error = new DTO.Base.Error(), EntityList = new List<Domain.Entities.Question>() };
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

        public QuestionResponse Update(QuestionRequest request)
        {
            var response = new QuestionResponse { Error = new DTO.Base.Error(), Entity = new Domain.Entities.Question() };
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

        public async Task<QuestionResponse> UpdateAsync(QuestionRequest request)
        {
            var response = new QuestionResponse { Error = new DTO.Base.Error(), Entity = new Domain.Entities.Question() };
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

