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
    public class StudentCoachService : IStudentCoachService
    {
        private readonly IStudentCoachRepository _repository;
        public StudentCoachService(IStudentCoachRepository repository)
        {
            _repository = repository;
        }
        public StudentCoachResponse Add(StudentCoachRequest request)
        {
            var response = new StudentCoachResponse
            { Entity = new Domain.Entities.StudentCoach(), Error = new DTO.Base.Error() };
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

        public async Task<StudentCoachResponse> AddAsync(StudentCoachRequest request)
        {
            var response = new StudentCoachResponse
            { Entity = new Domain.Entities.StudentCoach(), Error = new DTO.Base.Error() };
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

        public void Delete(StudentCoachRequest request)
        {
            request.Entity.Status = (int)Status.Deleted;
            Update(request);
        }

        public async Task DeleteAsync(StudentCoachRequest request)
        {
            request.Entity.Status = (int)Status.Deleted;
            await UpdateAsync(request);
        }

        public StudentCoachResponse GetByFilter(StudentCoachRequest request)
        {
            throw new NotImplementedException();
        }

        public StudentCoachResponse GetById(int id)
        {
            var response = new StudentCoachResponse { Error = new DTO.Base.Error(), Entity = new Domain.Entities.StudentCoach() };
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

        public StudentCoachResponse GetList()
        {
            var response = new StudentCoachResponse { Error = new DTO.Base.Error(), EntityList = new List<Domain.Entities.StudentCoach>() };
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

        public StudentCoachResponse Update(StudentCoachRequest request)
        {
            var response = new StudentCoachResponse { Error = new DTO.Base.Error(), Entity = new Domain.Entities.StudentCoach() };
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

        public async Task<StudentCoachResponse> UpdateAsync(StudentCoachRequest request)
        {
            var response = new StudentCoachResponse { Error = new DTO.Base.Error(), Entity = new Domain.Entities.StudentCoach() };
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
