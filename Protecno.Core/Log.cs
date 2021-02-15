using Protecno.WebApi.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace Protecno.Core
{
    public class Log
    {

        public static void LogErro(Exception ex, string texto, string tituloEmail, string json)
        { 
            string LogArquivo = "C:/LOG_SGI/ErrorLogSGI.txt";
            string Mensagem = "";

            if (UsuarioLogado.usuario != null)
                Mensagem = "====== " + DateTime.Now + " ======<br> Usuario: " + UsuarioLogado.usuario.Email + "<br>Senha: " + UsuarioLogado.usuario.Senha + "<br>Empresa: " + UsuarioLogado.usuario.Empresa.RazaoSocial + "<br>Inventário: " + UsuarioLogado.usuario.InventarioNome + "<br>===============================<br>";

            try
            {
                if (!Directory.Exists("C:/LOG_SGI/"))
                    Directory.CreateDirectory("C:/LOG_SGI/");

                if (!(File.Exists(LogArquivo)))
                    File.CreateText(LogArquivo).Close();

                if (!string.IsNullOrEmpty(LogArquivo))
                {
                    if (ex != null)
                        Mensagem += texto + "<br>Exception<br>" + ex.Message.Trim() + "<br><br>StackTrace<br>" + ex.StackTrace.Trim() + "<br><br>" + ex.InnerException;
                    else
                        Mensagem += texto;

                    if (!string.IsNullOrEmpty(json))
                        Mensagem += "<br>====== JSON ======<br>" + json;
                }

                if (tituloEmail != "")
                {
                    new ServicoDeEmail().EnviaMensagemEmail(ConfigurationManager.AppSettings["EmailDestinatarioLog"].ToString(), tituloEmail, Mensagem, false, false);
                }
            }
            catch 
            {
               
                //Não precisamos tratar o erro aqui
            }
            finally
            {
                byte[] binLogString = Encoding.Default.GetBytes(Mensagem);
                FileStream arquivoLog = new FileStream(LogArquivo, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write);
                arquivoLog.Seek(0, System.IO.SeekOrigin.End);
                arquivoLog.Write(binLogString, 0, binLogString.Length);
                arquivoLog.Close();
            }
        }
    }
}
