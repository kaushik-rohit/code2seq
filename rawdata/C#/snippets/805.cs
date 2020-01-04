public static string GetLanguage(long id)
        {
            using (var db = new WWContext())
            {
                Player p = null;
                var grp = db.Groups.FirstOrDefault(x => x.GroupId == id);
                if (grp == null)
                    p = db.Players.FirstOrDefault(x => x.TelegramId == id);
                if (p != null && String.IsNullOrEmpty(p.Language))
                {
                    p.Language = "English";
                    db.SaveChanges();
                }
                return grp?.Language ?? p?.Language ?? "English";
            }
        }