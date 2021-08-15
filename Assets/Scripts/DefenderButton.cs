using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] GameObject defenderPrefab;

    private Color selectedColor = Color.white;
    private Color unselectedColor = Color.gray;

    private void Awake()
    {
        GetComponent<SpriteRenderer>().color = unselectedColor;
    }

    private void OnMouseDown()
    {
        UnselectAll();
        GetComponent<SpriteRenderer>().color = selectedColor;
        GameArea.Instance.defender = defenderPrefab;
    }

    private void UnselectAll()
    { 
        foreach (var button in FindObjectsOfType<DefenderButton>())
        {
            button.GetComponent<SpriteRenderer>().color = unselectedColor;
		}
	}
}
