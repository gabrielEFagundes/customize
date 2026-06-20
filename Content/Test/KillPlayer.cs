using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ModLoader;

namespace customize.Content.Test;

class KillPlayer : ModPlayer
{
    public override void ProcessTriggers(TriggersSet triggersSet)
    {
        if (Customize.KillKeyBind.JustPressed)
        {
            Player.KillMe(PlayerDeathReason.LegacyEmpty(), 10000000f, 1);
        }
    }
}