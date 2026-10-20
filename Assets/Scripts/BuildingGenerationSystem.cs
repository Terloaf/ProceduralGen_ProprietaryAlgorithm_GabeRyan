using NUnit.Framework.Constraints;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class BuildingGenerationSystem : MonoBehaviour
{
    public GameObject building;
    public int setBuildingAmount;
    private Vector3 buildingPos;


    struct BoundingBox
    {
        public int Xmin;
        public int Xmax;
        public int Ymin;
        public int Ymax;

        public BoundingBox(int minX, int maxX, int minY, int maxY)
        {
            Xmin = minX;
            Xmax = maxX;
            Ymin = minY;
            Ymax = maxY;
            
        }
    }

  
    
    // Update is called once per frame
    void Update()
    {
       
    }

    public void Generate()
    {
        for(int i = 0; i < setBuildingAmount; i++)
        {
            int buildingx = Random.Range(-20, 20);
            int buildingz = Random.Range(-20, 20);
            int buildingScaleY = Random.Range(2, 50);
            int buildingScaleX = Random.Range(1, 3);
            int buildingscaleZ = Random.Range(1, 3);
            buildingPos = new Vector3(buildingx, 0, buildingz);
           
            
            Instantiate(building, buildingPos, default);

            building.transform.localScale = new Vector3(buildingScaleX, buildingScaleY, buildingscaleZ);
        }



    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == gameObject.CompareTag("Building"))
        {
            Debug.Log("regenerated");
            Destroy(building.gameObject);
            Generate();
        }
    }

    private void CheckPos()
    {

    }
}
