using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train {
    class BusinessWagon : PersonalWagon {
        private Person steward;
        internal Person Steward { get => steward; set => steward = value; }
        /// <summary>
        /// vytvoří instanci business vagonu
        /// </summary>
        /// <param name="numberOfChairs"></param>
        /// <param name="steward"></param>
        public BusinessWagon(int numberOfChairs, Person steward) : base(numberOfChairs) {
            this.steward = steward;
        }
		/// <summary>
		/// vrátí popis business vagonu
		/// </summary>
		/// <returns></returns>
		public override string ToString() {
            return $" Business vagon, počet sedadel: {NumberOfChairs}, steward: {Steward.FirstName} {Steward.LastName}";
        }
    }
}
