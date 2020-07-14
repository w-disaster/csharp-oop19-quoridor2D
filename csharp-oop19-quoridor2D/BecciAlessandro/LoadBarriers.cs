using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;
using csharp_oop19_quoridor2D.Fabri_Luca.Positioning;
using csharp_oop19_quoridor2D.Fabri_Luca.RoundBarriers;

namespace csharp_oop19_quoridor2D.BecciAlessandro
{
    public class LoadBarriers
    {
        private readonly String pathFile;
        private RoundBarriers rb;

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
            var listBarrier = new List<IBarrier>();
            var reader = new StreamReader(pathFile);
            for (var i = 0; i < LinesInSaveFile(pathFile) / SaveBarriers.BarrierComponents ; i++)
            {
                var coord = JsonSerializer.Deserialize<Coordinate>(reader.ReadLine());
                var orientation = JsonSerializer.Deserialize<BarrierOrientation>(reader.ReadLine());
                var piece = JsonSerializer.Deserialize<BarrierPiece>(reader.ReadLine());
                listBarrier.Add(new Barrier(coord, orientation, piece));
            }
            reader.Close();
            Console.WriteLine(listBarrier);
            return true;
        }
    }
}