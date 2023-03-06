using BepInEx;
using BepInEx.Configuration;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace CameraDistance;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BasePlugin
{
    static public ConfigEntry<float> c_wallHitRadius;
    static public ConfigEntry<float> c_CameraRotSpeed;
    static public ConfigEntry<float> c_smashTime;
    static public ConfigEntry<float> c_mouseSmashTime;
    static public ConfigEntry<float> c_smashTimeCounter;
    static public ConfigEntry<float> c_minVerticalAngle;
    static public ConfigEntry<float> c_maxVerticalAngle;
    static public ConfigEntry<float> c_distanceScaleMax;
    static public ConfigEntry<float> c_distanceScaleMin;

    private ConfigEntry<string> configGreeting;
    private ConfigEntry<bool> configDisplayGreeting;

    public Plugin()
    {
        c_CameraRotSpeed = Config.Bind("CameraFieldScript", "cameraRotSpeed", (float)120, "Speed the camera rotates");
        c_minVerticalAngle = Config.Bind("CameraFieldScript", "minVerticalAngle", (float)0, "Min camera height angle");
        c_maxVerticalAngle = Config.Bind("CameraFieldScript", "maxVerticalAngle", (float)60, "Max camera height angle");
        c_distanceScaleMax = Config.Bind("CameraFieldScript", "distanceScaleMax", (float)5, "The farthest the camera can get to the character");
        c_distanceScaleMin = Config.Bind("CameraFieldScript", "distanceScaleMin", (float)1, "The closest the camera can get to the character");
    }

    public override void Load()
    {
        // Plugin startup logic
        Log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        Harmony.CreateAndPatchAll(typeof(Patches));
    }
}
