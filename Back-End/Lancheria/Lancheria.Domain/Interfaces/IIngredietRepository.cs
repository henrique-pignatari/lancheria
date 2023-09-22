using Lancheria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lancheria.Domain.Interfaces
{
    public interface IIngredietRepository
    {
        Task<IEnumerable<Ingredient>> GetIngredientsAsync();
        Task<Ingredient> GetByIdAsync(int id);
        Task<Ingredient> CreateAsync(Ingredient ingredient);
        Task<Ingredient> UpdateAsync(Ingredient ingredient);
        Task<Ingredient> DeleteAsync(Ingredient ingredient);
    }
}
