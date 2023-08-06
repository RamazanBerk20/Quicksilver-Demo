using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timeScaleText;

   private void Awake()
   {
        Cursor.lockState = CursorLockMode.Locked;
   }

    private void Update()
    {
        timeScaleText.text = "Time Scale: " + Time.timeScale.ToString("F2");
    }
}
