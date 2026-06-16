namespace customize.Content.Draws;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.Localization;
using Terraria.ModLoader;

public class DeathMessageCustom : ModSystem
{
    // BRO I'M LOWKEY SO HAPPY I FIGURED THIS SHIT OUT
    public override void OnLocalizationsLoaded()
    {
        Lang.inter[38] = LocalizedText.Empty;
    }

    public override void PostDrawInterface(SpriteBatch spriteBatch)
    {
        if(!Main.LocalPlayer.dead) return;

        string text = "Don't ragequit.";
        DynamicSpriteFont font = FontAssets.DeathText.Value;
        Vector2 pos = new Vector2(
            Main.screenWidth / 2f - font.MeasureString(text).X / 2f,
            Main.screenHeight / 2f - 60f
        );

        spriteBatch.DrawString(font, text, pos, Main.LocalPlayer.GetDeathAlpha(Color.Transparent));
    }

}