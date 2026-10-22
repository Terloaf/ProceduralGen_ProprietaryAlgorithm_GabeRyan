using JetBrains.Annotations;
using NUnit.Framework.Constraints;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildingGenerationSystem : MonoBehaviour
{
    public GameObject building;
    public GameObject street;
    public int setBuildingAmount;

    private Vector3 buildingPos;
    private Vector3 streetPos;

    private Vector3 halfExtents;
    public int streetRotation;

    public bool generationCompleted;


    // Update is called once per frame
    void Update()
    {
       
    }

    public void Generate()
    {
        if (generationCompleted == true) return;
        int streetx = Random.Range(-25, 25);
        streetPos = new Vector3(streetx, 0, 30);
        if (streetRotation == 0)
        {
            
            Instantiate(street, streetPos, default);
        }

        

        for(int i = 0; i < setBuildingAmount; i++)
        {
            int buildingx = Random.Range(-20, 20);
            int buildingz = Random.Range(-20, 20);
            int buildingScaleY = Random.Range(2, 50);
            int buildingScaleX = Random.Range(1, 3);
            int buildingscaleZ = Random.Range(1, 3);
            buildingPos = new Vector3(buildingx, 0, buildingz);
            halfExtents = new Vector3(buildingScaleX / 2, buildingScaleY / 2, buildingscaleZ / 2);
            building.transform.localScale = new Vector3(buildingScaleX, buildingScaleY, buildingscaleZ);

            Collider[] hitColliders = Physics.OverlapBox(buildingPos, halfExtents, default);


            if (hitColliders.Length == 0)
            {
                Instantiate(building, buildingPos, default);

            }

            else continue;
            


        }


        generationCompleted = true;
    }
    public void ResetGeneration()
    {
        SceneManager.LoadScene(0);
    }




}
