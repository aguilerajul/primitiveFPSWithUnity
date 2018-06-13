public static class GlobalActions
{
    private static int EnemiesDead { get; set; }    
    public static bool IsShotGunDroped { get; set; }
    public static bool ChangedWeapon { get; set; }
    public static bool HasRevolver { get; set; }
    public static bool HasMachineGun { get; set; }
    public static bool HasShotGun { get; set; }
    public static bool IsBossDead { get; set; }
    public static bool BossDrop { get; set; }
    public static bool PlayerHasStone { get; set; }

    public static void UpdateEnemiesDeadCount()
    {
        EnemiesDead++;
    }

    public static int GetCurrentEnemiesDead()
    {
        return EnemiesDead;
    }

}
