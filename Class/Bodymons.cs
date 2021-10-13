using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bodymons
{
     public class Bodymons
    {
        private int defaultHp = 100;
        private string defaultName = "Mwenye Munyaradzi";
        private bool defaultowned = false;
        private MuscleSet defaultMuscleset = new MuscleSet();
        private int defaultPosingSkill = 1;

        private int hp;
        private string name;
        private bool owned;
        private MuscleSet muscles = new MuscleSet();
        private int posingSkill;



        public int PosingSkill
        {
            get
            {
                if (posingSkill == 0 || posingSkill.Equals(null))
                {
                    return defaultPosingSkill;
                }
                else
                {
                    return posingSkill;
                }
            }
            set { }
        }


        public int Hp
        {
            get
            {
                return hp;
            }
            set
            {
                if (hp == 0 || hp.Equals(null))
                {
                    hp = defaultHp;
                }
                else
                {
                    hp = value;

                }
            }
        }

        public string Name
        {
            get
            {
                if (String.IsNullOrEmpty(name))
                {
                    return defaultName;
                }
                else
                {
                    return name;
                }
            }
            set { name = value; }
        }

        public bool Owned
        {
            get
            {
                if (owned.Equals(null))
                {
                    return defaultowned;
                }
                else
                {
                    return owned;
                }
            }
            set { owned = value; }
        }

        public MuscleSet Muscles
        {
            get { return muscles; }
            set { muscles = value; }
        }
    }

    

    //ronnie.m.lat.value = 10;
}
