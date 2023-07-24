using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCube : MonoBehaviour
{
    // ������ cube Prefab
    public Transform cubeToCreate;

    // ������ Prefab�� ������ ����
    public Transform cube;

    // Prefab ���� �޼ҵ�
    public void DragCube()
    {
        // ���� �����Ǿ� �巡�� ���� Prefab�� ���� ��� if�� �� �ڵ� ����
        if (cube == null)
        {
            // ���� ȭ�鿡 �ִ� ���콺 Ŀ���� x,y ��ǥ�� ī�޶� ���� ���� �� ��ũ��Ʈ�� ����Ǵ� ������Ʈ�� z��ǥ�� ����� ScreenPoint Vector3 position �� ����
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z);
            // ������Ʈ�� �̵��� �� ������ x,z ��ǥ�� ���� WorldPoint Vector3 position ����
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);

            // Prefab�� �����ϰ� cube ������ ����
            cube = Instantiate(cubeToCreate, new Vector3(worldPosition.x, 1f, worldPosition.y), Quaternion.identity);

            // �� ��ũ��Ʈ�� ������ Prefab�� �����ϰ� ����
            cube.GetComponent<DragObject>().createCube = this;

            // �ش� ������Ʈ ��ũ��Ʈ�� draggable ������ true�� ������ ���콺�� ���� ������ �� �ְ� �����
            cube.GetComponent<DragObject>().draggable = true;
        }
    }

}