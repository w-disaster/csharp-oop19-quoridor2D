using System.Collections.Generic;

namespace csharp_oop19_quoridor2D.Fabri_Luca.RoundBarriers
{
    public interface IRoundBarriers
    {
        /// <summary>
        /// Adds a barrier
        /// </summary>
        /// <param name="barrier"></param>
        void add(IBarrier barrier);

        /// <summary>
        /// Contains
        /// </summary>
        /// <param name="barrier"></param>
        /// <returns></returns> true if there is a IBarrier barrier
        bool contains(IBarrier barrier);

        /// <summary>
        /// Get barriers as a list IList
        /// </summary>
        /// <returns></returns> the list
        IList<IBarrier> getBarriersAsList();
    }
}