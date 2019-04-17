using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CsTitleScene : MonoBehaviour
{
    bool isHowToActive = false;
    bool isOptionActive = false;

    public GameObject howToPannel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GoInGame()
    {
        SceneManager.LoadScene("InGameScene");
    }
    public void GoShop()
    {
        SceneManager.LoadScene("ShopScene");
    }
    public void GoHowTo()
    {
        howToPannel.SetActive(true);
        isHowToActive = true;

    }
    public void PressBackButton()
    {
        if (isHowToActive == true)
        {
            howToPannel.SetActive(false);
            isHowToActive = false;
        }
        else if (isOptionActive == true)
        {

        }
    }
}
