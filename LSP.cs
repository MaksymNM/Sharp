using System;


    class Program
    {
        static void Main(string[] args)
        {
            Computers computers = new Laptop();
            Console.WriteLine(computers.GetType()+ ": " + computers.GetName());
            Console.WriteLine(computers.PlayGame("change-game"));
            Console.WriteLine("---------------------");
            computers = new Desktop();
            Console.WriteLine(computers.GetType()+ ": " + computers.GetName());
            Console.WriteLine(computers.PlayGame("change-game"));
            Console.WriteLine("---------------------");
            computers = new Monoblock();
            Console.WriteLine(computers.GetType() + ": " + computers.GetName());
            Console.WriteLine(computers.PlayGame("change-game"));
        }
    }
    



    public abstract class Computers
    {
        public abstract string GetName();
        public abstract string GetType();
        public abstract string PlayGame(string game);
    }
    
    public class Laptop : Computers
    {
        public override string GetName()
        {
            return "Asus ROG";
        }
        public override string GetType()
        {
            return "Laptop";
        }
        
        public override string PlayGame(string game)
        {
            if(game == "Super Mario")
                throw new Exception("Cannot launch this game");

            Random r = new Random();
            int fps = r.Next(30,60);
            string res = "FPS: "+ fps.ToString();
            if(fps < (40-50))
                throw new Exception("Running slow, buy a new device"); 
            return res;          
        }
    }
    public class Desktop : Computers
    {
        public override string GetName()
        {
            return "Artline";
        }
        public override string GetType()
        {
            return "Desktop";
        }
        public override string PlayGame(string game)
        {
            if(game == "Half-Life 3")
                throw new Exception("Is not released ((");

            Random r = new Random();
            int fps = r.Next(80,250);
            string res = "FPS: "+fps.ToString();
            
            if(fps < 100)
                throw new Exception("Running slow, buy a new device");  
            return res;      
        }
    }
    public class Monoblock : Computers
    {
        public override string GetName()
        {
            return "Apple iMac";
        }
        
        public override string GetType()
        {
           return "Monoblock";
        }
        
        public override string PlayGame(string game)
        {
            if(game == "AnyGame")
                throw new Exception("No games on mac sry(");

            Random r = new Random();
            int fps = r.Next(60,80);
            string res = "FPS: "+fps.ToString();
            
            if(fps < 50)
                throw new Exception("Running slow, buy a new ApplE iMAC PRO");            
            return res;
        }
    }