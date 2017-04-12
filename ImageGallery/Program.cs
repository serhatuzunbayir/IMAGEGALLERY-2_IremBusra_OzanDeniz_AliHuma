using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageGallery
{
    public interface IAlbum
    {
        void Show(int depth);
        string getItemName();
    }


    public class Album : IAlbum
    {

        string name;
        List<IAlbum> my_album = new List<IAlbum>();

        public string getItemName()
        {
            return name;
        }
        public Album(string album_name)
        {
            name = album_name;
        }

        public void Show(int depth)
        {
            Console.WriteLine("|----------------------|");
            Console.WriteLine(new String('-', depth) + "Album: " + name);
            Console.WriteLine("|----------------------|");


            if (my_album.Count() < 1)
            {
                Console.WriteLine("|_Your album is empty__|");
            }

            else
            {
                foreach (IAlbum item in my_album)
                {

                    item.Show(depth + 2);
                }
                Console.WriteLine("|______________________|");

            }

        }
        public void AddPhoto(IAlbum album)
        {
            my_album.Add(album);
        }

        public IAlbum Find(string name)
        {

            IAlbum album = my_album.Find(x => x.getItemName() == name);
            return album;
        }



    }

    public class Photo : IAlbum
    {
        string name;
        public Photo(string photo_name)
        {

            name = photo_name;
        }

        public string getItemName()
        {
            return name;
        }
        public void Show(int depth)
        {

            Console.WriteLine("|**********************|");
            Console.WriteLine(new String('-', depth) + "Photo: " + name);
            Console.WriteLine("|**********************|");
        }


    }







    class Program
    {
        static void Main(string[] args)
        {

            int menuSelection = 0;
            string name;

            Album root, album;
            Photo photo;
            root = new Album("Root");
            do
            {

                Console.WriteLine("~~ Menu ~~");
                Console.WriteLine("1 - To create new album");
                Console.WriteLine("2 - To create new photo");
                Console.WriteLine("3 - To edit items");
                Console.WriteLine("9 - To show all");
                Console.WriteLine("0 - To exit");

                menuSelection = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(menuSelection);


                switch (menuSelection)
                {

                    case 1:
                        Console.Clear();

                        Console.WriteLine("Please enter an album name (0 - Go back to Menu)");
                        name = Convert.ToString(Console.ReadLine());

                        if (name == "0") break;
                        Console.WriteLine("Album '" + name + "' created!");
                        album = new Album(name);
                        root.AddPhoto(album);
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Please enter a photo name (0 - Go back to Menu)");
                        name = Convert.ToString(Console.ReadLine());

                        if (name == "0") break;
                        Console.WriteLine("Photo '" + name + "' created!");
                        photo = new Photo(name);
                        root.AddPhoto(photo);
                        break;

                    case 3:
                        Console.Clear();
                        root.Show(0);
                        Console.WriteLine("Enter item name");
                        name = Convert.ToString(Console.ReadLine());

                        try
                        {
                            Album item = (Album)root.Find(name);
                            Console.WriteLine("Enter an item name to add> " + item.getItemName());
                            name = Convert.ToString(Console.ReadLine());
                            item.AddPhoto(root.Find(name));
                            Console.WriteLine("Success!");
                        }

                        catch (Exception e)
                        {
                            throw e;
                        }

                        
                        break;
                    case 9:
                        Console.Clear();
                        root.Show(0);
                        break;
                }


            } while (menuSelection != 0);



            



            Console.WriteLine("Exit from switch-case");
            Console.ReadKey();
        }
    }
}
