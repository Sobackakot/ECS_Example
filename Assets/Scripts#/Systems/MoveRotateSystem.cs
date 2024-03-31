using Unity.Entities;
using Unity.Transforms;

public partial struct MoveRotateSystem : ISystem 
{ 
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<RotateSpeed>();
        state.RequireForUpdate<MoveSpeed>();
    }
    public void OnUpdate( ref SystemState state)
    {
        float delatTime = SystemAPI.Time.DeltaTime;
        foreach (MoveRotateAspect aspect in SystemAPI.Query< MoveRotateAspect> ())
        {
            aspect.MoveRotateObject(delatTime);
        }
    }
} 
     

