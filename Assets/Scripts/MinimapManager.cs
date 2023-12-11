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
        // �̵� ������ �����Ͽ� �÷��̾� �г��� ��ġ�� ������Ʈ (y ��ǥ�� �ݿ�)
        float playerOffsetY = playerInitialOffset.y + (playerObject.position.y - transform.position.y) * movementRatio;
        playerMinimapPanel.transform.position = new Vector3(playerInitialPosition.x, playerInitialPosition.y + playerOffsetY, playerInitialPosition.z);

        // �̵� ������ �����Ͽ� �� �г��� ��ġ�� ������Ʈ (y ��ǥ�� �ݿ�)
        float enemyOffsetY = enemyInitialOffset.y - (enemyObject.position.y - transform.position.y) * movementRatio;
        enemyMinimapPanel.transform.position = new Vector3(enemyInitialPosition.x, enemyInitialPosition.y + enemyOffsetY, enemyInitialPosition.z);
    }
}
