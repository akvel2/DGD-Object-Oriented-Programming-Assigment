using System;

// ===== PART A: predictions (written before running) =====
// A1: 5       (11 / 4 = 2, 11 % 4 = 3, 2 + 3)
// A2: Hurt    (45 > 50 false, 45 > 20 true)
// A3: 4       (i=1: -1, i=2: 1, i=3: 0, i=4: 4)
// A4: 14      (Twice(3) = 6, Twice(7) = 14)

// ===== B1 =====
{
    int baseDamage = 40;
    int armor = 15;
    int level = 4;

    int damage = baseDamage - armor;
    if (level >= 5) damage += 10;
    if (damage < 1) damage = 1;

    string label;
    if (damage >= 30) label = "Strong hit";
    else if (damage >= 10) label = "Normal hit";
    else label = "Weak hit";

    Console.WriteLine($"Damage: {damage} ({label})");
    // Tests: level = 6 -> Damage: 35 (Strong hit); armor = 50 -> Damage: 1 (Weak hit)
}

// ===== B2 =====
{
    int gold = 120;
    int choice = 2;

    string item = "";
    int price = 0;

    switch (choice)
    {
        case 1: item = "Sword"; price = 100; break;
        case 2: item = "Bow"; price = 80; break;
        case 3: item = "Potion"; price = 25; break;
        default: Console.WriteLine("Invalid choice"); break;
    }

    if (price > 0)
    {
        if (gold >= price)
        {
            gold -= price;
            Console.WriteLine($"You bought a {item}! Gold left: {gold}");
        }
        else
        {
            Console.WriteLine($"You need {price - gold} more gold for the {item}");
        }
    }
}

// ===== B3 =====
{
    for (int wave = 1; wave <= 30; wave++)
    {
        if (wave % 3 == 0 && wave % 5 == 0)
            Console.WriteLine($"Wave {wave}: BOSS");
        else if (wave % 3 == 0)
            Console.WriteLine($"Wave {wave}: Slime");
        else if (wave % 5 == 0)
            Console.WriteLine($"Wave {wave}: Bat");
        else
            Console.WriteLine($"Wave {wave}: empty");
    }
}

// ===== B4 =====
{
    int level = 1;
    int xp = 0;
    int fights = 0;

    while (level < 5)
    {
        xp += 35;
        fights++;

        if (xp >= 100)
        {
            xp -= 100;
            level++;
            Console.WriteLine($"LEVEL UP! Now level {level}");
        }
    }

    Console.WriteLine($"Reached level 5 after {fights} fights (xp left: {xp})");
}

// ===== B5 =====
{
    int Clamp(int value, int min, int max)
    {
        if (value < min) return min;
        if (value > max) return max;
        return value;
    }

    Console.WriteLine(Clamp(150, 0, 100));
    Console.WriteLine(Clamp(-20, 0, 100));
    Console.WriteLine(Clamp(55, 0, 100));

    int hp = 80;
    hp = Clamp(hp + 50, 0, 100);
    Console.WriteLine($"HP after potion: {hp}");
}

// ===== B6 =====
{
    string GetRank(int score)
    {
        if (score >= 1000) return "Gold";
        else if (score >= 500) return "Silver";
        else if (score >= 1) return "Bronze";
        else return "No medal";
    }

    for (int score = 0; score <= 1250; score += 250)
    {
        Console.WriteLine($"Score {score}: {GetRank(score)}");
    }
}

// ===== B7 =====
{
    int Attack(int hp, int damage)
    {
        hp -= damage;
        if (hp < 0) hp = 0;
        return hp;
    }

    bool IsAlive(int hp)
    {
        return hp > 0;
    }

    int playerHp = 150;
    int bossHp = 120;
    int turn = 1;

    while (IsAlive(playerHp) && IsAlive(bossHp))
    {
        bossHp = Attack(bossHp, 25);
        if (!IsAlive(bossHp))
        {
            Console.WriteLine($"Turn {turn} | Boss: 0");
            break;
        }

        int bossDamage = 25;
        if (turn % 3 == 0) bossDamage = 50;
        playerHp = Attack(playerHp, bossDamage);

        Console.WriteLine($"Turn {turn} | Boss: {bossHp} | Player: {playerHp}");
        if (IsAlive(playerHp)) turn++;
    }

    if (IsAlive(playerHp))
        Console.WriteLine($"You win in {turn} turns! HP left: {playerHp}");
    else
        Console.WriteLine($"The boss wins in {turn} turns.");
}

// ===== B8 =====
{
    string Hint(int guess, int secret)
    {
        if (guess < secret) return "Too low";
        if (guess > secret) return "Too high";
        return "Correct!";
    }

    int secret = 42;
    int triesLeft = 5;
    bool found = false;

    while (triesLeft > 0 && !found)
    {
        Console.Write($"Guess ({triesLeft} tries left): ");
        int guess = int.Parse(Console.ReadLine());
        triesLeft--;

        string hint = Hint(guess, secret);
        Console.WriteLine(hint);
        if (hint == "Correct!") found = true;
    }

    if (found)
        Console.WriteLine($"You found it in {5 - triesLeft} tries!");
    else
        Console.WriteLine($"No tries left. The number was {secret}.");
}
