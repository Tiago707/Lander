using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nave : MonoBehaviour
{
    [SerializeField]
    float maxRelativeVelocity = 2f;

    [SerializeField]
    float maxRotation = 10f;

    [SerializeField]
    float thrustForce = 150f;

    [SerializeField]
    float torqueForce = 25f;
    
    [SerializeField]
    float fuel = 500f;

    [SerializeField]
    float fuelburn = 10f;

    [SerializeField]
    float fuelburnTorque = 5f;

    [SerializeField]
    Rigidbody2D rigidbody;

    [SerializeField] 
    Text fueltxt;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (fuel > 0)
            {
                rigidbody.AddTorque(torqueForce * Time.deltaTime);
                fuel -= fuelburnTorque* Time.deltaTime;
            }        
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            if (fuel > 0)
            {
                rigidbody.AddTorque(-torqueForce * Time.deltaTime);
                fuel -= fuelburnTorque * Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            if (fuel > 0)
            {
                rigidbody.AddForce(transform.up * thrustForce * Time.deltaTime);
                fuel -= fuelburn * Time.deltaTime;
            }
        }
        fueltxt.text = fuel.ToString();
        if (fuel <= 0)
        {
            fueltxt.text = "0";
        } 
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.tag == "Platform")
       {
       //bati na plataforma
       Debug.Log("Aterrei na plataforma...");
       if (collision.relativeVelocity.magnitude > maxRelativeVelocity || Mathf.Abs(transform.localEulerAngles.z) > maxRotation)
       {
        Debug.Log("Mas rebentei!");
       }
      }else
      {
       Debug.Log("Bati na lua... explodi!");
      }
      
    }
}
