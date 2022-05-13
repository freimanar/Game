using UnityEngine;
public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    public Turret standartTurret;
    public Turret missileLaumcher;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandartTurret()
    {
        buildManager.SelectedTurretToBuild(standartTurret);
    }

    public void SelectMissileTurret()
    {
        buildManager.SelectedTurretToBuild(missileLaumcher);
    }

}