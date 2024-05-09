using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using UnityEngine;

namespace Hawthorne
{
    public static class NPCModHook
    {
        public static void Setup()
        {
            IDetour hook = new Hook(typeof(Cat_sCradle.SavePerRun).GetMethod(nameof(Cat_sCradle.SavePerRun.Check), ~BindingFlags.Default), typeof(NPCModHook).GetMethod(nameof(Set), ~BindingFlags.Default));
        }
        public static void Set(Action<string, bool> orig, string name, bool value)
        {
            orig(name, value);
            if (name == "Help" && value == true) Do();
            else Debug.Log("not this one");
        }
        public static void Do()
        {
            Debug.Log("this one");
        }
    }
}
