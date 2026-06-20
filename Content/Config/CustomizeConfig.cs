using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace customize.Content.Config;

public class CustomizeConfig : ModConfig
{
    public override ConfigScope Mode => ConfigScope.ClientSide;

    [DefaultValue("You were slain...")] 
    public string deathText;
}