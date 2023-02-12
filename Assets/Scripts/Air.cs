using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Air : MonoBehaviour
{
   [SerializeField] Transform playerTransform;
    Vector3 offcet;
    Vector3 newPosition;
    float lerpValue = 1f;
    public ParticleSystem air;

    // Start is called before the first frame update
    void Start()
    {
        var airEffect = air.main;
        airEffect.simulationSpeed = 10f;
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
