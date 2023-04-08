using FreeCourse.PhotoStock.Dtos;
using FreeCourse.Shared.BaseController;
using FreeCourse.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.PhotoStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : CustomBaseController
    {

        [HttpPost]

        public async Task<IActionResult> PhotoSave(IFormFile photo, CancellationToken cancellationToken)
        {
            if (photo != null && photo.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot/photos", photo.FileName);

                var stream = new FileStream(path, FileMode.Create);
                await photo.CopyToAsync(stream);

                var returnPath = "/photos" + photo.FileName;
                PhotoDto photoDto = new()
                {
                    Url = returnPath,
                };
                return CreateActionResultInstance(Response<PhotoDto>.Success(photoDto, 200));
            }
            return CreateActionResultInstance(Response<PhotoDto>.Fail("Failed upload photo", 404));


        }


        [HttpGet]
        public IActionResult PhotoDelete(string photoUrl)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos", photoUrl);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);

                return CreateActionResultInstance(Response<NoConetent>.Success(204));
            }
            return CreateActionResultInstance(Response<NoConetent>.Fail("Photo cannot be deleted", 404));
        }
    }
}
