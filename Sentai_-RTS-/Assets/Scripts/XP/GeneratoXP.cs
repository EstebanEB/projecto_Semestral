using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneratoXP : MonoBehaviour
{
    public Text CurrentLevelTXT;
    public Text PointsToLevelUpTXT;

    public Slider barXP;

    public float CurrentLevel = 0;
    public float NextLevel = 0;
    public float PointsNextLevel = 0;
    public float remainingPoints = 0;
    public float CurrentPoints = 0;
	
	void Start ()
    {
        NextLevel = CurrentLevel + 1;
        PointsToLevelUp(NextLevel);
        CalculateLevel(CurrentLevel);
	}
	
    public void PointsToLevelUp( float Level)
    {
        //x elevado al 2/10
        PointsNextLevel = (Mathf.Pow((Level), 2) / 10);
        PointsToLevelUpTXT.text = "" + PointsNextLevel * 100;
        barXP.maxValue = PointsNextLevel * 100;

        if (remainingPoints > 0)
        {
            barXP.value = remainingPoints * 100;
        }
        else
        {
            barXP.value = 0;
        }
    }

    public void CalculateLevel(float pointsObtained)
    {
        CurrentPoints *= 100;
        CurrentPoints += pointsObtained;
        if (remainingPoints > 0)
        {
            CurrentPoints += (remainingPoints * 100);
            remainingPoints = 0;
        }

        barXP.value = CurrentPoints;

        CurrentPoints /= 100;
        float currentLvlTemp = Mathf.Sqrt(CurrentPoints * 10);

        if (currentLvlTemp >= NextLevel)
        {
            if (CurrentPoints > PointsNextLevel)
            {
                remainingPoints = CurrentPoints - PointsNextLevel;
            }
            NextLevel ++;
            PointsToLevelUp(NextLevel);
            CurrentLevel = currentLvlTemp;
            CurrentLevelTXT.text = "" + CurrentLevel;
            CurrentPoints = 0;
        }
    }
}
