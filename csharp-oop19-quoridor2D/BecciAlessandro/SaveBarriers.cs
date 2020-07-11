using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;
using csharp_oop19_quoridor2D.Fabri_Luca.RoundBarriers;

namespace csharp_oop19_quoridor2D.BecciAlessandro
{
    public class SaveBarriers
    {
        public void Save(RoundBarriers barriers)
        {
            var barriersList = barriers.GetBarriersAsList();
            var barriersGraph = barriers.GetBarriersAsGraph();
            File.WriteAllText("barriersList", JsonSerializer.Serialize(barriersList));
            
        }
    }
}