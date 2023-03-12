using CameraDistance;
using HarmonyLib;
using UnityEngine;

[HarmonyPatch(typeof(CameraScriptField))]
[HarmonyPatch("Reset")]
class Patches
{
    [HarmonyPostfix]
    static void Postfix(CameraScriptField __instance)
    {
        __instance.m_CameraRotSpeed = Plugin.c_cameraRotSpeed.Value;
        __instance.minVerticalAngle = Plugin.c_minVerticalAngle.Value;
        __instance.maxVerticalAngle = Plugin.c_maxVerticalAngle.Value;
        __instance.distanceScaleMax = Plugin.c_distanceScaleMax.Value;
        __instance.distanceScaleMin = Plugin.c_distanceScaleMin.Value;
        __instance.offset           = new Vector3(Plugin.c_offsetX.Value, Plugin.c_offsetY.Value, Plugin.c_offsetZ.Value);
        __instance.distance         = Plugin.c_defaultDistance.Value;
    }
}
