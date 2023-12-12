using UnityEngine;

public class DualMinimapManager : MonoBehaviour
{
    public GameObject playerMinimapPanel; // �̸� ������ �÷��̾� �г��� Inspector���� �Ҵ�
    public GameObject enemyMinimapPanel; // �̸� ������ �� �г��� Inspector���� �Ҵ�
    public Transform playerObject; // �÷��̾��� Transform ������Ʈ�� �Ҵ�
    public Transform enemyObject; // ���� Transform ������Ʈ�� �Ҵ�
    public Vector3 playerInitialOffset;
    public Vector3 enemyInitialOffset;
    public float movementRatio = 0.1f; // �̵� ���� ����

    private Vector3 playerInitialPosition;
    private Vector3 enemyInitialPosition;

    void Start()
    {
        // �̹� ������ �гε��� �ʱ� ��ġ�� ����
        playerInitialPosition = playerMinimapPanel.transform.position;
        enemyInitialPosition = enemyMinimapPanel.transform.position;
    }

    void Update()
    {
        // 이동 비율을 적용하여 플레이어 패널의 위치를 업데이트 (z 좌표만 반영)
        float playerOffsetZ = (playerInitialOffset.z - playerObject.position.z) * movementRatio;
        playerMinimapPanel.transform.localPosition = new Vector3(0, -playerOffsetZ, 0);
        
        // 이동 비율을 적용하여 적 패널의 위치를 업데이트 (z 좌표만 반영)
        float enemyOffsetZ = (enemyInitialOffset.z - enemyObject.position.z) * movementRatio;
        enemyMinimapPanel.transform.localPosition = new Vector3(0, -enemyOffsetZ, 0);
    }
}
