using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientodeobjeto : MonoBehaviour
{
    public float velocidad = 5.0f;

    public int puntoLimiteDerecha = 1220;
    public int  puntoLimiteIzquierda = -1432;

    private bool moviendoDerecha = true;

    void Update()
    {
        if (moviendoDerecha)
        {
            transform.Translate(velocidad * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.Translate(-velocidad * Time.deltaTime, 0, 0);
        }

        if (transform.position.x >= puntoLimiteDerecha)
        {
            moviendoDerecha = false;
        }
        else if (transform.position.x <= puntoLimiteIzquierda)
        {
            moviendoDerecha = true;
        }
    }
}
