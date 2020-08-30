using System;
using BepInEx;
using RoR2;
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

            On.EntityStates.Huntress.ArrowRain.OnEnter += (orig, self) =>
            {
                Chat.AddMessage("this shit actually works hoyl");

                orig(self);
            };
        }
    }
}
