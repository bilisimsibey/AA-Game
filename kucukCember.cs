using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kucukCember : MonoBehaviour
{
    Rigidbody2D rb;
    public int hiz;
    bool hareketKontrol = false;

    GameObject oyunYöneticisi;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //rigidbody özelligi depolandi
        oyunYöneticisi = GameObject.FindGameObjectWithTag("oyunYöneticisi");
    }

    private void FixedUpdate()
    {
        if (!hareketKontrol) //false ise
        {
            rb.MovePosition(rb.position + Vector2.up * hiz * Time.deltaTime);//moveposition taşı anlamında, vector2 değeri alıyor.
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="donenCember")
        {
            transform.SetParent(collision.transform);//değen objenin child i olmasini sagliyor
            hareketKontrol = true;
        }
        if (collision.gameObject.tag=="kucukCember")
        {
            oyunYöneticisi.GetComponent<oyunYoneticisi>().OyunBitti(); //baska scriptten fonksiyon cagrildi
        }
    }


}
