using UnityEngine;
using System.Collections.Generic;

namespace Game.Buildings
{
    public class BuildingVisual : MonoBehaviour
    {
        [SerializeField] private GameObject cellPartPrefab;

        public void Initialize(Building building)
        {
            foreach (Vector2Int offset in building.Shape)
            {
                var cellVisual = Instantiate(cellPartPrefab, transform);
                cellVisual.transform.localPosition = new Vector3(offset.x, 0.5f, offset.y);
            }
        }
    }
}