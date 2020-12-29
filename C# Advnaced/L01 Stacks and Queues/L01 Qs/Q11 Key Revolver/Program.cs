using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        // Reading input:
        int bulletPrice = int.Parse(Console.ReadLine());
        int magSize = int.Parse(Console.ReadLine());
        var bullets = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse)); // back->front
        var locks = new Queue<int>(Console.ReadLine().Split(' ').Select(int.Parse)); // front->back
        int value = int.Parse(Console.ReadLine());

        // Begin shooting locks:
        int currentBulletsFired = 0;
        int totalBulletsFired = 0;

        while (bullets.Any() && locks.Any())
        {
            int bullet = bullets.Pop();
            int currentLock = locks.Peek();
            
            // update info:
            totalBulletsFired++;
            currentBulletsFired++;
            
            if (bullet <= currentLock) // lock broken:
            {
                locks.Dequeue();
                Console.WriteLine("Bang!");
            }
            else // couldn't break lock:
            {
                Console.WriteLine("Ping!");
            }

             // check reloading:
            bool reload = currentBulletsFired == magSize && bullets.Any();
            if (reload)
            {
                Console.WriteLine("Reloading!");
                currentBulletsFired = 0;
            }

            
        }
        // Depending on bullets or locks being empty, print output:
        bool unlocked = !locks.Any();
        if (unlocked)
        {
            int earning = value -= totalBulletsFired * bulletPrice;
            Console.WriteLine($"{bullets.Count()} bullets left. Earned ${earning}");
        }
        else // out of bullets:
        {
            Console.WriteLine($"Couldn't get through. Locks left: {locks.Count()}");
        }
    }
}