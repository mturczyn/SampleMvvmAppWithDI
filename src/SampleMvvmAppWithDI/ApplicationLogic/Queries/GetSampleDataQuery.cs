using AutoMapper;
using MediatR;
using SampleMvvmAppWithDI.DAL;
using SampleMvvmAppWithDI.DTOs;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SampleMvvmAppWithDI.ApplicationLogic.Queries
{
    public class GetSampleDataQuery
    {
        public class Request : IRequest<Response>
        {

        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly ISampleDataProvider _sampleDataProvider;
            private readonly IMapper _mapper;

            public Handler(ISampleDataProvider sampleDataProvider, IMapper mapper)
            {
                _sampleDataProvider = sampleDataProvider;
                _mapper = mapper;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var entites = await _sampleDataProvider.GetSampleData();
                var dtos = _mapper.Map<List<SampleEntityDto>>(entites);

                return new Response()
                {
                    Results = dtos,
                };
            }
        }

        public class Response
        {
            public IEnumerable<SampleEntityDto> Results { get; set; }
        }
    }
}
