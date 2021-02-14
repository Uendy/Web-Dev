using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        var trainers = new List<Trainer>();
        string pokemonInput;
        while ((pokemonInput = Console.ReadLine()) != "Tournament")
        {
            //"{trainerName} {pokemonName} {pokemonElement} {pokemonHealth}"
            var pokemonInfo = pokemonInput.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var pokemonName = pokemonInfo[1];
            var pokemonElement = pokemonInfo[2];
            var pokemonHealth = int.Parse(pokemonInfo[3]);

            var pokemon = new Pokemon(pokemonName, pokemonHealth, pokemonElement);

            var trainerName = pokemonInfo[0];
            bool newTrainer = !trainers.Any(x => x.Name == trainerName);
            if (newTrainer)
            {
                var trainer = new Trainer(trainerName, 0, new List<Pokemon>() { pokemon});
                trainers.Add(trainer);
            }
            else // only add pokemone to trainer:
            {
                var trainer = trainers.Find(x => x.Name == trainerName);
                trainer.Pokemons.Add(pokemon);
            }
        }

        string element;
        while ((element = Console.ReadLine()) != "End")
        {
            foreach (var trainer in trainers)
            {
                bool hasElement = trainer.Pokemons.Any(x => x.Element == element);
                if (hasElement)
                {
                    trainer.Badges++;
                }
                else
                {
                    trainer.Pokemons.ForEach(x => x.HP -= 10);
                    trainer.Pokemons = trainer.Pokemons.Where(x => x.HP > 0).ToList(); // Remove any dead pokemon
                }
            }
        }

        trainers = trainers.OrderByDescending(x => x.Badges).ToList();
        foreach (var trainer in trainers)
        {
            //{trainerName} {badges} {numberOfPokemon}"
            Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count()}");
        }
    }
}