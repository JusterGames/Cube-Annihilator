using UnityEngine;

public class ItemDestroyer : MonoBehaviour
{
    public GameObject[] items;
    public GUIStyle style;

    void OnGUI()
    {
        // Check if all items have been destroyed
        bool allDestroyed = true;
        foreach (GameObject item in items)
        {
            if (item != null)
            {
                allDestroyed = false;
                break;
            }
        }

        // If all items have been destroyed, show win text in green
        if (allDestroyed)
        {
            GUI.color = Color.green;
            GUI.Label(new Rect(Screen.width/2 - 50, Screen.height/2 - 25, 100, 50), "You Won!", style);
        }
    }
}
