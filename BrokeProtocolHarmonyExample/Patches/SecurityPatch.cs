using BrokeProtocol;
using BrokeProtocol.Managers;
using BrokeProtocol.Utility;
using HarmonyLib;
using System.Linq;
using UnityEngine;

namespace BrokeProtocolHarmonyExample.Patches
{
    [HarmonyPatch(typeof(SecurityTrigger))]
    [HarmonyPatch(nameof(SecurityTrigger.OnTriggerEnter))]
    public static class OnTriggerEnterSecurityPatch
    {
        public static int[] NoSecurity { get; private set; } = new int[] { 10, 15 };

        public static bool Prefix(SecurityTrigger __instance, Collider other)
        {
            if (!__instance.entity)
            {
                return true; // Return true to run vanilla function

            }
            ApartmentPlace apartmentPlace = __instance.entity.GetPlace as ApartmentPlace;
            if (apartmentPlace != null && !ShManager.IgnoreCollision(other))
            {
                var shApartment = apartmentPlace.GetEntranceApartment.svDoor.other.GetPlace;
                if (NoSecurity.Contains(shApartment.GetIndex))
                {
                    return false;   // Return false to stop execution.
                }
            }
            return true;
        }
    }
}
