using Gun_Simulation.Models;
using System;

namespace Gun_Simulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Gun gun = new Gun("Glock", 50, 30);

            while (true)
            {
                try
                {
                    GunMenu(gun);
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid!\nTry Again!");
                }
            }
        }

        static void GunMenu(Gun gun)
        {
            Console.WriteLine("Please Choose\n1 - Reload Gun\n2 - Shoot\n3 - Full Shoot\n4 - Gun information\n");

            int choicedActionNumber = int.Parse(Console.ReadLine());

            switch (choicedActionNumber)
            {
                case 1:
                    Console.Write("Fully reload or manual? Y/N: ");
                    string isFullReload = Console.ReadLine();

                    if (isFullReload.ToLower() == "y")
                    {
                        Console.WriteLine(gun.Reload());
                    }
                    else
                    {
                        Console.Write("Enter bullet count: ");
                        Console.WriteLine(gun.Reload(int.Parse(Console.ReadLine())));
                    }

                    break;
                case 2:
                    Console.Write("How many bullets do you shoot ? ");
                    int bulletCount = int.Parse(Console.ReadLine());
                    Console.WriteLine(gun.Shoot(bulletCount));
                    break;
                case 3:
                    Console.WriteLine(gun.Shoot());
                    break;
                case 4:
                    Console.WriteLine(gun.ToString());
                    break;
            }
        }
    }
}
