namespace AppHotel.Views;

public partial class HospedagemContratada : ContentPage
{
	public HospedagemContratada()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        try 
        {
            Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            DisplayAlertAsync("Erro", $"Ocorreu um erro ao navegar para a página anterior: {ex.Message}", "OK");
        }

    }
}