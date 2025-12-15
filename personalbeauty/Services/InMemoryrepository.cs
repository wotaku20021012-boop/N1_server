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
                new Question { Id = 1, Text = "ほしいのは？" },
                new Question { Id = 2, Text = "ほしいのは？" },
                new Question { Id = 3, Text = "ほしいタイプは？" },
                new Question { Id = 4, Text = "理想の仕上がりは？" },
                new Question { Id = 5, Text = "近い肌の色は？" },
                new Question { Id = 6, Text = "希望の価格帯は？" },
            };

            // ▼ 選択肢データ
            Options = new()
            {
            	// ID=1の選択肢
                new OptionItem { Id = 1, QuestionId = 1, Text = "メイク用道具" },
                new OptionItem { Id = 2, QuestionId = 1, Text = "ベースメイク用コスメ" },
                new OptionItem { Id = 3, QuestionId = 1, Text = "ポイントメイク用コスメ" },
                
                // ID=2の選択肢
                new OptionItem { Id = 4, QuestionId = 2, Text = "スキンケア" },
                new OptionItem { Id = 5, QuestionId = 2, Text = "化粧下地" },
                new OptionItem { Id = 6, QuestionId = 2, Text = "ファンデーション" },
                new OptionItem { Id = 7, QuestionId = 2, Text = "コンシーラー" },
                new OptionItem { Id = 8, QuestionId = 2, Text = "フェイスパウダー" },
                
                // ID=3の選択肢
                new OptionItem { Id = 9, QuestionId = 3, Text = "パウダー" },
                new OptionItem { Id = 10, QuestionId = 3, Text = "リキッド" },
                new OptionItem { Id = 11, QuestionId = 3, Text = "クッション" },
                
                // ID=4の選択肢
                new OptionItem { Id = 12, QuestionId = 4, Text = "マット" },
                new OptionItem { Id = 13, QuestionId = 4, Text = "セミマット" },
                new OptionItem { Id = 14, QuestionId = 4, Text = "ツヤ" },
                
                // ID=5の選択肢
                new OptionItem { Id = 15, QuestionId = 5, Text = "肌の色が明るめでピンクみがかかっている" },
                new OptionItem { Id = 16, QuestionId = 5, Text = "肌の色が明るめで黄みがかかっている" },
                new OptionItem { Id = 17, QuestionId = 5, Text = "肌の色が暗めでピンクみがかかっている" },
                new OptionItem { Id = 18, QuestionId = 5, Text = "肌の色が暗めで黄みがかかっている" },
                
                // ID=6の選択肢
                new OptionItem { Id = 19, QuestionId = 6, Text = "～1,500円" },
                new OptionItem { Id = 20, QuestionId = 6, Text = "1,500円～" },


            };

            // ▼ チャット遷移フロー
            Flows = new()
            {
                new FlowItem { QuestionId = 1, OptionId = 2, NextQuestionId = 2 },
                new FlowItem { QuestionId = 2, OptionId = 6, NextQuestionId = 3 },
                new FlowItem { QuestionId = 3, OptionId = 9, NextQuestionId = 4 },
                new FlowItem { QuestionId = 4, OptionId = 12, NextQuestionId = 5 },
                new FlowItem { QuestionId = 5, OptionId = 15, NextQuestionId = 6 },

                // ここで最終結果
                new FlowItem { QuestionId = 6, OptionId = 19, NextQuestionId = null },
            };

            // ▼ 商品（化粧品）データ
            Cosmetics = new()
            {
                new Cosmetic { Id = 1, Name = "キャンメイクマシュマロフィニッシュパウダー(MI)", Price = 1034, Tags = new() { "無香料", "肌に優しめ", "マット" },ImageUrl = "http://localhost:5215/images/cosmetics/canmake.png" },

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
