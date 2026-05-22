using AppHotel.Models;
namespace AppHotel.Views
{
    public partial class ContratacaoHospedagem : ContentPage
    {
        private App PropriedadesApp;

        public ContratacaoHospedagem()
        {
            InitializeComponent();
            PropriedadesApp = (App)Application.Current;
            pck_quarto.ItemsSource = PropriedadesApp.lista_quarto;

            dtpck_checkin.MinimumDate = DateTime.Now;
            dtpck_checkin.MaximumDate = new DateTime(DateTime.Now.Year,
                DateTime.Now.Month +1, DateTime.Now.Day);

            dtpck_checkout.MinimumDate = dtpck_checkin.Date?.AddDays(1);
            dtpck_checkout.MaximumDate = dtpck_checkin.Date?.AddMonths(6);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

            try
            {
                Hospedagem h = new Hospedagem
                {
                    QuartoSelecionado = (Quarto)pck_quarto.SelectedItem,
                    QtdAdultos = Convert.ToInt32(stp_Adulto.Value),
                    QtdCriancas = Convert.ToInt32(stp_Crianca.Value),
                    DataCheckIn = dtpck_checkin.Date.Value,
                    DataCheckOut = dtpck_checkout.Date.Value,
                };

                await Navigation.PushAsync(new HospedagemContratada()
                    { BindingContext = h
                    });

            }
            catch (Exception ex)
            {
                await DisplayAlertAsync("Erro", $"Ocorreu um erro ao navegar para a página de cadastro: {ex.Message}", "OK");
            }
        }

    }
}