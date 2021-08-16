using UnityEngine;

public class Fox : Attacker
{
    [Header("Fox")]
    [SerializeField] float jumpSpeed;

    public void StartJumpMovement()
    {
        currentSpeed = jumpSpeed;
    }


    protected override void OnMeetDefender(Defender defender)
    {
        if (defender is Gravestone)
        {
            animator.SetTrigger("Jump");
            return;
        }
        base.OnMeetDefender(defender);
    }
}
