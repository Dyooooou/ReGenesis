public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance;

    public GameObject SelectedTower;

    void Awake()
    {
        Instance = this;
    }

    public void SelectTower(GameObject tower)
    {
        SelectedTower = tower;
    }

    void OnMouseDown(){
    if(IsOccupied)
        return;

    if(BuildManager.Instance.SelectedTower == null)
        return;

    PlaceTower(BuildManager.Instance.SelectedTower);
}
}