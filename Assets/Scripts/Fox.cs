using UnityEngine;

public class Fox : Attacker
{
    protected override void OnMeetDefender(Defender defender)
    {
        if (defender is Gravestone)
        {
            return;
		}
        base.OnMeetDefender(defender);
	}
}
