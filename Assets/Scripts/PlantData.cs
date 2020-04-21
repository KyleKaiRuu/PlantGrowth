using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantData : MonoBehaviour
{
    public string plantSpecies;
    public string plantColor;
    public bool isHybrid;

    public List<GameObject> parents;
    public List<GameObject> hybridsPossible;
}
