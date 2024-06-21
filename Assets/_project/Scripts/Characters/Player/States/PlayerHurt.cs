using System.Collections;
using UnityEngine;

public class PlayerHurt : HurtState{
    public override void EnterState(){
        Debug.Log("Player Hurt State");
        Player.ChangeAnimation(Player.HURT);
        Player.StartCoroutine(HurtRoutine());
    }

    private IEnumerator HurtRoutine(){
        yield return new WaitForSeconds(1f);
        Player.ChangeState(Player.IdleState);
        yield return null;
    }

    public override string ToString(){
        return "Hurt";
    }
}