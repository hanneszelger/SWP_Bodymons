using System;
using System.Collections;
using System.Collections.Generic;


public class Fight
	{

		public static double Damage;
		public Fight()
		{



		}

		public Fight(Bodymons Bodymon, Bodymons EnemyBodymon, string TypeOfAttack)
		{
			MuscleSet ms = new MuscleSet();
			//Recognise what kind of attack was chosen
			switch (TypeOfAttack)
			{
				case "FrontDoubleBiceps":
					Damage = FrontDoubleBiceps(Bodymon, EnemyBodymon);
					break;
				case "LatSpread":
					Damage = LatSpread(Bodymon, EnemyBodymon);
					break;
				case "SideChest":
					Damage = SideChest(Bodymon, EnemyBodymon);
					break;
				case "QuadStomp":
					Damage = QuadStomp(Bodymon, EnemyBodymon);
					break;
				case "BackDoubleBiceps":
					Damage = BackDoubleBiceps(Bodymon, EnemyBodymon);
					break;
				case "DorianEagle":
					Damage = DorianEagle(Bodymon, EnemyBodymon);
					break;
			}
			//inflict the calculated damage 
			EnemyBodymon.Hp = -Damage;
		}

		public static double FrontDoubleBiceps(Bodymons BodymonParameter, Bodymons EnemyBodymon)
		{
			//allied bodymon 
			double ValueDamage = BodymonParameter.Muscles.Biceps * 1.15 + BodymonParameter.Muscles.Lat * 0.45 + BodymonParameter.Muscles.Abdominals * 0.5;
			//enemy bodymon
			double ValueDamageFromEnemy = EnemyBodymon.Muscles.Biceps * 1 + EnemyBodymon.Muscles.Lat * 0.3 + EnemyBodymon.Muscles.Abdominals * 0.5;
			//total damage, that will be dealt to enemy 
			double TotalDamage = ValueDamage - ValueDamageFromEnemy;
			return TotalDamage;
		}

		public static double LatSpread(Bodymons BodymonParameter, Bodymons EnemyBodymon)
		{
			//allied bodymon 
			double ValueDamage = BodymonParameter.Muscles.Biceps * 0.6 + BodymonParameter.Muscles.Lat * 1.75 + BodymonParameter.Muscles.Abdominals * 1;
			//enemy bodymon
			double ValueDamageFromEnemy = EnemyBodymon.Muscles.Biceps * 0.4 + EnemyBodymon.Muscles.Lat * 1.25 + EnemyBodymon.Muscles.Abdominals * 0.5;
			//total damage, that will be dealt to enemy 
			double TotalDamage = ValueDamage - ValueDamageFromEnemy;
			return TotalDamage;
		}

		public static double SideChest(Bodymons BodymonParameter, Bodymons EnemyBodymon)
		{
			//allied bodymon 
			double ValueDamage = BodymonParameter.Muscles.Biceps * 0.75 + BodymonParameter.Muscles.Lat * 0.1 + BodymonParameter.Muscles.Chest * 2;
			//enemy bodymon
			double ValueDamageFromEnemy = EnemyBodymon.Muscles.Biceps * 0.25 + EnemyBodymon.Muscles.Lat * 0.01 + EnemyBodymon.Muscles.Chest * 1.5;
			//total damage, that will be dealt to enemy 
			double TotalDamage = ValueDamage - ValueDamageFromEnemy;
			return TotalDamage;
		}

		public static double QuadStomp(Bodymons BodymonParameter, Bodymons EnemyBodymon)
		{
			//allied bodymon 
			double ValueDamage = BodymonParameter.Muscles.Quads * 2 + BodymonParameter.Muscles.Lat * 0.5 + BodymonParameter.Muscles.Abdominals * 0.75;
			//enemy bodymon
			double ValueDamageFromEnemy = EnemyBodymon.Muscles.Quads * 1 + EnemyBodymon.Muscles.Lat * 0.35 + EnemyBodymon.Muscles.Abdominals * 0.6;
			//total damage, that will be dealt to enemy 
			double TotalDamage = ValueDamage - ValueDamageFromEnemy;
			return TotalDamage;
		}

		public static double BackDoubleBiceps(Bodymons BodymonParameter, Bodymons EnemyBodymon)
		{
			//allied bodymon 
			double ValueDamage = BodymonParameter.Muscles.Biceps * 1.5 + BodymonParameter.Muscles.Lat * 2 + BodymonParameter.Muscles.Quads * 0.1;
			//enemy bodymon
			double ValueDamageFromEnemy = EnemyBodymon.Muscles.Biceps * 0.5 + EnemyBodymon.Muscles.Lat * 1 + EnemyBodymon.Muscles.Abdominals * 0.01;
			//total damage, that will be dealt to enemy 
			double TotalDamage = ValueDamage - ValueDamageFromEnemy;
			return TotalDamage;
		}

		public static double DorianEagle(Bodymons BodymonParameter, Bodymons EnemyBodymon)
		{
			//allied bodymon 
			double ValueDamage = BodymonParameter.Muscles.Biceps * 1 + BodymonParameter.Muscles.Lat * 1.5 + BodymonParameter.Muscles.Abdominals * 0.2;
			//enemy bodymon
			double ValueDamageFromEnemy = EnemyBodymon.Muscles.Biceps * 0.5 + EnemyBodymon.Muscles.Lat * 0.5 + EnemyBodymon.Muscles.Abdominals * 0.1;
			//total damage, that will be dealt to enemy 
			double TotalDamage = ValueDamage - ValueDamageFromEnemy;
			return TotalDamage;
		}
	
	
}