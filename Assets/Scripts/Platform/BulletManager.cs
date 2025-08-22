using System.Collections.Generic;
using UnityEngine;

public class BulletManager : BaseManager<BulletManager>
{
    [SerializeField]
    private List<BulletController> bulletPool;
    [SerializeField]
    private BulletController objectToPool;
    [SerializeField]
    private int amountToPool;

    protected override void Awake()
    {
        base.Awake();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitPool();
    }

    private void InitPool()
    {
        bulletPool = new();
        for (int i = 0; i < amountToPool; i++)
        {
            BulletController bullet = Instantiate(objectToPool, this.transform, true);
            bullet.DeActive();
            bulletPool.Add(bullet);
        }
    }

    public BulletController GetBullet()
    {
        for (int i = 0; i < bulletPool.Count; i++)
        {
            if (!bulletPool[i].IsActive)
            {
                return bulletPool[i];
            }
        }

        return null;
    }
}
