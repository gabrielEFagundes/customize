namespace customize.Content.Draws;

using Terraria;
using Terraria.ModLoader;
using MonoMod.Cil;
using Mono.Cecil.Cil;

public class DeathMessageCustom : ModSystem
{
    public override void Load()
    {
        IL_Main.DrawInterface += PatchDeathText;
    }

    public override void Unload()
    {
        IL_Main.DrawInterface -= PatchDeathText;
    }

    private void PatchDeathText(ILContext il)
    {
        var cursor = new ILCursor(il);

        if(cursor.TryGotoNext(i => i.MatchLdstr("You were slain...")))
        {
            cursor.Remove();
            cursor.Emit(OpCodes.Ldstr, "Don't ragequit."); // lame
        }
    }

}