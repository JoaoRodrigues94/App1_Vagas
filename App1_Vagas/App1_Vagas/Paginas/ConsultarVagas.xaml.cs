using App1_Vagas.Banco;
using App1_Vagas.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_Vagas.Paginas
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class ConsultarVagas : ContentPage
  {
    List<Vaga> lista { get; set; }
    public ConsultarVagas()
    {
      InitializeComponent();

      DataBase DB = new DataBase();
      lista = DB.Consultar();
      ListaVaga.ItemsSource = DB.Consultar();

      lblCount.Text = lista.Count.ToString();
    }
    public void GoCadastro(object sender, EventArgs args)
    {
      Navigation.PushAsync(new CadastrarVaga());
    }
    public void GoMinhasVagas(object sender, EventArgs args)
    {
      Navigation.PushAsync(new MinhasVagasCadastradas());
    }
    public void MaisDetalheAction(object sender, EventArgs args)
    {
      Label lblDetalhe = (Label)sender;
      Vaga vaga = ((TapGestureRecognizer)lblDetalhe.GestureRecognizers[0]).CommandParameter as Vaga;
      
      Navigation.PushAsync(new DetalharVaga(vaga));
    }
    public void PesquisarAction(object sender, TextChangedEventArgs args)
    {
      ListaVaga.ItemsSource = lista.Where(x => x.NomeVaga.Contains(args.NewTextValue)).ToList(); // Informação que foi digitada por último
    }
  }
}