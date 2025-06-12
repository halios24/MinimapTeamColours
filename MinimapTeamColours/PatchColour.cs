using System.Reflection;
using UnityEngine;

namespace MinimapTeamColours;

public class PatchColour
{
    // Existing fields for team colors
    private static UnityEngine.Color BlueTeamNewColor = new UnityEngine.Color(Plugin.modSettings.blueteamRedValue,
        Plugin.modSettings.blueteamGreenValue, Plugin.modSettings.blueteamBlueValue);

    private static UnityEngine.Color RedTeamNewColor = new UnityEngine.Color(Plugin.modSettings.redteamRedValue,
        Plugin.modSettings.redteamGreenValue, Plugin.modSettings.redteamBlueValue);

    static readonly FieldInfo _teamBlueColorField =
        typeof(UIMinimap).GetField("teamBlueColor", BindingFlags.Instance | BindingFlags.NonPublic);

    static readonly FieldInfo _teamRedColorField =
        typeof(UIMinimap).GetField("teamRedColor", BindingFlags.Instance | BindingFlags.NonPublic);

    public static void PatchMinimapTeamColours()
    {
        UIMinimap minimap = NetworkBehaviourSingleton<UIMinimap>.Instance;

        _teamBlueColorField.SetValue(minimap, BlueTeamNewColor);
        _teamRedColorField.SetValue(minimap, RedTeamNewColor);
        Plugin.Log("MinimapTeamColours patched");
    }

    public static void resetMinimapTeamColours()
    {
        UIMinimap minimap = NetworkBehaviourSingleton<UIMinimap>.Instance;

        _teamBlueColorField.SetValue(minimap, Color.blue);
        _teamRedColorField.SetValue(minimap, Color.red);
        Plugin.Log("MinimapTeamColours reset");
    }
}