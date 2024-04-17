using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using BepInEx;
using BepInEx.Bootstrap;
using BrutalAPI;
using UnityEngine;
using UnityEngine.UIElements;
using MonoMod.RuntimeDetour;
using JetBrains.Annotations;
using System.Text;
using System.Threading;
using System.Runtime.CompilerServices;
using Tools;
using UnityEngine.SceneManagement;
using System.Timers;
using UnityEngine.Diagnostics;
using UnityEngine.UI;
using System.Xml;
using System.Dynamic;
using Hawthorne;

namespace Hawthorne
{
    public static class ResourceLoader
    {
        public static Texture2D LoadTexture(string name)
        {
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = assembly.GetManifestResourceNames().First(r => r.Contains(name));
                var resource = assembly.GetManifestResourceStream(resourceName);
                using var memoryStream = new MemoryStream();
                var buffer = new byte[16384];
                int count;
                while ((count = resource!.Read(buffer, 0, buffer.Length)) > 0)
                    memoryStream.Write(buffer, 0, count);
                var spriteTexture = new Texture2D(0, 0, TextureFormat.ARGB32, false)
                {
                    anisoLevel = 1,
                    filterMode = 0
                };

                spriteTexture.LoadImage(memoryStream.ToArray());
                return spriteTexture;
            }
            catch (Exception ex)
            {
                if (name != "PassivePlaceholder.png") return LoadTexture("PassivePlaceholder.png");
                else throw ex;
            }
        }

        public static Sprite LoadSprite(string name, int ppu = 32, Vector2? pivot = null)
        {
            if (pivot == null) { pivot = new Vector2(0.5f, 0.5f); }
            var assembly = Assembly.GetExecutingAssembly();

            Sprite sprite;

            try
            {
                var resourceName = assembly.GetManifestResourceNames().First(r => r.Contains(name));
                var resource = assembly.GetManifestResourceStream(resourceName);
                using var memoryStream = new MemoryStream();
                var buffer = new byte[16384];
                int count;
                while ((count = resource!.Read(buffer, 0, buffer.Length)) > 0)
                    memoryStream.Write(buffer, 0, count);
                var spriteTexture = new Texture2D(0, 0, TextureFormat.ARGB32, false)
                {
                    anisoLevel = 1,
                    filterMode = 0
                };

                spriteTexture.LoadImage(memoryStream.ToArray());
                sprite = Sprite.Create(spriteTexture, new Rect(0, 0, spriteTexture.width, spriteTexture.height), (Vector2)pivot, ppu);

            }
            catch (InvalidOperationException)
            {
                if (DoDebugs.SpriteNull) Debug.LogError("Sprite: " + name + " is null");
                if (DoDebugs.SpriteNull) Debug.LogWarning("Missing Texture! Check for typos when using ResourceLoader.LoadSprite() and that all of your textures have their build action as Embedded Resource.");
                sprite = LoadPassivePlaceholder("PassivePlaceholder.png", ppu, pivot);
            }

            return sprite;
        }
        public static MemoryStream LoadMemory(string name)
        {
            var assembly = Assembly.GetExecutingAssembly();

            try
            {
                var resourceName = assembly.GetManifestResourceNames().First(r => r.Contains(name));
                var resource = assembly.GetManifestResourceStream(resourceName);
                using var memoryStream = new MemoryStream();
                var buffer = new byte[16384];
                int count;
                while ((count = resource!.Read(buffer, 0, buffer.Length)) > 0)
                    memoryStream.Write(buffer, 0, count);

                return memoryStream;

            }
            catch (Exception ex)
            {
                if (DoDebugs.SpriteNull) Debug.LogError("Sprite: " + name + " is null");
                if (DoDebugs.SpriteNull) Debug.LogWarning("Missing Texture! Check for typos when using ResourceLoader.LoadSprite() and that all of your textures have their build action as Embedded Resource.");
                if (name != "PassivePlaceholder.png") return LoadMemory("PassivePlaceholder.png");
                else throw ex;
            }
        }

        public static Sprite LoadPassivePlaceholder(string name = "PassivePlaceholder.png", int ppu = 32, Vector2? pivot = null)
        {
            if (pivot == null) { pivot = new Vector2(0.5f, 0.5f); }
            var assembly = Assembly.GetExecutingAssembly();

            Sprite sprite;

            try
            {
                var resourceName = assembly.GetManifestResourceNames().First(r => r.Contains(name));
                var resource = assembly.GetManifestResourceStream(resourceName);
                using var memoryStream = new MemoryStream();
                var buffer = new byte[16384];
                int count;
                while ((count = resource!.Read(buffer, 0, buffer.Length)) > 0)
                    memoryStream.Write(buffer, 0, count);
                var spriteTexture = new Texture2D(0, 0, TextureFormat.ARGB32, false)
                {
                    anisoLevel = 1,
                    filterMode = 0
                };

                spriteTexture.LoadImage(memoryStream.ToArray());
                sprite = Sprite.Create(spriteTexture, new Rect(0, 0, spriteTexture.width, spriteTexture.height), (Vector2)pivot, ppu);

            }
            catch (InvalidOperationException)
            {
                if (DoDebugs.SpriteNull) Debug.LogError("Sprite: " + name + " is null");
                throw new Exception("Missing Texture! Check for typos when using ResourceLoader.LoadSprite() and that all of your textures have their build action as Embedded Resource.");
            }

            return sprite;
        }

