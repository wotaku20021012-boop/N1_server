using personalbeauty.Models;

namespace personalbeauty.Services
{
    public class InMemoryRepository
    {
        // ▼ キャッシュ（チャット回答ログ）
        public List<ChatLog> ChatLogs { get; set; } = new();

        // ▼ フォーム回答ログ
        public List<FormRequest> FormLogs { get; set; } = new();

        // ▼ チャットの質問
        public List<Question> Questions { get; set; }

        // ▼ 質問に紐づく選択肢
        public List<OptionItem> Options { get; set; }

        // ▼ チャットの遷移フロー
        public List<FlowItem> Flows { get; set; }

        // ▼ 商品データ
        public List<Cosmetic> Cosmetics { get; set; }

        public InMemoryRepository()
        {
            // ▼ 質問データ
            Questions = new()
            {
                new Question { Id = 1, Text = "肌の悩みはどれですか？" },
                new Question { Id = 2, Text = "どの仕上がりが好みですか？" }
            };

            // ▼ 選択肢データ
            Options = new()
            {
                new OptionItem { Id = 1, QuestionId = 1, Text = "乾燥" },
                new OptionItem { Id = 2, QuestionId = 1, Text = "ニキビ" },
                new OptionItem { Id = 3, QuestionId = 2, Text = "ツヤ肌" },
                new OptionItem { Id = 4, QuestionId = 2, Text = "マット肌" }
            };

            // ▼ チャット遷移フロー
            Flows = new()
            {
                new FlowItem { QuestionId = 1, OptionId = 1, NextQuestionId = 2 },
                new FlowItem { QuestionId = 1, OptionId = 2, NextQuestionId = 2 },

                // ここで最終結果
                new FlowItem { QuestionId = 2, OptionId = 3, NextQuestionId = null },
                new FlowItem { QuestionId = 2, OptionId = 4, NextQuestionId = null },
            };

            // ▼ 商品（化粧品）データ
            Cosmetics = new()
{
    new Cosmetic { Id = 1, Name = "高保湿クリームEX", Price = 1800, Tags = new() { "乾燥", "保湿", "ツヤ" }},
    new Cosmetic { Id = 2, Name = "薬用ニキビケアジェル", Price = 1200, Tags = new() { "ニキビ", "脂性肌" }},
    new Cosmetic { Id = 3, Name = "マット仕上げ美容液", Price = 2500, Tags = new() { "マット", "テカリ防止" }},
    new Cosmetic { Id = 4, Name = "敏感肌用保湿ローション", Price = 1600, Tags = new() { "敏感肌", "低刺激", "乾燥" }},
    new Cosmetic { Id = 5, Name = "美白ブライトニングセラム", Price = 2900, Tags = new() { "美白", "くすみ", "シミ" }},
    new Cosmetic { Id = 6, Name = "皮脂コントロール化粧水", Price = 1500, Tags = new() { "脂性肌", "テカリ防止" }},
    new Cosmetic { Id = 7, Name = "ツヤ肌ファンデーション", Price = 2200, Tags = new() { "ツヤ", "乾燥" }},
    new Cosmetic { Id = 8, Name = "マットクッションファンデ", Price = 2600, Tags = new() { "マット", "皮脂吸着" }},
    new Cosmetic { Id = 9, Name = "敏感肌用クレンジングミルク", Price = 1400, Tags = new() { "敏感肌", "低刺激" }},
    new Cosmetic { Id = 10, Name = "角質クリア美容液", Price = 1800, Tags = new() { "毛穴", "角質", "くすみ" }},
    new Cosmetic { Id = 11, Name = "しっとり化粧水 プレミアム", Price = 1700, Tags = new() { "乾燥", "保湿" }},
    new Cosmetic { Id = 12, Name = "皮脂崩れ防止下地", Price = 1200, Tags = new() { "マット", "テカリ防止", "脂性肌" }},
    new Cosmetic { Id = 13, Name = "ツヤ出し下地グロウ", Price = 1400, Tags = new() { "ツヤ", "うるおい" }},
    new Cosmetic { Id = 14, Name = "美白UVエッセンス SPF50", Price = 2000, Tags = new() { "美白", "日焼け止め" }},
    new Cosmetic { Id = 15, Name = "オイルフリー美容液", Price = 2300, Tags = new() { "脂性肌", "ニキビ" }},
    new Cosmetic { Id = 16, Name = "しっとりクリームファンデ", Price = 2500, Tags = new() { "乾燥", "ツヤ" }},
    new Cosmetic { Id = 17, Name = "毛穴ぼかしプライマー", Price = 1900, Tags = new() { "毛穴", "テカリ防止" }},
    new Cosmetic { Id = 18, Name = "敏感肌用UVミルク", Price = 1600, Tags = new() { "敏感肌", "日焼け止め" }},
    new Cosmetic { Id = 19, Name = "透明感アップ美容液", Price = 2800, Tags = new() { "くすみ", "美白" }},
    new Cosmetic { Id = 20, Name = "皮脂吸着パウダー", Price = 1300, Tags = new() { "マット", "皮脂吸着" }},
};

        }
    }

    public class FlowItem
    {
        public int QuestionId { get; set; }
        public int OptionId { get; set; }
        public int? NextQuestionId { get; set; }
    }
}
