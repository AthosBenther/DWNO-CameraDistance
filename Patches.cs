using HarmonyLib;


[HarmonyPatch(typeof(CameraScriptField))]
[HarmonyPatch("Reset")]
class Patches
{
    [HarmonyPostfix]
    static void Postfix(CameraScriptField __instance)
    {
        __instance.distanceScaleMax = 5;
    }
}
