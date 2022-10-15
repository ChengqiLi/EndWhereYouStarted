
public abstract class EnemyBaseState 
{
    //进入状态
    public abstract void EnterState(EnemyScript enemy);
    //状态中
    public abstract void OnState(EnemyScript enemy);
}
