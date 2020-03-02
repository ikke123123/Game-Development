using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public GameObject effect;

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
        GameObject clone = (GameObject)Instantiate(effect, transform.position, transform.rotation);
        //target object
        Destroy(target.gameObject);
        //Destroy parent of target
        if (target.parent.childCount <= 1)
        {
            Destroy(target.parent.gameObject,1f);
        }
        //destroy bullet
        Destroy(gameObject);
        //destroy particle effect
        Destroy(clone,1f);
    }
}
