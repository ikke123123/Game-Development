using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public GameObject effect;

    public float speed = 65f;
    public int damage = 20;

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
        GameObject clone = (GameObject)Instantiate(effect, transform.position, transform.rotation);
        //destroy bullet
        Destroy(gameObject);
        //destroy particle effect
        Destroy(clone,1f);
        Damage(target);
    }
    void Damage(Transform enemy)
    {
        MinionsAttack e = enemy.GetComponent<MinionsAttack>();

        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }
}
