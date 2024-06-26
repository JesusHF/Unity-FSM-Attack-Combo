using UnityEngine;

public abstract class State
{
    public StateMachine StateMachine { get; private set; }

    protected float _time { get; set; }
    protected float _fixedtime { get; set; }
    protected float _latetime { get; set; }

    public virtual void OnEnter(StateMachine _stateMachine)
    {
        StateMachine = _stateMachine;
    }

    public virtual void OnUpdate()
    {
        _time += Time.deltaTime;
    }

    public virtual void OnFixedUpdate()
    {
        _fixedtime += Time.deltaTime;
    }

    public virtual void OnLateUpdate()
    {
        _latetime += Time.deltaTime;
    }

    public virtual void OnExit() { }

    #region Passthrough Methods

    /// <summary>
    /// Removes a gameobject, component, or asset.
    /// </summary>
    /// <param name="obj">The type of Component to retrieve.</param>
    protected static void Destroy(UnityEngine.Object obj)
    {
        UnityEngine.Object.Destroy(obj);
    }

    /// <summary>
    /// Returns the component of type T if the game object has one attached, null if it doesn't.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    protected T GetComponent<T>() where T : Component { return StateMachine.GetComponent<T>(); }

    /// <summary>
    /// Returns the component of Type <paramref name="type"/> if the game object has one attached, null if it doesn't.
    /// </summary>
    /// <param name="type">The type of Component to retrieve.</param>
    /// <returns></returns>
    protected Component GetComponent(System.Type type) { return StateMachine.GetComponent(type); }

    /// <summary>
    /// Returns the component with name <paramref name="type"/> if the game object has one attached, null if it doesn't.
    /// </summary>
    /// <param name="type">The type of Component to retrieve.</param>
    /// <returns></returns>
    protected Component GetComponent(string type) { return StateMachine.GetComponent(type); }
    #endregion
}