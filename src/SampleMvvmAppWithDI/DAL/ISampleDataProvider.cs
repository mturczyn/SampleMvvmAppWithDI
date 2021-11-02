using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SampleMvvmAppWithDI.DAL
{
    public interface ISampleDataProvider
    {
        Task<List<SampleEntity>> GetSampleDataAsync(CancellationToken cancellationToken);
    }
}
