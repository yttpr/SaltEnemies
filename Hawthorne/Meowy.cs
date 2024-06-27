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
            YellowAngelTheme.Add(2467453);//waiting on maddie
            EvilEyeSong.Add(2467454);
            GraveSong.Add(2467455);
            EvilDogTheme.Add(2467456);//waiting on millie
            UFOSong.Add(2467457);
            SinkerSong.Add(2467458);
            //event:/Hawthorne/Noisy/PA_Roar
            //event:/Hawthorne/PersonalAngelSong
            //event:/Hawthorne/Noisy/Bone_Roar
            //event:/Hawthorne/ShooterSong
            //event:/Hawthorne/ComplimentaryTheme
            //event:/Hawthorne/EvilDogTheme

            //event:/Blackwater/InventionSong
            //event:/Blackwater/BlackAndBlueSong
            //event:/Blackwater/BlueSkySong
        }
    }
    
}
