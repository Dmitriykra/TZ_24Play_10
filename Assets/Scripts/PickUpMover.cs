using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpMover : MonoBehaviour
{
    [SerializeField] PlayerCollector playerCollector;
    private RaycastHit raycastHit;
    bool isCollide = false;
    private Vector3 direction = Vector3.forward;
        

    private float beerJarVol = 0.558f;

    // Start is called before the first frame update
    void Start()
    {
        playerCollector = GameObject.FindObjectOfType<PlayerCollector>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastSetter();
    }

    void RaycastSetter()
    {
        if(Physics.Raycast(transform.position, direction, out raycastHit, beerJarVol))
        {
            /*if(!isCollide)
            {
                isCollide = true;
                playerCollector.Increase(gameObject);
                SetDirection();
            }*/
            if(raycastHit.transform.tag == "CubeWall")
            {
                playerCollector.DecreaseBlock(gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(!isCollide)
            {
                isCollide = true;
                playerCollector.Increase(gameObject);
                SetDirection();
            }
    }

    private void SetDirection() {
        direction = Vector3.back;  
    }
}
