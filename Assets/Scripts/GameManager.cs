using System;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public static GameManager Instance { get; private set; }
  public string Name;
  private HighScore CurrentHighScore;

  private void Awake()
  {
    if(Instance != null)
    {
      Destroy(gameObject);
      return;
    }

    Instance = this;
    DontDestroyOnLoad(gameObject);
    LoadHighScoreFromFile();
  }

  public string GetHighScorerName()
  {
    return CurrentHighScore.name;
  }

  public int GetHighScorerScore()
  {
    return CurrentHighScore.score;
  }

  [Serializable]
  class HighScore
  {
    public string name = "";
    public int score = 0;
  }

  public void CheckAndSaveHighScore(int score)
  {
    if(score > CurrentHighScore.score)
    {
      // Save the new high score.
      CurrentHighScore.score = score;
      CurrentHighScore.name = Name;

      string highScoreJson = JsonUtility.ToJson(CurrentHighScore);
      File.WriteAllText(Application.persistentDataPath + "/highscore.json", highScoreJson);
    }
  }

  public void LoadHighScoreFromFile()
  {
    CurrentHighScore = new HighScore();
    if (File.Exists(Application.persistentDataPath + "/highscore.json"))
    {
      string fileContents = File.ReadAllText(Application.persistentDataPath + "/highscore.json");
      CurrentHighScore = JsonUtility.FromJson<HighScore>(fileContents);
    }
  }
}
