using ClockIt.src.ApplicationLayer.Services.Interfaces;
using ClockIt.src.Core.Domain.BOs.Interfaces;
using ClockIt.src.Shared.DTOs.EmailDTOs;
using ClockIt.src.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIt.src.ApplicationLayer.Services
{
    class EmailService : IEmailService
    {
        private readonly IEmailBO _emailBO;
        public string Code { get; private set; }
        public string Email { get; private set; }
        private DateTime GenerationTimeUtc { get; set; }

        public const double ExpirationMinutes = 5;

        public EmailService(IEmailBO emailBO)
        {
            _emailBO = emailBO;
        }

        public void GenerateAndStoreCode()
        {
            Code = new Random().Next(100000, 999999).ToString();
            GenerationTimeUtc = DateTime.UtcNow; 
        }

        public void SendVerificationCode(EmailValidationDTO credentials)
        {
            Email = credentials.Email.Value;

            GenerateAndStoreCode();

            using (var smtpClient = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587))
            {
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;

                smtpClient.Credentials = new System.Net.NetworkCredential("noreply.clockit@gmail.com", "muuapiegmbprbatv");

                string htmlEmailBody = @$"
                    <!DOCTYPE html>
                    <html lang=""pt-br"">
                    <head>
                        <meta name=""color-scheme"" content=""light dark"">
                        <meta name=""supported-color-schemes"" content=""light dark"">
                        <meta charset=""UTF-8"">
                        <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                        <title>Seu Código de Verificação</title>
                    </head>
                    <body style=""margin:0;padding:0;font-family:Arial,sans-serif;-webkit-font-smoothing:antialiased;-moz-osx-font-smoothing:grayscale;background-color:#f5f5f5;"">
                        <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" style=""background-color:#f5f5f5;"">
                            <tr>
                                <td align=""center"" style=""padding:20px;"">
                                    <!--[if (gte mso 9)|(IE)]>
                                    <table width=""600"" align=""center"" cellpadding=""0"" cellspacing=""0"" role=""presentation""><tr><td>
                                    <![endif]-->
                                    <div style=""width:100%;max-width:600px;margin:40px auto;background-color:#f5f5f5;border:1px solid #e0e0e0;border-radius:8px;overflow:hidden;box-shadow:0 4px 6px rgba(0,0,0,0.05);"">
                                        <table role=""presentation"" width=""100%"" cellpadding=""0"" cellspacing=""0"">
                                            <tr>
                                                <td align=""center"" style=""padding:0 40px 30px 40px;color:#1C1C1E;font-family:Arial,sans-serif;text-align:center;"">
                                                  
                                                    <table role=""presentation"" width=""100%"" cellpadding=""0"" cellspacing=""0"">
                                                        <tr><td height=""16"" style=""line-height:16px;font-size:0;"">&nbsp;</td></tr>
                                                    </table>

                                                    <h1 style=""font-size:34px;font-weight:500;margin-bottom:16px;"">Seu código de verificação</h1>

                                                    <table role=""presentation"" width=""100%"" cellpadding=""0"" cellspacing=""0"">
                                                        <tr><td height=""14"" style=""line-height:20px;font-size:0;"">&nbsp;</td></tr>
                                                    </table>

                                                    <p style=""font-size:26px;line-height:1.5;"">Olá, {credentials.EnterpriseName}</p>

                                                    <table role=""presentation"" width=""100%"" cellpadding=""0"" cellspacing=""0"">
                                                        <tr><td height=""12"" style=""line-height:16px;font-size:0;"">&nbsp;</td></tr>
                                                    </table>

                                                    <p style=""font-size:20px;line-height:1.5;"">Use este código para concluir a verificação. Por segurança, não compartilhe este código com ninguém.</p>

                                                    <table role=""presentation"" width=""100%"" cellpadding=""0"" cellspacing=""0"">
                                                        <tr><td height=""45"" style=""line-height:45px;font-size:0;"">&nbsp;</td></tr>
                                                    </table>

                                                    <table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""margin:0 auto;"">
                                                        <tr>
                                                            <td align=""center"" style=""font-size:48px; font-weight:700; color:#1a73e8; background-color:#f0f0f0; padding:20px 40px; border-radius:8px; letter-spacing:30px; padding-left: 70px;"">
                                                                {Code}
                                                            </td>
                                                        </tr>
                                                    </table>

                                                    <table role=""presentation"" width=""100%"" cellpadding=""0"" cellspacing=""0"">
                                                        <tr><td height=""45"" style=""line-height:45px;font-size:0;"">&nbsp;</td></tr>
                                                    </table>

                                                    <p style=""font-size:20px;color:#1C1C1E;margin-bottom:24px;"">Este código expira em <strong>5 minutos</strong>.</p>
                                                    <p style=""font-size:18px;line-height:1.5;"">Caso não reconheça esta atividade, por favor, desconsidere este e-mail.</p>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align=""center"" style=""padding:20px 0;background-color:#f0f0f0;font-size:14px;color:#242526;font-family:Arial,sans-serif;"">
                                                    <p style=""margin:0 0 5px 0;"">&copy; {DateTime.Now.Year} ClockIt. Todos os direitos reservados.</p>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <!--[if (gte mso 9)|(IE)]>
                                    </td></tr></table>
                                    <![endif]-->
                                </td>
                            </tr>
                        </table>
                    </body>
                    </html>";

                var mailMessage = new System.Net.Mail.MailMessage
                {
                    From = new System.Net.Mail.MailAddress("noreply.clockit@gmail.com", "ClockIt"),
                    Subject = $"Código de Verificação de Email: {Code}",
                    Body = htmlEmailBody,
                    IsBodyHtml = true,
                };

                mailMessage.To.Add(Email);

                smtpClient.Send(mailMessage);

                MessageBox.Show($"Código de verificação de email enviado para {Email}!", "ClockIt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ReSendVerificationCode(EmailValidationDTO credentials)
        {
            Email = credentials.Email.Value;

            GenerateAndStoreCode();

            using (var smtpClient = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587))
            {
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;

                smtpClient.Credentials = new System.Net.NetworkCredential("noreply.clockit@gmail.com", "muuapiegmbprbatv");

                string htmlEmailBody = @$"
                    <!DOCTYPE html>
                    <html lang=""pt-br"">
                    <head>
                        <meta name=""color-scheme"" content=""light dark"">
                        <meta name=""supported-color-schemes"" content=""light dark"">
                        <meta charset=""UTF-8"">
                        <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                        <title>Seu Código de Verificação</title>
                    </head>
                    <body style=""margin:0;padding:0;font-family:Arial,sans-serif;-webkit-font-smoothing:antialiased;-moz-osx-font-smoothing:grayscale;background-color:#f5f5f5;"">
                        <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" style=""background-color:#f5f5f5;"">
                            <tr>
                                <td align=""center"" style=""padding:20px;"">
                                    <!--[if (gte mso 9)|(IE)]>
                                    <table width=""600"" align=""center"" cellpadding=""0"" cellspacing=""0"" role=""presentation""><tr><td>
                                    <![endif]-->
                                    <div style=""width:100%;max-width:600px;margin:40px auto;background-color:#f5f5f5;border:1px solid #e0e0e0;border-radius:8px;overflow:hidden;box-shadow:0 4px 6px rgba(0,0,0,0.05);"">
                                        <table role=""presentation"" width=""100%"" cellpadding=""0"" cellspacing=""0"">
                                            <tr>
                                                <td align=""center"" style=""padding:0 40px 30px 40px;color:#1C1C1E;font-family:Arial,sans-serif;text-align:center;"">
                                                  
                                                    <table role=""presentation"" width=""100%"" cellpadding=""0"" cellspacing=""0"">
                                                        <tr><td height=""16"" style=""line-height:16px;font-size:0;"">&nbsp;</td></tr>
                                                    </table>

                                                    <h1 style=""font-size:34px;font-weight:500;margin-bottom:16px;"">Seu código de verificação</h1>

                                                    <table role=""presentation"" width=""100%"" cellpadding=""0"" cellspacing=""0"">
                                                        <tr><td height=""14"" style=""line-height:20px;font-size:0;"">&nbsp;</td></tr>
                                                    </table>

                                                    <p style=""font-size:26px;line-height:1.5;"">Olá, {credentials.EnterpriseName}</p>

                                                    <table role=""presentation"" width=""100%"" cellpadding=""0"" cellspacing=""0"">
                                                        <tr><td height=""12"" style=""line-height:16px;font-size:0;"">&nbsp;</td></tr>
                                                    </table>

                                                    <p style=""font-size:20px;line-height:1.5;"">Use este código para concluir a verificação. Por segurança, não compartilhe este código com ninguém.</p>

                                                    <table role=""presentation"" width=""100%"" cellpadding=""0"" cellspacing=""0"">
                                                        <tr><td height=""45"" style=""line-height:45px;font-size:0;"">&nbsp;</td></tr>
                                                    </table>

                                                    <table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""margin:0 auto;"">
                                                        <tr>
                                                            <td align=""center"" style=""font-size:48px; font-weight:700; color:#1a73e8; background-color:#f0f0f0; padding:20px 40px; border-radius:8px; letter-spacing:30px; padding-left: 70px;"">
                                                                {Code}
                                                            </td>
                                                        </tr>
                                                    </table>

                                                    <table role=""presentation"" width=""100%"" cellpadding=""0"" cellspacing=""0"">
                                                        <tr><td height=""45"" style=""line-height:45px;font-size:0;"">&nbsp;</td></tr>
                                                    </table>

                                                    <p style=""font-size:20px;color:#1C1C1E;margin-bottom:24px;"">Este código expira em <strong>5 minutos</strong>.</p>
                                                    <p style=""font-size:18px;line-height:1.5;"">Caso não reconheça esta atividade, por favor, desconsidere este e-mail.</p>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align=""center"" style=""padding:20px 0;background-color:#f0f0f0;font-size:14px;color:#242526;font-family:Arial,sans-serif;"">
                                                    <p style=""margin:0 0 5px 0;"">&copy; {DateTime.Now.Year} ClockIt. Todos os direitos reservados.</p>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <!--[if (gte mso 9)|(IE)]>
                                    </td></tr></table>
                                    <![endif]-->
                                </td>
                            </tr>
                        </table>
                    </body>
                    </html>";

                var mailMessage = new System.Net.Mail.MailMessage
                {
                    From = new System.Net.Mail.MailAddress("noreply.clockit@gmail.com", "ClockIt"),
                    Subject = $"Código de Verificação de Email: {Code}",
                    Body = htmlEmailBody,
                    IsBodyHtml = true,
                };

                mailMessage.To.Add(Email);

                smtpClient.Send(mailMessage);

                MessageBox.Show($"Um novo código de verificação foi enviado para {Email}!", "ClockIt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ValidateInputCode(string inputCode)
        {
            inputCode = inputCode.Trim();

            var codeValidation = new CodeValidationDTO(inputCode, Code);

            _emailBO.ValidateInputCode(codeValidation);
        }

    }
}
