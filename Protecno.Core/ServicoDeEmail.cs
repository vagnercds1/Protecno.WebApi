using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace Protecno.Core
{
    public class ServicoDeEmail
    {
        /// <summary>
        /// Transmite uma mensagem de email sem anexos
        /// </summary>
        /// <param name="Destinatario">Destinatario (Recipient)</param>
        /// <param name="Remetente">Remetente (Sender)</param>
        /// <param name="Assunto">Assunto da mensagem (Subject)</param>
        /// <param name="enviaMensagem">Corpo da mensagem(Body)</param>
        /// <returns>Status da mensagem</returns>
        public string EnviaMensagemEmail(string Destinatario, string Assunto, string corpoDoEmail, bool bodyHtml, bool enviaCopiaOculta)
        {
            string retorno = "";

            string smtp = ConfigurationManager.AppSettings["SMTPRemetente"].ToString();
            string remetente = ConfigurationManager.AppSettings["EmailRemetente"].ToString();
            string CopiaOculta = ConfigurationManager.AppSettings["CopiaOculta"].ToString();
            string senha = ConfigurationManager.AppSettings["SenhaEmailRemetente"].ToString();
            int porta = Convert.ToInt32(ConfigurationManager.AppSettings["PortaSMTP"].ToString());
            bool EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"].ToString());
            bool UseDefaultCredentials = Convert.ToBoolean(ConfigurationManager.AppSettings["UseDefaultCredentials"].ToString());

            var client = new System.Net.Mail.SmtpClient();
            client.Host = smtp;
            client.Port = porta;
            client.EnableSsl = EnableSsl;
            client.UseDefaultCredentials = UseDefaultCredentials;
            client.Credentials = new System.Net.NetworkCredential(remetente, senha);

            MailMessage mail = new MailMessage
            {
                Sender = new System.Net.Mail.MailAddress(remetente, "SGI-WEB"),
                From = new MailAddress(remetente, "SGI-WEB")
            };
            mail.To.Add(new MailAddress(Destinatario, Destinatario));
            mail.Subject = Assunto;
            mail.Body = corpoDoEmail;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            if (enviaCopiaOculta)
                mail.Bcc.Add(CopiaOculta);

            try
            {
                client.Send(mail);
            }
            catch (System.Exception erro)
            {
                throw erro;
            }
            finally
            {
                mail = null;
            }

            return retorno;
        }

        public string EnviaMensagemEmail3(string Destinatario, string Assunto, string corpoDoEmail, bool bodyHtml, bool enviaCopiaOculta)
        {
            string retorno = "";
            try
            {
                string smtp = ConfigurationManager.AppSettings["SMTPRemetente"].ToString();
                string remetente = ConfigurationManager.AppSettings["EmailRemetente"].ToString();
                string CopiaOculta = ConfigurationManager.AppSettings["CopiaOculta"].ToString();
                string senha = ConfigurationManager.AppSettings["SenhaEmailRemetente"].ToString();
                int porta = Convert.ToInt32(ConfigurationManager.AppSettings["PortaSMTP"].ToString());

                using (var msg = new MailMessage(remetente, Destinatario, Assunto, corpoDoEmail))
                {
                    msg.IsBodyHtml = bodyHtml;

                    if (enviaCopiaOculta)
                        msg.Bcc.Add(CopiaOculta);

                    using (var smtpClient = new SmtpClient(smtp, porta))
                    {
                        smtpClient.EnableSsl = false;
                        smtpClient.Timeout = 2 * 60 * 1000;
                        smtpClient.UseDefaultCredentials = true;
                        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtpClient.Credentials = new NetworkCredential(remetente, senha);

                        smtpClient.Send(msg);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retorno;
        }

        ///// <summary>
        ///// Transmite uma mensagem de email com um anexo
        ///// </summary>
        ///// <param name="Destinatario">Destinatario (Recipient)</param>
        ///// <param name="Remetente">Remetente (Sender)</param>
        ///// <param name="Assunto">Assunto da mensagem (Subject)</param>
        ///// <param name="enviaMensagem">Corpo da mensagem(Body)</param>
        ///// <param name="anexos">Um array de strings apontando para a localização de cada anexo</param>
        ///// <returns>Status da mensagem</returns>
        //public   string EnviaMensagemComAnexos(string Destinatario, string Remetente,
        //    string Assunto, string enviaMensagem, ArrayList anexos)
        //{
        //    try
        //    {
        //        // valida o email
        //        bool bValidaEmail = ValidaEnderecoEmail(Destinatario);

        //        if (bValidaEmail == false)
        //            return "Email do destinatário inválido:" + Destinatario;

        //        // Cria uma mensagem
        //        MailMessage mensagemEmail = new MailMessage(
        //           Remetente,
        //           Destinatario,
        //           Assunto,
        //           enviaMensagem);

        //        // The anexos arraylist should point to a file location where
        //        // the attachment resides - add the anexos to the message
        //        foreach (string anexo in anexos)
        //        {
        //            Attachment anexado = new Attachment(anexo, MediaTypeNames.Application.Octet);
        //            mensagemEmail.Attachments.Add(anexado);
        //        }

        //        SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
        //        client.EnableSsl = true;
        //        NetworkCredential cred = new NetworkCredential("macoratte@gmail.com", "hw8vup5e");
        //        client.Credentials = cred;

        //        // Inclui as credenciais
        //        client.UseDefaultCredentials = true;

        //        // envia a mensagem
        //        client.Send(mensagemEmail);

        //        return "Mensagem enviada para " + Destinatario + " às " + DateTime.Now.ToString() + ".";
        //    }
        //    catch (Exception ex)
        //    {
        //        string erro = ex.InnerException.ToString();
        //        return ex.Message.ToString() + erro;
        //    }
        //}

        /// <summary>
        /// Confirma a validade de um email
        /// </summary>
        /// <param name="enderecoEmail">Email a ser validado</param>
        /// <returns>Retorna True se o email for valido</returns>
        public bool ValidaEnderecoEmail(string enderecoEmail)
        {
            try
            {
                //define a expressão regulara para validar o email
                string texto_Validar = enderecoEmail;
                Regex expressaoRegex = new Regex(@"\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}");

                // testa o email com a expressão
                if (expressaoRegex.IsMatch(texto_Validar))
                {
                    // o email é valido
                    return true;
                }
                else
                {
                    // o email é inválido
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
