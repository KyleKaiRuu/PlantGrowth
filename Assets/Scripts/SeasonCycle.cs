using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SeasonCycle : MonoBehaviour
{
    public DateTime date;
    public int month;
    public enum SEASON
    {
        WINTER,
        SPRING,
        SUMMER,
        FALL
    }

    public SEASON season;

    public bool isSetWinter;

    private void Update()
    {
        if (!isSetWinter)
        {
            switch (DateTime.Now.Month)
            {
                case int n when ((n < 3) || (n < 11)):
                    season = SEASON.WINTER;
                    break;
                case int n when ((n > 3) && (n < 6)):
                    season = SEASON.SPRING;
                    break;
                case int n when ((n > 5) && (n < 9)):
                    season = SEASON.SUMMER;
                    break;
                case int n when ((n > 8) && (n < 12)):
                    season = SEASON.FALL;
                    break;
                default:
                    season = SEASON.SPRING;
                    break;
            }
        }
        else
        {
            season = SEASON.WINTER;
        }
    }
}
