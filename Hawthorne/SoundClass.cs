using System;
using System.IO;
using UnityEngine;

namespace Hawthorne
{
    public static class SoundClass
    {
        public static void CreateSoundBankFile(string resourceName, bool onlyIfNotExist = false)
        {
            CreateResourceFile(resourceName, Application.dataPath + "/StreamingAssets", resourceName + ".bank", onlyIfNotExist);
            //call this like, CreateSoundBankFile("FunnyGuyHitNoise");
        }

        public static void CreateResourceFile(string resourceName, string path, string outputName, bool onlyIfNotExist = false)
        {
            byte[] resource = new byte[0] { };
            try
            {
                resource = ResourceLoader.ResourceBinary(resourceName);
            }
            catch (Exception ex)
            {
                Debug.Log("YOUR FILE DOES NOT EXIST MOTHERFUCKER");
            }
            if (resource.Length > 0 && !(onlyIfNotExist && File.Exists(path + "/" + outputName)))
            {
                File.WriteAllBytes(path + "/" + outputName, resource);
            }
        }

        public static void Setup()
        {
            CreateSoundBankFile("HawthorneBank");
            CreateSoundBankFile("HawthorneBank.strings");
            CreateSoundBankFile("Friendship");
            CreateSoundBankFile("Friendship.strings");

            FMODUnity.RuntimeManager.LoadBank("HawthorneBank", true);
            FMODUnity.RuntimeManager.LoadBank("HawthorneBank.strings", true);
            FMODUnity.RuntimeManager.LoadBank("Friendship", true);
            FMODUnity.RuntimeManager.LoadBank("Friendship.strings", true);

        }
    }
    public static class AssetsFiling
    {
        public static void CreateAssetFile(string resourceName, bool onlyIfNotExist = false)
        {
            CreateResourceFile(resourceName, Application.dataPath + "/StreamingAssets", resourceName, onlyIfNotExist);
            //call this like, CreateSoundBankFile("FunnyGuyHitNoise");
        }

        public static void CreateResourceFile(string resourceName, string path, string outputName, bool onlyIfNotExist = false)
        {
            byte[] resource = new byte[0] { };
            try
            {
                resource = ResourceLoader.ResourceBinary(resourceName);
            }
            catch (Exception ex)
            {
                Debug.Log("YOUR FILE DOES NOT EXIST MOTHERFUCKER");
            }
            if (resource.Length > 0 && !(onlyIfNotExist && File.Exists(path + "/" + outputName)))
            {
                File.WriteAllBytes(path + "/" + outputName, resource);
            }
        }

