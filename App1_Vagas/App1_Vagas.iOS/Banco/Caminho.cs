using App1_Vagas.Banco;
using Foundation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using App1_Vagas.iOS.Banco;

[assembly:Dependency(typeof(Caminho))]
namespace App1_Vagas.iOS.Banco
{
  public class Caminho : ICaminho
  {
    public string ObterCaminho(string NomeArquivoBanco)
    {
      string caminhoDaPasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); //retorna o caminho até uma determinada pasta

      string caminhoBiblioteca = Path.Combine(caminhoDaPasta, "..", "Library");

      string caminhoBanco = Path.Combine(caminhoBiblioteca, NomeArquivoBanco);

      return caminhoBanco;
    }
  }
}