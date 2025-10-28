using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    void Start()
    {
        StartCorutine(StartMoving());
    }

    IEnumerator StartMoving()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.2f);
            GetComponent<Transorm>().position += speed;
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
        StartCorutine(StartMoving());
    }
}
