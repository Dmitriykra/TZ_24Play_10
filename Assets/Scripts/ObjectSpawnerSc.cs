using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnerSc : MonoBehaviour
{
    public GameObject ground;
    public float delay = 7f;
    List<GameObject> listOfGrounds = new List<GameObject>();

    void Start()
    {
        GameObject firstCube = Instantiate(ground, ground.transform.position, Quaternion.identity);
        listOfGrounds.Add(firstCube);
        StartCoroutine(SpawnCube());
        StartCoroutine(DestroyCube());
    }

    IEnumerator SpawnCube()
    {
        while (true)
        {
            Vector3 position;
            if(listOfGrounds.Count > 0)
            {
                GameObject lastCube = listOfGrounds[listOfGrounds.Count - 1];
                position = lastCube.transform.position;
                position.z -= 29f;
            }
            else 
            {
                position = ground.transform.position;
            }
            GameObject newCube = Instantiate(ground, position, Quaternion.identity) as GameObject;
            listOfGrounds.Add(newCube);
            yield return new WaitForSeconds(delay);
        }
    }

    IEnumerator DestroyCube()
    {
        while (true)
        {
            if(listOfGrounds.Count > 3)
            {
                GameObject cubeToDestroy = listOfGrounds[0];
                listOfGrounds.RemoveAt(0);
                Destroy(cubeToDestroy);
            }
            yield return new WaitForSeconds(7f);
        }
    }
}
