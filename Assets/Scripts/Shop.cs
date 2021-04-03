using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBluePrint archer;
    public TurretBluePrint cannon;
    public TurretBluePrint mage;

    private BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectArcher()
    {
        Debug.Log("Archer sélectionné");
        buildManager.SelectTurretToBuild(archer);
    }

    public void SelectCannon()
    {
        Debug.Log("Cannon sélectionné");
        buildManager.SelectTurretToBuild(cannon);
    }

    public void SelectMage()
    {
        Debug.Log("Mage sélectionné");
        buildManager.SelectTurretToBuild(mage);
    }
}
