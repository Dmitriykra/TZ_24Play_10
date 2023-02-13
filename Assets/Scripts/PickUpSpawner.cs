using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    public GameObject prefabCube;


    float xCoord = 2f;
    float yCoord = 0.5f;
    float zCoordMin = 15f;
    float zCoordMax = 0f;
    float distanceBetweenCubes = 1f;
    float newZ_pos = 0f;
    int constZ = -15;
    float timePassed = 0f;
    float activeTime = 2f;


   void Start()
   {
        //CreatNewCubeSet();
   }

    void CreatNewCubeSet()
    {
        for(int i = 0; i<newZ_pos; i++)
        {
            zCoordMin = zCoordMin+constZ;
            zCoordMax = zCoordMax+constZ;
        }
        for (int i = 0; i < 3; i++)
        {
            GameObject cube = Instantiate(prefabCube);
            cube.transform.position = new Vector3(Random.Range(
                xCoord, -xCoord), yCoord, Random.Range(
                    zCoordMin, zCoordMax));          
        }   
    }

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
        if(timePassed >= activeTime)
            {
                CreatNewCubeSet();
                timePassed = 0;
                newZ_pos++;
            }
            timePassed += Time.deltaTime;
        
        DestroyPickUp();
        }  
    } 

    void DestroyPickUp()
    {  
        foreach (GameObject cube in GameObject.FindGameObjectsWithTag("Cube"))
        {
            if (cube.transform.position.z > 
                UnityEngine.Camera.main.WorldToScreenPoint(transform.position).z)
            {
                Destroy(cube);
            }
        }
    }
}
