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

    public List<GameObject> nearbyPlants = new List<GameObject>();

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
            plantGrowthComp.nearbyPlants = new List<GameObject>();
            HybridChance();

            Destroy(gameObject);
        }
    }

    void HybridChance()
    {
        int rand = Random.Range(0, 2);
        if (rand == 0)
        {
            PlantData thisObjData = gameObject.GetComponent<PlantData>();
            if (thisObjData.hybridsPossible.Count != 0)
            {
                for (int i = 0; i < thisObjData.hybridsPossible.Count; i++)
                {
                    PlantData temp = thisObjData.hybridsPossible[i].gameObject.GetComponent<PlantData>();
                    for (int j = 0; j < temp.parents.Count; j++)
                    {
                        if (thisObjData.hybridsPossible[i].GetComponent<PlantData>().parents[j].gameObject.GetComponent<PlantData>().plantSpecies == thisObjData.plantSpecies
                            && thisObjData.hybridsPossible[i].GetComponent<PlantData>().parents[j].gameObject.GetComponent<PlantData>().plantColor == thisObjData.plantColor)
                        {
                            if (nearbyPlants != null)
                            {
                                for (int k = 0; k < nearbyPlants.Count; k++)
                                {
                                    for (int m = 0; m < nearbyPlants[k].gameObject.GetComponent<PlantData>().hybridsPossible[i].GetComponent<PlantData>().parents.Count; m++)
                                    {
                                        if (nearbyPlants[k].gameObject.GetComponent<PlantData>().hybridsPossible[i].GetComponent<PlantData>().parents[m].gameObject.GetComponent<PlantData>().plantSpecies == nearbyPlants[k].GetComponent<PlantData>().plantSpecies
                                            && nearbyPlants[k].gameObject.GetComponent<PlantData>().hybridsPossible[i].GetComponent<PlantData>().parents[m].gameObject.GetComponent<PlantData>().plantColor == nearbyPlants[k].GetComponent<PlantData>().plantColor)
                                        {
                                            Debug.Log("Instantiated Hybrid");

                                            Instantiate(thisObjData.hybridsPossible[i]);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(gameObject.tag))
        {
            if (!nearbyPlants.Contains(other.gameObject))
            {
                nearbyPlants.Add(other.gameObject);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(gameObject.tag))
        {
            if (!nearbyPlants.Contains(other.gameObject))
            {
                nearbyPlants.Add(other.gameObject);
            }
        }
    }
}
