using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour
{
    public Vector3 speed;
    public Vector3 speedOpposite;
    public Vector3 up;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(StartMoving());
    }

    IEnumerator StartMoving()
    {

        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.2f);
            GetComponent<Transform>().position += speed;
        }
        GetComponent<Transform>().position += up;
        for (int i = 0; i < 6; i++)
        {
            yield return new WaitForSeconds(0.2f);
            GetComponent<Transform>().position += speedOpposite;
        }
        GetComponent<Transform>().position += up;
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.2f);
            GetComponent<Transform>().position += speed;
        }
        GetComponent<Transform>().position += up;
        StartCoroutine(StartMoving());
    }

     /*void OnCollisionEnter2D(Collision2D collision)
     {
        if (collision.gameObject.CompareTag("reset"))
        {
            Debug.Log("reset: " + collision.gameObject.name);
        }
     }*/
     
     private Vector3 originalPosition;

        void Awake()
        {
            originalPosition = transform.position;
        }

        public void ResetPosition()
        {
            transform.position = originalPosition; // Reset to the stored original position
        }
}
