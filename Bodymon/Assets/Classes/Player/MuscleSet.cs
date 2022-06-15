using UnityEngine;

[System.Serializable]
public class MuscleSet
{
    public MuscleSet()
    {

    }
    public MuscleSet(double _lat, double _chest, double _quads, double _biceps, double _abdominals)
    {
        lat = _lat;
        chest = _chest;
        quads = _quads;
        biceps = _biceps;
        abdominals = _abdominals;
    }

    public double defaultValue = 1;
    private double maxValue = 100;

    public double lat;
    public double chest;
    public double quads;
    public double biceps;
    public double abdominals;

    
    public double MaxValue
    {
        get { return maxValue; }
    }

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
            if (value <= maxValue)
            {
                return value;
            }
            else
            {
                return maxValue;
            }
        }
    }
}
