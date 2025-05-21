using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class SportFacility
    {
        private int sportFacilityId;
        private string name;
        private string type;
        private string description;
        private int capacity;

        public int SportFacilityId
        {
            get { return sportFacilityId; }
            set { sportFacilityId = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

    }
}
