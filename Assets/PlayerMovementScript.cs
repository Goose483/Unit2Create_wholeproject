using UnityEngine;

public class PlayerMovementScript:MonoBehaviour
{
    public Vector3 leftDirection;
    public Vector3 rightDirection;

    public GameObject gameManager;

    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            GetComponent<Transform>().position += leftDirection;
        }
        
        if(Input.GetKey(KeyCode.D))
        {
            GetComponent<Transform>().position += rightDirection;
            
        }
    }
}
