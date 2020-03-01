using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public Transform effect;

    public float speed = 65f;

    public void Chase(Transform _target)
    {
        target = _target;
    }
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distancePerFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distancePerFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distancePerFrame, Space.World);
    }

    void HitTarget()
    {
        Instantiate(effect, transform.position, transform.rotation);
        Destroy(target.gameObject);
        Destroy(gameObject);
    }
}
