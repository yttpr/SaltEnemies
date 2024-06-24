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
            PCall(YellowAngel.Add, 544451);//custom sounds
            PCall(EvilDog.Add, 544450);
            PCall(Eyeball.Add, 544449);//custom sounds
            PCall(Grave.Add, 544448);
            PCall(Defender.Add, 544447);
            PCall(UFO.Add, 544446);//custom sounds
            PCall(Personal.Add, 544445);//custom sounds
            PCall(Sinker.Add, 544444);
            PCall(Complimentary.Add, 544443);
            PCall(Shooter.Add, 544442);//custom sounds
            PCall(Head.Add, 544441);//custom sounds
        }
        public static void AddEncounters()
        {
            //event:/Hawthorne/Noisy/YA_Roar
            //event:/Hawthorne/EvilEyeTheme
            //event:/Hawthorne/Noisy/Eye_Roar
            //event:/Hawthorne/GraveTheme
            //event:/Hawthorne/UFOTheme
            //event:/Hawthorne/Noisy/PA_Roar
            //event:/Hawthorne/SinkerTheme
            //event:/Hawthorne/Noisy/Bone_Roar
        }
    }
}
