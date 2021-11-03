using System;
using System.Collections.Generic;
using System.Text;

namespace Gun_Simulation.Models
{
    class Gun
    {
        public string Type { get; set; }

        private int _totalBulletSize;
        public int TotalBulletSize
        {
            get { return _totalBulletSize; }
            private set
            {
                if (value >= 0)
                {
                    _totalBulletSize = value;
                }
            }
        }

        private int _magazineSize;
        public int MagazineSize
        {
            get { return _magazineSize; }
            set
            {
                if (value > 0)
                {
                    _magazineSize = value;
                }
            }
        }

        private int _bulletLeft;
        public int BulletLeft
        {
            get { return _bulletLeft; }
            set
            {
                if (_magazineSize >= value)
                {
                    _bulletLeft = value;
                }
            }
        }

        public Gun(string type, int totalBulletSize, int magazineSize)
        {
            Type = type;
            TotalBulletSize = totalBulletSize;
            MagazineSize = magazineSize;
            BulletLeft = MagazineSize;
        }

        public string Shoot(int fireBulletCount)
        {
            if (fireBulletCount > BulletLeft)
            {
                return $"You don't have enough bullets! Please reload bullets.";
            }

            BulletLeft -= fireBulletCount;

            return $"\nYou fired {fireBulletCount} bullets.";
        }

        public string Shoot()
        {
            int remainingBullet = BulletLeft;
            BulletLeft -= remainingBullet;

            if (remainingBullet > 0)
            {
                return $"\nYou fired {remainingBullet} bullets.";
            }

            return $"You don't have enough bullets! Please reload bullets.";
        }

        public string Reload(int bulletCount)
        {

            if (MagazineSize > bulletCount)
            {
                TotalBulletSize -= bulletCount;
                BulletLeft += bulletCount;
                return $"\nYour gun is reloaded with {bulletCount} bullet.";
            }

            return $"\nAccepted bullet count: {MagazineSize}";
        }

        public string Reload()
        {
            int bulletNeedCount = MagazineSize - BulletLeft;

            if (BulletLeft < MagazineSize)
            {
                TotalBulletSize -= bulletNeedCount;
                BulletLeft = MagazineSize;
                return $"\nYour gun is reloaded with {bulletNeedCount} bullet.";
            }
            return $"\nYou can't, because gun magazine is full.";
        }

        public override string ToString()
        {
            return $"\nGun type is: {Type}\n" +
                    $"Total bullet: {TotalBulletSize}\n" +
                    $"Bullet remaining count: {BulletLeft}\n";
        }
    }
}
