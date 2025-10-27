using UnityEngine;
using TMPro;
public class GameManagerScript : MonoBehaviour
{
  [SerializeField] TMP_Text scoreText;
  [SerializeField] float score;

  private void Update()
  {
        score =+ 1; 
        scoreText = score.ToString;
  }
}
