using Microsoft.AspNetCore.Mvc;
using personalbeauty.Models;
using personalbeauty.Services;

namespace personalbeauty.Controllers
{
    [ApiController]
    [Route("api/chat")]
    public class ChatController : ControllerBase
    {
        private readonly InMemoryRepository _repo;

        public ChatController(InMemoryRepository repo)
        {
            _repo = repo;
        }

        // --- 質問取得 ---
        [HttpGet("question/{id}")]
        public IActionResult GetQuestion(int id)
        {
            var q = _repo.Questions.FirstOrDefault(x => x.Id == id);
            if (q == null) return NotFound();

            var options = _repo.Options.Where(o => o.QuestionId == id).ToList();

            return Ok(new { question = q, options });
        }

        // --- 次の質問 or 結果 ---
        [HttpGet("next")]
        public IActionResult Next(int questionId, int optionId)
        {
            var flow = _repo.Flows
                .FirstOrDefault(f => f.QuestionId == questionId && f.OptionId == optionId);

            if (flow == null) return NotFound();

            // ▼ キャッシュログ（任意で利用可能）
            _repo.ChatLogs.Add(new ChatLog
            {
                QuestionId = questionId,
                OptionId = optionId,
                Timestamp = DateTime.Now
            });

            // ▼ 最終結果 → 商品検索
            // if (flow.NextQuestionId == null)
            // {
            //    var selected = _repo.Options.First(o => o.Id == optionId);

             //  var matches = _repo.Cosmetics
              //      .Where(c => c.Tags.Any(t => selected.Text.Contains(t)))
                //    .Take(3)
                  //  .ToList();

              //  return Ok(new { result = matches });
            // }
            if (flow.NextQuestionId == null)
            {
                return Ok(new
                {
                    result = _repo.Cosmetics
                });
            }

            return Ok(new { nextQuestionId = flow.NextQuestionId });
        }
    }
}
