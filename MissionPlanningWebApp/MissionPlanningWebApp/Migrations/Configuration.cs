namespace MissionPlanningWebApp.Migrations
{
    using MissionPlanningWebApp.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    //internal sealed class Configuration : DbMigrationsConfiguration<MissionPlanningWebApp.Models.DistributionRulesDBContext>
    //{
    //    public Configuration()
    //    {
    //        AutomaticMigrationsEnabled = true;
    //    }

    //}

    internal sealed class Configuration : DbMigrationsConfiguration<MissionPlanningWebApp.Models.LtLDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LtLDbContext context)
        {
 	        base.Seed(context);

			var equipment = new List<Equipment>()
			{
				//"Clothing and Armor", "Personal Care", "Supplies", "Weapons and Ammunition", ""
				new Equipment { Name = "MRE", Weight = 1.3, Firepower = 0.0, Category = "Supplies"},
				new Equipment { Name = "Water", Weight = 27.6, Firepower = 0.0, Category = "Supplies"},
				new Equipment { Name = "M16/M4", Weight = 7.8, Firepower = 3.0, Category = "Weapons and Ammunition"},
				new Equipment { Name = "M249", Weight = 27.6, Firepower = 3.0, Category = "Weapons and Ammunition"},
				new Equipment { Name = "M203", Weight = 72.5, Firepower = 4.0, Category = "Weapons and Ammunition"},
				new Equipment { Name = "Helmet", Weight = 1.0, Firepower = 0.0, Category = "Clothing and Armor"},
				new Equipment { Name = "Armor Vest", Weight = 1.0, Firepower = 0.0, Category = "Clothing and Armor"},
				new Equipment { Name = "Armor Vest w/ SAPPI Plates", Weight = 7.8, Firepower = 0.0, Category = "Clothing and Armor"},
				new Equipment { Name = "Armor Vest w/ SAPPI Plates & Accessories", Weight = 27.6, Firepower = 0.0, Category = "Clothing and Armor"},
				new Equipment { Name = "Ballistic Eye Protection", Weight = 72.5, Firepower = 3.0, Category = "Clothing and Armor"},
				new Equipment { Name = "Knee, Elbow Pad Set", Weight = 1, Firepower = 0.0, Category = "Clothing and Armor"},
				new Equipment { Name = "Optics: ACOG (magifying site)", Weight = 21.1, Firepower = 4.0, Category = "Weapons and Ammunition"},
				new Equipment { Name = "Optics: Thermal", Weight = 1.0, Firepower = 0.0, Category = "Clothing and Armor"},
				new Equipment { Name = "Optics: Pac4/PEQ2A (Infra Red lasers for aiming at night)", Weight = 1.0, Firepower = 0.0, Category = "Weapons and Ammunition"},
				new Equipment { Name = "Optics: PVS-14 (night vision goggles)", Weight = 1.7, Firepower = 0.0, Category = "Clothing and Armor"},
				new Equipment { Name = "Squad Radio", Weight = 27.6, Firepower = 2.0, Category = "Supplies"},
				new Equipment { Name = "Lightweight Helmet", Weight = 3.45, Firepower = 0.0, Category = "Clothing and Armor"},
				new Equipment { Name = "FR Gloves, Frog", Weight = 0.3, Firepower = 0.0, Category = "Clothing and Armor"},
				new Equipment { Name = "Modular Tactical Vest", Weight = 14.45, Firepower = 0.0, Category = "Clothing and Armor"},
				new Equipment { Name = "E-SAPI Set (medium, front and back)", Weight = 11, Firepower = 0.0, Category = "Clothing and Armor"},
				new Equipment { Name = "Side-SAPI Set", Weight = 5, Firepower = 0.0, Category = "Clothing and Armor"},
				new Equipment { Name = "Patrol Pack", Weight = 2.425, Firepower = 0.0, Category = "Clothing and Armor"},
				new Equipment { Name = "RCO", Weight = 1.0, Firepower = 0.0, Category = "Clothing and Armor"},
				new Equipment { Name = "Service Rifle, M16A4", Weight = 8.24, Firepower = 3.0, Category = "Weapons and Ammunition"},
				new Equipment { Name = "Combat Assault Sling", Weight = 0.42, Firepower = 2.0, Category = "Weapons and Ammunition"},
				new Equipment { Name = "M-16 Magazine with 30 Rounds", Weight = 1.05, Firepower = 0.0, Category = "Weapons and Ammunition"},
				new Equipment { Name = "Multi-purpose Bayonet", Weight = 1.3, Firepower = 1.0, Category = "Weapons and Ammunition"},
				new Equipment { Name = "Grenade, Hand, G8811 Fragmentation", Weight = 2, Firepower = 4.0, Category = "Weapons and Ammunition"},
				new Equipment { Name = "100oz Hydration System (filled)", Weight = 6.906, Firepower = 0.0, Category = "Supplies"},
				new Equipment { Name = "Individual First Aid Kit (IFAK)", Weight = 1, Firepower = 0.0, Category = "Supplies"},
				new Equipment { Name = "Paint, Face, Camouflage Stick", Weight = 0.14, Firepower = 0.0, Category = "Supplies"},
				new Equipment { Name = "Personal Illumination System", Weight = 0.625, Firepower = 0.0, Category = "Supplies"},
				new Equipment { Name = "Ballistic Eye Wear", Weight = 0.15, Firepower = 0.0, Category = "Clothing and Armor"},
				new Equipment { Name = "Ear Plugs with Case", Weight = 0.1, Firepower = 0.0, Category = "Supplies"},
				new Equipment { Name = "M50 Gas Mask w/ Hood, All Accessories (medium)", Weight = 5.6, Firepower = 0.0, Category = "Clothing and Armor"},
				new Equipment { Name = "GORTEX Top", Weight = 2.2, Firepower = 0.0, Category = "Clothing and Armor"},
				new Equipment { Name = "GORTEX Bottom", Weight = 2.2, Firepower = 0.0, Category = "Clothing and Armor"},
				new Equipment { Name = "PEQ-15 ATPIAL w/out SOFT CASE", Weight = 0.51, Firepower = 0.0, Category = "Supplies"},
				new Equipment { Name = "IWNS-T", Weight = 2, Firepower = 0.0, Category = "Supplies"},
				new Equipment { Name = "IISR/Quiet Pro w/ Spare Battery", Weight = 1.96, Firepower = 0.0, Category = "Supplies"},
				new Equipment { Name = "Regular Complete Uniform", Weight = 8.408, Firepower = 0.0, Category = "Clothing and Armor"},
				new Equipment { Name = "Squad Automatic Weapon, M249", Weight = 15.3, Firepower = 3.0, Category = "Weapons and Ammunition"},
				new Equipment { Name = "LBE for M249", Weight = 7.341, Firepower = 0.0, Category = "Weapons and Ammunition"},
				new Equipment { Name = "Cartridge, 5.56 Link (200)", Weight = 6.9, Firepower = 0.0, Category = "Weapons and Ammunition"},
				new Equipment { Name = "PVS-17C", Weight = 3.0, Firepower = 0.0, Category = "Clothing and Armor"},
				new Equipment { Name = "AN/PAS-D(V2)", Weight = 2.8, Firepower = 0.0, Category = "Clothing and Armor"},
				new Equipment { Name = "G940 Green Smoke Grenade", Weight = 2.0, Firepower = 0.0, Category = "Weapons and Ammunition"},
				new Equipment { Name = "CARTRIDGE, 40MM, HIGH EXPLOSIVE DUAL PURPOSE M433 QTY OF 18", Weight = 14.5, Firepower = 0.0, Category = "Weapons and Ammunition"},
				new Equipment { Name = "Grenade Launcher, M203", Weight = 3.0, Firepower = 4.0, Category = "Weapons and Ammunition"},
				new Equipment { Name = "Ammunition, Smoke", Weight = 2.4, Firepower = 0.0, Category = "Weapons and Ammunition"},
				new Equipment { Name = "Ammunition, Flares", Weight = 1.0, Firepower = 0.0, Category = "Weapons and Ammunition"},
				new Equipment { Name = "LBE for M203", Weight = 8.665, Firepower = 0.0, Category = "Weapons and Ammunition"},
				new Equipment { Name = "PSQ-18 (Enhanced Sight M203", Weight = 1.2, Firepower = 0.0, Category = "Weapons and Ammunition"},
				new Equipment { Name = "Thermal Binoculars", Weight = 3.75, Firepower = 0.0, Category = "Supplies"},
				new Equipment { Name = "148", Weight = 1.88, Firepower = 0.0, Category = "Supplies"},
				new Equipment { Name = "M9 Pistol", Weight = 2.1, Firepower = 2.0, Category = "Weapons and Ammunition"},
				new Equipment { Name = "M9 Magazine with 15 Rounds", Weight = 0.45, Firepower = 0.0, Category = "Weapons and Ammunition"},
				new Equipment { Name = "UNIT 1 BAG/ 6 IV'S/ 02 TANK QUESTIONABLE", Weight = 25, Firepower = 0.0, Category = "Supplies"},
				new Equipment { Name = "IMPROVED LOAD BEARING EQUIPMENT", Weight = 10.5, Firepower = 0.0, Category = "Clothing and Armor"},
				new Equipment { Name = "ENTRENCHING TOOL WITH CASE", Weight = 2.5, Firepower = 0.0, Category = "Supplies"},
				new Equipment { Name = "EXTRA SOCKS", Weight = 0.16, Firepower = 0.0, Category = "Clothing and Armor"},
				new Equipment { Name = "PONCHO", Weight = 1.6, Firepower = 0.0, Category = "Clothing and Armor"},
				new Equipment { Name = "PONCHO LINER", Weight = 1.6, Firepower = 0.0, Category = "Clothing and Armor"},
				new Equipment { Name = "TOOTH BRUSH WITH PASTE", Weight = 0.3, Firepower = 0.0, Category = "Personal Care"},
				new Equipment { Name = "CHAPSTICK", Weight = 0.01, Firepower = 0.0, Category = "Personal Care"},
				new Equipment { Name = "100 WEIGHT FLEECE JACKET", Weight = 0.661, Firepower = 0.0, Category = "Clothing and Armor"},
				new Equipment { Name = "300 WEIGHT FLEECE JACKET", Weight = 1.322, Firepower = 0.0, Category = "Clothing and Armor"},
				new Equipment { Name = "POLYPRO TOP", Weight = 0.44, Firepower = 0.0, Category = "Clothing and Armor"},
				new Equipment { Name = "POLYPRO BOTTOM", Weight = 0.462, Firepower = 0.0, Category = "Clothing and Armor"},
				new Equipment { Name = "COLD WEATHER GLOVES AND MITTENS", Weight = 1.325, Firepower = 0.0, Category = "Clothing and Armor"},
				new Equipment { Name = "WATCH CAP", Weight = 0.55, Firepower = 0.0, Category = "Supplies"},
				new Equipment { Name = "SHAVING GEAR, TOWEL, FACE CLOTH", Weight = 2.0, Firepower = 0.0, Category = "Personal Care"},
				new Equipment { Name = "INSECT REPELLANT", Weight = 0.75, Firepower = 0.0, Category = "Personal Care"},
				new Equipment { Name = "SEWING KIT", Weight = 0.1, Firepower = 0.0, Category = "Supplies"},
				new Equipment { Name = "MAT, ISOPOR", Weight = 1.5, Firepower = 0.0, Category = "Supplies"},
				new Equipment { Name = "BIVY SACK", Weight = 2.2, Firepower = 0.0, Category = "Supplies"},
				new Equipment { Name = "MODULAR SLEEPING BAG", Weight = 4.5, Firepower = 0.0, Category = "Supplies"},
				new Equipment { Name = "TWO MAN TENT", Weight = 8.5, Firepower = 0.0, Category = "Supplies"},
				new Equipment { Name = "JLIST SUIT COMPLETE WITH BOOTS AND GLOVES", Weight = 10, Firepower = 0.0, Category = "Clothing and Armor"},
				new Equipment { Name = "BATTERIES, AA (4)", Weight = 0.375, Firepower = 0.0, Category = "Supplies"},
				new Equipment { Name = "UNIFORM, UTILITY, CAMOUFLAGE", Weight = 2.97, Firepower = 0.0, Category = "Clothing and Armor"},
				new Equipment { Name = "UNIFORM, UTILITY, BELT", Weight = 0.3, Firepower = 0.0, Category = "Clothing and Armor"},
				new Equipment { Name = "T-SHIRT, GREEN", Weight = 0.18, Firepower = 0.0, Category = "Clothing and Armor"},
				new Equipment { Name = "UNDERSHORTS, BOXER", Weight = 0.25, Firepower = 0.0, Category = "Clothing and Armor"},
				new Equipment { Name = "BOOTS, COMBAT WITH LACES", Weight = 4.1, Firepower = 0.0, Category = "Clothing and Armor"},
				new Equipment { Name = "SOCKS", Weight = 0.16, Firepower = 0.0, Category = "Clothing and Armor"},
				new Equipment { Name = "WATCH, WRIST", Weight = 0.1, Firepower = 0.0, Category = "Supplies"},
				new Equipment { Name = "CARD, ID", Weight = 0.028, Firepower = 0.0, Category = "Supplies"},
				new Equipment { Name = "DOG TAGS", Weight = 0.1, Firepower = 0.0, Category = "Personal Care"},
				new Equipment { Name = "UNIFORM, UTILITY, CAP", Weight = 0.22, Firepower = 0.0, Category = "Clothing and Armor"}
			};

			var parameters = new List<MissionParameter>()
			{
				new MissionParameter { Name = "Duration", Value = 15, IsSelected = true },
				new MissionParameter { Name = "Threat level", Value = 150, IsSelected = true },
				new MissionParameter { Name ="Expected Enemy Contact: none(0), light(1), medium(2), heavey(3)", Value = 1, IsSelected = true },
				new MissionParameter { Name ="Enemy Capabilities: small arms", Value = 1, IsSelected = true },
				new MissionParameter { Name ="Enemy Capabilities: RPG", Value = 0, IsSelected = true },
				new MissionParameter { Name ="Enemy Capabilities: IED 1", Value = 0, IsSelected = true },
				new MissionParameter { Name ="Enemy Capabilities: IED 2", Value = 0, IsSelected = true },
				new MissionParameter { Name ="Enemy Capabilities: NBC (nuclear, biological, chemical)", Value =0, IsSelected = true },
				new MissionParameter { Name ="Temperature: cold(0), temperate(1), hot(2)", Value = 0, IsSelected = true },
				new MissionParameter { Name ="Light data",Value = 0, IsSelected = true},
				new MissionParameter { Name ="Route",Value = 0, IsSelected = true},
				new MissionParameter { Name ="Terrain - Mountainous(0), Forrest(1), Urban(2), Desert(3)", Value = 0, IsSelected = true },
				new MissionParameter { Name ="Start DTG (date time group)", Value = 1, IsSelected = true },
				new MissionParameter { Name ="Patrol: Raid",Value = 1, IsSelected = true },
				new MissionParameter { Name ="Patrol: Humanitarian", Value = 1, IsSelected = true },
				new MissionParameter { Name ="Patrol: Hasty Defense", Value = 1, IsSelected = true },
				new MissionParameter { Name ="End DTG (date time group)", Value = 1, IsSelected = true },
				new MissionParameter { Name ="Offensive Tasks: Engage Targets Day", Value = 1, IsSelected = true },
				new MissionParameter { Name ="Offensive Tasks: Engage Targets Night", Value = 1, IsSelected = true },
				new MissionParameter { Name ="Offensive Tasks: Call/Adjust Indirect Fires", Value = 1, IsSelected = true },
				new MissionParameter { Name ="Offensive Tasks: Knock out Bunker", Value = 1, IsSelected = true},
				new MissionParameter { Name ="Offensive Tasks: Observe - over distance", Value = 1, IsSelected = true},
				new MissionParameter { Name ="Offensive Tasks: Observe - night", Value = 1, IsSelected = true},
				new MissionParameter { Name ="Survivability Tasks: IMT (Individual Movement Technique)", Value = 1, IsSelected = true},
				new MissionParameter { Name ="Survivability Tasks: Prepare Tactical Position", Value = 1, IsSelected = true },
				new MissionParameter { Name ="1st Aid Tasks: Stop Bleeding", Value = 1, IsSelected = true },
				new MissionParameter { Name ="1st Aid Tasks: Stabilize Casualty", Value = 1, IsSelected = true },
				new MissionParameter { Name ="1st Aid Tasks: Casualty Evacuation", Value = 1, IsSelected = true },
				new MissionParameter { Name ="Misc Tasks: Detainee Ops.", Value = 1, IsSelected = true},
				new MissionParameter { Name ="Misc Tasks: Crowd Control", Value = 1, IsSelected = true},
				new MissionParameter { Name ="C2 Tasks: Commo Internal", Value = 1, IsSelected = true},
				new MissionParameter { Name ="C2 Tasks: Commo External", Value = 1, IsSelected = true},
				new MissionParameter { Name ="Sustainment Tasks: Feed Squad", Value = 1, IsSelected = true},
				new MissionParameter { Name ="Sustainment Tasks: Generate Power", Value = 1, IsSelected = true},
				new MissionParameter { Name ="Sustainment Tasks: Protect vs. Climate", Value = 1, IsSelected = true},
				new MissionParameter { Name ="Sustainment Tasks: Protect vs. NBC Attack", Value = 1, IsSelected = true}
			};

            var characteristics = new List<Characteristic>()
            { 
                //Toughness, Size/Strength, Experience, PFT Score
                new Characteristic { Char = "Squad Role" },
                new Characteristic { Char = "Size/Strength" },
                new Characteristic { Char = "Experience" },
                new Characteristic { Char = "PFT Score" }
            };

			/*
			var rules = new List<MissionRule>(){
				new MissionRule { ParamId = 0, RuleCond = "G", RuleData = 6, EquipId = 0, ConstrCond = "G", ConstrRHS = 13 },
				new MissionRule { ParamId = 0, RuleCond = "G", RuleData = 14, EquipId = 0, ConstrCond = "G", ConstrRHS =  26},
				new MissionRule { ParamId = 0, RuleCond = "G", RuleData = 22, EquipId = 0, ConstrCond = "G", ConstrRHS =  39},
				new MissionRule { ParamId = 0, RuleCond = "G", RuleData = 30, EquipId = 0, ConstrCond = "G", ConstrRHS =  52},
				new MissionRule { ParamId = 0, RuleCond = "G", RuleData = 30, EquipId = 0, ConstrCond = "G", ConstrRHS =  65},
				new MissionRule { ParamId = 22, RuleCond = "E", RuleData = 1, EquipId = 14, ConstrCond = "G", ConstrRHS =  10},
				new MissionRule { ParamId = 22, RuleCond = "E", RuleData = 1, EquipId = 12, ConstrCond = "G", ConstrRHS =  2},
				new MissionRule { ParamId = 30, RuleCond = "E", RuleData = 1, EquipId = 15, ConstrCond = "G", ConstrRHS =  4}
			};
			rules.ForEach(r => context.MissionRules.AddOrUpdate(a => a.ParamId, r));
			*/

			equipment.ForEach(e => context.Equipment.AddOrUpdate(b => b.Name, e));
			parameters.ForEach(p => context.MissionParameters.AddOrUpdate(q => q.Name, p));
			characteristics.ForEach(chr => context.Characteristics.AddOrUpdate(c => c.Char, chr));
            context.SaveChanges();
        }
    }
}
