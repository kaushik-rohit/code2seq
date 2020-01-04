public static bool RemoveMobile(Mobile m, string title = null)
        {
            if (EnhancementList.ContainsKey(m))
            {
                if (title != null)
                {
                    EnhancementAttributes match = EnhancementList[m].FirstOrDefault(attrs => attrs.Title == title);

                    if (match != null && EnhancementList[m].Contains(match))
                    {
                        if(match.Attributes.BonusStr > 0)
                            m.RemoveStatMod("MagicalEnhancementStr");

                        if (match.Attributes.BonusDex > 0)
                            m.RemoveStatMod("MagicalEnhancementDex");

                        if (match.Attributes.BonusInt > 0)
                            m.RemoveStatMod("MagicalEnhancementInt");

                        EnhancementList[m].Remove(match);
                    }
                }

                if(EnhancementList[m].Count == 0 || title == null)
                    EnhancementList.Remove(m);

                m.CheckStatTimers();
                m.UpdateResistances();
                m.Delta(MobileDelta.Stat | MobileDelta.WeaponDamage | MobileDelta.Hits | MobileDelta.Stam | MobileDelta.Mana);

                m.Items.ForEach(i => i.InvalidateProperties());

                return true;
            }

            return false;
        }