using MediatR;
using SampleMvvmAppWithDI.Abstractions;
using SampleMvvmAppWithDI.ApplicationLogic.Queries;
using SampleMvvmAppWithDI.DTOs;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SampleMvvmAppWithDI.ViewModels.GetData
{
    public class GetDataViewModel : BaseViewModel
    {
        private readonly IMediator _mediator;

        public GetDataViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public ObservableCollection<SampleEntityDto> SampleEntities { get; } = new ObservableCollection<SampleEntityDto>();

        public ICommand GetSampleDataCommand => Command(GetSampleData);

        private async Task GetSampleData()
        {
            var response = await _mediator.Send(new GetSampleDataQuery.Request());

            foreach (var dto in response.Results)
            {
                SampleEntities.Add(dto);
            }
        }
    }
}
