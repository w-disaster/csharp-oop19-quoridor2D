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
        private readonly String pathFile;
        public static readonly int BarrierComponents = 3;
        
        public SaveBarriers()
        {
            pathFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "saveBarriers.txt");
        }
        
        public Boolean Save(RoundBarriers barriers)
        {
            var barriersList = barriers.GetBarriersAsList();
            var barriersGraph = barriers.GetBarriersAsGraph();
            var writer = new StreamWriter(pathFile);
            foreach(var barrier in barriersList)
            {
                writer.WriteLine(JsonSerializer.Serialize(barrier.Coordinate));
                writer.WriteLine(JsonSerializer.Serialize(barrier.Orientation));
                writer.WriteLine(JsonSerializer.Serialize(barrier.Piece));
            }
            writer.Close();
            return true;
        }

        public int GetBarrierComponents()
        {
            return BarrierComponents;
        }
    }
}