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
            PCall(Illusion.Add, 544509);
            PCall(RedFlower.Add, 544508);
            PCall(BlueFlower.Add, 544507);
            PCall(YellowFlower.Add, 544506);
            PCall(PurpleFlower.Add, 544505);
            PCall(GreyFlower.Add, 544504);
            PCall(Solvent.Add, 544503);
            PCall(WindSong.Add, 544502);
            PCall(Sigil.Add, 544501);
            PCall(Tank.Add, 544500);
            PCall(ClockTower.Add, 544499);
            PCall(Tortoise.Add, 544498);
            PCall(Coffin.Add, 544497);
            PCall(Reaper.Add, 544496);
            PCall(Skyloft.Add, 544495);
            PCall(Miriam.Add, 544494);
            PCall(EyePalm.Add, 544493);
            PCall(Merced.Add, 544492);
            PCall(Butterfly.Add, 544491);
            PCall(Shua.Add, 544490);
            PCall(Nameless.Add, 544489);
            PCall(Tripod.Add, 544488);
            PCall(Rabies.Add, 544487);
            PCall(Glass.Add, 544486);
            PCall(Damocles.Add, 544485);
            PCall(Deep.Add, 544484);
            PCall(Postmodern.Add, 544483);
            PCall(War.Add, 544482);
            PCall(SnakeGod.Add, 544481);
            PCall(CrashesYourGame.Add, 544480);
            PCall(Hunter.Add, 544479);
            PCall(Firebird.Add, 544478);
            PCall(Beak.Add, 544477);
            PCall(Scarecrow.Add, 544476);
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
            PCall(Boat.Add, 544464);
            PCall(Train.Add, 544463);
            PCall(RedBot.Add, 544462);
            PCall(BlueBot.Add, 544461);
            PCall(YellowBot.Add, 544460);
            PCall(PurpleBot.Add, 544459);
            PCall(GreyBot.Add, 544458);
            PCall(GlassedSun.Add, 544457);
            PCall(Crystal.Add, 544456);
            PCall(Stone.Add, 544455);
            PCall(Dragon.Add, 544454);
            PCall(Vase.Add, 544453);
            PCall(Forget.Add, 544452);
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
            ModMod.MonckEZ();
            ModMod.MonckMed();
            ModMod.MonckHard();
            ModMod.IconoclastHard();
            ModMod.DisembodiedMed();
            ModMod.DisembodiedHard();
            ModMod.UnflarbShore();
            ModMod.MonkeyMed();
            ModMod.MonkeyHard();
            ModMod.NephMed();
            ModMod.NephHard();
            ModMod.GizoMed();
            ModMod.GizoHard();
            ModMod.GreyGuts();
            ModMod.GreySpog();
            ModMod.ChapMed();
            ModMod.NowakSpog();
            ModMod.OphanimHard();
            ModMod.PeonMed();
            ModMod.PeonEZ();
            ModMod.PsychoMed();
            ModMod.PsychoHard();
            ModMod.LeviMed();
            ModMod.LeviHard();
            ModMod.AnglerHard();
            ModMod.MetaH();
            ModMod.RedBlueEZ();
            ModMod.YellowBlueEZ();
            ModMod.YellowPurpleEZ();
            ModMod.RedBlueMed();
            ModMod.YellowBlueMed();
            ModMod.YellowPurpleMed();
            ModMod.PurpleBlueMed();
            ModMod.BlueYellowMed();
            ModMod.RedYellowMed();
            ModMod.BluePurpleOrph();
            ModMod.PurpleRedOrph();
            ModMod.YellowRedOrph();
            ModMod.RedBlueOrph();
            ModMod.RedPurpleOrph();
            ModMod.PurpleYellowOrph();
            ModMod.DrumMed();
            ModMod.DrumHard();
            ModMod.HarbMed();
            ModMod.HarbHard();
            ModMod.AvianMed();
            ModMod.AvianHard();
            ModMod.RuntMed();
            ModMod.RuntHard();
            ModMod.LurchyMed();
            ModMod.LurchyHard();
            ModMod.FesterMed();
            ModMod.FesterHard();
            ModMod.PaceMed();
            ModMod.PaceHard();
            ModMod.GordoMed();
            ModMod.GordoHard();
            ModMod.GordoGoliath();
            ModMod.GoliathMed();
            ModMod.GoliathHard();
            ModMod.ColoRedEZ();
            ModMod.ColoBlueEZ();
            ModMod.ColoRedMed();
            ModMod.ColoBlueMed();
            ModMod.ColoPurpShore();
            ModMod.ColoYellowShore();
            ModMod.ColoPurpMed();
            ModMod.ColoYellowMed();
            ModMod.RockShore();
            ModMod.BuddyShore();
            ModMod.TetoShore();
            ModMod.HoundOrph();
            ModMod.SpligBluePurpleShoreEZ();
            ModMod.SpligBlueYellowShoreEZ();
            ModMod.SpligRedYellowShoreEZ();
            ModMod.SpligRedPurpleShoreEZ();
            ModMod.SpligRedPurpleShoreMed();
            ModMod.SpligBluePurpleShoreMed();
            ModMod.SpligRedYellowShoreHard();
            ModMod.CladEZ();
            ModMod.CladRandMed();
            ModMod.CladStaticMed();
            ModMod.CladHardShore();
            ModMod.LymphEZ();
            ModMod.LymphMed();
            ModMod.LymphHard();
            ModMod.SheoOne();
            ModMod.SheoTwo();
            ModMod.SpligBluePurpleOrph();
            ModMod.SpligRedYellowOrph();
            ModMod.CladMedOrph();
            ModMod.CladHardOrph();
            ModMod.SheoOrph();
            ModMod.FesterManOrph();
            ModMod.FumeOrph();
            ModMod.WhimSpoggleOrph();
            ModMod.EvangGard();
            ModMod.EggChoir();
            ModMod.ChancellorEZ();
            ModMod.ChancellorMed();
            ModMod.ChancellorH();
            ModMod.HogEZ();
            ModMod.HogMed();
            ModMod.HogHard();
            ModMod.JanEZ();
            ModMod.JanMed();
            ModMod.JanHard();
            ModMod.MarbleEZ();
            ModMod.MarbleMed();
            ModMod.MarbleHard();
            ModMod.FrostEZ();
            ModMod.FrostMed();
            ModMod.FrostHard();
            ModMod.ErrantMed();
            ModMod.ErrantHard();
            ModMod.StatueEZ();
            ModMod.StatueMed();
            ModMod.StatueHard();
            ModMod.BolerOrph();
            ModMod.CrabMed();
            ModMod.CrabHard();
            ModTwo.NosestoneTemplateMed("SweatingNosestoneEncountersMedium", "SweatingNosestone_EN");
            ModTwo.NosestoneTemplateMed("ProlificNosestoneEncountersMedium", "ProlificNosestone_EN");
            ModTwo.NosestoneTemplateMed("ScatterbrainedNosestoneEncountersMedium", "ScatterbrainedNosestone_EN");
            ModTwo.NosestoneTemplateMed("MesmerizingNosestoneEncountersMedium", "MesmerizingNosestone_EN");
            ModTwo.NosestoneTemplateMed("UninspiredNosestoneEncountersMedium", "UninspiredNosestone_EN");
            ModTwo.NosestoneTemplateHard("SweatingNosestoneEncountersHard", "SweatingNosestone_EN");
            ModTwo.NosestoneTemplateHard("ProlificNosestoneEncountersHard", "ProlificNosestone_EN");
            ModTwo.NosestoneTemplateHard("ScatterbrainedNosestoneEncountersHard", "ScatterbrainedNosestone_EN");
            ModTwo.NosestoneTemplateHard("MesmerizingNosestoneEncountersHard", "MesmerizingNosestone_EN");
            ModTwo.NosestoneTemplateHard("UninspiredNosestoneEncountersHard", "UninspiredNosestone_EN");
            ModTwo.DancerEZ();
            ModTwo.DancerMed();
            ModTwo.DancerHard();
            ModTwo.MooneEZ();
            ModTwo.MooneMed();
            SaltMod.PixelShore();
            SaltMod.PixelOrph();
            SaltMod.EnigmaOrph();
            SaltMod.AnglerMed();
            SaltMod.AnglerHard();
            SaltMod.CameraShore();
            SaltMod.CameraOrph();
            SaltMod.CameraGard();
            SaltMod.CrowOrphMed();
            SaltMod.CrowOrphHard();
            SaltMod.CrowGard();
            SaltMod.SatyrHard();
            SaltMod.UnmungShore();
            SaltMod.UnmungGard();
            SaltMod.SomethingMed();
            SaltMod.SomethingHard();
            SaltMod.Stars();
            SaltMod.FreudOrph();
            SaltMod.FreudGard();
            SaltMod.RusticHard();
            SaltMod.MortalHard();
            SaltMod.IllusionMed();
            SaltMod.IllusionHard();
            SaltMod.IllusionGard();
            SaltMod.PFlowerOrph();
            SaltMod.YFlowerOrph();
            SaltMod.PFlowerGard();
            SaltMod.YFlowerGard();
            SaltMod.YFlowerEZ();
            SaltMod.BFlowerGard();
            SaltMod.RFlowerGard();
            SaltMod.GFlowerGard();
            SaltMod.MiriamHard();
            SaltMod.EyePalmOrph();
            SaltMod.EyePalmGard();
            SaltMod.EyePalmEZ();
            SaltMod.TankOrph();
            SaltMod.TankGard();
            SaltMod.SigilOrph();
            SaltMod.SigilGard();
            SaltMod.TortOrph();
            SaltMod.TortGard();
            SaltMod.ClockGard();
            SaltMod.TripodShore();
            SaltMod.TripodGard();
            SaltMod.RabieEZ();
            SaltMod.RabieMed();
            SaltMod.RabieHard();
            SaltMod.ManicTwo();
            SaltMod.SnakeGodHard();
            SaltMod.HuntOrphMed();
            SaltMod.HuntOrphHard();
            SaltMod.HuntGard();
            SaltMod.FirebirdMed();
            SaltMod.FirebirdHard();
            SaltMod.BeakShore();
            SaltMod.BeakHard();
            SaltMod.BeakEZ();
            SaltMod.BeakOrph();
            SaltMod.WarShore();
            SaltMod.WarOrph();
            SaltMod.WindSongMed();
            SaltMod.SolventEZ();
            SaltMod.SkyloftShore();
            SaltMod.ButterflyEZ();
            SaltMod.GrandfatherGard();
            SaltMod.ReaperMed();
            SaltMod.ShuaEZ();
            SaltMod.BlackStarEZ();
            SaltMod.NerveEZ();
            SaltMod.NerveMed();
            SaltMod.MawGard();
            SaltMod.IconoclastTwo();
            SaltMod.ClioneShoreMed();
            SaltMod.ClioneShoreH();
            SaltMod.ClioneOrph();
            SaltMod.ClioneGard();
            SaltMod.YNLEZ();
            SaltMod.YNLMed();
            SaltMod.PinanoEZ();
            SaltMod.PinanoMed();
            SaltMod.PinanoHard();
            SaltMod.MinanaEZ();
            SaltMod.SpitatoEZ();
            SaltMod.SpitatoMed();
            SaltMod.BoatEZ();
            SaltMod.BoatMed();
            SaltMod.StoplightMed();
            SaltMod.StoplightHard();
            SaltTwo.RedBotEZ();
            SaltTwo.RedBotMed();
            SaltTwo.RedBotHard();
            SaltTwo.RedBotGard();
            SaltTwo.YellowBotOrph();
            SaltTwo.YellowBotHard();
            SaltTwo.YellowBotEZ();
            SaltTwo.YellowBotGard();
            SaltTwo.BlueBotEZ();
            SaltTwo.BlueBotMed();
            SaltTwo.PurpleBotEZ();
            SaltTwo.PurpleBotMed();
            SaltTwo.GreyBotMed();
            SaltTwo.GreyBotHard();
            SaltTwo.GlassSunHard();
            SaltTwo.MercedGard();
            SaltTwo.CrystalMed();
            SaltTwo.CrystalHard();
            SaltTwo.DragonHard();
            SaltTwo.OdeMed();
            SaltTwo.ShuaMed();
            SaltTwo.AngelEZ();
            SaltTwo.GlassEZ();
            SaltTwo.WindleShoreEZ();
            SaltTwo.WindleShoreMed();
        }
    }
}
