using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace customize.Content.UI;

/// <summary>
/// I won't use this yet, for now, customize will have its options on the default
/// configuration ui. 
/// 
/// I plan adding a UI in the future, but it's kind of complicated to
/// mess with this, so yeah, not now.
/// </summary>
public class UiSystem : ModSystem
{
    public class CustomizeUi : UIState {}

    internal UserInterface userInterface;
    internal CustomizeUi customizeUi;

    private GameTime _lastUiUpdate;

    public override void Load()
    {
        if(!Main.dedServ)
        {
            userInterface = new UserInterface();

            customizeUi = new CustomizeUi();
            customizeUi.Activate();
        }
    }

    public override void UpdateUI(GameTime gameTime)
    {
        _lastUiUpdate = gameTime;
        if(userInterface?.CurrentState != null)
        {
            userInterface.Update(gameTime);
        }
    }

    public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
    {
        int mouseIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
        if(mouseIndex != -1)
        {
            layers.Insert(mouseIndex, new LegacyGameInterfaceLayer(
                "Customize : userInterface",
                delegate{
                    if(_lastUiUpdate != null && userInterface?.CurrentState != null)
                        userInterface.Draw(Main.spriteBatch, _lastUiUpdate);

                    return true;
                },
                InterfaceScaleType.UI
            ));
        }
    }

    public override void Unload()
    {
        // I'll probably use this later
    }
}