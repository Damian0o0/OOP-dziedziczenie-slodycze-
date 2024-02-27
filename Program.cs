namespace OOP4
{
    class Program
    {



        static void Main(string[] args)
        {
            ShowData();
        }




        static void MaxCocoa(int x)
        {
            //1. wyszukaj obiekt z największą zawartoscią kakao
            //2. Ile zapłacimy jeżeli kupimy po kilogramie każdego rodzaju cukierków?
            //3. Wypisz informacje o wszystkich produktach firm,
            // których nazwa rozpoczyna sie literą W
            //4.



        }



        static void ShowData()
        {
            string file = @"storage.txt";
            string[] NamesChocolate = { "Malinowa", "Gorzka", "Wiśniowa", "Mleczna" };
            int[] NamesCandy = { 14, 10, 23, 18 };
            var rand = new Random();
            using (StreamReader sr = File.OpenText(file))
            {
                string s;
                int i = 0;
                Sweets[] sweets = new Sweets[20];
                while ((s = sr.ReadLine()) != null)
                {
                    var tab = s.Split(";");
                    if (tab[0] == "1")
                    {
                        int index = rand.Next(3);
                        Chocolate chocolate = new Chocolate(NamesChocolate[index]);
                        chocolate.SetInfo(tab[2], tab[3], Convert.ToInt32(tab[1]));
                        sweets[i] = chocolate;
                        sweets[i].Info();
                        i++;
                    }
                    if (tab[0] == "2")
                    {
                        int index = rand.Next(3);
                        Candy candy = new Candy(NamesCandy[index]);
                        candy.SetInfo(tab[2], tab[3], Convert.ToInt32(tab[1]));
                        sweets[i] = candy;
                        sweets[i].Info();
                        i++;




                    }
                }
            }
        }



        class Sweets
        {
            //klasa bazowa Słodycze (Cukierki, Czekoladki, Batoniki)
            public string Manu;
            public string Descr;
            public int Cocoa;
            public void SetInfo(string manu, string descr, int cocoa)
            {
                this.Manu = manu;
                this.Descr = descr;
                this.Cocoa = cocoa;
            }
            public virtual void Info()
            {
                Console.WriteLine(Manu + " wyprodukował: " + Descr);
                Console.WriteLine("Zawartość kakao: " + Cocoa + "%.");
            }



        }



        class Candy : Sweets
        {
            //klasa pochodna Cukierki
            private int Price = 0;
            public Candy(int price)
            {
                Price = price;
            }
            public override void Info()
            {
                Console.WriteLine(Manu + " wyprodukował: " + Descr);
                Console.WriteLine("Zawartość kakao: " + Cocoa + "%.");
                Console.WriteLine("Cena za kilogram: " + Price);
            }



        }



        class Chocolate : Sweets
        {
            //klasa pochodna Czekolady
            private string Name = "Smaczniusia";
            public Chocolate(string name)
            {
                Name = name;
            }
            public override void Info()
            {
                base.Info();
                Console.WriteLine("Unikatowa nazwa czekoladek: " + Name);



            }



        }
    }
}