using UnityEngine;

public class DuckState : Abstract{
    public override void EnterState(){
        Player.GroundCheckBox.localPosition = new Vector3(0, -0.61f, 0);
        Player.StandForm.gameObject.SetActive(false);
        Player.DuckMode.gameObject.SetActive(true);

        Player.ChangeAnimation(Player.DUCK);
    }

    public override void LogicUpdate(){
        if (!Player.Inputs.Crouch){
            Player.ChangeState(Player.IdleState);
            // if(Player.Inputs.Shot){
            //     Player.ChangeState(Player.StandShoot);
            // }else{
            //     Player.ChangeState(Player.IdleState);
            // }
        }

        if (Player.Inputs.Shot){
            Player.HandleShoot();
        }
    }

    public override void PhysicsUpdate(){
        
    }

    public override void ExitState(){
        Player.GroundCheckBox.localPosition = new Vector3(0, -1.11f, 0);
        Player.DuckMode.gameObject.SetActive(false);
        Player.StandForm.gameObject.SetActive(true);
    }

    public override string ToString(){
        return "Duck";
    }
}