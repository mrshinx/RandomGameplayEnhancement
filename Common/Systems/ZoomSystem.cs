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
using Terraria.Graphics;
using RandomGameplayEnhancement.Common.Players;
using RandomGameplayEnhancement.Common.Configs;

namespace RandomGameplayEnhancement.Common.Systems
{
    public class ZoomSystem : ModSystem
    {
        Status previousPlayerStatus = Status.None;
        int frame = 0;
        int frame2 = 0;
        bool needChangeZoom = false;
        Vector2 previousStatusZoom = new Vector2(1f,1f);
        Vector2 currentStatusZoom = new Vector2(1f,1f);

        public override void ModifyTransformMatrix(ref SpriteViewMatrix Transform)
        {
            if (Main.gameMenu || !ModContent.GetInstance<Config>().allowDynamicZoom)
                return;

            Status playerStatus = Main.LocalPlayer.GetModPlayer<PlayerStatus>().playerStatus;

            // Check if player has changed status
            if (playerStatus != previousPlayerStatus)
            {
                previousPlayerStatus = playerStatus;
                frame = 0;
                previousStatusZoom = currentStatusZoom;
                needChangeZoom = true;
            }
            // If so, zoom level needs to be changed
            if (needChangeZoom)
            {
                frame++;
                SmoothZoom(playerStatus);

                if (frame == 45)
                {
                    previousStatusZoom = currentStatusZoom;
                    needChangeZoom = false;
                }
            }

            Transform.Zoom = currentStatusZoom;
        }

        private void SmoothZoom(Status playerStatus)
        {
            float restZoom = ModContent.GetInstance<Config>().RestZoom;
            float idleZoom = ModContent.GetInstance<Config>().IdleZoom;
            float activeZoom = ModContent.GetInstance<Config>().OutCombatZoom;
            float combatZoom = ModContent.GetInstance<Config>().InCombatZoom;

            switch (playerStatus)
            {
                case Status.Rest:
                    currentStatusZoom = Vector2.Lerp(previousStatusZoom, new Vector2(restZoom, restZoom), frame / 45f);
                    break;
                case Status.Idle:
                    currentStatusZoom = Vector2.Lerp(previousStatusZoom, new Vector2(idleZoom, idleZoom), frame / 45f);
                    break;
                case Status.Active:
                    currentStatusZoom = Vector2.Lerp(previousStatusZoom, new Vector2(activeZoom, activeZoom), frame / 45f);
                    break;
                case Status.Combat:
                    currentStatusZoom = Vector2.Lerp(previousStatusZoom, new Vector2(combatZoom, combatZoom), frame / 45f);
                    break;
            }
        }

    }
}
