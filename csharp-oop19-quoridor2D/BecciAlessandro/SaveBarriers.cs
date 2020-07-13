using System;
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

        private String pathFile;
        public SaveBarriers()
        {
            pathFile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + Path.PathSeparator +
                                                 ".quoridorcsharp" +
                                                 Path.PathSeparator + "barriersList";
        }
        
        public Boolean Save(RoundBarriers barriers)
        {
            var barriersList = barriers.GetBarriersAsList();
            var barriersGraph = barriers.GetBarriersAsGraph();
            Console.WriteLine(pathFile);
            File.WriteAllText(pathFile, JsonSerializer.Serialize(barriersList));
            Console.WriteLine(pathFile);
            return true;
        }
    }
}