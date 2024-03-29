﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Hawthorne
{
    public static class GroupFour
    {
        public static void Setup()
        {
            DelayedAttackManager.Setup();
            SigilManager.Setup();
            WitheringFix.Setup();
            DrowningManager.Setup();
            PostmodernHandler.Setup();
            NoiseHandler.Setup();
            SepulchreFix.Setup();
            FleetingHandler.Setup();
        }
        public static void AddEnemies()
        {
            Angel.Add(544510);
            Illusion.Add(544509);
            RedFlower.Add(544508);
            BlueFlower.Add(544507);
            YellowFlower.Add(544506);
            PurpleFlower.Add(544505);
            GreyFlower.Add(544504);
            Solvent.Add(544503);
            WindSong.Add(544502);
            Sigil.Add(544501);
            Tank.Add(544500);
            ClockTower.Add(544499);
            Tortoise.Add(544498);
            Coffin.Add(544497);
            Reaper.Add(544496);
            Skyloft.Add(544495);
            Miriam.Add(544494);
            EyePalm.Add(544493);
            Merced.Add(544492);
            Butterfly.Add(544491);
            Shua.Add(544490);
            Nameless.Add(544489);
            Tripod.Add(544488);
            Rabies.Add(544487);
            Glass.Add(544486);
            Damocles.Add(544485);
            Deep.Add(544484);
            Postmodern.Add(544483);
            War.Add(544482);
            SnakeGod.Add(544481);
            CrashesYourGame.Add(544480);
            Hunter.Add(544479);
            Firebird.Add(544478);
            Beak.Add(544477);
            Scarecrow.Add(544476);
            Windle.Add(544475);
            Blackstar.Add(544474);
            Singularity.Add(544473);
            Indicator.Add(544472);
            Maw.Add(544471);
            Clione.Add(544470);
            Children.Add(544469);
            Lobotomy.Add(544468);
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
            FreudGroup.Add(6329);
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
            SigilGroup.Add(2467413);//doesnt has music
            TortoiseSong.Add(2467414);
            ClockTowerSong.Add(2467415);
            TripodGroup.Add(2467416);//doesnt has music
            RabiesGroup.Add(2467417);
            LonelyFlummox.Add();
            RedoManiskins.Add();
            SnakeGroup.Add(2467418);
            HunterGroup.Add(2467419);
            FirebirdGroup.Add(2467420);//doesnt has music
            BeakGroup.Add(2467421);
            WarbirdGroup.Add(2467422);//doesnt has music
            WindSongGroup.Add(2467423);
            SolventGroup.Add(2467424);
            SkyloftGroup.Add(2467425);
            ButterflyGroup.Add(2467426);//doesnt has music
            GrandfatherGroup.Add(2467427);//doesnt has music
            ReaperGroup.Add(2467428);//EMBER IS WORKING ON IT
            ShuaGroup.Add(2467429);
            BlackStarGroup.Add(2467430);//doesnt has music
            IndicatorGroup.Add(2467431);
            MawGroup.Add(2467432);//doesnt has music
            Iconoclast2Group.Add();
            ClioneSong.Add(2467433);
            //make lobotomy encounters and add music
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
            ModMod.JanMed();
            ModMod.MarbleEZ();
            ModMod.MarbleMed();
            ModMod.MarbleHard();
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
        }
    }
}
