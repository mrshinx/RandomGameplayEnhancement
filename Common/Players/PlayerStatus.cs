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

namespace RandomGameplayEnhancement.Common.Players
{
    public enum Status
    {
        None,
        Combat,
        Idle,
        Active,
        Rest
    }
    public class PlayerStatus : ModPlayer
    {
        public Status playerStatus = Status.Active;
        public int combatTimer = 0;

        public override void PreUpdate()
        {
            combatTimer = Math.Clamp(combatTimer-1,0,600);
        }

        public override void PostUpdate()
        {
            for (int i = 0; i < Main.maxNPCs; ++i)
            {
                NPC npc = Main.npc[i];
                if (npc.active && npc.boss)
                {
                    playerStatus = Status.Combat;
                    combatTimer = 420;
                    return;
                }
            }

            if (Player.TalkNPC != null || Player.sleeping.isSleeping || Player.sitting.isSitting)
            {
                playerStatus = Status.Rest;
                return;
            }

            if (combatTimer == 0)
            {
                playerStatus = Player.afkCounter > 300 ? Status.Idle : Status.Active;
            }
            else playerStatus = Status.Combat;
        }

        public override void OnHitAnything(float x, float y, Entity victim)
        {
            combatTimer = 420;
            playerStatus = Status.Combat;
        }

        public override void OnHitByNPC(NPC npc, Player.HurtInfo hurtInfo)
        {
            combatTimer = 420;
            playerStatus = Status.Combat;
        }
    }
}
