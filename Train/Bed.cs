using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train {
    class Bed {
        private int number;
        private bool reserved;

        public int Number { get => number; set => number = value; }
        public bool Reserved { get => reserved; set => reserved = value; }
        /// <summary>
        /// vytvoří instanci postele
        /// </summary>
        public Bed() { }
        /// <summary>
        /// zarezervuje postel nebo její rezervaci zruší
        /// </summary>
        /// <param name="reserved"></param>
        public Bed(bool reserved) {
            Reserved = reserved;
        }
    }
}
