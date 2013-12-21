﻿using System;
using System.Text;

public enum BatteryType
{
    LiIon, NiMH, NiCd
}

public class Battery
{
    private BatteryType batteryModel;
    private int? hoursIdle;
    private int? hoursTalked;

    // constructors

    public Battery(BatteryType baterryModel)
        : this(baterryModel, null, null)
    {
    }

    public Battery(BatteryType baterryModel, int? hoursIdle)
        : this(baterryModel, hoursIdle, null)
    {
    }

    public Battery(BatteryType baterryModel, int? hoursIdle, int? hoursTalked)
    {
        this.BatteryModel = baterryModel;
        this.HoursIdle = hoursIdle;
        this.HoursTalked = hoursTalked;
    }

    // properties 

    public BatteryType BatteryModel
    {
        get { return this.batteryModel; }
        set { this.batteryModel = value; }
    }

    public int? HoursIdle
    {
        get { return this.hoursIdle; }
        set
        {
            if (value >= 0 || value == null)
            {
                this.hoursIdle = value;
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }

    public int? HoursTalked
    {
        get { return this.hoursTalked; }
        set
        {
            if (value >= 0 || value == null)
            {
                this.hoursTalked = value;
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }

    public override string ToString()
    {
        StringBuilder endText = new StringBuilder();
        endText.AppendLine("-------Battery---------");
        endText.AppendLine(this.batteryModel.ToString());
        endText.AppendLine(this.hoursIdle.ToString());
        endText.AppendLine(this.hoursTalked.ToString());
        return endText.ToString();
    }

}
