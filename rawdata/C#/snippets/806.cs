public static string GetLanguage(int id)
        {
            using (var db = new WWContext())
            {
                var p = db.Players.FirstOrDefault(x => x.TelegramId == id);
                if (String.IsNullOrEmpty(p?.Language) && p != null)
                {
                    p.Language = "English";
                    db.SaveChanges();
                }
                return p?.Language ?? "English";
            }
        }