using Microsoft.Xna.Framework;
using RandomGameplayEnhancement.Common.Configs;
using RandomGameplayEnhancement.Common.Database;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RandomGameplayEnhancement.Common
{
    public class Utils
    {
        internal static void NPCDeathQuote(NPC npc)
        {
            if (!ModContent.GetInstance<Config>().AllowEnemyQuote) return;
            Random random = new Random();

            if (random.Next(0, 10) == 0)
            {
                string quote = QuoteDatabase.enemyDeathQuote[random.Next(0, QuoteDatabase.enemyDeathQuote.Count)];
                int textID = CombatText.NewText(npc.Hitbox, Color.Red, quote, true);

                Main.combatText[textID].lifeTime = 90;
                Main.combatText[textID].scale = 2f;
                Main.combatText[textID].crit = true;
            }
        }
        internal static void NPCOnHitQuote(NPC npc)
        {
            if (!ModContent.GetInstance<Config>().AllowEnemyQuote) return;

            Random random = new Random();

            if (random.Next(0, 4) == 0)
            {
                string quote = QuoteDatabase.enemyOnHitQuote[random.Next(0, QuoteDatabase.enemyOnHitQuote.Count)];
                int textID = CombatText.NewText(npc.Hitbox, Color.Red, quote, true);

                Main.combatText[textID].lifeTime = 75;
                Main.combatText[textID].scale = 2f;
                Main.combatText[textID].crit = true;
            }
        }

        internal static void NPCWhenHitQuote(NPC npc)
        {
            if (!ModContent.GetInstance<Config>().AllowEnemyQuote) return;

            Random random = new Random();

            if (random.Next(0, 10) == 0)
            {
                string quote = QuoteDatabase.enemyWhenHitQuote[random.Next(0, QuoteDatabase.enemyWhenHitQuote.Count)];
                int textID = CombatText.NewText(npc.Hitbox, Color.Red, quote, true);

                Main.combatText[textID].lifeTime = 75;
                Main.combatText[textID].scale = 2f;
                Main.combatText[textID].crit = true;
            }
        }
    }
}
