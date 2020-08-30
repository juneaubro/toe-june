using BepInEx;
using BepInEx.Configuration;
using System;
using UnityEngine;

namespace PepegaYes
{
    [BepInPlugin("org.bepinex.plugins.pepegayes", "PepegaYes", "1.0.0")]
    public class PepegaYes : BaseUnityPlugin
    {
        private ConfigEntry<string> configGreeting;
        private ConfigEntry<bool> configDisplayGreeting;

        void Awake()
        {
            configGreeting = Config.Bind("General", "GreetingText", "get ready for your acrid to level up", "A greeting text to show when the game is launched");
            configDisplayGreeting = Config.Bind("General.Toggles", "DisplayGreeting", true, "Greeting text to show when the game launches");

            if (configDisplayGreeting.Value)
                Logger.LogInfo(configGreeting.Value);


        }
    }
}
