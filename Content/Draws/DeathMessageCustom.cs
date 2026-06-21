namespace customize.Content.Draws;

using System.Collections.Generic;
using customize.Content.Config;
using customize.Content.Monitors;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;

// I had to redraw the entire Vanilla layer for Death Text, one day I'll find a more performatic way to do the same
// it allows some cooler customization though.
public class DeathMessageCustom : ModSystem
{

    string deathStr;
    string coinsLostStr;
    string countdownStr;

    public override void OnLocalizationsLoaded()
    {
        Lang.inter[38] = LocalizedText.Empty;
    }

    public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
    {
        int deathTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Death Text"));
        if(deathTextIndex != -1)
        {
            layers.RemoveAt(deathTextIndex);
            
            layers.Insert(deathTextIndex, new LegacyGameInterfaceLayer("Customize: Death Text", 
                delegate
                {
                    if(!Main.LocalPlayer.dead) return true;

                    deathStr = Main.LocalPlayer.GetModPlayer<MonitorPlayerDeath>().deathStringOption ?? "You were slain... (Couldn't change the death msg)";
                    coinsLostStr = "dropped " + Main.LocalPlayer.lostCoinString; // concat it with something or it just shows the coins lost

                    int secondsLeft = Main.LocalPlayer.respawnTimer / 60;

                    // keeps it synced with the little beeps
                    if(Main.LocalPlayer.respawnTimer % 60 != 0) secondsLeft++;
                    countdownStr = secondsLeft.ToString();
                    
                    DynamicSpriteFont font = FontAssets.DeathText.Value;
                    Vector2 textPos = new(
                        Main.screenWidth / 2f - font.MeasureString(deathStr).X / 2f,
                        Main.screenHeight / 2f - 60f
                    );

                    Vector2 coinsLostPos = new(
                        Main.screenWidth / 2f - font.MeasureString(coinsLostStr).X * 0.40f / 2f,
                        textPos.Y + 60f
                    );

                    Vector2 countdownPos = new(
                        Main.screenWidth / 2f - font.MeasureString(countdownStr).X / 2f,
                        coinsLostPos.Y + 60f
                    );

                    var noColor = Main.LocalPlayer.GetDeathAlpha(Color.Transparent);

                    Main.spriteBatch.DrawString(font, deathStr, textPos, noColor);
                    Main.spriteBatch.DrawString(font, coinsLostStr, coinsLostPos, noColor, 0f, Vector2.Zero, 0.40f, SpriteEffects.None, 0f);
                    Main.spriteBatch.DrawString(font, countdownStr, countdownPos, noColor, 0f, Vector2.Zero, 0.75f, SpriteEffects.None, 0f);

                    return true;
                },
                InterfaceScaleType.UI
            ));
        }
    }

}