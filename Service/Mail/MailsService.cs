using Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Service.Mail
{
    public class MailsService
    {
        private readonly Dictionary<string, string> MailTemplatesDict = new Dictionary<string, string>();

        public void Clear()
        {
            lock (MailTemplatesDict)
            {
                MailTemplatesDict.Clear();
            }
        }

        private string CreateEmailBody(string languageSign, string template, string webSiteUrl)
        {
            if (!string.IsNullOrEmpty(languageSign) && !string.IsNullOrEmpty(template))
            {
                try
                {
                    using (StreamReader reader = new StreamReader($"{AppSettings.EmailTemplatePath}/rs/{template}.html", Encoding.Default))
                    {
                        var body = reader.ReadToEnd();
                        if (!string.IsNullOrEmpty(body))
                        {
                            return body;
                        }
                        else
                        {
                            //m_Logger.Error($"Email template {template} for language {languageSign} is empty.");
                            return string.Empty;
                        }
                    }
                }
                catch (Exception exc)
                {
                    //m_Logger.Error(exc, $"Problem finding email template: {template} for language {languageSign}.");
                }
            }
            return string.Empty;
        }
    }
}
