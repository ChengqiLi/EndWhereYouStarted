
public class CucumberScript : EnemyScript,IDamageable
{
    public void GetHit(float damage)
    {
        health -= damage;
        if(health<1)
        {
            health = 0;
            isDead = true;
        }
        anim.SetTrigger("hit");
    }

    public void SetOff()//Animation Event
    {
        if(targetPoint.gameObject.GetComponent<BobmScript>()!=null)
        {
            targetPoint.gameObject.GetComponent<BobmScript>().TurnOff();
        }
    }
}
