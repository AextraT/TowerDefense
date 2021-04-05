using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject UI;
    private Node target;

    public Text upgradeCost;
    public Button upgradeButton;

    public void SetTarget(Node _target)
    {
        target = _target;
        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded)
        {
            upgradeButton.interactable = true;
            upgradeCost.text = "-" + target.turretBluePrint.upgradeCost;
        }
        else
        {
            upgradeButton.interactable = false;
            upgradeCost.text = "---";
        }

        UI.SetActive(true);
    }

    public void Hide()
    {
        UI.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }
}