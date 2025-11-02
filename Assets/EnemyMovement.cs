using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 1f; // horizontal speed
    public float verticalSpeed = 0.5f; // vertical speed
    public float sideDistance = 3f; 
    public float screenLimitX = 8f; 
    public float topLimitY = 0.5f; 
    public float bottomLimitY = -4f;

    bool movingRight = true;
    bool movingUp = true;

    void Start()
    {
        StartCoroutine(MovePattern());
    }

    IEnumerator MovePattern()
    {
        while (true)
        {
            Vector3 startPos = transform.position;
            Vector3 targetPos = startPos + (movingRight ? Vector3.right : Vector3.left) * sideDistance;
            targetPos.x = Mathf.Clamp(targetPos.x, -screenLimitX, screenLimitX);

            float t = 0;
            while (t < 1f)
            {
                t += Time.deltaTime * moveSpeed;
                float newX = Mathf.Lerp(startPos.x, targetPos.x, t);

                // move up or down smoothly
                float newY = transform.position.y + (movingUp ? verticalSpeed : -verticalSpeed) * Time.deltaTime;
                newY = Mathf.Clamp(newY, bottomLimitY, topLimitY);

                transform.position = new Vector3(newX, newY, transform.position.z);

                // flip vertical direction if hitting top/bottom
                if (newY >= topLimitY) movingUp = false;
                if (newY <= bottomLimitY) movingUp = true;

                yield return null;
            }

            // flip horizontal direction
            movingRight = !movingRight;
        }
    }
}
