using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.GameData;

namespace OmniFarmMigrate
{
    /// <summary>The mod entry point.</summary>
    internal sealed class ModEntry : Mod
    {
        /*********
        ** Public methods
        *********/
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            bool isLoaded = helper.ModRegistry.IsLoaded("glimmerDev.OmnifarmEx");
            if (!isLoaded)
            {
                Monitor.Log("Please install OmniFarmEx before using this mod!!", LogLevel.Error);
                return;
            }
            helper.Events.GameLoop.SaveLoaded += OnSaveLoaded;
        }


        /*********
        ** Private methods
        *********/
        private void OnSaveLoaded(object? sender, SaveLoadedEventArgs e)
        {
            List<ModFarmType> farmTypes = this.Helper.GameContent.Load<List<ModFarmType>>(@"Data/AdditionalFarms");
            for (int i = 0; i < farmTypes.Count; i++)
            {
                if (farmTypes[i].Id == "GlimmerDev.OmniFarmEx/OmniFarm")
                {
                    Monitor.Log("Found OmniFarmEx farm type.");
                    Game1.whichModFarm = farmTypes[i];
                    Helper.Reflection.
                    break;
                }
            }
        }
    }
}