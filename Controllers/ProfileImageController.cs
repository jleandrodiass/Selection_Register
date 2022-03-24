using System.Runtime.InteropServices;//WindowsRuntime;
using System.Net.Mime;
using System.IO.Enumeration;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Selection_Register.repositorio;
using IHostingEnvironment = Microsoft.Extensions.Hosting.IHostingEnvironment;

namespace Selection_Register.modelo.Controllers
{

    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ProfileImageController : ControllerBase
   {
      public IHostingEnvironment hostingEnvironment;
   
      public ProfileImageController(IHostingEnvironment hostingEnv )
      {
          hostingEnvironment = hostingEnv;
      }
      [HttpPut]
      [Route("{usuarioId}")]
      public ActionResult UploadImages(int usuarioId, IFormFile arquivo)
      {
        if(arquivo == null)
        {
            return BadRequest();
        }

        using (var db = new repositorio.Contexto())
        {          

            MemoryStream ms = new MemoryStream();
            arquivo.OpenReadStream().CopyTo(ms);
            UploadArquivos arqui = new UploadArquivos()
            {
                Descricao = arquivo.FileName,
                Dados = ms.ToArray(),
                ContentType = arquivo.ContentType
            };

            db.UploadArquivos.Add(arqui);
            db.SaveChanges();
            
            return  Ok("Saved Successfully");
        }
      }
      [HttpGet]
      public IActionResult Visualizar(int id)
      {
          using (var db = new repositorio.Contexto())
          {
                var arquivos_Cv = db.UploadArquivos.FirstOrDefault(x => x.ID == id);
                return File (arquivos_Cv.Dados, arquivos_Cv.ContentType);

          }
      }
   }

}                   //  public ActionResult UploadImages(int usuarioId, IFormFile arquivo)
                //       {
                //         if(arquivo == null)
                //         {
                //             return BadRequest();
                //         }

                //         using (var db = new repositorio.Contexto())
                //         {          

                //             MemoryStream ms = new MemoryStream();
                //             arquivo.OpenReadStream().CopyTo(ms);
                //             UploadArquivos arqui = new UploadArquivos()
                //             {
                //                 Descricao = arquivo.FileName,
                //                 Dados = ms.ToArray(),
                //                 ContentType = arquivo.ContentType
                //             };

                //             db.UploadArquivos.Add(arqui);
                //             db.SaveChanges();
                            
                //             return  Ok("Saved Successfully");
                //         }






        //     {

        //         try
        //         {
        //             var files = HttpContext.Request.Form.Files;
        //             if(files != null && files.Count > 0)
        //             {
        //                 foreach(var file in files)
        //                 {
        //                     FileInfo fi = new FileInfo(file.FileName);
        //                     var newfilename = "Image_"+DateTime.Now.TimeOfDay.Milliseconds + fi.Extension;
        //                     var path = Path.Combine("",hostingEnvironment.ContentRootPath+"//Images//"+newfilename);
        //                     using (var stream = new FileStream(path, FileMode.Create))
        //                     {
        //                         file.CopyTo(stream);
        //                     }
        //                     ImageUpload imageUpload = new ImageUpload();
        //                     imageUpload.ImagePath = path;
        //                     imageUpload.InsertdOn = DateTime.Now;
        //                     db.ImageUpload.Add(imageUpload);
        //                     db.SaveChanges();
        //                 }
        //                 return "Saved Successfully";
        //             }
        //             else 
        //             {
        //                 return "Select Files";
        //             }
        //         }
        //         catch(Exception e1)
        //         {
        //             return e1.Message;
        //         }
        //     }
        // }
        // //[HttpPost]
        // //public ActionResult<string> UploadImages()
        // [HttpGet]
        // public ActionResult<List<ImageUpload>> GetImagesUpload()
        // {
        //     using (var db = new repositorio.Contexto())
        //     {
        //         var result = db.ImageUpload.ToList();
        //         return result;
        //     }
        // }
    // {

    //     [HttpPost]
    //     //[Authorize]
    //     public ActionResult Register(Info_Candidato novoCandidato)
    //     {
    //       // string Authenticated() => $"Cadastro Ok";

    //         using (var db = new repositorio.Contexto())
    //         {
    //             db.Info_Candidato.Add(novoCandidato);
    //             db.SaveChanges();
    //             return Ok(novoCandidato);
    //         }
            
    //     }


        //  private readonly IWebHostEnvironment _webHostEnvironment;

        //  public Info_CadidatosController(IWebHostEnvironment webHostEnvironment)
        //  {
        //      _webHostEnvironment = webHostEnvironment;
        //  }
        //  [HttpPost("upload")]
       

        //     [HttpPost]
        //    public async Task<ActionResult> Upload(List<IFormFile> files)
        //    {
        //        using (var db = new repositorio.Contexto())
        //        {

        //             if(files.Count == 0)
        //             {
        //                 return BadRequest();
        //             }
        //             string directoryPath = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources","Info_Candidato");
        //             foreach(var file in files)
        //             {
        //                 string filePath = Path.Combine(directoryPath, file.FileName);
        //                 using (var stream = new FileStream(filePath,FileMode.Create))
        //                 {
        //                     var novoCandidato = new Info_Candidato
        //                     {
        //                         FileName = file.FileName,
        //                         ContentType = file.ContentType,
        //                         Filesize_Cv = file.Length
        //                     };
        //                     //file.CopyTo(stream);
        //                     await file.CopyToAsync(stream);
        //                     db.Info_Candidato.Add(novoCandidato);
        //                     await db.SaveChangesAsync();
        //                 }
        //             }
        //            return Ok("Upload Successful");
        //         }
        //    }
        //    [HttpPost("download /{ID}")]
        // public async Task<ActionResult> Download(int ID)
        // {
        //     using (var db  = new repositorio.Contexto())
        //     {

        //         // var provider = new FileExttensionContentTypeProvider();
        //         var infoId = await db.Info_Candidato.FindAsync(ID);
        //         if(infoId == null)
        //         {
        //             return NotFound();
        //         }
        //         var file = Path.Combine(_webHostEnvironment.ContentRootPath,"Resources","Info_Candidato",Info_Candidato.FileName );
                
        //         string ContentType;
        //         if
        //     }
        // }
  //  }
        // public Info_Candidato Post(Info_Candidato novoCandidato)
        // {
        //     using (var db = new repositorio.Contexto())
        //     {
        //         db.Info_Candidato.Add(novoCandidato);
        //         db.SaveChanges();
        //         return novoCandidato;
        //     }
        // }