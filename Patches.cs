using HarmonyLib;
using Il2CppInterop.Runtime;
using System;
using BepInEx.Logging;
using CameraDistance;


[HarmonyPatch(typeof(CameraScriptField))]
[HarmonyPatch("Reset")]
class Patches
{
    static IntPtr newValue = (IntPtr)0;
        
    [HarmonyPostfix]
    static void Postfix(CameraScriptField __instance)
    {
        __instance.distanceScaleMax = 5;
    }
}
