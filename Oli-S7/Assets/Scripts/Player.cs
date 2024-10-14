using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 500.0f;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Debug.Log("Horizontal: " +horizontal+ " Vertical: " +vertical);
        
        this.transform.Translate(new Vector3(horizontal, 0,vertical) * Time.deltaTime);
    }
}
