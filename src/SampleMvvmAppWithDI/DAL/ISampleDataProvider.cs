using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleMvvmAppWithDI.DAL
{
    public interface ISampleDataProvider
    {
        Task<List<SampleEntity>> GetSampleData();
    }
}
