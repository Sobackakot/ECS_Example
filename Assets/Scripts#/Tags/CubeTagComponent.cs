using Unity.Entities;
using UnityEngine;

public class CubeTagComponent : MonoBehaviour
{
    private class Baker : Baker<CubeTagComponent>
    {
        public override void Bake(CubeTagComponent authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new CubeTag());
        }
    }
}
public struct CubeTag: IComponentData
{

}
