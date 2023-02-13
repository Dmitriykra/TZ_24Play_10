using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    public GameObject prefabWall;
    float positionZ = 15f;
    float positionX = 2f;
    float newZ_pos = 1f;
    float timePassed = 0f;
    float activeTime = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        CreatNewWallSet();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            if(timePassed >= activeTime)
            {
                CreatNewWallSet();
                timePassed = 0;
                newZ_pos++;
            }
            timePassed += Time.deltaTime;
            DestroyWall();
        }
    }

    void DestroyWall(){
        GameObject[] walls = GameObject.FindGameObjectsWithTag("CubeWall");
        foreach (GameObject wall in walls)
        {
            if (wall.transform.position.z > 
                UnityEngine.Camera.main.WorldToScreenPoint(transform.position).z)
            {
                Destroy(wall, 2f);
            }
        }
    }

    void InstantiateWallBlock(float x, float y)
    {
        Instantiate(prefabWall, new Vector3(x, y, positionZ), Quaternion.identity);
    }

    public void CreatNewWallSet(){
        
        for(int i = 0; i<newZ_pos; i++)
        {
            positionZ = positionZ -20+newZ_pos;
        }
        
        //1 block
        int randomBlockNumber_1 = Random.Range(1, 5);
        for(int i = 0; i<randomBlockNumber_1; i++)
        {
            float positionX = 2f;
            float yPos = i;
            InstantiateWallBlock(positionX, yPos);
            //GameObject wall_1 = Instantiate(prefabWall, new Vector3(positionX, yPos, positionZ), Quaternion.identity);
            //wall_1.name = "wall_1";
        }    

        //2 block
        int randomBlockNumber_2 = Random.Range(1, 5);
        for(int i = 0; i<randomBlockNumber_2; i++)
        {
            float yPos = i;
            positionX = 1f;
            InstantiateWallBlock(positionX, yPos);
        }

        //3 block
        int randomBlockNumber_3 = Random.Range(1, 5);
        for(int i = 0; i<randomBlockNumber_3; i++)
        {
            float yPos = i;
            positionX = 0f;
            InstantiateWallBlock(positionX, yPos);
        }

        //4 block
        int randomBlockNumber_4 = Random.Range(1, 5);
        for(int i = 0; i<randomBlockNumber_4; i++)
        {
            float yPos = i;
            positionX = -1f;
            InstantiateWallBlock(positionX, yPos);
        }

        //5 block
        int randomBlockNumber_5 = Random.Range(1, 5);
        for(int i = 0; i<randomBlockNumber_5; i++)
        {
            float yPos = i;
            positionX = -2f;
            InstantiateWallBlock(positionX, yPos);
        }
    }
}
