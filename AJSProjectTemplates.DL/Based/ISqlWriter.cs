using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJSProjectTemplates.DL.Based
{
    public interface ISqlWriter<TDto>
    {
        void Save();
        IQueryable<TDto> SaveWithIQueryableOutput(TDto dto);
        IEnumerable<TDto> SaveWithIEnumerableOutput(TDto dto);
        void Delete();
    }
}
