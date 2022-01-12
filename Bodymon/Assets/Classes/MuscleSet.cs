using System;

    public class MuscleSet
    {
        private double defaultValue = 1;

        private double lat;
        private double chest;
        private double quads;
        private double biceps;
        private double abdominals;


        public double Lat
        {
            get { return checkDouble(lat); }
            set { lat = value; }
        }

        public double Chest
        {
            get { return checkDouble(chest); }
            set { chest = value; }
        }

        public double Quads
        {
            get { return checkDouble(quads); }
            set { quads = value; }
        }

        public double Biceps
        {
            get { return checkDouble(biceps); }
            set { biceps = value; }
        }

    public double Abdominals
    {
        get { return checkDouble(abdominals); }
        set { abdominals = value; }
    }


    //private int checkInt(int value)
    //    {
    //        if (value < 1 || value.Equals(null))
    //        {
    //            return defaultValue;
    //        }
    //        else
    //        {
    //            return value;
    //        }
    //    }

    private double checkDouble(double value)
    {
        if (value.Equals(null))
        {
            return defaultValue;
        }
        else
        {
            return value;
        }
    }
}
