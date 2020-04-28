using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DaylightCycle : MonoBehaviour
{
    public bool testing;

    public enum TIMEOFDAY
    {
        MORNING,
        DAY,
        EVENING,
        NIGHT
    }

    public TIMEOFDAY timeOfDay;

    public DateTime time;

    public int hour;

    private int nightHour;
    private int dayHour;
    private int morningHour;
    private int eveningHour;

    public bool isSet;

    public bool nightSet;

    private SeasonCycle seasonCycle;
    SeasonCycle.SEASON season;
    private void Awake()
    {
        if(TryGetComponent(out SeasonCycle _sc))
        {
            seasonCycle = _sc;
        }
        if (seasonCycle != null)
        {
            season = seasonCycle.season;
            switch (season)
            {
                case SeasonCycle.SEASON.WINTER:
                    morningHour = 7;
                    dayHour = 11;
                    eveningHour = 17;
                    nightHour = 19;
                    break;
                case SeasonCycle.SEASON.SPRING:
                    morningHour = 5;
                    dayHour = 10;
                    eveningHour = 17;
                    nightHour = 20;
                    break;
                case SeasonCycle.SEASON.SUMMER:
                    morningHour = 4;
                    dayHour = 9;
                    eveningHour = 17;
                    nightHour = 20;
                    break;
                case SeasonCycle.SEASON.FALL:
                    morningHour = 6;
                    dayHour = 10;
                    eveningHour = 18;
                    nightHour = 19;
                    break;
                default:
                    morningHour = 7;
                    dayHour = 10;
                    eveningHour = 17;
                    nightHour = 19;
                    break;
            }

            CheckTime();
        }
    }

    private void Update()
    {
        {
            CheckTime();
        }
    }

    void CheckTime()
    {
        if (!isSet)
        {
            time = DateTime.Now;
            if (!testing)
            {
                hour = time.Hour;
            }

            switch (hour)
            {
                case int n when ((hour >= morningHour) && (hour <= dayHour)):
                    timeOfDay = TIMEOFDAY.MORNING;
                    break;
                case int n when (hour >= dayHour && hour <= eveningHour):
                    timeOfDay = TIMEOFDAY.DAY;
                    break;
                case int n when (hour >= eveningHour && hour <= nightHour):
                    timeOfDay = TIMEOFDAY.EVENING;
                    break;
                default:
                    timeOfDay = TIMEOFDAY.NIGHT;
                    break;
            }
        }
        else
        {
            if (nightSet)
            {
                timeOfDay = TIMEOFDAY.NIGHT;
            }
            else
            {
                timeOfDay = TIMEOFDAY.DAY;
            }
        }
    }
}
