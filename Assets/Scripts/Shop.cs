using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBluePrint archer;
    public TurretBluePrint cannon;
    public TurretBluePrint mage;
    public TurretBluePrint scorpion;

    private BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectArcher()
    {
        buildManager.SelectTurretToBuild(archer);
    }

    public void SelectCannon()
    {
        buildManager.SelectTurretToBuild(cannon);
    }

    public void SelectMage()
    {
        buildManager.SelectTurretToBuild(mage);
    }

    public void SelectScorpion()
    {
        buildManager.SelectTurretToBuild(scorpion);
    }
}