        public static void Setup()
        {
            CreateAssetFile("group4");
        }
    }
    internal class Plan
    {
        public Plan()
        {
            //CNS: too support (not dangerous) 000000000000000000000000
            //dead god: still waiting
            //enigma: has theme. 
            //dead pixel: has theme
            //little angel: too support (not dangerous) 000000000000000000000000
            //satyr: choir boy
            //unmung: mung theme
            //crow: minister
            //something: has theme (by millie)
            //freud: skinner
            //fakeflower: scrungie
            //stars: they use the jumbler theme??
            //rustic: jumbler
            //gopel: spoggjon
            //camera: has theme
            //the deep: ember made
            //postmodern + war: has theme
            //fake angel: too support (not dangerous) (literally not dangerous) 000000000000000000000000
            //illusion: poggle
            //flowers: has theme
            //solvent: too support (too simple) 000000000000000000000000 (if yes sacrifice theme)
            //wind song: too support (too simple) 000000000000000000000000 (if yes find some music box song on freesound)
            //sigil: spoggle theme
            //tank: has theme
            //clock tower: inner child? con may make.
            //tortoise: has theme
            //grandfather: too support (withering centric) 000000000000000000000000 (if yes flarb song)
            //reaper: too support (withering centric) (intention to be support) 000000000000000000000000
            //skyloft: too support (not dangerous) (intention to be secret) 000000000000000000000000
            //miriam: make maybe?
            //medamuade: images
            //merced: too support (too simple) (intention to be secret) 000000000000000000000000
            //butterfly: too support (not dangerous) 000000000000000000000000 (if yes spoggle)
            //shua: too support (too simple) 000000000000000000000000 (if yes, inner child)
            //nameless: too support (too simple) (way too simple and gimmick reliant) 000000000000000000000000
            //snake god: smoothskin theme?
            //tripodfish: keko theme
            //lyssa: flamingoa theme
            //glass figurine: too support (confusion) 000000000000000000000000
        }
        public Plan(int two)
        {
            //CNS: no roar 000000000000000000000000
            //dead god: default homunculus
            //enigma: use choir hit sounds
            //dead pixel: has custom
            //little angel: no roar 000000000000000000000000
            //satyr: sepulchre
            //unmung: mung roar
            //crow: minister
            //something: tamagoa hit noises
            //freud: skinner
            //fakeflower: voboola
            //stars: jumble hollow
            //rustic: purpl spog
            //gopel: red spog
            //camera: maniskin
            //the deep: jorro
            //postmodern + war: pixel roar
            //fake angel: no roar 000000000000000000000000
            //illusion: shiverer
            //flowers: blue -> mung; red -> minister; purple -> musicman; yellow -> purpspog; grey -> blueguts;
            //solvent: no roar 000000000000000000000000 (if yes use sacrifice)
            //wind song: no roar 000000000000000000000000 (if yes use hit sound)
            //sigil: resonant spoggle die
            //tank: use it's death sound
            //clock tower: doll death noise
            //tortoise: flarb if ember does not give sounds
            //grandfather: no roar 000000000000000000000000 (if yes use my own visage death sounds)
            //reaper: no roar 000000000000000000000000
            //skyloft: no roar 000000000000000000000000
            //miriam: bimini hurt
            //medamuade: images
            //merced: no roar 000000000000000000000000
            //butterfly: no roar 000000000000000000000000 (if yes just silent anyway)
            //shua: no roar 000000000000000000000000 (if yes maniskin)
            //nameless: no roar 000000000000000000000000
            //snake god: conductor roar
            //tripodfish: manic men roar
            //lyssa: pearl die roar
            //glass figurine: no roar 000000000000000000000000
        }
        public Plan(bool three)
        {
            //CNS: no encounter needed 000000000000000000000000
            //dead god: has encounter done 000000000000000000000000
            //enigma: needs encounter done 000000000000000000000000
            //dead pixel: needs encounter done 000000000000000000000000
            //little angel: no encounter 000000000000000000000000
            //satyr: has encounter, done 000000000000000000000000
            //unmung: has encounter, done 000000000000000000000000
            //crow: needs encounter done 000000000000000000000000
            //something: needs encounter done 000000000000000000000000
            //freud: has encounter, done 000000000000000000000000
            //fakeflower: needs encounter done 000000000000000000000000
            //stars: has encounter done 000000000000000000000000
            //rustic: has encounter, done 000000000000000000000000
            //gopel: has encounter, done 000000000000000000000000
            //camera: has encounter, done 000000000000000000000000
            //the deep: needs encounter done 000000000000000000000000
            //postmodern + war: needs special shit
            //fake angel: no encounter 000000000000000000000000
            //illusion: needs encounter done 000000000000000000000000
            //flowers: needs encounter done 000000000000000000000000
            //solvent: no encounter 000000000000000000000000 (might?)
            //wind song: no encounter 000000000000000000000000 (might?)
            //sigil: needs encounter done 000000000000000000000000
            //tank: needs encounter done 000000000000000000000000
            //clock tower: needs encounter done 000000000000000000000000
            //tortoise: needs encounter done 000000000000000000000000
            //grandfather: no encounter 000000000000000000000000 (might?)
            //reaper: no encounter 000000000000000000000000
            //skyloft: no encounter 000000000000000000000000
            //miriam: needs encounter 000000000000000000000000
            //medamuade: needs encounter done 000000000000000000000000
            //merced: no encounter 000000000000000000000000
            //butterfly: no encounter 000000000000000000000000 (might?)
            //shua: no encounter 000000000000000000000000 (might?)
            //nameless: no encounter 000000000000000000000000
            //snake god: needs encounter done 000000000000000000000000
            //tripodfish: needs encounter done 000000000000000000000000
            //lyssa: needs encounter done 000000000000000000000000
            //glass figurine: no encounter 000000000000000000000000
        }
        public Plan(string bird)
        {
            //enemy: roar, song, hurt, death
            //hunter: custom roar, scrungie, custom hurt, custom die
            //firebird: minister, choir boy, minister, minister
            //beak: kekastle die, minister, keko, keko
            //warbird: hunter roar, sacrifice, tank, tank
        }
    }
}
