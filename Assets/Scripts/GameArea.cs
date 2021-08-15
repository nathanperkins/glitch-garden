using UnityEngine;

public class GameArea : MonoBehaviour
{
    public static GameArea Instance;
    public GameObject defender;

    private void Awake()
    {
        Instance = this;
    }

    private void OnMouseDown()
    {
        SpawnDefender(SquareClicked());
    }

    private Vector2 SquareClicked()
    {
        Vector2 clickPos = Input.mousePosition;
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
	}

    private Vector2 SnapToGrid(Vector2 point)
    { 
        return new Vector2(
            x: Mathf.RoundToInt(point.x),
            y: Mathf.RoundToInt(point.y)
        );
	}

    private void SpawnDefender(Vector2 point)
    {
        Debug.Log($"Spawning defender at {point}");
        Instantiate(defender, point, Quaternion.identity);
	}
}
