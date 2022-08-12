using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    float donmeHizi;

    void Update() //y ekseninde (kendi etrafýnda) objenin dönüþü. her obje farklý biçimlerde dönebilir.
    {

        if (this.gameObject.tag == "sigara")
        {
            donmeHizi = 10;
            transform.Rotate(0, donmeHizi * 10f * Time.deltaTime, 0);
        }
        else if (this.gameObject.tag == "elma")
        {
            donmeHizi = 10;
            transform.Rotate(0, donmeHizi * 8f * Time.deltaTime, 0);
        }
        else if (this.gameObject.tag == "fastfood")
        {
            donmeHizi = 10;
            transform.Rotate(0, donmeHizi * 10f * Time.deltaTime, 0);
        }
        else if (this.gameObject.tag == "muz")
        {
            donmeHizi = 10;
            transform.Rotate(0, donmeHizi * 8f * Time.deltaTime, 0);
        }
        else if (this.gameObject.tag == "portakal")
        {
            donmeHizi = 10;
            transform.Rotate(0, donmeHizi * 6f * Time.deltaTime, 0);
        }
    }
}
