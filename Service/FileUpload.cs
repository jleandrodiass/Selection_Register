using System.IO;
using System;
using System.Text.RegularExpressions;
using Azure.Storage.Blobs;

namespace Selection_Register.Service
{
    public class FileUpload
    {
        public string UploadBase64Image(string base64Image , string container)
        {
            //Gera um nome radomico para imagem
            var fileName = Guid.NewGuid().ToString() +".jpg";

            //Limpa o hash enviado
            var data = new Regex(@"^data : image\/[a-z]+;base64,").Replace(base64Image,""); 

            //Gerando um array de Bytes
            byte[] imageBytes = Convert.FromBase64String(data);

            //Define o BlOB no qual a imagem saré armazenada
            var blobcliente = new BlobClient("SUA Conn STRING",container, fileName);
            
            //Envia a imagem
            using (var stream = new MemoryStream(imageBytes))
            {
                blobcliente.Upload(stream);
            }
            //Retorna a URL da imagem  
            return blobcliente.Uri.AbsoluteUri;

        }
    }
}