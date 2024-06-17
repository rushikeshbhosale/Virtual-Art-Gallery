﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Virtual_Art_Gallery.Exceptions;
using Virtual_Art_Gallery.Models;
using Virtual_Art_Gallery.Repository;
using Virtual_Art_Gallery.VirtualArtGallery;

namespace Virtual_Art_Gallery.Service
{
    internal class GalleryManagementService
    {
        private readonly GalleryManagementRepository _gallerymanagement;

        public GalleryManagementService()
        {
            _gallerymanagement = new GalleryManagementRepository();
        }

        public void AddGallery(Gallery gallery)
        {
            if (_gallerymanagement.AddGallery(gallery))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Insertion Successful");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Insertion not successful. Try again!!!");
            }
        }

        public void UpdateGallery(Gallery gallery)
        {
            if (_gallerymanagement.UpdateGallery(gallery))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Updation successful");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Updation unsuccessful. Try again!!!");
            }
        }

        public void RemoveGallery(int galleryId)
        {
            try
            {
                GalleryNotFoundException.GalleryNotFound(galleryId);
                if (_gallerymanagement.RemoveGallery(galleryId))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Record has been deleted successfully");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Deletion unsuccessful.Try again!!!");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void SearchGallery()
        {
            try
            {
                var galleries = _gallerymanagement.searchGallery();

                foreach (Gallery item in galleries)
                {
                    
                    Console.WriteLine("ID: " + item.GalleryID);
                    Console.WriteLine("Name: " + item.Name);
                    Console.WriteLine("Description: " + item.Description);
                    Console.WriteLine("Location: " + item.Location);
                    Console.WriteLine("Curator: " + item.Curator);

                    // Format the opening time to hh:mm tt (hours:minutes AM/PM)
                    string openingTimeFormatted = item.OpeningHours.ToString(@"hh\:mm\:ss");
                    Console.WriteLine("Opening Time: " + DateTime.Parse(openingTimeFormatted).ToString("hh:mm tt"));

                    Console.WriteLine(new string('-', 120));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public void artworksInGallery(int galleryId)
        {
            try
            {
                GalleryNotFoundException.GalleryNotFound(galleryId);

                var artworks = _gallerymanagement.artworksInGallery(galleryId);

                foreach (Artwork item in artworks)
                {
                    Console.WriteLine("ID: " + item.ArtworkID);
                    Console.WriteLine("Title: " + item.Title);
                    Console.WriteLine("Description: " + item.Description);
                    Console.WriteLine("Creation Date: " + item.CreationDate.ToString("dd-MM-yyyy"));
                    Console.WriteLine("Medium: " + item.Medium);
                    Console.WriteLine("Image URL: " + item.ImageURL);
                    Console.WriteLine("Artist: " + item.ArtistId);
                    Console.WriteLine(new string('-', 132)); 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public void HandleMenu()
        {
            int choice = 0;
            do
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Gallery Management");
                Console.WriteLine("---------------------");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("1. Add Gallery\n2. Update Gallery\n3. Remove Gallery\n4. Display All Gallery\n5. Display Artworks in Gallery\n6. Exit\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());
                Console.WriteLine();
                Gallery gallery;
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter Name: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter description: ");
                        string desc = Console.ReadLine();
                        Console.WriteLine("Enter location: ");
                        string location = Console.ReadLine();
                        Console.WriteLine("Enter Curator id: ");
                        int curator = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter opening hour: ");
                        string time = Console.ReadLine();
                        gallery = new Gallery() { Name = name, Description = desc, Location = location, Curator = curator, OpeningHours = TimeSpan.Parse(time) };
                        AddGallery(gallery);
                        break;

                    case 2:
                        try
                        {
                            Console.WriteLine("Enter Gallery Id: ");
                            int id = int.Parse(Console.ReadLine());
                            GalleryNotFoundException.GalleryNotFound(id);
                            Console.WriteLine("Enter Name: ");
                            string u_name = Console.ReadLine();
                            Console.WriteLine("Enter description: ");
                            string u_desc = Console.ReadLine();
                            Console.WriteLine("Enter location: ");
                            string u_location = Console.ReadLine();
                            Console.WriteLine("Enter artist Id: ");
                            int u_curator = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter opening time: ");
                            string u_time = Console.ReadLine();
                            gallery = new Gallery(id, u_name, u_desc, u_location, u_curator, TimeSpan.Parse(u_time));
                            UpdateGallery(gallery);
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 3:
                        Console.WriteLine("Enter gallery id: ");
                        int gallery_id = int.Parse(Console.ReadLine());
                        RemoveGallery(gallery_id);
                        break;

                    case 4:
                        SearchGallery();
                        break;

                    case 5:
                        Console.WriteLine("Enter gallery id: ");
                        int galleryId = int.Parse(Console.ReadLine());
                        artworksInGallery(galleryId);
                        break;

                    case 6:
                        Console.WriteLine("Exiting....");
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Try again!!!");
                        break;
                }
            } while (choice != 6);
        }
    }
}
