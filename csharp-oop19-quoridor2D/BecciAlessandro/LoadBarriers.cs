using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;
using csharp_oop19_quoridor2D.FabriLuca.Positioning;
using csharp_oop19_quoridor2D.FabriLuca.RoundBarriers;

namespace csharp_oop19_quoridor2D.BecciAlessandro
{
    public class LoadBarriers
    {
        private readonly String pathFile;
        public List<IBarrier> Barriers { get; set; }

        public LoadBarriers()
        {
            pathFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "saveBarriers.txt");
        }

        private int LinesInSaveFile(String path)
        {
            var reader = new StreamReader(path);
            var counter = 0;
            while (!reader.EndOfStream)
            {
                reader.ReadLine();
                counter++;
            }

            return counter;
       }
        
        public Boolean Load()
        {
            Barriers = new List<IBarrier>();
            var reader = new StreamReader(pathFile);
            for (var i = 0; i < LinesInSaveFile(pathFile) / SaveBarriers.BarrierComponents ; i++)
            {
                var firstCoord = JsonSerializer.Deserialize<int>(reader.ReadLine());
                var secondCoord = JsonSerializer.Deserialize<int>(reader.ReadLine());
                var orientation = JsonSerializer.Deserialize<BarrierOrientation>(reader.ReadLine());
                var piece = JsonSerializer.Deserialize<BarrierPiece>(reader.ReadLine());
                Barriers.Add(new Barrier(new Coordinate(firstCoord, secondCoord), orientation, piece));
            }
            reader.Close();
            return true;
        }
    }
}