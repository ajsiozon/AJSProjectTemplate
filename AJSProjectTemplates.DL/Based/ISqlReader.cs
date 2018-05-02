using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJSProjectTemplates.DL.Based
{
    public interface ISqlReader<out TDto>
    {
        IEnumerable<TDto> GetIEnumerableData();
    }
}
