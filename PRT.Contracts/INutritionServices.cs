using PRT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRT.Contracts
{
    public interface INutritionServices
    {
        bool NutritionCreate(NutritionCreate model);
        IEnumerable<NutritionList> GetNutritions();
        NutritionDetail GetNutritionById(int nutritionId);

    }
}
