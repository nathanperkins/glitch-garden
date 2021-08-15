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

    public void AddStars(int amount)
    {
        stars += amount;
        UpdateDisplay();
    }

    public bool SpendStars(int amount)
    {
        if (amount > stars)
        {
            return false;
        }

        stars -= amount;
        UpdateDisplay();
        return true;
    }
}
