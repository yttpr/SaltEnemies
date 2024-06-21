using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace Hawthorne
{
    public static class Meowy
    {
        public static void PCall(Action call)
        {
            try { call(); }
            catch (Exception ex)
            {
                try
                {
                    Debug.LogError(call.GetMethodInfo().Name + " FUCKING FAILED TO GET ADDED");
                }
                catch
                {
                    Debug.LogError("some fucking function failed to get added");
                }

                Debug.LogError(ex.ToString() + ex.Message + ex.StackTrace);
            }
        }
        public static void PCall(Action<int> call, int var)
        {
            try { call(var); }
            catch (Exception ex)
            {
                try
                {
                    Debug.LogError(call.GetMethodInfo().Name + " FUCKING FAILED TO GET ADDED");
                }
                catch
                {
                    Debug.LogError("some fucking function failed to get added");
                }

                Debug.LogError(ex.ToString() + ex.Message + ex.StackTrace);
            }
        }
        public static void AddEnemies()
        {
            PCall(YellowAngel.Add, 544451);
            PCall(EvilDog.Add, 544450);
            PCall(Eyeball.Add, 544449);
            PCall(Grave.Add, 544448);
            PCall(Defender.Add, 544447);
            PCall(UFO.Add, 544446);
        }
    }
}
