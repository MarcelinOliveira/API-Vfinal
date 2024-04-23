using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using WebApplication1.Helpers;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpPost("upload")]
        public async Task<ActionResult> Upload([FromForm] ICollection<IFormFile> files)
        {
            try
            {
                if (files == null || files.Count == 0)
                    return BadRequest();
                List<byte[]> data = new();
                foreach (var formfile in files)
                {
                    if (formfile.Length > 0)
                    {
                        using (var stream = new MemoryStream())
                        {
                            await formfile.CopyToAsync(stream);
                            data.Add(stream.ToArray());
                        }
                    }
                }
                var slvImg = new SalvaImagem("C:\\Users\\junio\\Desktop\\TCC\\Imagens");
                foreach (var file in data)
                {
                    slvImg.SalvarImagem(file);
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }
    }   
}
