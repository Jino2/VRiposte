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
        // �̵� ������ �����Ͽ� �÷��̾� �г��� ��ġ�� ������Ʈ (z ��ǥ�� �ݿ�)
        float playerOffsetZ = playerInitialOffset.z + (playerObject.position.z - transform.position.z) * movementRatio;
        playerMinimapPanel.transform.position = new Vector3(playerInitialPosition.x, playerInitialPosition.y, playerInitialPosition.z + playerOffsetZ);

        // �̵� ������ �����Ͽ� �� �г��� ��ġ�� ������Ʈ (z ��ǥ�� �ݿ�)
        float enemyOffsetZ = enemyInitialOffset.z - (enemyObject.position.z - transform.position.z) * movementRatio;
        enemyMinimapPanel.transform.position = new Vector3(enemyInitialPosition.x, enemyInitialPosition.y, enemyInitialPosition.z + enemyOffsetZ);
    }
}
