using CameraDistance;
using HarmonyLib;[HarmonyPatch(typeof(CameraScriptField))][HarmonyPatch("Reset")]class Patches{    [HarmonyPostfix]    static void Postfix(CameraScriptField __instance)    {        __instance.wallHitRadius = Plugin.c_wallHitRadius.Value;        __instance.m_CameraRotSpeed = Plugin.c_CameraRotSpeed.Value;        __instance.minVerticalAngle = Plugin.c_minVerticalAngle.Value;        __instance.maxVerticalAngle = Plugin.c_maxVerticalAngle.Value;        __instance.distanceScaleMax = Plugin.c_distanceScaleMax.Value;        __instance.distanceScaleMin = Plugin.c_distanceScaleMin.Value;
    }}