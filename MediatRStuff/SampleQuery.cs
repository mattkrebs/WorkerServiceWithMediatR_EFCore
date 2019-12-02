using DBStuff;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRStuff
{
    public class SampleQuery : IRequest<string>
    {


        public class SampleQueryHandler : IRequestHandler<SampleQuery, string>
        {
            private IMyContext _context;

            public SampleQueryHandler(IMyContext context)
            {
                _context = context;
            }

            public Task<string> Handle(SampleQuery request, CancellationToken cancellationToken)
            {
                return Task.FromResult("WORKING on MY Machine");
            }
        }
    }
}
