using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DataContext context;
        public PokemonRepository(DataContext context)
        {
            this.context = context;
        }

        public bool CreatePokemon(int ownerId, int categoryId, Pokemon pokemon)
        {
            var owner = context.Owners.Where(a => a.Id == ownerId).FirstOrDefault();
            var category = context.Categories.Where(a => a.Id == categoryId).FirstOrDefault();

            var pokemonOwner = new PokemonOwner()
            {
                Owner = owner,
                Pokemon = pokemon,
            };

            context.Add(pokemonOwner);

            var pokemonCategory = new PokemonCategory()
            {
                Category = category,
                Pokemon = pokemon,
            };

            context.Add(pokemonCategory);

            context.Add(pokemon);

            return Save();
        }

        public Pokemon GetPokemon(int id)
        {
            return context.Pokemons.Where(p => p.Id == id).FirstOrDefault();
        }

        public Pokemon GetPokemon(string name)
        {
            return context.Pokemons.Where(p => p.Name == name).FirstOrDefault();
        }

        public decimal GetPokemonRating(int pokeId)
        {
            var review = context.Reviews.Where(p => p.Pokemon.Id == pokeId);

            if (review.Count() <= 0)
                return 0;

            return ((decimal)review.Sum(r => r.Rating) / review.Count());
        }

        public ICollection<Pokemon> GetPokemons()
        {
            //var pokemonList = (from p in context.Pokemons
            //                   join r in context.Reviews on p.Id equals r.Pokemon.Id into reviewsGroup
            //                   from review in reviewsGroup.DefaultIfEmpty()
            //                   group review by new { p.Id, p.Name, p.BirthDate } into g
            //                   select new Pokemon
            //                   {
            //                       Id = g.Key.Id,
            //                       Name = g.Key.Name,
            //                       BirthDate = g.Key.BirthDate,
            //                       Reviews = g.Select(r => new Review
            //                       {
            //                           Id = r != null ? r.Id : 1,
            //                           Rating = r != null ? r.Rating : 1,
            //                           Text = r != null ? r.Text : "",
            //                           Title = r != null ? r.Title : "",
            //                       }).ToList()
            //                   }).ToList();

            //return pokemonList;
            return context.Pokemons.OrderBy(p => p.Id).ToList();
        }

        public bool PokemonExists(int pokeId)
        {
            return context.Pokemons.Any(p => p.Id == pokeId);
        }

        public bool Save()
        {
            var saved = context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
