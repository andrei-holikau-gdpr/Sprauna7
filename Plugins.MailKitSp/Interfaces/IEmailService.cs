﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins.MailKitSp.Interfaces
{
    public interface IEmailService
    {
        public Task SendEmailAsync(string ToEmail, string messageSubject, string HTMLBody);
    }
}
