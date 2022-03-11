using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
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

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        // (Sumbu Y) Bergerak dengan Box Racyast, jika membalikkan null maka bisa bergerak jika tidak maka tak bisa bergerak
        if(hit.collider == null)
        {
            //Menggunakan Delta Time agar berjalan mulus di semua perangkat
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        // (Sumbu X) Bergerak dengan Box Racyast, jika membalikkan null maka bisa bergerak jika tidak maka tak bisa bergerak
        if (hit.collider == null)
        {
            //Menggunakan Delta Time agar berjalan mulus di semua perangkat
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
    }
}
