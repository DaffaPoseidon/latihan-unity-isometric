using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;

    private Vector3 moveDelta;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //Inputan untuk movement
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        moveDelta = new Vector3(x, y, 0);

        //Bergerak ke kanan
        if(moveDelta.x > 0)
        {
            transform.localScale = Vector3.one;
        }

        //Bergerak ke kiri
        else if(moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //Menggunakan Delta Time agar berjalan mulus di semua perangkat
        transform.Translate(moveDelta * Time.deltaTime);
    }
}
