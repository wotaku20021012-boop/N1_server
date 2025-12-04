using Microsoft.AspNetCore.Mvc;
using personalbeauty.Models;
using personalbeauty.Services;

namespace personalbeauty.Controllers
{
    [ApiController]
    [Route("api/form")]
    public class FormController : ControllerBase
    {
        private readonly InMemoryRepository _repo;

        public FormController(InMemoryRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("submit")]
        public IActionResult SubmitForm([FromBody] FormRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            // ▼ キャッシュ保持（後で統計にも使える）
            _repo.FormLogs.Add(request);

            // ▼ 商品検索
            var match = _repo.Cosmetics
                .Where(c =>
                    (request.Problem != null && c.Tags.Any(t => request.Problem.Contains(t))) ||
                    (request.Preference != null && c.Tags.Any(t => request.Preference.Contains(t)))
                )
                .Take(3)
                .ToList();

            if (match.Count == 0)
                return Ok(new { result = "該当なし" });

            return Ok(new { result = match });
        }
    }
}