        public static byte[] ResourceBinary(string name)
        {
            try
            {
                Assembly a = Assembly.GetExecutingAssembly();
                var resourceName = a.GetManifestResourceNames().First(r => r.Contains(name));
                if (DoDebugs.SpriteNull) Debug.Log(resourceName);
                using (Stream resFilestream = a.GetManifestResourceStream(resourceName))
                {
                    if (resFilestream == null) return null;
                    byte[] ba = new byte[resFilestream.Length];
                    resFilestream.Read(ba, 0, ba.Length);
                    if (DoDebugs.SpriteNull) Debug.Log(ba.Length);
                    return ba;
                }
            }
            catch (Exception ex)
            {
                Debug.LogError("THIS IS A RESOURCE LOADER ERROR FOR RESOURCE BINARY SPECIFICALLY. THE FILE THAT FAILED TO LOAD WAS " + name);
                Debug.LogError(ex.Message + ex.StackTrace);
                return new byte[0];
            }
        }

    } //Resource Loader!
}
namespace YourNamespace
{
    public static class ResourceLoader
    {
        public static Texture2D LoadTexture(string name)
        {
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = assembly.GetManifestResourceNames().First(r => r.Contains(name));
                var resource = assembly.GetManifestResourceStream(resourceName);
                using var memoryStream = new MemoryStream();
                var buffer = new byte[16384];
                int count;
                while ((count = resource!.Read(buffer, 0, buffer.Length)) > 0)
                    memoryStream.Write(buffer, 0, count);
                var spriteTexture = new Texture2D(0, 0, TextureFormat.ARGB32, false)
                {
                    anisoLevel = 1,
                    filterMode = 0
                };

                spriteTexture.LoadImage(memoryStream.ToArray());
                return spriteTexture;
            }
            catch (Exception ex)
            {
                Debug.LogError("THIS IS A RESOURCE LOADER ERROR");
                Debug.LogError("Texture: " + name + " is null");
                Debug.LogError(ex.ToString() + ex.Message + ex.StackTrace);
                throw new Exception("Missing Texture! Check for typos when using ResourceLoader.LoadTexture() and that all of your textures have their build action as Embedded Resource.");
            }
        }

        public static Sprite LoadSprite(string name, int ppu = 32, Vector2? pivot = null)
        {
            if (pivot == null) { pivot = new Vector2(0.5f, 0.5f); }
            var assembly = Assembly.GetExecutingAssembly();

            Sprite sprite;

            try
            {
                var resourceName = assembly.GetManifestResourceNames().First(r => r.Contains(name));
                var resource = assembly.GetManifestResourceStream(resourceName);
                using var memoryStream = new MemoryStream();
                var buffer = new byte[16384];
                int count;
                while ((count = resource!.Read(buffer, 0, buffer.Length)) > 0)
                    memoryStream.Write(buffer, 0, count);
                var spriteTexture = new Texture2D(0, 0, TextureFormat.ARGB32, false)
                {
                    anisoLevel = 1,
                    filterMode = 0
                };

                spriteTexture.LoadImage(memoryStream.ToArray());
                sprite = Sprite.Create(spriteTexture, new Rect(0, 0, spriteTexture.width, spriteTexture.height), (Vector2)pivot, ppu);

            }
            catch (Exception ex)
            {
                Debug.LogError("THIS IS A RESOURCE LOADER ERROR");
                Debug.LogError("Sprite: " + name + " is null");
                Debug.LogError(ex.ToString() + ex.Message + ex.StackTrace);
                throw new Exception("Missing Texture! Check for typos when using ResourceLoader.LoadSprite() and that all of your textures have their build action as Embedded Resource.");
            }

            return sprite;
        }

        public static byte[] ResourceBinary(string name)
        {
            try
            {
                Assembly a = Assembly.GetExecutingAssembly();
                var resourceName = a.GetManifestResourceNames().First(r => r.Contains(name));
                using (Stream resFilestream = a.GetManifestResourceStream(resourceName))
                {
                    if (resFilestream == null) return null;
                    byte[] ba = new byte[resFilestream.Length];
                    resFilestream.Read(ba, 0, ba.Length);
                    return ba;
                }
            }
            catch (Exception ex)
            {
                Debug.LogError("THIS IS A RESOURCE LOADER ERROR FOR RESOURCE BINARY SPECIFICALLY. THE FILE THAT FAILED TO LOAD WAS " + name);
                Debug.LogError(ex.ToString() + ex.Message + ex.StackTrace);
                throw new Exception("Missing Resource! Check for typos when using ResourceLoader.ResourceBinary() and that all of your resources have their build action as Embedded Resource.");
            }
        }

    } //Resource Loader!
}
