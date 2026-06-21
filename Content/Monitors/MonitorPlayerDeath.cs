using customize.Content.Config;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace customize.Content.Monitors;

public class MonitorPlayerDeath : ModPlayer
{

    public string deathStringOption;

    public override void UpdateDead()
    {
        var config = ModContent.GetInstance<CustomizeConfig>();
        if(config != null)
        {
            deathStringOption = config.deathText;
        }
    }
}