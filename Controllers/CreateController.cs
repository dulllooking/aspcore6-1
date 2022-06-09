using Microsoft.AspNetCore.Mvc;

namespace aspcore6_1.Controllers
{
    public class CreateController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(IFormFile FileUpload_FileName)   // 多檔上傳，請用 List<IFormFile>
        {
            try {
                if (FileUpload_FileName.Length > 0)   // 檢查 <input type="file"> 是否輸入檔案？
                {
                    using (var ms = new MemoryStream()) {

                        FileUpload_FileName.CopyTo(ms);
                        if (ms.Length < 2097152) {
                            var path = $@"Upload\{FileUpload_FileName.FileName}";
                            using (var stream = new FileStream(path, FileMode.Create)) {
                                FileUpload_FileName.CopyToAsync(stream);
                            }
                        }

                    }

                    ViewBag.Message = "上傳成功。";
                }
            }
            catch {
                ViewBag.Message = "上傳失敗。File upload failed!!";
            }
            return View();
        }
    }
}
