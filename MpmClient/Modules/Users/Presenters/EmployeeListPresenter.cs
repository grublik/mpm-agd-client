using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using MpmClient.Api;
using MpmClient.Modules.Users.Views.Interface;

namespace MpmClient.Modules.Users.Presenters
{
    internal class EmployeeListPresenter
    {
        private readonly IEmployeeList _view;

        public EmployeeListPresenter(IEmployeeList view)
        {
            _view = view;
            _view.LoadEmployeeList += OnLoad;
        }

        public IEmployeeList GetView()
        {
            return _view;
        }

        private async void OnLoad(object? sender, EventArgs e)
        {
            await LoadEmployees().ConfigureAwait(true);
        }

        private async Task LoadEmployees()
        {
            try
            {
                using var httpClient = AppServices.ApiClientFactory.CreateHttpClient();
                // var pClient = AppServices.ApiClientFactory.CreateProfileClient(Settings.Default.MpmApiServerAddr, httpClient);

                var client = new EmployeesClient("", httpClient);

                var employees = await client.ListAsync().ConfigureAwait(true);
                _view.SetEmployeesData(employees);
            }
            catch (ApiException ex)
            {
                MessageBox.Show(ex.Response ?? ex.Message, "Błąd API", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
