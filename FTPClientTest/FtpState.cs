using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FTPClientTest
{
    class FtpState
    {
        private ManualResetEvent wait;
        private FtpWebRequest request;
        private string fileName;
        private Exception operationException = null;

        public string status;

        public FtpState()
        {
            wait = new ManualResetEvent(false);
        }

        public ManualResetEvent OperationComplete => wait;
        public FtpWebRequest Request => request;
        public string FileName => fileName;
        public Exception OperationException => operationException;
        public string StatusDescription => status;
    }
}
