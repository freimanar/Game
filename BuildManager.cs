using UnityEngine;


public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;
    private Turret TurretToBuilt;
    public bool CanBuild { get { return TurretToBuilt != null; } }
    public bool HasMoney { get { return Stats.Money >= TurretToBuilt.cost; } }

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuiltManager in scene!");
            return;
        }
        instance = this;
    }
    public GameObject standartTurretPrefab;
    public GameObject anotherTurretPrefab;

    public void BuildTurretOn(Node node)
    {
        if (Stats.Money < TurretToBuilt.cost)
        {
            return;
        }
        Stats.Money -= TurretToBuilt.cost; 

        GameObject turret = (GameObject)Instantiate(TurretToBuilt.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
    }

    public void SelectedTurretToBuild(Turret turret)
    {
        TurretToBuilt = turret;
    }
}