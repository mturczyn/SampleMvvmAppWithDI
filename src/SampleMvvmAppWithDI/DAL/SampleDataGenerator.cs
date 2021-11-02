using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SampleMvvmAppWithDI.DAL
{
    public class SampleDataGenerator : ISampleDataProvider
    {
        public Task<List<SampleEntity>> GetSampleDataAsync(CancellationToken cancellationToken)
        {
            var count = new Random().Next(5, 15);

            var entities = new List<SampleEntity>();

            for (int i = 0; i < count; i++)
            {
                entities.Add(new SampleEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = $"Name {Guid.NewGuid()}",
                });
            }

            return Task.FromResult(entities);
        }
    }
}
