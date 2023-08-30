using System;
using System.IO;
using UnityEngine;

namespace BetterScreenMessages
{
	[KSPAddon(KSPAddon.Startup.SpaceCentre, true)]
	public class BetterScreenMessages : MonoBehaviour
    {
		void Awake()
		{
			try
			{
				var settingsfile = $"{KSPUtil.ApplicationRootPath}GameData/BetterScreenMessages/PluginData/settings.cfg";
				if (File.Exists(settingsfile))
				{
					var settings = ConfigNode.Load(settingsfile).GetNode("BetterScreenMessagesConfig");

					ScreenMessages.Instance.textPrefab.text.fontSize = float.Parse(settings.GetValue("font_size"));

					var upper_left = settings.GetNode("UPPER_LEFT");
					ScreenMessages.Instance.upperLeft.transform.localPosition = new Vector3(float.Parse(upper_left.GetValue("pos_x")), float.Parse(upper_left.GetValue("pos_y")), ScreenMessages.Instance.upperLeft.transform.localPosition.z);
					var upper_right = settings.GetNode("UPPER_RIGHT");
					ScreenMessages.Instance.upperRight.transform.localPosition = new Vector3(float.Parse(upper_right.GetValue("pos_x")), float.Parse(upper_right.GetValue("pos_y")), ScreenMessages.Instance.upperRight.transform.localPosition.z);
					var upper_center = settings.GetNode("UPPER_CENTER");
					ScreenMessages.Instance.upperCenter.transform.localPosition = new Vector3(float.Parse(upper_center.GetValue("pos_x")), float.Parse(upper_center.GetValue("pos_y")), ScreenMessages.Instance.upperCenter.transform.localPosition.z);
					var lower_center = settings.GetNode("LOWER_CENTER");
					ScreenMessages.Instance.lowerCenter.transform.localPosition = new Vector3(float.Parse(lower_center.GetValue("pos_x")), float.Parse(lower_center.GetValue("pos_y")), ScreenMessages.Instance.lowerCenter.transform.localPosition.z);
					var kerbal_eva = settings.GetNode("KERBAL_EVA");
					ScreenMessages.Instance.kerbalEva.transform.localPosition = new Vector3(float.Parse(kerbal_eva.GetValue("pos_x")), float.Parse(kerbal_eva.GetValue("pos_y")), ScreenMessages.Instance.kerbalEva.transform.localPosition.z);
				}
			}
			catch(Exception e){
				Debug.Log("[BetterScreenMessages] There was a problem loading the settings file.");
				Debug.LogException(e);
			}
		}
	}

#if DEBUG
	[KSPAddon(KSPAddon.Startup.SpaceCentre, false)]
	public class BMS : MonoBehaviour
	{
		void Update()
		{
			if (Input.GetKeyUp(KeyCode.Space))
			{
				ScreenMessages.PostScreenMessage("upper left", 1, ScreenMessageStyle.UPPER_LEFT, Color.green);
				ScreenMessages.PostScreenMessage("upper right", 1, ScreenMessageStyle.UPPER_RIGHT, Color.green);
				ScreenMessages.PostScreenMessage("upper center", 1, ScreenMessageStyle.UPPER_CENTER, Color.green);
				ScreenMessages.PostScreenMessage("lower center", 1, ScreenMessageStyle.LOWER_CENTER, Color.green);
				ScreenMessages.PostScreenMessage("kerbal eva", 1, ScreenMessageStyle.KERBAL_EVA, Color.green);
			}
		}
	}
#endif
}
