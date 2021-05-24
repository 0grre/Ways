using System;
using System.Collections.Generic;
using Ways_DAO.Models;

namespace Ways_DAO.Models
{
    public class OrientationChoice: AbstractChoice
    {
        public List<Orientation> Orientations { get; set; }

        public OrientationChoice(string label, DateTime createdAt, List<Orientation> orientations) : base(label, createdAt)
        {
            Orientations = orientations;
        }

        public List<Orientation> AddOrientation(Orientation orientation)
        {
           Orientations.Add(orientation);

           return Orientations;
        }
    }
}