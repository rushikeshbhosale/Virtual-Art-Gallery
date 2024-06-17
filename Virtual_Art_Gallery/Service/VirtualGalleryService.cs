﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virtual_Art_Gallery.Exceptions;
using Virtual_Art_Gallery.Models;
using Virtual_Art_Gallery.Repository;

namespace Virtual_Art_Gallery.Service
{
    internal class VirtualGalleryService
    {
        private readonly GalleryRepository _virtualgallery;

        public VirtualGalleryService()
        {
            _virtualgallery = new GalleryRepository();
        }

        public void addRecordsToArtwork(Artwork artwork)
        {
            try
            {
                ArtistNotFoundException.ArtistNotFound(artwork.ArtistId);
                if (_virtualgallery.addArtwork(artwork))
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
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void updateArtwork(Artwork artwork)
        {
            try
            {
                ArtistNotFoundException.ArtistNotFound(artwork.ArtistId);
                if (_virtualgallery.updateArtwork(artwork))
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
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void removeArtwork(int artworkId)
        {
            try
            {
                ArtworkNotFoundException.ArtworkNotFound(artworkId);
                if (_virtualgallery.removeArtwork(artworkId))
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void getArtwork(int artworkId)
        {
            try
            {
                ArtworkNotFoundException.ArtworkNotFound(artworkId);

               
                var artwork = _virtualgallery.getArtworkById(artworkId);

                Console.WriteLine("ID: " + artwork.ArtworkID);
                Console.WriteLine("Title: " + artwork.Title);
                Console.WriteLine("Description: " + artwork.Description);
                Console.WriteLine("Creation Date: " + artwork.CreationDate.ToString("dd-MM-yyyy"));
                Console.WriteLine("Medium: " + artwork.Medium);
                Console.WriteLine("Image URL: " + artwork.ImageURL);
                Console.WriteLine("Artist: " + artwork.ArtistId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        public void searchArtwork()
        {
            try
            {
                var artworks = _virtualgallery.searchArtworks();

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


        public void addFavorite(int u_id, List<int> a_id)
        {
            try
            {
                foreach (int item in a_id)
                {
                    ArtworkNotFoundException.ArtworkNotFound(item);
                }
                if (_virtualgallery.addArtworkToFavorite(u_id, a_id))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Favorite artwork added successfully");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Operation unsuccessful");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void removeFavorite(int u_id, int a_id)
        {
            try
            {
                ArtworkNotFoundException.ArtworkNotFound(a_id);
                if (_virtualgallery.removeArtworkFromFavorite(u_id, a_id))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Favorite artwork removed unsuccessfully");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Operation unsuccessful");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void getUserFavorite(int userId)
        {
            try
            {
               
                UserNotFoundException.UserNotFound(userId);

                var favoriteArtworks = _virtualgallery.getUserFavoriteArtworks(userId);

                // Print the details of each favorite artwork
                foreach (Artwork item in favoriteArtworks)
                {
                    Console.WriteLine("ID: " + item.ArtworkID);
                    Console.WriteLine("Title: " + item.Title);
                    Console.WriteLine("Description: " + item.Description);
                    Console.WriteLine("Creation Date: " + item.CreationDate.ToString("dd-MM-yyyy"));
                    Console.WriteLine("Medium: " + item.Medium);
                    Console.WriteLine("Image URL: " + item.ImageURL);
                    Console.WriteLine("Artist: " + item.ArtistId);
                    Console.WriteLine(new string('-', 132)); // Separator line between artworks
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public void Handlemenu()
        {

            int choice = 0, choice2 = 0, choice3 = 0;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Welcome to Virtual Art Gallery!!!\n\n");
                Console.WriteLine("Main Menu");
                Console.WriteLine("---------------");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Press 1: Artwork Management\nPress 2: User Favorite\nPress 3: Gallery Management\nPress 4: Exit\n\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (choice)
                {
                    case 1:
                        do
                        {
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Artwork Management");
                            Console.WriteLine("---------------------");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("1. Add Artwork\n2. Update Artwork\n3. Remove Artwork\n4. Get Artwork\n5. Display All Artwork\n6. Exit\n");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Enter your choice: ");
                            choice2 = int.Parse(Console.ReadLine());
                            Console.WriteLine();
                            Artwork artwork;
                            switch (choice2)
                            {
                                case 1:
                                    Console.WriteLine("Enter title: ");
                                    string title = Console.ReadLine();
                                    Console.WriteLine("Enter description: ");
                                    string desc = Console.ReadLine();
                                    Console.WriteLine("Enter creation date: ");
                                    string date = Console.ReadLine();
                                    Console.WriteLine("Enter medium: ");
                                    string medium = Console.ReadLine();
                                    Console.WriteLine("Enter image url: ");
                                    string url = Console.ReadLine();
                                    Console.WriteLine("Enter artist id: ");
                                    int artistId = int.Parse(Console.ReadLine());
                                    artwork = new Artwork() { Title = title, Description = desc, CreationDate = DateTime.Parse(date), Medium = medium, ImageURL = url, ArtistId = artistId };
                                    addRecordsToArtwork(artwork);
                                    break;

                                case 2:
                                    try
                                    {
                                        Console.WriteLine("Enter artwork id: ");
                                        int artId = int.Parse(Console.ReadLine());
                                        ArtworkNotFoundException.ArtworkNotFound(artId);
                                        Console.WriteLine("Enter title: ");
                                        string u_title = Console.ReadLine();
                                        Console.WriteLine("Enter description: ");
                                        string u_desc = Console.ReadLine();
                                        Console.WriteLine("Enter creation date: ");
                                        string u_date = Console.ReadLine();
                                        Console.WriteLine("Enter medium: ");
                                        string u_medium = Console.ReadLine();
                                        Console.WriteLine("Enter image url: ");
                                        string u_url = Console.ReadLine();
                                        Console.WriteLine("Enter artist id: ");
                                        int u_artistId = int.Parse(Console.ReadLine());
                                        artwork = new Artwork(artId, u_title, u_desc, DateTime.Parse(u_date), u_medium, u_url, u_artistId);
                                        updateArtwork(artwork);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    break;

                                case 3:
                                    Console.WriteLine("Enter artwork id: ");
                                    int a_id = int.Parse(Console.ReadLine());
                                    removeArtwork(a_id);
                                    break;

                                case 4:
                                    Console.WriteLine("Enter artwork id: ");
                                    int art_id = int.Parse(Console.ReadLine());
                                    getArtwork(art_id);
                                    break;

                                case 5:
                                    searchArtwork();
                                    break;

                                case 6:
                                    Console.WriteLine("Exiting....");
                                    break;

                                default:
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Try again!!!");
                                    break;
                            }
                        } while (choice2 != 6);
                        break;

                    case 2:
                        do
                        {
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("User Favorite");
                            Console.WriteLine("----------------");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("1. Add Favorite\n2. Remove Favorite\n3. Get Favorite\n4. Exit\n\n");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Enter your choice: ");
                            choice3 = int.Parse(Console.ReadLine());
                            Console.WriteLine();
                            switch (choice3)
                            {
                                case 1:
                                    try
                                    {
                                        searchArtwork();
                                        Console.WriteLine();
                                        Console.WriteLine("Enter user id: ");
                                        int userId = int.Parse(Console.ReadLine());
                                        UserNotFoundException.UserNotFound(userId);
                                        Console.WriteLine("Enter your favorite artwork ids (Enter 0 to stop)");
                                        List<int> artworkId = new List<int>();
                                        int input = 0;
                                        while (true)
                                        {
                                            input = int.Parse(Console.ReadLine());
                                            if (input == 0)
                                                break;
                                            artworkId.Add(input);
                                        }
                                        addFavorite(userId, artworkId);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    break;

                                case 2:
                                    try
                                    {
                                        Console.WriteLine("Enter user id: ");
                                        int user_id = int.Parse(Console.ReadLine());
                                        UserNotFoundException.UserNotFound(user_id);
                                        Console.WriteLine("Enter Artwork id: ");
                                        int artwork_id = int.Parse(Console.ReadLine());
                                        removeFavorite(user_id, artwork_id);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    break;

                                case 3:
                                    Console.WriteLine("Enter user id: ");
                                    int u_id = int.Parse(Console.ReadLine());
                                    getUserFavorite(u_id);
                                    break;

                                case 4:
                                    Console.WriteLine("Exiting....");
                                    break;

                                default:
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Try again!!!");
                                    break;
                            }
                        } while (choice3 != 4);
                        break;

                    case 3:
                        GalleryManagementService service = new GalleryManagementService();
                        service.HandleMenu();
                        break;

                    case 4:
                        Console.WriteLine("Exiting....");
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Try again!!!");
                        break;

                }
            } while (choice != 4);
        }
    }
}
