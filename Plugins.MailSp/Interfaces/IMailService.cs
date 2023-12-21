using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins.MailSp.Interfaces
{
    public interface IMailService
    {
        public Task SendEmailAsync(string ToEmail, string Subject, string HTMLBody);
        //public string GetUsername();
        //public string GetPassword();
        //public string GetFromEmail();
        //public string GetHost();
        //public int GetPort();
    }
}
