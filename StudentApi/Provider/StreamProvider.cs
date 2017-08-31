using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using MimeTypes;

namespace StudentApi.Provider
{
    public class StreamProvider : MultipartFormDataStreamProvider
    {
        public StreamProvider(string uploadPath) : base(uploadPath)
        {

        }

        public override string GetLocalFileName(HttpContentHeaders headers)
        {
            string extention = MimeTypes.MimeTypeMap.GetExtension(headers.ContentType.ToString());
            string fileName = Guid.NewGuid().ToString() + extention;

            if (string.IsNullOrWhiteSpace(fileName))
            {
                fileName = Guid.NewGuid().ToString() + "..mp3";
            }

            return fileName;
        }
    }
}