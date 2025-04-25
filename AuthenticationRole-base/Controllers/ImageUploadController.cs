using Microsoft.AspNetCore.Mvc;

namespace BlueGreenEG.Controllers
{
    public class ImageUploadController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ImageUploadController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                    return Json(new { error = "No file selected" });

                // Check file type
                var extension = Path.GetExtension(file.FileName).ToLower();
                if (extension != ".jpg" && extension != ".jpeg" && extension != ".png" && extension != ".gif")
                    return Json(new { error = "Unsupported file type. Supported types: jpg, jpeg, png, gif" });

                // Check file size (e.g., max 5MB)
                if (file.Length > 5 * 1024 * 1024)
                    return Json(new { error = "File is too large. Maximum size is 5MB" });

                // Create directory if it doesn't exist
                string articlesFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Articles");
                if (!Directory.Exists(articlesFolder))
                {
                    Directory.CreateDirectory(articlesFolder);
                }

                // Create unique filename
                string uniqueFileName = $"{Guid.NewGuid()}_{DateTime.Now.ToString("yyyyMMddHHmmss")}{extension}";
                string filePath = Path.Combine(articlesFolder, uniqueFileName);

                // Save file
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Return URL for the image
                var fileUrl = $"/Articles/{uniqueFileName}";

                // This format is crucial for TinyMCE - it expects a JSON object with a 'location' property
                return Json(new { location = fileUrl });
            }
            catch (Exception ex)
            {
                // Return error information
                return StatusCode(500, new { error = $"An error occurred: {ex.Message}" });
            }
        }
    }
}
