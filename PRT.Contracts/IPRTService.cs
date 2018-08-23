using PRT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRT.Contracts
{
    public interface IPRTService
    {
        bool PrtCreate(PrtScoresCreate model);
        IEnumerable<PrtScoresList> GetPrtScores();
        PrtDetail GetPrtById(int prtId);



    }
}
