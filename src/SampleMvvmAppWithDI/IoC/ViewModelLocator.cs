using Microsoft.Extensions.DependencyInjection;
using SampleMvvmAppWithDI.ViewModels.GetData;

namespace SampleMvvmAppWithDI.IoC
{
    /// <summary>
    /// Class used to bind to respective ViewModels in Views.
    /// </summary>
    public class ViewModelLocator
    {
        public GetDataViewModel GetDataViewModel
        {
            get { return IoCContainer.ServiceProvider.GetService<GetDataViewModel>(); }
        }
    }
}
