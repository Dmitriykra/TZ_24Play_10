using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{

    public static Menu menuManager;
    public bool gameState;
    public GameObject menuElement;
    // Start is called before the first frame update
    void Start()
    {
        gameState = false;
        menuManager = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        gameState = true;
        menuElement.SetActive(false);
    }

    public void PauseGame()
    {
        gameState = false;
        menuElement.SetActive(true);
    }
}
