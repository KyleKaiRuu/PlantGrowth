using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrowth : MonoBehaviour
{
    public enum GROWTHSTAGE
    {
        SPROUT,
        YOUNGLING,
        ADULT,
        ELDER
    };

    public GROWTHSTAGE currentStage = GROWTHSTAGE.SPROUT;
    public GROWTHSTAGE temp = GROWTHSTAGE.SPROUT;

    public int currentStageInt = 0;

    public float timer;

    public float timeBetweenStages;

    public GameObject younglingObject;
    public GameObject adultObject;
    public GameObject elderObject;

    private void Update()
    {
        if (currentStage != GROWTHSTAGE.ELDER)
        {
            timer += Time.deltaTime;
            if (timer >= timeBetweenStages)
            {
                currentStageInt++;
                timer = 0;
            }

            switch (currentStageInt)
            {
                case 1:
                    currentStage = GROWTHSTAGE.YOUNGLING;
                    break;
                case 2:
                    currentStage = GROWTHSTAGE.ADULT;
                    break;
                case 3:
                    currentStage = GROWTHSTAGE.ELDER;
                    break;
                default:
                    currentStage = GROWTHSTAGE.SPROUT;
                    break;
            }
            if (temp != currentStage)
            {
                StageChange();
            }
        }
        
    }

    void StageChange()
    {
        GameObject spawned = null;
        switch (currentStage)
        {
            case GROWTHSTAGE.YOUNGLING:
                spawned = Instantiate(younglingObject, gameObject.transform.position, Quaternion.identity);
                break;
            case GROWTHSTAGE.ADULT:
                spawned = Instantiate(adultObject, gameObject.transform.position, Quaternion.identity);
                break;
            case GROWTHSTAGE.ELDER:
                spawned = Instantiate(elderObject, gameObject.transform.position, Quaternion.identity);
                break;
            default:
                break;
        }

        if (spawned != null)
        {
            PlantGrowth plantGrowthComp = spawned.AddComponent<PlantGrowth>();
            plantGrowthComp.timeBetweenStages = timeBetweenStages;
            plantGrowthComp.currentStage = currentStage;
            plantGrowthComp.currentStageInt = currentStageInt;
            plantGrowthComp.temp = currentStage;
            plantGrowthComp.younglingObject = younglingObject;
            plantGrowthComp.adultObject = adultObject;
            plantGrowthComp.elderObject = elderObject;
            Destroy(gameObject);
        }
    }
}
