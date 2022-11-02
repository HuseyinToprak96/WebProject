using AutoMapper;
using Core.Layer.Interfaces.Repository;
using Core.Layer.Interfaces.Service;
using Core.Layer.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Layer.Services
{
    public class Service<T> : IService<T>
    {
        private readonly IGenericRepository<T> _genericRepository;
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _unitOfWork;
        public Service(IGenericRepository<T> genericRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<T> Add(T t)
        {
            await _genericRepository.Add(t);
            await _unitOfWork.CommitAsync();
            return t;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _genericRepository.GetAll();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _genericRepository.Where(expression);
        }
    }
}
