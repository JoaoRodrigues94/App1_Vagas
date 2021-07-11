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
  public partial class CadastrarVaga : ContentPage
  {
    public CadastrarVaga()
    {
      InitializeComponent();
    }
    public void SalvarAction(object sender, EventArgs args)
    {
      Vaga vaga = new Vaga();
      vaga.NomeVaga = NomeVaga.Text;
      vaga.Quantidade = Convert.ToInt16(Quantidade.Text);
      vaga.Salario = Convert.ToDouble(Salario.Text);
      vaga.Empresa = Empresa.Text;
      vaga.Cidade = Cidade.Text;
      vaga.Descricao = Descricao.Text;
      vaga.TipoContratacao = TipoContratacao.IsToggled ? "PJ" : "CLT";
      vaga.Telefone = Telefone.Text;
      vaga.Email = Email.Text;

      DataBase DB = new DataBase();
      DB.Cadastro(vaga);

      App.Current.MainPage = new NavigationPage(new ConsultarVagas());
    }
  }
}