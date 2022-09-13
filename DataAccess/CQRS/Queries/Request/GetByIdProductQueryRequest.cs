using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.DataAccess.CQRS.Queries.Request
{
    public class GetByIdProductQueryRequest
    {
        public Guid Id { get; set; }
    }
}
