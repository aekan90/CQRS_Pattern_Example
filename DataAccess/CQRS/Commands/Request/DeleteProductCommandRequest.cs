﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.DataAccess.CQRS.Commands.Request
{
    public class DeleteProductCommandRequest
    {
        public Guid Id { get; set; }
    }
}
