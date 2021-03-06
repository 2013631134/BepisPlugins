﻿using CharaCustom;
using CoordinateFileSystem;
using HarmonyLib;

namespace ExtensibleSaveFormat
{
    public partial class ExtendedSave
    {
        internal static partial class Hooks
        {
            //Override ExtSave for list loading at game startup
            [HarmonyPrefix]
            [HarmonyPatch(typeof(Config.ConfigCharaSelectUI), "CreateList")]
            [HarmonyPatch(typeof(CustomCharaFileInfoAssist), nameof(CustomCharaFileInfoAssist.CreateCharaFileInfoList))]
            [HarmonyPatch(typeof(CustomClothesFileInfoAssist), nameof(CustomClothesFileInfoAssist.CreateClothesFileInfoList))]
            [HarmonyPatch(typeof(CoordinateFileInfoAssist), nameof(CoordinateFileInfoAssist.CreateCharaFileInfoList))]
            internal static void CreateListPrefix() => LoadEventsEnabled = false;
            [HarmonyPostfix]
            [HarmonyPatch(typeof(Config.ConfigCharaSelectUI), "CreateList")]
            [HarmonyPatch(typeof(CustomCharaFileInfoAssist), nameof(CustomCharaFileInfoAssist.CreateCharaFileInfoList))]
            [HarmonyPatch(typeof(CustomClothesFileInfoAssist), nameof(CustomClothesFileInfoAssist.CreateClothesFileInfoList))]
            [HarmonyPatch(typeof(CoordinateFileInfoAssist), nameof(CoordinateFileInfoAssist.CreateCharaFileInfoList))]
            internal static void CreateListPostfix() => LoadEventsEnabled = true;
        }
    }
}