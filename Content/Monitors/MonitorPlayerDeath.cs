using customize.Content.Config;
using Terraria.ModLoader;

namespace customize.Content.Monitors;

public class MonitorPlayerDeath : ModPlayer
{

    public string contentOpt;
    
    public override void UpdateDead()
    {
        var config = ModContent.GetInstance<CustomizeConfig>();
        if(config != null)
        {
            contentOpt = config.deathText;
        }
    }
}