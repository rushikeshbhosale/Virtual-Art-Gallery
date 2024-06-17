﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtual_Art_Gallery.Models
{
    public class Gallery
    {
        public int GalleryID { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; } 
        public int Curator { get; set; } 
        public TimeSpan OpeningHours { get; set; }

        //public int ArtistID { get; set; }
        public Gallery()
        {
            
        }

        public Gallery(int id,string name,string description,string location,int curator,TimeSpan openingtime)
        {
            GalleryID = id;
            Name = name;
            Description = description;
            Location = location;
            Curator = curator;
            OpeningHours = openingtime;
            //ArtistID = artistID;
        }

        public override string ToString()
        {
            return $"{GalleryID,-5}  {Name,-23}  {Description,-30}  {Location,-25}  {Curator,-12}  {OpeningHours}";
        }
    }
}
