using UnityEngine;
using UnityEngine.UI;

public class Base : Defender
{
    [SerializeField] Text text;

    private void Start()
    {
        UpdateText();
    }

    public override void DealDamage(int damage)
    {
        base.DealDamage(damage);
        UpdateText();
    }

    private void UpdateText()
    {
        text.text = health.ToString();
    }


    protected override void Die()
    {
        Debug.Log("Game over!");
        Destroy(gameObject);
    }
}
