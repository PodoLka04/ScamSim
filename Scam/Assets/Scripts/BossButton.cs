using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class BossButton : MonoBehaviour
{
    public GameObject panel2ToRemove;
    public GameObject panel3ToRemove;
    public GameObject panel4ToRemove;

    public void Update()
    {
        if ((Data.Instance.hitrost >= 2) && (Data.Instance.boss1Win))
        {
            panel2ToRemove.SetActive(false);
        }
        if ((Data.Instance.hitrost >= 3) && (Data.Instance.boss2Win))
        {
            panel3ToRemove.SetActive(false);
        }
        if ((Data.Instance.hitrost >= 4) && (Data.Instance.boss3Win))
        {
            panel4ToRemove.SetActive(false);
        }
    }
    /* public GameObject BossPan1;

    void Start()
    {
        BossPan1.SetActive(false);
    }

    public void ShowAndHideBoss1Pan()//----------------2
    {
        BossPan1.SetActive(!BossPan1.activeSelf);
    }*/


    /*public void Clickk()
    {
        if (Data.Instance.Getboss1Win() == false)
        {
            SceneManager.LoadScene("Boss");
        }

        if (Data.Instance.Getboss1Win() == true && Data.Instance.Getboss2Win() == false)
        {
            SceneManager.LoadScene("Boss 1");
        }
        
        if (Data.Instance.Getboss2Win() == true && Data.Instance.Getboss2Win() == true)
        {
            SceneManager.LoadScene("Boss 2");
        }

        if (Data.Instance.Getboss3Win() == true)
        {
            SceneManager.LoadScene("Boss 3");
        }
    }*/

    public void boss1Button()
    {
        if (Data.Instance.hitrost >= 1)
        {
            SceneManager.LoadScene("Boss");
        }
    }
    public void boss2Button()
    {
        if (Data.Instance.hitrost >= 2)
        {
            SceneManager.LoadScene("Boss 1");
        }
    }
    public void boss3Button()
    {
        if (Data.Instance.hitrost >= 3)
        {
            SceneManager.LoadScene("Boss 2");
        }
    }
    public void boss4Button()
    {
        if (Data.Instance.hitrost == 4)
        {
            SceneManager.LoadScene("Boss 3");
        }
    }
}
