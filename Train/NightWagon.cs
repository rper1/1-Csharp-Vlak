using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train {
    class NightWagon : PersonalWagon {
        private Bed[] beds;
        private int numberOfBeds;
        public int NumberOfBeds { get => numberOfBeds; set => numberOfBeds = value; }
        internal Bed[] Beds { get => beds; set => beds = value; }
        /// <summary>
        /// vytvoří instanci spacího vagonu
        /// </summary>
        /// <param name="numberOfBeds"></param>
        /// <param name="numberOfChairs"></param>
        public NightWagon(int numberOfBeds, int numberOfChairs) :base(numberOfChairs){
            this.numberOfBeds = numberOfBeds;
        }
        /// <summary>
        /// vrátí popis vagonu
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return $" Noční vagon, počet sedadel: {NumberOfChairs}, počet lůžek: {NumberOfBeds}";
        }
    }
}
