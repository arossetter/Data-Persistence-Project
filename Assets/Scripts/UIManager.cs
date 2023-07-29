using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
  private void Start()
  {
    // Update the high score, if we can.
    if(GameManager.Instance.GetHighScorerName() != "")
    {
      GameObject.Find("High Score Text").GetComponent<TextMeshProUGUI>().text = "High Score: " + GameManager.Instance.GetHighScorerName() + ": " + GameManager.Instance.GetHighScorerScore();
    }
  }

  public void OnStartGame()
  {
    SceneManager.LoadScene(1);
  }
  public void OnQuitGame()
  {
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
  }
}
