using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject CreditsContainer;
    public GameObject MainMenuContainer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenCredits()
    {
        MainMenuContainer.SetActive(false);
        CreditsContainer.SetActive(true);
    }

    public void CloseCredits()
    {
        CreditsContainer.SetActive(false);
        MainMenuContainer.SetActive(true);
    }

}
