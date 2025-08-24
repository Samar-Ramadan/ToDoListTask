using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
namespace Infrastructure
{
    public class Pagination<T> where T : class
    {
        public static GeneralOutPut<T> PaginationList(IQueryable<T> list, PageingInfo info)
        {
            var query = info.OrderBy != null ? list.OrderBy(info.OrderBy + (info.Reverse ? "desc" : "asc")) : list;
            int count = query.Count();
            query = query.Skip(info.Skip).Take(info.Take);
            return new GeneralOutPut<T>()
            {
                TotalSize = count,
                Items = query,
            };
        }
    }
}
