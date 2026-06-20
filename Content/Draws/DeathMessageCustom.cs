namespace customize.Content.Draws;

using System.Collections.Generic;
using customize.Content.Config;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;

/* Ok, so, there's a big problem with this class...
 * Since the layer "Vanilla: Death Text" is used for both the message and the timer,
 * that means it completely wipes out the timer when it's modified.

 * I don't think PostDrawInterface had the same behavior, since it didn't modify the entire layer, only the death text.
 * Essentially, I'll have to rewrite the timer logic or just find another way to not override it.
 */
public class DeathMessageCustom : ModSystem
{

    public string contentOpt = ModContent.GetInstance<CustomizeConfig>().deathText;
    public override void OnLocalizationsLoaded()
    {
        Lang.inter[38] = LocalizedText.Empty;
    }

    public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
    {
        if(!Main.LocalPlayer.dead) return;

        int deathTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Death Text"));
        if(deathTextIndex != -1)
        {
            layers.RemoveAt(deathTextIndex);
            
            layers.Insert(deathTextIndex, new LegacyGameInterfaceLayer("Vanilla: Death Text", 
                delegate
                {
                    DynamicSpriteFont font = FontAssets.DeathText.Value;
                    Vector2 pos = new(
                        Main.screenWidth / 2f - font.MeasureString(contentOpt).X / 2f,
                        Main.screenHeight / 2f - 60f
                    );

                    Main.spriteBatch.DrawString(font, contentOpt, pos, Main.LocalPlayer.GetDeathAlpha(Color.Transparent));
                    return true;
                }
            ));
        }
    }

}