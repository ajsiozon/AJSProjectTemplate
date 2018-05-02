using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJSProjectTemplate.BL.Based
{
    public interface IWrite<TDto> where TDto : new()
    {
        void Save();
        IQueryable<TDto> SaveWithIQueryableOutput(TDto dto);
        IEnumerable<TDto> SaveWithIEnumerableOutput(TDto dto);
        void Delete();
    }
}
