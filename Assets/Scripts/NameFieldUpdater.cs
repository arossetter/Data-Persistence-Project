using TMPro;
using UnityEngine;

public class NameFieldUpdater : MonoBehaviour
{
  TMP_InputField inputField;
  // Start is called before the first frame update
  void Start()
  {
    inputField = gameObject.GetComponent<TMP_InputField>();
    inputField.text = GameManager.Instance.Name;
  }

  public void OnNameChanged()
  {
    GameManager.Instance.Name = inputField.text;
  }
}
