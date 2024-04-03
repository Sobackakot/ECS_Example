using Unity.Entities;
using UnityEngine;

public class SwitchComponent : MonoBehaviour
{
    public class Baker : Baker<SwitchComponent>
    {
        public override void Bake(SwitchComponent authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new SwitchSpawn());
            SetComponentEnabled<SwitchSpawn>(entity, false);
        }
    }
}
public struct SwitchSpawn : IComponentData, IEnableableComponent
{
   
}
