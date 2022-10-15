using System;

namespace encapsulation01
{
    internal class Program
    {
        public static void Main(string[] args)
        {
        }
    }
    
    class Weapon
    {
        private uint _bullets;
        private readonly uint _bulletPerOneShoot;
        
        public uint Damage { get; private set; }

        public Weapon(uint bullets, uint bulletPerOneShoot, uint damage)
        {
            _bullets = bullets;
            _bulletPerOneShoot = bulletPerOneShoot;
            Damage = damage;
        }

        public bool TryFire()
        {
            if (_bullets <= 0) 
                return false;
            
            _bullets -= _bulletPerOneShoot;
            return true;
        }
    }

    class Player
    {
        private int _health;

        public void SetDamage(int damage)
        {
            _health -= damage;
            TryDie();
        }

        private void TryDie()
        {
            if (_health > 0) 
                return;
            
            _health = 0;
            Console.WriteLine("I died");
        }
    }

    class Bot
    {
        private readonly Weapon _weapon = new Weapon(10, 1, 10);

        public void OnSeePlayer(Player player)
        {
            if (_weapon.TryFire())
            {
                player.SetDamage((int)_weapon.Damage);
            }
        }
    }
}