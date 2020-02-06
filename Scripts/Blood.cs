using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Blood : MonoBehaviour
{
    public Image OverlayImg;

    private float r;
    private float g;
    private float b;
    private float a;

    void Start()
    {
        r = OverlayImg.color.r;
        g = OverlayImg.color.g;
        b = OverlayImg.color.b;
        a = OverlayImg.color.a;


    }

    // Update is called once per frame
    void Update()
    {
         if (HealthBarScript.health <10f)
        {
            OverlayImg.color = new Color(r, g, b, 1f);
        }
        else  if (HealthBarScript.health < 20f)
        {
            OverlayImg.color = new Color(r, g, b, 0.8f);
        }
        else if (HealthBarScript.health < 30f)
        {
            OverlayImg.color = new Color(r, g, b, 0.6f);
        }
        else if (HealthBarScript.health < 40f)
        {
            OverlayImg.color = new Color(r, g, b,0.4f );
        }
        else if (HealthBarScript.health < 50f)
        {
            OverlayImg.color = new Color(r, g, b, 0.2f);
        }
        else if (HealthBarScript.health >= 50f)
        {
            OverlayImg.color = new Color(r, g, b, 0.0f);
        }

    }
 
}
