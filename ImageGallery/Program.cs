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
        int GetId();
        void Rename(string newName);
        IAlbum GetPhoto(int ID);
        
        
    }


    public class Album : IAlbum
    {
        int Id;
        string name;
        List<IAlbum> my_album = new List<IAlbum>();
        
        




        public Album(string album_name, int id)
        {
            name = album_name;
            Id = id;
        }

        public int GetId()
        {
            return Id;
        }

        public void Rename(string newName)
        {
            name = newName;
        }

        public void Show(int depth)
        {
            Console.WriteLine("|Id = |" + Id.ToString());
            Console.WriteLine(new String('-', depth) + "Album: " + name);
            


            if (my_album.Count() < 1)
            {
                Console.WriteLine("|_Your album is empty__|");
                Console.WriteLine("||");
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

        public void DeletePhoto(IAlbum album)
        {
            my_album.Remove(album);
        }
        
        
       
        public IAlbum GetPhoto(int ID)
        {
            if (Id == ID)
            {
                return this;
            }

            //Make it recursive
            //foreach (IAlbum alb in my_album.ToArray())
            //{
            //    if (alb.GetPhoto(ID) == null) continue;
            //}
            return null;
        }


    }

    public class Photo : IAlbum
    {
        int Id;
        string name;
        public Photo(string photo_name, int id)
        {

            name = photo_name;
            Id = id;
        }

        public int GetId()
        {
            return Id;
        }

        public IAlbum GetPhoto(int ID)
        {
            if (Id == ID)
                return this;
            else return null;
        }

        public void Rename(string newName)
        {
            name = newName;
        }

        public void Show(int depth)
        {

            Console.WriteLine("|Id = |" + Id);
            Console.WriteLine("|" + new String('-', depth) + "Photo: " + name);
            Console.WriteLine("||");
        }

       


    }

    
   

    







    class Program
    {
        static void Main(string[] args)
        {
            int albumId = 0;
            int menuSelection = 0;
            
            string name;

            Album root, album;
            Photo photo;
            root = new Album("Root", 0);
            do
            {

                Console.WriteLine("~~ Menu ~~");
                Console.WriteLine("1 - To create new album");
                Console.WriteLine("2 - To create new photo");
                Console.WriteLine("3 - To rename items");
                Console.WriteLine("4 - To delete item");
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
                        album = new Album(name, GetId());
                        root.AddPhoto(album);
                        
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Please enter a photo name (0 - Go back to Menu)");
                        name = Convert.ToString(Console.ReadLine());

                        if (name == "0") break;
                        Console.WriteLine("Photo '" + name + "' created!");
                        photo = new Photo(name, GetId());
                        root.AddPhoto(photo);
                        break;

                    case 3:
                        Console.Clear();
                        root.Show(0);
                        Console.WriteLine("Enter item Id");
                        int id = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter new name");
                        root.GetPhoto(id).Rename(Console.ReadLine());


                        break;

                    case 4:
                        Console.Clear();
                        root.Show(0);
                        Console.WriteLine("Enter item Id to delete");
                        int deleteId = Convert.ToInt32(Console.ReadLine());

                        root.DeletePhoto(root.GetPhoto(deleteId));

                        
                        break;


                    case 5:
                        Console.Clear();
                        root.Show(0);
                        Console.WriteLine("Enter two item id ([add_me] [to_this_ALBUM]");
                        int addId = Convert.ToInt32(Console.ReadLine());
                        int thisId = Convert.ToInt32(Console.ReadLine());

                        Album addToAlbum = null;
                        IAlbum item = null;


                        addToAlbum = (Album)root.GetPhoto(thisId);
                        item = root.GetPhoto(addId);

                        addToAlbum.AddPhoto(item);
                        root.DeletePhoto(item);
                        root.Show(0);
                        break;

                    case 9:
                        Console.Clear();
                        root.Show(0);
                        break;
                }


            } while (menuSelection != 0);

            int GetId()
            {
                albumId++;
                return albumId;
            }





            Console.WriteLine("Exit from switch-case");
            Console.ReadKey();
        }
    }
}
