using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJSProjectTemplate.BL.Based
{
    public class BusinessLogicCreator<T, TDto> where T : IWrite<TDto>, new() where TDto : new()
    {
        private readonly T _factory;

        public BusinessLogicCreator()
        {
            _factory = new T();
        }

        public void Save()
        {
            _factory.Save();
        }

        public IQueryable<TDto> SaveWithIQueryableOutput(TDto dto)
        {
            return _factory.SaveWithIQueryableOutput(dto);
        }

        public IEnumerable<TDto> SaveWithIEnumerableOutput(TDto dto)
        {
            return _factory.SaveWithIEnumerableOutput(dto);
        }
        public void Delete(TDto dto)
        {
            _factory.Delete();
        }

    }
}
