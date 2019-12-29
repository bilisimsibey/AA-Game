using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuControl : MonoBehaviour
{

    private void Start()
    {
        //PlayerPrefs.DeleteAll();
    }

    public void oyunaBasla()
    {
        int kayitliLevel = PlayerPrefs.GetInt("kayit");

        if (kayitliLevel==0)
        {
            SceneManager.LoadScene(kayitliLevel+1);
        }
        else
        {
            SceneManager.LoadScene(kayitliLevel);
        }
        

    }

    public void oyundanCik()
    {
        Application.Quit(); //oyundan cikis

    }
}
