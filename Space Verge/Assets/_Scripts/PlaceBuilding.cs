using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBuilding : MonoBehaviour
{
    public GameObject Building;

    public void Build()
    {
        Instantiate(Building);
        
    }
}
