using System;

    public class MuscleSet
    {
        private int defaultValue = 1;

        private int lat;
        private int chest;
        private int quads;
        private int biceps;


        public int Lat
        {
            get { return checkInt(lat); }
            set { lat = value; }
        }

        public int Chest
        {
            get { return checkInt(chest); }
            set { chest = value; }
        }

        public int Quads
        {
            get { return checkInt(quads); }
            set { quads = value; }
        }

        public int Biceps
        {
            get { return checkInt(biceps); }
            set { biceps = value; }
        }

        private int checkInt(int value)
        {
            if (value < 1 || value.Equals(null))
            {
                return defaultValue;
            }
            else
            {
                return value;
            }
        }
    }
