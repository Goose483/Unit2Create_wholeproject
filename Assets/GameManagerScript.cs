using UnityEngine;
using TMPro;
public class GameManagerScript : MonoBehaviour
{
  [SerializeField] TMP_Text scoreText;
  [SerializeField] float score;


  private void Update()
  {
        score += (Time.deltaTime * 5) * 1;
        scoreText.text = "Score: " + score.ToString("F0");
  }
  
}
