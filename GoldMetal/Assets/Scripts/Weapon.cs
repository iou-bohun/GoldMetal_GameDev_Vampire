using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int id;
    public int prefabId;
    public float dmg;
    public int count;
    public float speed;

    private void Start()
    {
        Init();
    }
    private void Update()
    {
        switch (id)
        {
            case 0:
                transform.Rotate(Vector3.back * speed * Time.deltaTime);
                break;
            default:
                break;

        }

        // .. Test levelup
        if (Input.GetButtonDown("Jump"))
        {
            LevelUp(20,5);
        }
    }

    public void Init()
    {
        switch (id)
        {
            case 0:
                speed = 150;
                Batch();
                break;
            default:
                break;

        }
    }

    public void LevelUp(float damage , int count)
    {
        this.dmg = damage;
        this.count += count;

        if(id == 0)
        {
            Batch();
        }
    }
    void Batch()
    {
        for(int index = 0; index < count; index++)
        {
            Transform bullet;
            if (index < transform.childCount)
            {
                bullet = transform.GetChild(index);
            }
            else
            {
                bullet = GameManager.Instance.pool.Get(prefabId).transform;
                bullet.parent = transform;
            }
            bullet.localPosition = Vector3.zero;
            bullet.localRotation = Quaternion.identity;

            Vector3 roVec = Vector3.forward * 360 * index / count;
            bullet.Rotate(roVec);
            bullet.Translate(bullet.up * 1.5f, Space.World);

            bullet.GetComponent<Bullet>().Init(dmg, -1); //.. -1is Infiniry per.
        }
    }
}
