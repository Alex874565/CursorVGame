using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyState : ScriptableObject
{ 
    [SerializeField] protected TelegraphPattern _telegraphPattern;
    
    protected EnemyContext _context;
    protected float _dice;

    protected float _timer;
    
    public void Initialize(EnemyContext enemyContext)
    {
        if(_context == null)
            _context = enemyContext;
    }
    
    public virtual void Enter()
    {
        _telegraphPattern?.Execute(_context.VisualController);
        _timer = 0;
        _dice = 99999;
    }
    
    public virtual void Update()
    {
    }

    public virtual void FixedUpdate()
    {
        
    }

    public virtual void LateUpdate()
    {
    }

    public virtual void Exit()
    {
        
    }
    
    public virtual EnemyState NextState()
    {
        List<EnemyAttack> _attacks = _context.Data.Attacks;
        List<EnemyMove> _moves = _context.Data.Moves;
        List<EnemyDash> _dashes = _context.Data.Dashes;
        List<EnemyIdle> _idles = _context.Data.Idles;
        
        Debug.Log($"Dice: {_dice}, AttackChance: {_context.Data.AttackChance}, MoveChance: {_context.Data.MoveChance}, DashChance: {_context.Data.DashChance}");
        if (_dice < _context.Data.AttackChance)
            return _attacks[Random.Range(0, _attacks.Count)];
        
        if (_dice < _context.Data.AttackChance + _context.Data.MoveChance)
            return _moves[Random.Range(0, _moves.Count)];
            
        if (_dice < _context.Data.AttackChance + _context.Data.MoveChance + _context.Data.DashChance)
            return _dashes[Random.Range(0, _dashes.Count)];
        
        if(_dice < 100)
            return _idles[Random.Range(0, _idles.Count)];

        return null;
    }

    protected void RollNextState()
    {
        _dice = Random.Range(0f, 100f);
    }
}