using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Delivery : MonoBehaviour
{
    [SerializeField]
    Sprite packagesprite,nopackage;

    private SpriteRenderer Sp;
    private Color mycolor;
    [SerializeField]
    private Color precolor=new Color(1,1,1,1);
    [SerializeField]
    private Sprite sp;
    bool x=false;
    AudioSource audio;
    [SerializeField] TextMeshProUGUI Score;
    [SerializeField] int counter = 0;

    /*  void OnCollisionEnter2D(Collision2D collision)
      {

          if (x)
          {
              Debug.Log("Package Delived!");
              Destroy(collision.gameObject);
          }

          else Debug.Log("Get Package First!!");

      }*/
    void OnTriggerEnter2D(Collider2D collision)
    {
        //rend = gameObject.GetComponent<Renderer>();
        //mycolor = new Color(244.9f, 10f, 0f, 0.1f);
        //rend.material.color = mycolor;
        //Debug.Log("Package Recived!");
        //x = true;
        //  Destroy(collision.gameObject);
        Sp = gameObject.GetComponent<SpriteRenderer>();

        
        if (collision.tag == "Package" && !x) {
            x = true;
            Destroy(collision.gameObject, 1f);

            Sp.sprite = packagesprite;
            Debug.Log("It was a package");
            audio =GetComponent<AudioSource>();
            audio.Play();
            counter++;
            Score.text = "Score "  +counter;
           

        }

        if(collision.tag == "Speed up")
        {

            Debug.Log("It was a speed up!");
           
        }

        if(collision.tag == "Customer" && x) {

            x = false;
            Debug.Log("Pakage dilevered");
            Sp.sprite = nopackage ; 

        }
        if(collision.tag == "GameObject") 
        {
            Debug.Log("Car is passing through GameObject");
            audio = GetComponent<AudioSource>();
            audio.Play();


        }





    }

}
