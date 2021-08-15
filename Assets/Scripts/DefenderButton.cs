using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender prefab;

    private Color selectedColor = Color.white;
    private Color unselectedColor = Color.black;

    private void Awake()
    {
        GetComponent<SpriteRenderer>().color = unselectedColor;
    }

    private void OnMouseDown()
    {
        UnselectAll();
        GetComponent<SpriteRenderer>().color = selectedColor;
        GameArea.Instance.SetSelectedDefender(prefab);
    }

    private void UnselectAll()
    { 
        foreach (var button in FindObjectsOfType<DefenderButton>())
        {
            button.GetComponent<SpriteRenderer>().color = unselectedColor;
		}
	}
}
