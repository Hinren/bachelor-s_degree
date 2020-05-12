using System;
using System.Collections.Generic;
using System.Text;

namespace SignLanguage.EF.Paging
{
    public interface IPaging<T> where T : class
    {
        PagingResult<T> GetPaged(int page, int pageSize);
    }
}
