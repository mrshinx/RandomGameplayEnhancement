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
using RandomGameplayEnhancement.Common.Configs;

namespace RandomGameplayEnhancement.Common.Players
{
    public class Screenshake : ModPlayer
    {

        public override void OnHitAnything(float x, float y, Entity victim)
        {
            if (ModContent.GetInstance<Config>().allowScreenshakeOnHit)
            {
                float magnitude = ModContent.GetInstance<Config>().ScreenshakeOnHitMagnitude;
                PunchCameraModifier modifier = new PunchCameraModifier(Player.position, (Main.rand.NextFloat() * ((float)Math.PI * 2f)).ToRotationVector2(), magnitude, 6f, 6, 1000f, FullName);
                Main.instance.CameraModifiers.Add(modifier);
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (target.life<=0 && ModContent.GetInstance<Config>().allowScreenshakeOnKill)
            {
                float magnitude = ModContent.GetInstance<Config>().ScreenshakeOnKillMagnitude;
                PunchCameraModifier modifier = new PunchCameraModifier(Player.position, (Main.rand.NextFloat() * ((float)Math.PI * 2f)).ToRotationVector2(), magnitude, 9f, 20, 1000f, FullName);
                Main.instance.CameraModifiers.Add(modifier);
            }
            if (hit.Crit && ModContent.GetInstance<Config>().allowScreenshakeOnHit)
            {
                float magnitude = ModContent.GetInstance<Config>().ScreenshakeOnCritMagnitude;
                PunchCameraModifier modifier = new PunchCameraModifier(Player.position, (Main.rand.NextFloat() * ((float)Math.PI * 2f)).ToRotationVector2(), magnitude, 6f, 12, 1000f, FullName);
                Main.instance.CameraModifiers.Add(modifier);
            }
        }

    }
}
