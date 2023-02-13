using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    public List<GameObject> blockList = new List<GameObject>();
    public GameObject lastBlock;
    float upHeight = 1.1f; 
    public float y; 
    int pickCounter = 0;
    public GameObject textPlusOne;
    float timePassed = 0;
    [SerializeField] public Animator Animator;
    [SerializeField] public Rigidbody[] AllRigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        //blockList 
        AddCubeToBottom();
        textPlusOne.SetActive(false);
        StayOnCube();
    }

    void StayOnCube()
    {
        for(int i = 0; i < AllRigidbody.Length; i++)
        {
            AllRigidbody[i].isKinematic = true;
        }
        
    }

    // Update is called once per frame
    public void Increase(GameObject _gameObject)
    {
        transform.position = new Vector3(transform.position.x,
            transform.position.y,  transform.position.z - upHeight);

        _gameObject.transform.position = new Vector3(lastBlock.transform.position.x,
            lastBlock.transform.position.y - upHeight, lastBlock.transform.position.z);

        _gameObject.transform.SetParent(transform);

        blockList.Add(_gameObject);

        AddCubeToBottom();
        
        pickCounter++;
        Debug.Log(pickCounter);

        for(int i = 0; i<pickCounter; i++)
        {
            textPlusOne.SetActive(true);
            Invoke("hide", 1f);
        }
        
    }

    void hide()
    {
        textPlusOne.SetActive(false);
    }

    public void DecreaseBlock(GameObject _gameObject)
    {
        _gameObject.transform.parent = null;
        blockList.Remove(_gameObject);
        AddCubeToBottom();
        Destroy(_gameObject, 3f);
    }

    private void AddCubeToBottom()
    {
        lastBlock = blockList[blockList.Count - 1];
    }
}
