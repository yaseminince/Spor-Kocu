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
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _repository;
        public BlogService(IBlogRepository repository)
        {
            _repository = repository;
        }
        public BlogResponse Add(BlogRequest request)
        {
            var response = new BlogResponse
            { Entity = new Domain.Entities.Blog(), Error = new DTO.Base.Error() };
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

        public async Task<BlogResponse> AddAsync(BlogRequest request)
        {
            var response = new BlogResponse
            { Entity = new Domain.Entities.Blog(), Error = new DTO.Base.Error() };
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

        public void Delete(BlogRequest request)
        {
            request.Entity.Status = (int)Status.Deleted;
            Update(request);
        }

        public async Task DeleteAsync(BlogRequest request)
        {
            request.Entity.Status = (int)Status.Deleted;
            await UpdateAsync(request);
        }

        public BlogResponse GetByFilter(BlogRequest request)
        {
            throw new NotImplementedException();
        }

        public BlogResponse GetById(int id)
        {
            var response = new BlogResponse { Error = new DTO.Base.Error(), Entity = new Domain.Entities.Blog() };
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

        public BlogResponse GetList()
        {
            var response = new BlogResponse { Error = new DTO.Base.Error(), EntityList = new List<Domain.Entities.Blog>() };
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

        public BlogResponse Update(BlogRequest request)
        {
            var response = new BlogResponse { Error = new DTO.Base.Error(), Entity = new Domain.Entities.Blog() };
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

        public async Task<BlogResponse> UpdateAsync(BlogRequest request)
        {
            var response = new BlogResponse { Error = new DTO.Base.Error(), Entity = new Domain.Entities.Blog() };
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
