using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader.Config;

namespace RandomGameplayEnhancement.Common.Configs
{
    public class Config : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Header("DynamicZoom")]

        [DefaultValue(true)]
        public bool allowDynamicZoom;

        [Range(1f, 2f)]
        [Increment(0.01f)]
        [DrawTicks]
        [DefaultValue(2f)]
        public float RestZoom;

        [Range(1f, 2f)]
        [Increment(0.01f)]
        [DrawTicks]
        [DefaultValue(1.65f)]
        public float IdleZoom;

        [Range(1f, 2f)]
        [Increment(0.01f)]
        [DrawTicks]
        [DefaultValue(1.35f)]
        public float OutCombatZoom;

        [Range(1f, 2f)]
        [Increment(0.01f)]
        [DrawTicks]
        [DefaultValue(1f)]
        public float InCombatZoom;

        [Header("EnemyFlashingOnHit")]

        [DefaultValue(true)]
        public bool allowEnemyFlashing;

        [Header("Screenshake")]

        [DefaultValue(true)]
        public bool allowScreenshakeOnHit;

        [Range(1f, 10f)]
        [Increment(0.5f)]
        [DrawTicks]
        [DefaultValue(3f)]
        public float ScreenshakeOnHitMagnitude;

        [Range(1f, 10f)]
        [Increment(0.5f)]
        [DrawTicks]
        [DefaultValue(5f)]
        public float ScreenshakeOnCritMagnitude;

        [DefaultValue(true)]
        public bool allowScreenshakeOnKill;

        [Range(1f, 20f)]
        [Increment(0.5f)]
        [DrawTicks]
        [DefaultValue(10f)]
        public float ScreenshakeOnKillMagnitude;

        [Header("EnemyQuote")]

        [DefaultValue(true)]
        public bool AllowEnemyQuote;
    }
}
