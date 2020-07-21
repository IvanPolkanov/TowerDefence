public interface ITower
{
    float damage { get; set; }
    float reloadTime { get; set; }

    float attackRadius { get; set; }

    bool isEnabled { get; set; }

    void SetState(bool state);

    void GradeTower(float damage, float reloadTime);
}