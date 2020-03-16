using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.Api
{
    public class FileUploadController : ApiControllerBase
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }


        [HttpPost]
        public Task<HttpResponseMessage> ImageUpload(HttpRequestMessage request, string documentType)
        {
            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string root = HttpContext.Current.Server.MapPath("~/FileUploads/Logo");
            var provider = new MultipartFormDataStreamProvider(root);
            //if (log.IsDebugEnabled)
            //{
            //    log.Debug("The Path is :  " + root);
            //}
            // Read the form data.
            ArrayList arrLst = new ArrayList();
            return Request.Content.ReadAsMultipartAsync(provider).ContinueWith(t =>
            {
                HttpResponseMessage response = null;
                var files = new List<string>();
                byte[] byteArray = null;

                DocumentDTO document = null;
                //  int doucmentId = 0;
                string fileType = null;
                string documentName = null;//Document Name is not provided in front end, so we are using filename as document name
                string fileName = null;
                string orginalFileName = null;
                foreach (MultipartFileData file in provider.FileData)
                {
                    byteArray = null;
                    // _fileservice = new FileClient();

                    if (string.IsNullOrEmpty(file.Headers.ContentDisposition.FileName))
                    {
                        throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable, "This request is not properly formatted"));
                    }

                    orginalFileName = file.Headers.ContentDisposition.FileName;

                    if (orginalFileName.StartsWith("\"") && orginalFileName.EndsWith("\""))
                    {
                        orginalFileName = orginalFileName.Trim('"');
                    }

                    fileType = file.Headers.ContentType.ToString();
                    fileName = file.Headers.ContentDisposition.FileName.Insert(1, DateTime.Now.ToString("yyyyMMddHHmmss_"));

                    if (fileName.StartsWith("\"") && fileName.EndsWith("\""))
                    {
                        fileName = fileName.Trim('"');
                    }
                    if (fileName.Contains(@"/") || fileName.Contains(@"\"))
                    {
                        fileName = Path.GetFileName(fileName);
                    }
                    if (documentName == null)
                    {
                        documentName = fileName.Substring(0, 4);
                    }
                    // fileName = fileName.AppendTimeStamp();
                    files.Add(fileName);

                    File.Copy(file.LocalFileName, Path.Combine(root, fileName), true);

                    byteArray = MultipleFileUploadStreamFile(Path.Combine(root, fileName));
                    document = new DocumentDTO(documentType, documentName, fileName, fileName, fileType, orginalFileName);
                    arrLst.Add(document);
                    // document = _fileservice.Upload(byteArray, fileName, fileType, documentName, documentType);

                    File.Delete(Path.Combine(root, file.LocalFileName));
                    //File.Delete(Path.Combine(root, fileName));
                }
                response = request.CreateResponse(HttpStatusCode.OK, arrLst);

                return response;
            }, TaskScheduler.FromCurrentSynchronizationContext());


        }

        [AllowAnonymous]
        [HttpPost]
        public Task<HttpResponseMessage> ImageUploadAno(HttpRequestMessage request, string documentType)
        {
            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string root = HttpContext.Current.Server.MapPath("~/FileUploads/Logo");
            var provider = new MultipartFormDataStreamProvider(root);
            //if (log.IsDebugEnabled)
            //{
            //    log.Debug("The Path is :  " + root);
            //}
            // Read the form data.
            ArrayList arrLst = new ArrayList();
            return Request.Content.ReadAsMultipartAsync(provider).ContinueWith(t =>
            {
                HttpResponseMessage response = null;
                var files = new List<string>();
                byte[] byteArray = null;

                DocumentDTO document = null;
                //  int doucmentId = 0;
                string fileType = null;
                string documentName = null;//Document Name is not provided in front end, so we are using filename as document name
                string fileName = null;
                string orginalFileName = null;
                foreach (MultipartFileData file in provider.FileData)
                {
                    byteArray = null;
                    // _fileservice = new FileClient();

                    if (string.IsNullOrEmpty(file.Headers.ContentDisposition.FileName))
                    {
                        throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable, "This request is not properly formatted"));
                    }

                    orginalFileName = file.Headers.ContentDisposition.FileName;

                    if (orginalFileName.StartsWith("\"") && orginalFileName.EndsWith("\""))
                    {
                        orginalFileName = orginalFileName.Trim('"');
                    }

                    fileType = file.Headers.ContentType.ToString();
                    fileName = file.Headers.ContentDisposition.FileName.Insert(1, DateTime.Now.ToString("yyyyMMddHHmmss_"));

                    if (fileName.StartsWith("\"") && fileName.EndsWith("\""))
                    {
                        fileName = fileName.Trim('"');
                    }
                    if (fileName.Contains(@"/") || fileName.Contains(@"\"))
                    {
                        fileName = Path.GetFileName(fileName);
                    }
                    if (documentName == null)
                    {
                        documentName = fileName.Substring(0, 4);
                    }
                    // fileName = fileName.AppendTimeStamp();
                    files.Add(fileName);

                    File.Copy(file.LocalFileName, Path.Combine(root, fileName), true);

                    byteArray = MultipleFileUploadStreamFile(Path.Combine(root, fileName));
                    document = new DocumentDTO(documentType, documentName, fileName, fileName, fileType, orginalFileName);
                    arrLst.Add(document);
                    // document = _fileservice.Upload(byteArray, fileName, fileType, documentName, documentType);

                    File.Delete(Path.Combine(root, file.LocalFileName));
                    //File.Delete(Path.Combine(root, fileName));
                }
                response = request.CreateResponse(HttpStatusCode.OK, arrLst);

                return response;
            }, TaskScheduler.FromCurrentSynchronizationContext());


        }

        //[HttpPost]
        //public Task<HttpResponseMessage> ImageUpload(HttpRequestMessage request)
        //{
        //    string documentType = string.Empty;
        //    // Check if the request contains multipart/form-data.
        //    if (!Request.Content.IsMimeMultipartContent())
        //    {
        //        throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
        //    }

        //    string root = HttpContext.Current.Server.MapPath("~/FileUploads");
        //    var provider = new MultipartFormDataStreamProvider(root);
        //    //if (log.IsDebugEnabled)
        //    //{
        //    //    log.Debug("The Path is :  " + root);
        //    //}
        //    // Read the form data.
        //    System.Collections.ArrayList arrLst = new System.Collections.ArrayList();
        //    return Request.Content.ReadAsMultipartAsync(provider).ContinueWith(t =>
        //    {
        //        HttpResponseMessage response = null;
        //        var files = new List<string>();
        //        byte[] byteArray = null;
        //        //DocumentVO document = null;

        //        //  int doucmentId = 0;
        //        string fileType = null;
        //        string documentName = null;//Document Name is not provided in front end, so we are using filename as document name
        //        string fileName = null;

        //        foreach (MultipartFileData file in provider.FileData)
        //        {
        //            byteArray = null;
        //            //_fileservice = new FileClient();

        //            if (string.IsNullOrEmpty(file.Headers.ContentDisposition.FileName))
        //            {
        //                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable, "This request is not properly formatted"));
        //            }

        //            fileType = file.Headers.ContentType.ToString();
        //            fileName = file.Headers.ContentDisposition.FileName;

        //            if (fileName.StartsWith("\"") && fileName.EndsWith("\""))
        //            {
        //                fileName = fileName.Trim('"');
        //            }
        //            if (fileName.Contains(@"/") || fileName.Contains(@"\"))
        //            {
        //                fileName = Path.GetFileName(fileName);
        //            }
        //            if (documentName == null)
        //            {
        //                documentName = fileName.Substring(0, 4);
        //            }
        //            files.Add(fileName);

        //            File.Copy(file.LocalFileName, Path.Combine(root, fileName), true);

        //            byteArray = MultipleFileUploadStreamFile(Path.Combine(root, fileName));
        //            //document = _fileservice.Upload(byteArray, fileName, fileType, documentName, documentType);
        //            //arrLst.Add(document);

        //            File.Delete(Path.Combine(root, file.LocalFileName));
        //            //File.Delete(Path.Combine(root, fileName));
        //        }
        //        response = request.CreateResponse(HttpStatusCode.OK, arrLst);

        //        return response;
        //    }, TaskScheduler.FromCurrentSynchronizationContext());
        //}


        [HttpPost]
        public Task<HttpResponseMessage> DeleteFile(HttpRequestMessage request)
        {
            string documentType = string.Empty;
            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string root = HttpContext.Current.Server.MapPath("~/FileUploads");
            var provider = new MultipartFormDataStreamProvider(root);
            //if (log.IsDebugEnabled)
            //{
            //    log.Debug("The Path is :  " + root);
            //}
            // Read the form data.
            ArrayList arrLst = new ArrayList();
            return Request.Content.ReadAsMultipartAsync(provider).ContinueWith(t =>
            {
                HttpResponseMessage response = null;
                var files = new List<string>();
                byte[] byteArray = null;
                //DocumentVO document = null;

                //  int doucmentId = 0;
                string fileType = null;
                string documentName = null;//Document Name is not provided in front end, so we are using filename as document name
                string fileName = null;

                foreach (MultipartFileData file in provider.FileData)
                {
                    byteArray = null;
                    //_fileservice = new FileClient();

                    if (string.IsNullOrEmpty(file.Headers.ContentDisposition.FileName))
                    {
                        throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable, "This request is not properly formatted"));
                    }

                    fileType = file.Headers.ContentType.ToString();
                    fileName = file.Headers.ContentDisposition.FileName;

                    if (fileName.StartsWith("\"") && fileName.EndsWith("\""))
                    {
                        fileName = fileName.Trim('"');
                    }
                    if (fileName.Contains(@"/") || fileName.Contains(@"\"))
                    {
                        fileName = Path.GetFileName(fileName);
                    }
                    if (documentName == null)
                    {
                        documentName = fileName.Substring(0, 4);
                    }
                    files.Add(fileName);

                    //File.Copy(file.LocalFileName, Path.Combine(root, fileName), true);

                    byteArray = MultipleFileUploadStreamFile(Path.Combine(root, fileName));
                    //document = _fileservice.Upload(byteArray, fileName, fileType, documentName, documentType);
                    //arrLst.Add(document);

                    File.Delete(Path.Combine(root, file.LocalFileName));
                    File.Delete(Path.Combine(root, fileName));
                }
                response = request.CreateResponse(HttpStatusCode.OK, arrLst);

                return response;
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        /// <summary>
        /// Single File Upload as well as Multiple File Upload
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private byte[] MultipleFileUploadStreamFile(string filename)
        {

            byte[] buff = null;
            FileStream fs = new FileStream(filename,
                                           FileMode.Open,
                                           FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            long numBytes = new FileInfo(filename).Length;
            buff = br.ReadBytes((int)numBytes);
            fs.Flush();
            fs.Close();
            br.Close();
            return buff;
        }

        [HttpPost]
        public HttpResponseMessage GetUserUploadedFiles(HttpRequestMessage request)
        {
            return GetHttpResponse(request, () =>
            {
                Request.Content.LoadIntoBufferAsync().Wait();
                var result = Task.Factory
                             .StartNew(() => Request.Content.ReadAsMultipartAsync().Result,
                              CancellationToken.None,
                              TaskCreationOptions.LongRunning,
                              TaskScheduler.Default).Result;

                var contents = result.Contents;
                HttpContent httpContent = contents.First();

                Stream file = httpContent.ReadAsStreamAsync().Result;

                string uploadedFileMediaType = httpContent.Headers.ContentType.MediaType;

                string filename = httpContent.Headers.ContentDisposition.FileName.Replace("\"", string.Empty);

                if (file.CanRead)
                {
                    // Code that will be executed on each file
                }
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, filename);
                return response;
            });
        }
    }
}