using System;
using System.IO;
using System.Web;
using Model.HMS;
using Model.HMS.Helper;

namespace Services.HMS
{
    public interface IEmailSevice
    {
        string TemplateFolder { get; set; }
        void SendRegisterConfirmationEmail(string mail, string receptName, string code);
    }

    public class EmailService : IEmailSevice
    {

        public EmailService()
        {
            if (HttpContext.Current != null)
            {
                var ss = App.Configurations.EmailTemplatePath.Value;
                string path = HttpContext.Current.Server.MapPath(App.Configurations.EmailTemplatePath.Value);
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);

                TemplateFolder = path;
            }
        }

        public string TemplateFolder { get; set; }
        public void SendRegisterConfirmationEmail(string receiverEmail, string receptName, string code)
        {
            if (String.IsNullOrEmpty(TemplateFolder)) return;

            string body = System.IO.File.ReadAllText(TemplateFolder + "\\" + App.Configurations.RegistrationEmailName.Value);
            string subject = App.Configurations.RegistrationEmailSubject.Value;


            body = body.Replace("$ReceiverName$", receptName);
            body = body.Replace("$Logo$", LinkHelper.Domain + "~/Content/assets/images/logo.png");
            body = body.Replace("$Recipient$", receiverEmail);
            body = body.Replace("$code$", code);

            EmailSender.Send(receiverEmail, subject, body);
        }
    }
}
