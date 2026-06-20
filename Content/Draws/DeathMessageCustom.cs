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

public class DeathMessageCustom : ModSystem
{

    public string contentOpt = ModContent.GetInstance<CustomizeConfig>().deathText;
    public override void OnLocalizationsLoaded()
    {
        Lang.inter[38] = LocalizedText.Empty;
    }

    public override void PostDrawInterface(SpriteBatch spriteBatch)
    {
        if(!Main.LocalPlayer.dead) return;

        DynamicSpriteFont font = FontAssets.DeathText.Value;
        Vector2 pos = new Vector2(
            Main.screenWidth / 2f - font.MeasureString(contentOpt).X / 2f,
            Main.screenHeight / 2f - 60f
        );

        spriteBatch.DrawString(font, contentOpt, pos, Main.LocalPlayer.GetDeathAlpha(Color.Transparent));
    }

}