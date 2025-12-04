using System;

namespace personalbeauty.Models
{
    public class FormSubmission
    {
        public int Id { get; set; }

        // ユーザー入力内容
        public string Problem { get; set; } = string.Empty;
        public string Preference { get; set; } = string.Empty;

        // 推奨結果
        public string RecommendedProduct { get; set; } = string.Empty;

        // 登録日時
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
