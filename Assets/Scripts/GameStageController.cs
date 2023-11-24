using UnityEngine;

public class GameStageController : MonoBehaviour
{
    public GameObject playerObject;
    public GameObject enemyObject;
    public static float offsetF => 0.5f;


    public void InitStage()
    {
        var stageMid = transform.position;
        playerObject.transform.position = stageMid - (transform.forward* 1.0f);
        enemyObject.transform.position = stageMid + (transform.forward* 1.0f);
    }
}