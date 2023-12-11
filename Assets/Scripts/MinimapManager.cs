using UnityEngine;

public class DualMinimapManager : MonoBehaviour
{
    public GameObject playerMinimapPanel; // 미리 생성된 플레이어 패널을 Inspector에서 할당
    public GameObject enemyMinimapPanel; // 미리 생성된 적 패널을 Inspector에서 할당
    public Transform playerObject; // 플레이어의 Transform 컴포넌트를 할당
    public Transform enemyObject; // 적의 Transform 컴포넌트를 할당
    public Vector3 playerInitialOffset;
    public Vector3 enemyInitialOffset;
    public float movementRatio = 0.1f; // 이동 비율 조정

    private Vector3 playerInitialPosition;
    private Vector3 enemyInitialPosition;

    void Start()
    {
        // 이미 생성된 패널들의 초기 위치를 저장
        playerInitialPosition = playerMinimapPanel.transform.position;
        enemyInitialPosition = enemyMinimapPanel.transform.position;
    }

    void Update()
    {
        // 이동 비율을 적용하여 플레이어 패널의 위치를 업데이트 (y 좌표만 반영)
        float playerOffsetY = playerInitialOffset.y + (playerObject.position.y - transform.position.y) * movementRatio;
        playerMinimapPanel.transform.position = new Vector3(playerInitialPosition.x, playerInitialPosition.y + playerOffsetY, playerInitialPosition.z);

        // 이동 비율을 적용하여 적 패널의 위치를 업데이트 (y 좌표만 반영)
        float enemyOffsetY = enemyInitialOffset.y - (enemyObject.position.y - transform.position.y) * movementRatio;
        enemyMinimapPanel.transform.position = new Vector3(enemyInitialPosition.x, enemyInitialPosition.y + enemyOffsetY, enemyInitialPosition.z);
    }
}
