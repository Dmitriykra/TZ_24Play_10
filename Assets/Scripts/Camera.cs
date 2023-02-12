using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    [SerializeField] Transform playerTransform;
    Vector3 offcet;
    Vector3 newPosition;
    float lerpValue = 1f;
    

    // Start is called before the first frame update
    void Start()
    {
        offcet = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        newPosition = Vector3.Lerp(transform.position, 
            new Vector3(0f, playerTransform.position.y,
                playerTransform.position.z) + offcet, lerpValue * Time.deltaTime);

        transform.position = newPosition;
    }
}
