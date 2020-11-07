using System;
using BepInEx;
using RoR2;
using RoR2.Projectile;
using UnityEngine;

namespace ToeKneeRED
{
    [BepInDependency("com.bepis.r2api")]
    [BepInPlugin("com.toekneered.ExamplePlugin", "Example Plugin by ToeKneeRED", "1.0.0")]

    public class ExamplePlugin : BaseUnityPlugin
    {

        public void Awake()
        {
            Logger.LogInfo("lol this shit loaded what a miracle");

            //On.EntityStates.Croco.FireSpit.FixedUpdate += (orig, self) =>
            //{
            //    Ray aimRay = base.GetAimRay();
            //    if (base.isAuthority)
            //    {
            //        DamageType value = this.crocoDamageTypeController ? this.crocoDamageTypeController.GetDamageType() : DamageType.Generic;
            //        FireProjectileInfo fireProjectileInfo = default(FireProjectileInfo);
            //        fireProjectileInfo.projectilePrefab = this.projectilePrefab;
            //        fireProjectileInfo.position = aimRay.origin;
            //        fireProjectileInfo.rotation = Util.QuaternionSafeLookRotation(aimRay.direction);
            //        fireProjectileInfo.owner = base.gameObject;
            //        fireProjectileInfo.damage = this.damageStat * this.damageCoefficient;
            //        fireProjectileInfo.damageTypeOverride = new DamageType?(value);
            //        fireProjectileInfo.force = this.force;
            //        fireProjectileInfo.crit = Util.CheckRoll(this.critStat, base.characterBody.master);
            //        ProjectileManager.instance.FireProjectile(fireProjectileInfo);
            //    }

            //    orig(self);
            //};
        }
    }
}
