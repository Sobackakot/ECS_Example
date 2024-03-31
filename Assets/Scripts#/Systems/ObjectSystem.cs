
using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

public partial struct RotateObjectSystem : ISystem
{
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<RotateSpeed>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {   
        state.Enabled= false;
        return;
        /*
        float deltaTime = SystemAPI.Time.DeltaTime;
        foreach (var (localTransform, rotateSpeed) 
            in SystemAPI.Query<RefRW<LocalTransform>, RefRO<RotateSpeed>>().WithAll<CubeTag>())
        {
            localTransform.ValueRW = localTransform.ValueRO.RotateY(rotateSpeed.ValueRO.speed * deltaTime);
        }
        */
        RotateObjectJob rotateObjectJob = new RotateObjectJob
        {
            deltaTime = SystemAPI.Time.DeltaTime
        };
        rotateObjectJob.ScheduleParallel();
    }
}

[BurstCompile]
[WithAll(typeof(CubeTag))] // Teg для исключения не нужных компонентов
                                 // можно указать Teg тут если использовать Job или в OnUpdate -> foreache
public partial struct RotateObjectJob : IJobEntity
{
    public float deltaTime;
     
    public void Execute(ref LocalTransform localTransform, in RotateSpeed rotateSpeed)
    {
        localTransform = localTransform.RotateY(rotateSpeed.speed * deltaTime);
    }
}
