using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.MaintenanceApplication.Services
{
    public class AuthMessageSenderOptions
    {
        public string MailBoxUserName { get; set; }
        public string MailBoxPassword { get; set; }
        public string MailBoxUserDisplayName { get; set; }
        public string MailBoxHost { get; set; }
        public string MailBoxPrivateKey { get; set; }
    }
}
