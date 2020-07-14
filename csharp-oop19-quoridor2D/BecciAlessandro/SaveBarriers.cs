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
        //The Components of a Barrier
        public static readonly int BarrierComponents = 4;
        
        public SaveBarriers()
        {
            pathFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "saveBarriers.txt");
        }
        
        /*
         * This can be used also for saving the graph.
         */
        public Boolean Save(RoundBarriers barriers)
        {
            var barriersList = barriers.GetBarriersAsList();
            var writer = new StreamWriter(pathFile);
            foreach(var barrier in barriersList)
            {
                writer.WriteLine(JsonSerializer.Serialize(barrier.Coordinate.First));
                writer.WriteLine(JsonSerializer.Serialize(barrier.Coordinate.Second));
                writer.WriteLine(JsonSerializer.Serialize(barrier.Orientation));
                writer.WriteLine(JsonSerializer.Serialize(barrier.Piece));
            }
            writer.Close();
            return true;
        }
    }
}