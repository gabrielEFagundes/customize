using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace customize
{
	// https://github.com/tModLoader/tModLoader/wiki/Basic-tModLoader-Modding-Guide#mod-skeleton-contents
	public class Customize : Mod
	{
		internal static ModKeybind KillKeyBind { get; private set; }

		public override void Load()
		{
			KillKeyBind = KeybindLoader.RegisterKeybind(this, "[TEST] kill player", "]");
		}
	}
}
