using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBluePrint archer;
    public TurretBluePrint scorpion;
    public TurretBluePrint cannon;
    public TurretBluePrint mage;

    public GameObject archerSelectedImage;
    public GameObject scorpionSelectedImage;
    public GameObject cannonSelectedImage;
    public GameObject mageSelectedImage;

    public GameObject[] selectedImages;

    private BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
        DeselectAll();
    }

    public void SelectArcher()
    {
        buildManager.SelectTurretToBuild(archer);
        DeselectAll();
        Select(archerSelectedImage);
    }

    public void SelectScorpion()
    {
        buildManager.SelectTurretToBuild(scorpion);
        DeselectAll();
        Select(scorpionSelectedImage);
    }

    public void SelectCannon()
    {
        buildManager.SelectTurretToBuild(cannon);
        DeselectAll();
        Select(cannonSelectedImage);
    }

    public void SelectMage()
    {
        buildManager.SelectTurretToBuild(mage);
        DeselectAll();
        Select(mageSelectedImage);
    }

    public void Select(GameObject selectedImage)
    {
        selectedImage.SetActive(true);
    }

    public void DeselectAll()
    {
        foreach (GameObject selectedImage in selectedImages)
        {
            selectedImage.SetActive(false);
        }
    }
}
