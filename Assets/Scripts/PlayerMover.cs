using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private float horizontalInput;
    private float frontPlayerSpeed = -7f;
    private float sidePlayerSpeed = -20f;
    private float sideBorders = 2f;
   
    void Update()
    {
        if(Input.GetMouseButton(0) && Menu.menuManager.gameState)
        {
            horizontalInput = Input.GetAxis("Mouse X");
            FrontMove();
            SideMove();
        }

        else 
        {
            horizontalInput = 0f;
        } 
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
