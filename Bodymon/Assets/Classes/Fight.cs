using System;


public class Class1
{

	int Damage;
	public Class1()
	{

	}

	public Class1(Bodymons Bodymon, Bodymons EnemyBodymon, string TypeOfAttack)
	{
		//Recognise what kind of attack was chosen
		switch (TypeOfAttack)
		{
            case "FrontDoubleBiceps":
				Damage = FrontDoubleBiceps(Bodymon, EnemyBodymon);
				break;
			case "LatSpread"
				Damage = LatSpread(Bodymon, EnemyBodymon);
				break;
			case "SideChest"
				Damage = SideChest(Bodymon, EnemyBodymon);
				break;
			case "QuadStomp"
				Damage = QuadStomp(Bodymon, EnemyBodymon);
				break;
			case "BackDoubleBiceps"
				Damage = BackDoubleBiceps(Bodymon, EnemyBodymon);
				break;
			case "DorianEagle"
				Damage = DorianEagle(Bodymon, EnemyBodymon);
		}
		//inflict the calculated damage 
		EnemyBodymon.hp = -Damage;
	}

	public static int FrontDoubleBiceps(Bodymon BodymonParameter, Bodymon EnemyBodymon)
	{
		//allied bodymon 
		int ValueDamage = BodymonParameter.Muscleset.Biceps * 1,15 + BodymonParameter.Muscleset.Lat * 0,45 + BodymonParameter.Muscleset.abdominals * 0,5;
		//enemy bodymon
		int ValueDamageFromEnemy = EnemyBodymon.Muscleset.Biceps * 1 + EnemyBodymon.Muscleset.Lat * 0,3 + EnemyBodymon.Muscleset.abdominals * 0,5;
		//total damage, that will be dealt to enemy 
		int TotalDamage = ValueDamage - ValueDamageFromEnemy;
		return TotalDamage;
	}

	public static int LatSpread(Bodymon BodymonParameter, Bodymon EnemyBodymon)
	{
		//allied bodymon 
		int ValueDamage = BodymonParameter.Muscleset.Biceps * 0,6 + BodymonParameter.Muscleset.Lat * 1,75 + BodymonParameter.Muscleset.abdominals * 1;
		//enemy bodymon
		int ValueDamageFromEnemy = EnemyBodymon.Muscleset.Biceps * 0,4 + EnemyBodymon.Muscleset.Lat * 1,25 + EnemyBodymon.Muscleset.abdominals * 0,5;
		//total damage, that will be dealt to enemy 
		int TotalDamage = ValueDamage - ValueDamageFromEnemy;
		return TotalDamage;
	}

	public static int SideChest(Bodymon BodymonParameter, Bodymon EnemyBodymon)
	{
		//allied bodymon 
		int ValueDamage = BodymonParameter.Muscleset.Biceps * 0,75 + BodymonParameter.Muscleset.Lat * 0,1 + BodymonParameter.Muscleset.chest * 2;
		//enemy bodymon
		int ValueDamageFromEnemy = EnemyBodymon.Muscleset.Biceps * 0,25 + EnemyBodymon.Muscleset.Lat * 0,01 + EnemyBodymon.Muscleset.chest * 1,5;
		//total damage, that will be dealt to enemy 
		int TotalDamage = ValueDamage - ValueDamageFromEnemy;
		return TotalDamage;
	}

	public static int QuadStomp(Bodymon BodymonParameter, Bodymon EnemyBodymon)
	{
		//allied bodymon 
		int ValueDamage = BodymonParameter.Muscleset.Quad * 2 + BodymonParameter.Muscleset.Lat * 0,5 + BodymonParameter.Muscleset.abdominals * 0,75;
		//enemy bodymon
		int ValueDamageFromEnemy = EnemyBodymon.Muscleset.Quad * 1 + EnemyBodymon.Muscleset.Lat * 0,35 + EnemyBodymon.Muscleset.abdominals * 0,6;
		//total damage, that will be dealt to enemy 
		int TotalDamage = ValueDamage - ValueDamageFromEnemy;
		return TotalDamage;
	}

	public static int BackDoubleBiceps(Bodymon BodymonParameter, Bodymon EnemyBodymon)
	{
		//allied bodymon 
		int ValueDamage = BodymonParameter.Muscleset.Biceps * 1,5 + BodymonParameter.Muscleset.Lat * 2 + BodymonParameter.Muscleset.Quad * 0,1;
		//enemy bodymon
		int ValueDamageFromEnemy = EnemyBodymon.Muscleset.Biceps * 0,5 + EnemyBodymon.Muscleset.Lat * 1 + EnemyBodymon.Muscleset.abdominals * 0,01;
		//total damage, that will be dealt to enemy 
		int TotalDamage = ValueDamage - ValueDamageFromEnemy;
		return TotalDamage;
	}

	public static int DorianEagle(Bodymon BodymonParameter, Bodymon EnemyBodymon)
	{
		//allied bodymon 
		int ValueDamage = BodymonParameter.Muscleset.Biceps * 1 + BodymonParameter.Muscleset.Lat * 1,5 + BodymonParameter.Muscleset.abdominals * 0,2;
		//enemy bodymon
		int ValueDamageFromEnemy = EnemyBodymon.Muscleset.Biceps * 0.5 + EnemyBodymon.Muscleset.Lat * 0.5 + EnemyBodymon.Muscleset.abdominals * 0.1;
		//total damage, that will be dealt to enemy 
		int TotalDamage = ValueDamage - ValueDamageFromEnemy;
		return TotalDamage;
	}

}
