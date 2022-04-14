using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    [SerializeField] private Bounce bounce;

    private Rigidbody2D r2d;
    private IEnemyHPSender hpSender;
    private bool bouncing;

    public void Update()
    {
        if (!bouncing)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                bouncing = true;
                hpSender.PlayerDamage(10);
                StartCoroutine(cor());
            }
        }
    }

    public void SenderSet(IEnemyHPSender hpSender)
    {
        this.hpSender = hpSender;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (/*ƒvƒŒƒCƒ„[UŒ‚*/true)
        {
            bouncing = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    }

    IEnumerator cor()
    {
        yield return new WaitForSeconds(3);
        bouncing = false;
    }

    public bool Bouncing
    {
        get => bouncing;
    }
}
