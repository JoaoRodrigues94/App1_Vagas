using App1_Vagas.Modelos;
using App1_Vagas.Banco;
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
  public partial class MinhasVagasCadastradas : ContentPage
  {
    List<Vaga> lista { get; set; }
    public MinhasVagasCadastradas()
    {
      InitializeComponent();
      Atualizar();
    }
    private void Atualizar()
    {
      DataBase DB = new DataBase();
      lista = DB.Consultar();
      ListaVaga.ItemsSource = DB.Consultar();

      lblCount.Text = lista.Count.ToString();
    }
    public void EditarAction(object sender, EventArgs args)
    {
      Label lblEditar = (Label)sender;
      Vaga vaga = ((TapGestureRecognizer)lblEditar.GestureRecognizers[0]).CommandParameter as Vaga;

      Navigation.PushAsync(new EditarVaga(vaga));
    }
    public void ExcluirAction(object sender, EventArgs args)
    {
      Label lblExcluir = (Label)sender;
      Vaga vaga = ((TapGestureRecognizer)lblExcluir.GestureRecognizers[0]).CommandParameter as Vaga;

      DataBase DB = new DataBase();
      DB.Excluir(vaga);

      // Atualizar a lista
      Atualizar();
    }
    public void PesquisarAction(object sender, TextChangedEventArgs args)
    {
      ListaVaga.ItemsSource = lista.Where(x => x.NomeVaga.Contains(args.NewTextValue)).ToList(); // Informação que foi digitada por último
    }
  }
}