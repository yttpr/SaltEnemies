using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace Hawthorne
{
    public static class GroupFour
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
        public static void Setup()
        {
            PCall(DelayedAttackManager.Setup);
            PCall(SigilManager.Setup);
            PCall(WitheringFix.Setup);
            PCall(DrowningManager.Setup);
            PCall(PostmodernHandler.Setup);
            PCall(NoiseHandler.Setup);
            PCall(SepulchreFix.Setup);
            PCall(FleetingHandler.Setup);
            PCall(FlitheringHandler.Setup);
            PCall(PimplesInfo.Setup);
        }
        public static void AddEnemies()
        {
            PCall(Angel.Add, 544510);
            PCall(Illusion.Add, 544509);=
            PCall(RedFlower.Add, 544508);
            PCall(BlueFlower.Add, 544507);
            PCall(YellowFlower.Add, 544506);
            PCall(PurpleFlower.Add, 544505);
            PCall(GreyFlower.Add, 544504);
            PCall(Solvent.Add, 544503);
            PCall(WindSong.Add, 544502);//custom sounds
            PCall(Sigil.Add, 544501);
            PCall(Tank.Add, 544500);//custom sounds
            PCall(ClockTower.Add, 544499);
            PCall(Tortoise.Add, 544498);
            PCall(Coffin.Add, 544497);
            PCall(Reaper.Add, 544496);
            PCall(Skyloft.Add, 544495);
            PCall(Miriam.Add, 544494);
            PCall(EyePalm.Add, 544493);
            PCall(Merced.Add, 544492);//custom sounds
            PCall(Butterfly.Add, 544491);//custom sounds
            PCall(Shua.Add, 544490);
            PCall(Nameless.Add, 544489);
            PCall(Tripod.Add, 544488);
            PCall(Rabies.Add, 544487);
            PCall(Glass.Add, 544486);
            PCall(Damocles.Add, 544485);
            PCall(Deep.Add, 544484);
            PCall(Postmodern.Add, 544483);//custom sounds
            PCall(War.Add, 544482);
            PCall(SnakeGod.Add, 544481);//custom sounds
            PCall(CrashesYourGame.Add, 544480);
            PCall(Hunter.Add, 544479);//custom sounds
            PCall(Firebird.Add, 544478);
            PCall(Beak.Add, 544477);
            PCall(Scarecrow.Add, 544476);//custom sounds
            PCall(Windle.Add, 544475);
            PCall(Blackstar.Add, 544474);
            PCall(Singularity.Add, 544473);
            PCall(Indicator.Add, 544472);
            PCall(Maw.Add, 544471);
            PCall(Clione.Add, 544470);
            PCall(Children.Add, 544469);
            PCall(Lobotomy.Add, 544468);
            PCall(Pinano.Add, 544467);
            PCall(Spitato.Add, 544466);
            PCall(Minana.Add, 544465);
            PCall(Boat.Add, 544464);//custom sounds?
            PCall(Train.Add, 544463);
            PCall(RedBot.Add, 544462);//custom sounds
            PCall(BlueBot.Add, 544461);//custom sounds
            PCall(YellowBot.Add, 544460);//custom sounds
            PCall(PurpleBot.Add, 544459);//custom sounds
            PCall(GreyBot.Add, 544458);//custom sounds
            PCall(GlassedSun.Add, 544457);
            PCall(Crystal.Add, 544456);//custom sounds
            PCall(Stone.Add, 544455);//custom sounds
            PCall(Dragon.Add, 544454);
            PCall(Vase.Add, 544453);
            PCall(Forget.Add, 544452);
            Meowy.AddEnemies();
        }
        public static void AddEncounters()
        {
            PixelSong.Add(2467402);
            EnigmaSong.Add(2467403);
            AnglerGroup.Add(2467404);
            CameraSong.Add(35788);
            CameraSong.Modify();
            BirdGroup.Add(2467405);
            SatyrSong.Modify();
            UnMungGroup.Add(6559);
            SomethingSong.Add(2467406);
            FreudGroup.Modify();
            //FreudGroup.Add(6329);
            GreyGroup.ModifyRust();
            GreyGroup.ModifyStone();
            DeepSong.Add(2467407);
            IllusionGroup.Add(2467408);
            FlowerSong.PurpleOrph(2467409);
            FlowerSong.PurpleGard(2467409);
            FlowerSong.YellowOrph(2367409);
            FlowerSong.YellowGard(2367409);
            FlowerSong.YellowEasy(2367409);
            FlowerSong.BlueGard(2267409);
            FlowerSong.RedGard(2167409);
            FlowerSong.GreyGard(2067409);
            MiriamSong.Add(2467410);
            EyePalmGroup.Add(2467411);
            TankSong.Add(2467412);
            SigilGroup.Add(2467413);
            TortoiseSong.Add(2467414);
            ClockTowerSong.Add(2467415);
            TripodGroup.Add(2467416);
            RabiesGroup.Add(2467417);
            LonelyFlummox.Add();
            RedoManiskins.Add();
            SnakeGroup.Add(2467418);
            HunterGroup.Add(2467419);
            FirebirdGroup.Add(2467420);
            BeakGroup.Add(2467421);
            WarbirdGroup.Add(2467422);
            WindSongGroup.Add(2467423);
            SolventGroup.Add(2467424);
            SkyloftGroup.Add(2467425);
            ButterflyGroup.Add(2467426);
            GrandfatherGroup.Add(2467427);
            ReaperGroup.Add(2467428);
            ShuaGroup.Add(2467429);
            BlackStarGroup.Add(2467430);
            IndicatorGroup.Add(2467431);
            MawGroup.Add(2467432);
            Iconoclast2Group.Add();
            ClioneSong.Add(2467433);
            YNLSong.Add(2467434);
            PinanoSong.Add(2467435);
            MinanaSong.Add(2467436);
            SpitatoSong.Add(2467437);
            BoatSong.Add(2467438);
            StoplightSong.Add(2467439);
            ApparatusSong.RedAdd(2467440);
            ApparatusSong.YellowAdd(2467441);
            ApparatusSong.BlueAdd(2467442);
            ApparatusSong.PurpleAdd(2467443);
            ApparatusSong.GreyAdd(2467444);
            SunSong.Add(2467445);
            MercedSong.Add(2467446);
            CrystalSong.Add(2467447);
            DragonSong.Add(2467448);
            OdeSong.Add(2467449);
            PaleSong.Add(2467450);
            GlassSong.Add(2467451);
            WindleSong.Add(2467452);
        }
        public static void ModifyEncounters()
        {
            Modifications.SkinMed();
            Modifications.SkinHard();
            Modifications.ShiverMed();
            Modifications.HisImageMed();
            Modifications.HisImageEZ();
            Modifications.HerImageMed();
            Modifications.GiggleMed();
            Modifications.HerImageEZ();
            Modifications.GiggleHard();
            Modifications.GiggleEZ();
            Modifications.SacrificeHard();
            Modifications.ChoirEZ();
            Modifications.RedSpogMedOrph();
            Modifications.ScrungieMed();
            Modifications.PuplrSpogMedOrph();
            Modifications.RevolaHard();
            Modifications.MusicManMed();
            Modifications.MusicManEZ();
            Modifications.PurpleGutsMedOrph();
            Modifications.BlueGutsMedOrph();
            Modifications.ConductorHard();
            Modifications.ManiskinHard();
            Modifications.ConductorMed();
            Modifications.VoboolaHard();
            Modifications.RedSpogShore();
            Modifications.YellowSpogShore();
            Modifications.BlueSpogShore();
            Modifications.MunglingMed();
            Modifications.PurpleSpogShore();
            Modifications.MunglingEZ();
            Modifications.MudLungMed();
            Modifications.MudLungEZ();
            Modifications.KekoMed();
            Modifications.KekastleHard();
            Modifications.KekoEZ();
            Modifications.YellowGutsShore();
            Modifications.BlueGutsShore();
            Modifications.RedGutsShore();
            Modifications.PurpleGutsShore();
            Modifications.FlarbHard();
            Modifications.GoaMed();
            Modifications.GoaHard();
        }
        public static void ModifyMods()
        {
            PCall(Extras.TacoPublic);
            PCall(Extras.TacoBeta);
            PCall(Extras.TPClassic);
            PCall(Extras.TPNewer);
            PCall(Extras.RainbowShore);
            PCall(Extras.RainbowOrph);
            PCall(Extras.ArtistGarden);
            PCall(Extras.ArtistOther);
            PCall(Extras.Colophons);
            PCall(Extras.ZLD1Public);
            PCall(Extras.ZLD1Beta);
            PCall(Extras.CathSpligs);
            PCall(Extras.CathShore);
            PCall(Extras.CathOther);
            PCall(Extras.Minichibis);
            PCall(Extras.GlitchClassic);
            PCall(Extras.GlitchNewer);
            PCall(Extras.Marmod);
            PCall(Extras.DuiOther);
            PCall(Extras.DuiStones);
            PCall(Extras.SaltClassic);
            PCall(Extras.SaltFour);
            PCall(Extras.SaltNext);
        }
    }
}
