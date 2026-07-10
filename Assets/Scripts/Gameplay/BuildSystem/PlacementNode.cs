using UnityEngine;

// Tempelkan script ini di tiap GameObject node/slot tempat tower bisa ditempatkan.
// Node butuh: Collider (untuk raycast) + Renderer (untuk feedback warna visual).
public class PlacementNode : MonoBehaviour
{
    public bool IsOccupied { get; private set; }
    public GameObject CurrentTower { get; private set; }

    [Header("Visual Feedback")]
    [SerializeField] private Renderer nodeRenderer;
    [SerializeField] private Color emptyColor = new Color(0.2f, 0.8f, 1f);   // cyan
    [SerializeField] private Color occupiedColor = new Color(0.4f, 0.4f, 0.4f);
    [SerializeField] private Color hoverColor = Color.yellow;

    private void Awake()
    {
        if (nodeRenderer == null)
            nodeRenderer = GetComponent<Renderer>();

        SetVisual(emptyColor);
    }

    public void OnHoverEnter()
    {
        if (!IsOccupied) SetVisual(hoverColor);
    }

    public void OnHoverExit()
    {
        if (!IsOccupied) SetVisual(emptyColor);
    }

    public bool PlaceTower(GameObject towerPrefab)
    {
        if (IsOccupied || towerPrefab == null) return false;

        CurrentTower = Instantiate(towerPrefab, transform.position, Quaternion.identity, transform);
        IsOccupied = true;
        SetVisual(occupiedColor);
        return true;
    }

    public void RemoveTower()
    {
        if (CurrentTower != null) Destroy(CurrentTower);
        CurrentTower = null;
        IsOccupied = false;
        SetVisual(emptyColor);
    }

    private void SetVisual(Color color)
    {
        // .material (bukan .sharedMaterial) otomatis bikin instance,
        // jadi warna tiap node tidak saling menimpa.
        if (nodeRenderer != null) nodeRenderer.material.color = color;
    }
}
