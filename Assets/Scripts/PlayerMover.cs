using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private float horizontalInput;
    private float frontPlayerSpeed = -7f;
    private float sidePlayerSpeed = -70f;
    private float sideBorders = 2f;
   

    // Update is called once per frame
    void Update()
    {
    
        if(Input.GetMouseButton(0))
        {
            horizontalInput = Input.GetAxis("Mouse X");
        }

        else 
        {
            horizontalInput = 0f;
        } 

        FrontMove();
        SideMove();
    }

    private void FrontMove()
    {
        transform.Translate(Vector3.forward * 
            frontPlayerSpeed * Time.deltaTime);
    }

    private void SideMove()
    {
        float xAxisMove = transform.position.x + 
            horizontalInput * sidePlayerSpeed * Time.deltaTime;

        xAxisMove = Mathf.Clamp(xAxisMove, -sideBorders, sideBorders);    

        transform.position = new Vector3(xAxisMove, 
            transform.position.y, transform.position.z);
    }



}
