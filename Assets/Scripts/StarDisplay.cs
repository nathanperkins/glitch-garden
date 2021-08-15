using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int stars = 100;
    Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        text.text = stars.ToString();
    }

    public bool HaveEnoughStars(int amount)
    {
        return stars >= amount;
	}

    public void AddStars(int amount)
    {
        stars += amount;
        UpdateDisplay();
    }

    public void SpendStars(int amount)
    {
        stars -= amount;
        UpdateDisplay();
    }
}
