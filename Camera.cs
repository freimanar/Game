using UnityEngine;

public class Camera: MonoBehaviour
{

    public float panSpeed = 2f; //�������� ��������
    private bool doMovement = true;
    public float scrollSpeed = 1f;
    public float movexSpeed = 1f;
    public float movezSpeed = 1f; // �������� �����������/��������
    public float minY = 5f; // ����������� �����������
    public float maxY = 30f; // ������������ ��������
    public float minx = 3f;
    public float maxx = 10f;
    public float minz = 3f;
    public float maxz = 10f;



    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            doMovement = !doMovement;

        if (!doMovement)
            return;

        if (Input.GetKey("w"))
        { //��� ������� �� ������� w ���������� �������� ������
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s")) // �����
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d")) // ������
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a")) // �����
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel"); // ��� ������������� "������" ����
        Vector3 pos = transform.position; // ������ ����������� ������
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;


        float movex = Input.GetAxis("Horizontal"); // ��� ������������� "������" ����
        Vector3 pos1 = transform.position; // ������ ����������� ������
        pos1.x -= movex * 1000 * movexSpeed * Time.deltaTime;
        pos1.x = Mathf.Clamp(pos.x, minx, maxx);
        transform.position = pos1;

        float movez = Input.GetAxis("Vertical"); // ��� ������������� "������" ����
        Vector3 pos2 = transform.position; // ������ ����������� ������
        pos2.z -= movez * 1000 * movezSpeed * Time.deltaTime;
        pos2.z = Mathf.Clamp(pos.z, minz, maxz);
        transform.position = pos2;
    }
}