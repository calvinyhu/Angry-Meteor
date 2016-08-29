using UnityEngine;
using System.Collections;

public class ProjectileFollow : MonoBehaviour
{
    public Transform projectile;
    public Transform farLeft;
    public Transform farRight;

    void Update()
    {
        if (projectile != null)
        {
            FollowProjectile();
        }
    }

    void FollowProjectile()
    {
        Vector3 newPos = transform.position;
        newPos.x = projectile.position.x;
        newPos.x = Mathf.Clamp(newPos.x, farLeft.position.x, farRight.position.x);
        transform.position = newPos;
    }
}
