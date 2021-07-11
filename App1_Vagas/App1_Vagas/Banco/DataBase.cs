using System;
using System.Collections.Generic;
using System.Text;
using App1_Vagas.Modelos;
using SQLite;
using Xamarin.Forms;

namespace App1_Vagas.Banco
{
  class DataBase
  {
    // String de Conexão
    private SQLiteConnection _conexao;
    public DataBase()
    {
      var dep = DependencyService.Get<ICaminho>();
      string caminho = dep.ObterCaminho("database.sqlite");

      _conexao = new SQLiteConnection(caminho);
      // Criar tabela
      _conexao.CreateTable<Vaga>();
    }
    // Métodos de inserção, consulta etc
    public List<Vaga> Consultar()
    {

      return _conexao.Table<Vaga>().ToList();
    }
    public List<Vaga> Pesquisar(string palavra) 
    {

      return _conexao.Table<Vaga>().Where(x => x.NomeVaga.Contains(palavra)).ToList();
    }
    public List<Vaga> ObterVagaPorId(int id)
    {
      return _conexao.Table<Vaga>().Where(x => x.Id == id).ToList();
    }
    public void Cadastro(Vaga vaga)
    {
      _conexao.Insert(vaga);
    }
    public void Atualizacao(Vaga vaga)
    {
      _conexao.Update(vaga);
    }
    public void Excluir(Vaga vaga)
    {
      _conexao.Delete(vaga);
    }
  }
}
