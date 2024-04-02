using Unity.Entities;
using UnityEngine;

public class PrefabComponent : MonoBehaviour
{
    public GameObject cubePrefab;
    public int amountToSpawn;
    private class Baker : Baker<PrefabComponent>
    {
        public override void Bake(PrefabComponent authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.None);
            AddComponent(entity, new ObjectPrefab
            {
                cubePrefab =  GetEntity(authoring.cubePrefab, TransformUsageFlags.Dynamic),
                 amountToSpawn = authoring.amountToSpawn
            });
        }
    }
}
public struct ObjectPrefab : IComponentData
{
    public Entity cubePrefab;
    public int amountToSpawn;
}
