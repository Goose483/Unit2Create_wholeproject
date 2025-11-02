using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public Vector3 leftDirection;
    public Vector3 rightDirection;
    public float screenLimitX = 8f; // adjust to your screen width

    void Update()
    {
        Vector3 pos = transform.position;

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            pos += leftDirection;
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            pos += rightDirection;
        }

        // clamp x so player can't go offscreen
        pos.x = Mathf.Clamp(pos.x, -screenLimitX, screenLimitX);

        transform.position = pos;
    }
}
