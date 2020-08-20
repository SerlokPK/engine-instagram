using Common;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Text;

namespace Service.Mail
{
    public class MailsService
    {
        private readonly Dictionary<string, string> MailTemplatesDict = new Dictionary<string, string>();
        private readonly Logger m_Logger = LogManager.GetCurrentClassLogger();

        public void Clear()
        {
            lock (MailTemplatesDict)
            {
                MailTemplatesDict.Clear();
            }
        }

        public bool RegisteredUserSendMail(string mailSubject, string languageSign, string email, string username, string link)
        {
            var body = CreateEmailBody(languageSign, "UserRegistered");
            body = body.Replace("{name}", username);
            body = body.Replace("{link}", link);
            return SendEmailWithAttachment(languageSign, email, mailSubject, true, body, null, null, null);
        }

        private string CreateEmailBody(string languageSign, string template)
        {
            if (!string.IsNullOrEmpty(languageSign) && !string.IsNullOrEmpty(template))
            {
                try
                {
                    using (StreamReader reader = new StreamReader($"{AppSettings.EmailTemplatePath}/{languageSign}/{template}.html", Encoding.Default))
                    {
                        var body = reader.ReadToEnd();
                        if (!string.IsNullOrEmpty(body))
                        {
                            return body;
                        }
                        else
                        {
                            m_Logger.Error($"Email template {template} for language {languageSign} is empty.");
                            return string.Empty;
                        }
                    }
                }
                catch (Exception exc)
                {
                    m_Logger.Error(exc, $"Problem finding email template: {template} for language {languageSign}.");
                }
            }
            return string.Empty;
        }

        private string GetMailTemplate(string languageSign)
        {
            lock (MailTemplatesDict)
            {
                if (MailTemplatesDict.ContainsKey(languageSign))
                {
                    return MailTemplatesDict[languageSign];
                }
            }
            var layout = CreateEmailBody(languageSign, "_EmailLayout");
            lock (MailTemplatesDict)
            {
                if (MailTemplatesDict.ContainsKey(languageSign))
                {
                    MailTemplatesDict[languageSign] = layout;
                }
                else
                {
                    MailTemplatesDict.Add(languageSign, layout);
                }
            }
            return layout;
        }

        private bool SendEmailWithAttachment(string languageSign, string to, string subject, bool isBodyHtml, string body, string filePath, byte[] dataAttachment, string replyTo)
        {
            if (string.IsNullOrEmpty(body))
            {
                m_Logger.Error("SendEmailWithAttacment - No email body.");
                return false;
            }
            var layout = GetMailTemplate(languageSign);
            layout = layout.Replace("{body}", body);

            var mail = new Models.Mail.Mail()
            {
                To = to,
                Subject = subject,
                IsBodyHtml = isBodyHtml,
                Body = layout,
                AttachmentPath = filePath,
                AttachmentData = dataAttachment,
                ReplayTo = replyTo,
                From = AppSettings.EmailSettingsFrom,
                FromName = AppSettings.EmailSettingsFromName,
                Host = AppSettings.EmailSettingsHost,
                Username = AppSettings.EmailSettingsUsername,
                Pass = AppSettings.EmailSettingsPassword,
                Port = AppSettings.EmailSettingsPort,
                EnableSsl = AppSettings.EmailSettingsEnableSsl
            };


            if (!string.IsNullOrEmpty(mail.From) && !string.IsNullOrEmpty(mail.Host) && !string.IsNullOrEmpty(mail.Username) && !string.IsNullOrEmpty(mail.Pass))
            {
                SendEmailWithAttachment(mail);
                return true;
            }

            m_Logger.Warn("Mail not configured.");
            return false;
        }

        private static bool SendEmailWithAttachment(Models.Mail.Mail mail)
        {
            try
            {
                var smtp = new SmtpClient(mail.Host, mail.Port)
                {
                    EnableSsl = mail.EnableSsl,
                    Credentials = new System.Net.NetworkCredential(mail.Username, mail.Pass),
                };

                MailAddress fromAddress = new MailAddress(mail.From, mail.FromName);
                MailAddress toAddress = new MailAddress(mail.To);

                var email = new MailMessage(fromAddress, toAddress);
                email.Subject = mail.Subject;
                email.Body = mail.Body;
                email.IsBodyHtml = mail.IsBodyHtml;
                if (!string.IsNullOrEmpty(mail.ReplayTo))
                {
                    email.ReplyToList.Add(mail.ReplayTo);
                }
                if (!string.IsNullOrEmpty(mail.AttachmentPath))
                {
                    var atch = new Attachment(mail.AttachmentPath);
                    email.Attachments.Add(atch);
                }
                if (mail.AttachmentData != null)
                {
                    Stream streamData = new MemoryStream(mail.AttachmentData);
                    var atch = new Attachment(streamData, "byteAttachment");
                    email.Attachments.Add(atch);
                }
                smtp.Send(email);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
