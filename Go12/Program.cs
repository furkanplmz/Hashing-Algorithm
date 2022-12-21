using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Go12
{
    internal class Program
    {   
        class Block
        {
            public int data;
            public Block next;
            public Block prev;
        }
        static int hashing (int data)
        {
            data = data - 213205001;
            data = data % 100;
            return data;
        }
        static void ekle(int data)
        {
            int indis = hashing(data);
            if (hash[indis]==0)
            {
                hash[indis] = data;
            }
            else
            {
                //for (int i = 0; i < hash.Length; i++)
                //{
                //    if (hash[i] == 0)
                //    {
                //        hash[i] = data;
                //        break;
                //    }
                //}

                //linked list ile çözümü
                Block bL = new Block();
                bL.data = data;
                //if(coll[indis]!=null)
                //{coll[indis].prev=bl;}
                bL.next = coll[indis];
                coll[indis] = bL;
               
            }
        }
        static int search(int data)
        {
            int indis = hashing(data);
            int bulundu = 0;
            if (hash[indis] == data)
            {
                return 1;
            }
            else
            {
                //for (int i = 0; i < hash.Length; i++)
                //{
                //    if (hash[i] == data)
                //    {
                //        bulundu = 1; 
                //        break;
                //    }
                //}

                //linked list ile çözümü
                Block temp = coll[indis];
                while (temp!=null)
                {
                    if (temp.data == data)
                    {
                        bulundu = 1;
                        break;
                    }
                    temp = temp.next;
                }
            }
            return bulundu;
        }
        static int[] hash=new int[100];
        
        static Block[] coll=new Block[100];

        static void delete(int data)
        {
            int indis=hashing(data);
            if (hash[indis] == data)
            {
                hash[indis] = 0;
                //yoksa linked list ile search ve delete et.
                if (coll[indis]!=null)
                {
                    hash[indis] = coll[indis].data;
                    coll[indis] = coll[indis].next;
                }
                else
                {
                    hash[indis] = 0;
                }
            }
            else
            {
                //
            }
        }
        static void Main(string[] args)
        {

            //hashing arama/search en hızlı arama x[indis] üzerinden
            //diziler üzerinde implement //hashing linked list ile yazılamaz//
            //hangi veri arama için kullanılacak
            //veri---->sayi ya
            //çevirmeliyiz
            //dönüşüm hash function
            //dengeli dağıtmak
            //hashing hash function performansına bağlıdır. 
            //moduler % kullanacağız
            //ABC = 65+66+67 assci değerleri    -65 TEN ÇIKARTIRSAK 65 TAN ÖNCESİNİ ALIR
            //A = 65    
            //1,2,3,4,5,6,7
            //2132055001...213205999 - 213205001;    213205057  213205024
            //213205025=2+1+3+2+0+5+0+2+5=20

            ekle(213205005);
            ekle(213205105);
            ekle(213205205);
            //collusion oluştu mod 100 olduğu için aynı yere yazdılar overrite oluştu
            if (search(213205005)==1)
            {
                Console.WriteLine("Bulundu");
            }
            else
            {
                Console.WriteLine("Bulunamadı");
            }
            if (search(213205205) == 1)
            {
                Console.WriteLine("Bulundu");
            }
            else
            {
                Console.WriteLine("Bulunamadı");
            }



            Console.ReadLine();
        }
    }
}
