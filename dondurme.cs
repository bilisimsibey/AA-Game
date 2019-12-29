using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dondurme : MonoBehaviour
{
    public float hiz;

    private void Update()
    {
        transform.Rotate(0,0,hiz*Time.deltaTime); //z ekseninde donme islemis
    }

   
}
