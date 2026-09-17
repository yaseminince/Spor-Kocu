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
    public class ScheduleLessonService : IScheduleLessonService
    {
        private readonly IScheduleLessonRepository _repository;
        public ScheduleLessonService(IScheduleLessonRepository repository)
        {
            _repository = repository;
        }
        public ScheduleLessonResponse Add(ScheduleLessonRequest request)
        {
            var response = new ScheduleLessonResponse
            { Entity = new Domain.Entities.ScheduleLesson(), Error = new DTO.Base.Error() };
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

        public async Task<ScheduleLessonResponse> AddAsync(ScheduleLessonRequest request)
        {
            var response = new ScheduleLessonResponse
            { Entity = new Domain.Entities.ScheduleLesson(), Error = new DTO.Base.Error() };
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

        public void Delete(ScheduleLessonRequest request)
        {
            request.Entity.Status = (int)Status.Deleted;
            Update(request);
        }

        public async Task DeleteAsync(ScheduleLessonRequest request)
        {
            request.Entity.Status = (int)Status.Deleted;
            await UpdateAsync(request);
        }

        public ScheduleLessonResponse GetByFilter(ScheduleLessonRequest request)
        {
            throw new NotImplementedException();
        }

        public ScheduleLessonResponse GetById(int id)
        {
            var response = new ScheduleLessonResponse { Error = new DTO.Base.Error(), Entity = new Domain.Entities.ScheduleLesson() };
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

        public ScheduleLessonResponse GetList()
        {
            var response = new ScheduleLessonResponse { Error = new DTO.Base.Error(), EntityList = new List<Domain.Entities.ScheduleLesson>() };
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

        public ScheduleLessonResponse Update(ScheduleLessonRequest request)
        {
            var response = new ScheduleLessonResponse { Error = new DTO.Base.Error(), Entity = new Domain.Entities.ScheduleLesson() };
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

        public async Task<ScheduleLessonResponse> UpdateAsync(ScheduleLessonRequest request)
        {
            var response = new ScheduleLessonResponse { Error = new DTO.Base.Error(), Entity = new Domain.Entities.ScheduleLesson() };
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
