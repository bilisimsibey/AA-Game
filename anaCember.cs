using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anaCember : MonoBehaviour
{
    public GameObject kucukCember; //instantiate edilecek obje
    GameObject OyunYöneticisi;

    private void Start()
    {
        OyunYöneticisi = GameObject.FindGameObjectWithTag("oyunYöneticisi");
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1")) //mouse sol tusuna tıklandıgında
        {
            kucukCemberOlustur(); //fonksiyonu calistir
            OyunYöneticisi.GetComponent<oyunYoneticisi>().KucukCemberlerdeTextGosterme();
        }
    }

    void kucukCemberOlustur()
    {
        Instantiate(kucukCember,transform.position,transform.rotation); //bu scriptin bağlı olduğu objenin bulundugu konumda obje yarat

    }
}
