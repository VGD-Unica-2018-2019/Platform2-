using UnityEngine.SceneManagement;
public class VictoryItem : CollectibleController
{
    protected override void ActionPerformed(GameCharacterController gameCharacterController)
    {
        base.ActionPerformed(gameCharacterController);
        if(SceneManager.GetActiveScene().buildIndex!=3){
            SceneTransitioner.GetInstance().GoToScene(SceneManager.GetActiveScene().buildIndex + 1);
        }else{
            SceneTransitioner.GetInstance().GoToScene(7);
        }
    }
}