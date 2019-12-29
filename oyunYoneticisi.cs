using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class oyunYoneticisi : MonoBehaviour
{
    GameObject donenCember;
    GameObject anaCember;
    public Animator animator;

    public Text donenCemberLevel;

    public Text bir, iki, uc;

    public int kacTaneKücükCemberOlsun;

    bool kontrol = true;
    private void Start()
    {
        PlayerPrefs.SetInt("kayit", int.Parse((SceneManager.GetActiveScene().name)));

        donenCember = GameObject.FindGameObjectWithTag("donenCember"); //gameobject sınıfından tag'a gore objeyi bulup değeri depolandı
        anaCember = GameObject.FindGameObjectWithTag("anaCember");//gameobject sınıfından tag'a gore objeyi bulup değeri depolandı
        donenCemberLevel.text = SceneManager.GetActiveScene().name; //text'e kacinci levelde isek level numarası atanıyor
        if (kacTaneKücükCemberOlsun<2) //kücük cember sayısı 2den kücük ise
        {
            bir.text = kacTaneKücükCemberOlsun.ToString(); //birinci text'e kücük cember sayısını ata

        }
        else if (kacTaneKücükCemberOlsun<3)
        {
            bir.text = kacTaneKücükCemberOlsun.ToString();
            iki.text = (kacTaneKücükCemberOlsun-1).ToString();
        }
        else
        {
            bir.text = kacTaneKücükCemberOlsun.ToString();
            iki.text = (kacTaneKücükCemberOlsun - 1).ToString();
            uc.text = (kacTaneKücükCemberOlsun - 2).ToString();

        }
    }

    public void KucukCemberlerdeTextGosterme()
    {
        kacTaneKücükCemberOlsun--;
        if (kacTaneKücükCemberOlsun < 2)
        {
            bir.text = kacTaneKücükCemberOlsun.ToString();
            iki.text = "";
            uc.text = "";

        }
        else if (kacTaneKücükCemberOlsun < 3)
        {
            bir.text = kacTaneKücükCemberOlsun.ToString();
            iki.text = (kacTaneKücükCemberOlsun - 1).ToString();
            uc.text = "";
        }
        else
        {
            bir.text = kacTaneKücükCemberOlsun.ToString();
            iki.text = (kacTaneKücükCemberOlsun - 1).ToString();
            uc.text = (kacTaneKücükCemberOlsun - 2).ToString();

        }

        if (kacTaneKücükCemberOlsun==0)
        {
            StartCoroutine(YeniLevel());
        }

    }

    IEnumerator YeniLevel()
    {
        donenCember.GetComponent<dondurme>().enabled = false; //değişkene getcomponent ile scripti etkisizleştirildi
        anaCember.GetComponent<anaCember>().enabled = false;//değişkene getcomponent ile scripti etkisizleştirildi
        yield return new WaitForSeconds(1.5f); // 1 saniye bekletiyoruz
        if (kontrol)
        {
            animator.SetTrigger("yeniLevel"); //oyunbitti isimli trigger(koşul) saglanan animasyonu calistir
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(int.Parse(SceneManager.GetActiveScene().name) + 1); //int parse ile string degeri int e dönüstürüp sonra ki level icin mevcut level adina 1 ekliyoruz
        }

        
    }
    public void OyunBitti()
    {
        StartCoroutine(cagrilanMetod()); //coroutine cagriyoruz calistiriyoruz
    }
    IEnumerator cagrilanMetod()
    {
        donenCember.GetComponent<dondurme>().enabled = false; //değişkene getcomponent ile scripti etkisizleştirildi
        anaCember.GetComponent<anaCember>().enabled = false;//değişkene getcomponent ile scripti etkisizleştirildi
        animator.SetTrigger("oyunbitti"); //oyunbitti isimli trigger(koşul) saglanan animasyonu calistir
        kontrol = false;
        yield return new WaitForSeconds(1); // 1 saniye bekletiyoruz     
        SceneManager.LoadScene("anaMenu"); //anaMenu sahnesine git
    }
}
