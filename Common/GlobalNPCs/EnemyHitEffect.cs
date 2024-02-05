using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.GameInput;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Graphics.CameraModifiers;
using System.IO;
using Terraria.ModLoader.IO;
using log4net.Core;
using Mono.Cecil;
using RandomGameplayEnhancement.Common.Configs;

namespace RandomGameplayEnhancement.Common.GlobalNPCs
{
    public class EnemyHitEffect : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public int frame = 0;

        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            if (frame >0 && ModContent.GetInstance<Config>().allowEnemyFlashing)
            {
                frame--;
                drawColor.R = 255;
                drawColor.G = 255;
                drawColor.B = 255;
                npc.colo
            }
        }

        public override void OnHitByItem(NPC npc, Player player, Item item, NPC.HitInfo hit, int damageDone)
        {
            if (frame == 0) frame = 6;
            if (!npc.boss)
                Utils.NPCWhenHitQuote(npc);
        }

        public override void OnHitByProjectile(NPC npc, Projectile projectile, NPC.HitInfo hit, int damageDone)
        {
            if (frame == 0) frame = 6;
            if (!npc.boss)
                Utils.NPCWhenHitQuote(npc);
        }

        public override void OnHitPlayer(NPC npc, Player target, Player.HurtInfo hurtInfo)
        {
            if (!npc.boss)
                Utils.NPCOnHitQuote(npc);
        }

        public override void HitEffect(NPC npc, NPC.HitInfo hit)
        {

        }

        public override void OnKill(NPC npc)
        {
            if (!npc.boss)
                Utils.NPCDeathQuote(npc);
        }
    }
}
