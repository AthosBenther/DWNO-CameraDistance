using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using HarmonyLib.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace CameraDistance;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BasePlugin
{
    public static ManualLogSource Logger;

    static public ConfigEntry<float> c_wallHitRadius;
    static public ConfigEntry<float> c_cameraRotSpeed;
    static public ConfigEntry<float> c_smashTime;
    static public ConfigEntry<float> c_mouseSmashTime;
    static public ConfigEntry<float> c_smashTimeCounter;
    static public ConfigEntry<float> c_minVerticalAngle;
    static public ConfigEntry<float> c_maxVerticalAngle;
    static public ConfigEntry<float> c_distanceScaleMax;
    static public ConfigEntry<float> c_distanceScaleMin;
    static public ConfigEntry<float> c_offsetX;
    static public ConfigEntry<float> c_offsetY;
    static public ConfigEntry<float> c_offsetZ;
    static private ConfigEntry<float> _c_defaultDistanceScale;

    private ConfigEntry<string> configGreeting;
    private ConfigEntry<bool> configDisplayGreeting;

    static public ConfigEntry<float> c_defaultDistanceScale
    {
        get { return _c_defaultDistanceScale; }
        set
        {
            float input = value.Value;
            if (input < c_distanceScaleMin.Value)
            {
                Logger.LogError("The configuration defaultDistance must be greater than distanceScaleMin");
                return;
            }
            else if (input > c_distanceScaleMax.Value)
            {
                Logger.LogError("The configuration defaultDistance must be smaller than distanceScaleMax");
                return;
            }
            else
            {
                _c_defaultDistanceScale = value;
            }
        }
    }



    public Plugin()
    {
        Logger = Log;
        HarmonyFileLog.Enabled = true;

        c_cameraRotSpeed = Config.Bind("CameraFieldScript", "cameraRotSpeed", 120f, "Speed the camera rotates");
        c_minVerticalAngle = Config.Bind("CameraFieldScript", "minVerticalAngle", 0f, "Min camera height angle");
        c_maxVerticalAngle = Config.Bind("CameraFieldScript", "maxVerticalAngle", 60f, "Max camera height angle");
        c_distanceScaleMax = Config.Bind("CameraFieldScript", "distanceScaleMax", 5f, "The farthest the camera can get to the character");
        c_distanceScaleMin = Config.Bind("CameraFieldScript", "distanceScaleMin", 1f, "The closest the camera can get to the character");
        c_offsetX = Config.Bind("CameraFieldScript", "offsetX", 0.75f, "The X target point displacement of the camera, in relation to the character");
        c_offsetY = Config.Bind("CameraFieldScript", "offsetY", 1.25f, "The Y target point displacement of the camera, in relation to the character");
        c_offsetZ = Config.Bind("CameraFieldScript", "offsetZ", 0.5f, "The Z target point displacement of the camera, in relation to the character");
        c_defaultDistanceScale = Config.Bind("CameraFieldScript", "defaultDistanceScale", 5f, "The default distance the camera will be every time it is loaded");
    }

    public override void Load()
    {
        // Plugin startup logic
        Log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        Harmony.CreateAndPatchAll(typeof(Patches));
    }
}
