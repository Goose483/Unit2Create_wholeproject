using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public Vector3 leftDirection;
    public Vector3 rightDirection;

    public GameObject gameManager;

    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Transform>().position += leftDirection;
        }
        
        if(Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Transform>().position += rightDirection;
            
        }
    }
}
