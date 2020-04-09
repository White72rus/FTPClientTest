using FTPClientTest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OmsisWebApp
{
    public class FTPClient
    {
        private string _Host;
        private static string _UserName;
        private static string _Password;
        FtpWebRequest ftpRequest;
        FtpWebResponse ftpResponse;
        private bool _UseSSL = false;
        private string downLoadPath = "C:/Users/leshok-ka/Downloads/FTP/";

        public string Host { get => this._Host; set => this._Host = value; }
        public string UserName { get => _UserName; set => _UserName = value; }
        public string Password { get => _Password; set => _Password = value; }
        public bool UseSSL { get => _UseSSL; set => _UseSSL = value; }
        public string DownLoadPath { get => downLoadPath; set => downLoadPath = value; }
        /// <summary>
        /// Download file from FTP. This method async.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="filename"></param>
        /// <param name="destname"></param>
        /// <returns></returns>
        public async Task<bool> DownloadFile(string path, string filename, string destname)
        {
            try
            {
                ftpRequest = (FtpWebRequest)WebRequest.Create("ftp://" + _Host + path + "/" + filename);
                ftpRequest.Credentials = new NetworkCredential(_UserName, _Password);
                ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                ftpRequest.EnableSsl = _UseSSL;

                DirectoryInfo df = new DirectoryInfo(DownLoadPath);

                if (!df.Exists)
                {
                    //return false;
                    df.Create();
                }

                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                Stream responseStream = ftpResponse.GetResponseStream();
                FileStream fileStream = new FileStream(DownLoadPath + destname, FileMode.Create, FileAccess.ReadWrite);

                byte[] buffer = new byte[1024];
                int size = 0;

                while ((size = responseStream.Read(buffer, 0, 1024)) > 0)
                {
                    await fileStream.WriteAsync(buffer, 0, size).ConfigureAwait(true);
                }

                responseStream.Close();
                ftpResponse.Close();
                fileStream.Close();

                return true;
            }
            catch (Exception ex)
            {
                StringBuilder errorMessages = new StringBuilder();

                errorMessages.Append(
                    "Message: " + ex.Message + "\n" +
                    "InnerException: " + ex.InnerException + "\n" +
                    "Source: " + ex.Source + "\n" +
                    "StackTrace: " + ex.StackTrace + "\n");

                Tools.Red(errorMessages.ToString());
                return false;
            }

        }

        private static void UploadFileAsync(string fname, string tname) {
            ManualResetEvent waitObject;

            Uri uri = new Uri(tname);
            string fileName = fname;
            FtpState state = new FtpState();
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(uri);
            request.Method = WebRequestMethods.Ftp.UploadFile;

            request.Credentials = new NetworkCredential(_UserName, _Password);

            //state.Request = request;
        }

        /// <summary>
        /// Gets list files from FTP.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string GetFileList(string path) {

            ftpRequest = (FtpWebRequest)WebRequest.Create("ftp://" + _Host + path);
            ftpRequest.Credentials = new NetworkCredential(_UserName, _Password);
            ftpRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            ftpRequest.EnableSsl = _UseSSL;

            ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();

            Stream responseStream = ftpResponse.GetResponseStream();
            StreamReader streamReader = new StreamReader(responseStream);
            string result = streamReader.ReadToEnd();
            streamReader.Close();
            responseStream.Close();
            ftpResponse.Close();
            return result;
        }

        public List<string> GetFileList(string path, bool flag = true)
        {
            return GetFileList(path).Split("\n".ToCharArray()).ToList<string>();
        }
    }
}
