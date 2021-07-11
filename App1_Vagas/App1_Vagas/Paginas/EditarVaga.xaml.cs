using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1_Vagas.Banco;
using App1_Vagas.Modelos;

namespace App1_Vagas.Paginas
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class EditarVaga : ContentPage
  {
    private Vaga vaga { get; set; }
    public EditarVaga(Vaga vaga)
    {
      InitializeComponent();
      this.vaga = vaga;

      NomeVaga.Text = vaga.NomeVaga;
      Empresa.Text = vaga.Empresa;
      Quantidade.Text = vaga.Quantidade.ToString();
      Cidade.Text = vaga.Cidade;
      Salario.Text = vaga.Salario.ToString();

      Descricao.Text = vaga.Descricao;
      TipoContratacao.IsToggled = (vaga.TipoContratacao == "CLT") ? false : true;
      Telefone.Text = vaga.Telefone;
      Email.Text = vaga.Email;
    }
    public void SalvarAction(object sender, EventArgs args)
    {
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
      DB.Atualizacao(vaga);

      App.Current.MainPage = new NavigationPage(new MinhasVagasCadastradas());

    }
  }
}