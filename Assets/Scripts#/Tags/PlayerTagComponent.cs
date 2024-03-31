 
using Unity.Entities;
using UnityEngine;

public class PlayerTagComponent : MonoBehaviour
{
    private class Baker : Baker<PlayerTagComponent>
    {
        public override void Bake(PlayerTagComponent authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new PlayerTag());
        }
    }
}
public struct PlayerTag : IComponentData
{

}
