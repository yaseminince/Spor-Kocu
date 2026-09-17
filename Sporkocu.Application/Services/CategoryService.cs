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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public CategoryResponse Add(CategoryRequest request)
        {
            var response = new CategoryResponse
            { Entity = new Domain.Entities.Category(), Error = new DTO.Base.Error() };
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

        public async Task<CategoryResponse> AddAsync(CategoryRequest request)
        {
            var response = new CategoryResponse
            { Entity = new Domain.Entities.Category(), Error = new DTO.Base.Error() };
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

        public void Delete(CategoryRequest request)
        {
            request.Entity.Status = (int)Status.Deleted;
            Update(request);
        }

        public async Task DeleteAsync(CategoryRequest request)
        {
            request.Entity.Status = (int)Status.Deleted;
            await UpdateAsync(request);
        }

        public CategoryResponse GetByFilter(CategoryRequest request)
        {
            throw new NotImplementedException();
        }

        public CategoryResponse GetById(int id)
        {
            var response = new CategoryResponse { Error = new DTO.Base.Error(), Entity = new Domain.Entities.Category() };
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

        public CategoryResponse GetList()
        {
            var response = new CategoryResponse { Error = new DTO.Base.Error(), EntityList = new List<Domain.Entities.Category>() };
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

        public CategoryResponse Update(CategoryRequest request)
        {
            var response = new CategoryResponse { Error = new DTO.Base.Error(), Entity = new Domain.Entities.Category() };
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

        public async Task<CategoryResponse> UpdateAsync(CategoryRequest request)
        {
            var response = new CategoryResponse { Error = new DTO.Base.Error(), Entity = new Domain.Entities.Category() };
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

