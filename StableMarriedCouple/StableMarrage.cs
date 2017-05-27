using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StableMarriedCouple
{
    class StableMarrage
    {
        //Adjacancy matrices for disjoint sets mapping
        private int[][] manpreference;//Store the Preference table of men
        private int[][] womanpreference;//Store the Preference table of woman
        private int numofcouple;//Store the number of couples
        //private static readonly bool value = false;
        private Random rnd = new Random();//Random function generator 

        static void Main(string[] args)
        {
            //Two disjoint sets manlist and womanlist
            string[] manlist = { "George", "Jerry", "Kramer", "Newman","Mark" };
            string[] womanlist = { "Carrie", "Leela", "Kamala", "Jane","Rai" };
            //int numofcouple = manlist.Length;
            int numofmen = manlist.Length;
            int numofwomen = womanlist.Length;
            StableMarrage couple = new StableMarrage(numofmen, numofwomen);//Checking stable marrages
            couple.showPreftable(manlist, womanlist);//Show the preference tables
            int[] marriedCouple = couple.stableCouple(numofmen, numofwomen);//Take the married couples
            couple.showMarriagecouples(marriedCouple,manlist,womanlist);//Show married couples on the console
            Console.ReadKey();
        }
        //Create the random preferences for each men and women list
        public StableMarrage(int menlength,int womenlength) {
            this.numofcouple = Math.Max(menlength, womenlength);
            manpreference = new int[womenlength][];
            womanpreference = new int[menlength][];
            for (int i = 0; i < womenlength; i++)
            {
                manpreference[i] = new int[menlength];
                randomGenerator(manpreference[i]);}
            for (int i = 0; i < menlength; i++)
            {
                womanpreference[i] = new int[womenlength];
                randomGenerator(womanpreference[i]);
            }
        }
        //Store the list values in random order most significant to least significant
        private void randomGenerator(int[] vector){
            for (int i = 0; i < vector.Length; i++)
                vector[i] = i;
            //Create the random permutation
            for (int i = vector.Length - 1; i > 0; i--) {
                int j = rnd.Next(i + 1);//Random value generate
                int temp = vector[i];//Swap the values v[i] and random value v[j]
                vector[i] = vector[j];
                vector[j] = temp;
            }
        }
        //Argument parse to the showMatrix() method to print tables
        private void showPreftable(string[] manlist, string[] womanlist)
        {
            Console.WriteLine("Man Preference Table for each woman :\n");
            showMatrix(manpreference, manlist,womanlist);
            Console.WriteLine("\nWoman Preference Table for each man :\n");
            showMatrix(womanpreference, womanlist,manlist);
        }
        //Display the matrix of preference order of men and women list
        private void showMatrix(int[][] matrix, string[] memberlist,string[] referencelist)
        {
            if (matrix == null)
                Console.WriteLine("Can't visible preference table");
            for (int i = 0; i < matrix.Length; i++) {
                Console.Write(referencelist[i]+"\t-\t");
                for (int j = 0; j < matrix[i].Length; j++) {
                    Console.Write(memberlist[matrix[i][j]] + "\t");
                }
                Console.WriteLine();
            }
        }
        //Return a stable married couples array where currentCouple[i] is the man married to woman i
        private int[] stableCouple(int manlistlength, int womanlistlength) 
        {
            int[] currentCouple = new int[numofcouple];//Woman i is currently engaged to the man vector[i]
            const int NOT_ENGAGED = -1;
            for (int i = 0; i < currentCouple.Length; i++)
                currentCouple[i] = NOT_ENGAGED;
            //List of men that who are not currently engaged
            LinkedList freemen = new LinkedList();
            for (int i = 0; i < manlistlength; i++)
            {
                freemen.Add(i);
            }
            //This is for the (nextPosition[i]) next woman to ehome i has not proposed
            int[] nextPosition = new int[numofcouple];
           
            
            //Compute Ranking and element removing from the queue
            while(!freemen.isEmpty())
            {
                int man = freemen.Remove().iData;
                int woman = manpreference[man][nextPosition[man]];
                 
                nextPosition[man]++;
                    
                //showValue("man = " + man + "woman = " + woman);
                if (currentCouple[woman] == NOT_ENGAGED)
                {
                    currentCouple[woman] = man;
                }
                else
                {
                    int otherman = currentCouple[woman];
                    if (preferenceOrder(woman, man, otherman))
                    {
                        currentCouple[woman] = man;
                        freemen.Add(otherman);
                    }
                    else
                        freemen.Add(man);
                }
            }
            return currentCouple;
        }

        //Returns true if woman prefers man to otherman
        private bool preferenceOrder(int woman, int man, int otherman)
        {
            for (int i = 0; i < numofcouple; i++) {
                int preference = womanpreference[woman][i];
                if (preference == man)
                    return true;
                if (preference == otherman)
                    return false;
            }
            Console.WriteLine("Invalid preference occur in woman list : " + woman);
            return false;
        }
        //Display the matrix of marriedCouples
        private void showMarriagecouples(int[] marriedcouple,string[] manlist,string[] womanlist)
        {
            Console.WriteLine("List of married couples :\n");
            Console.WriteLine("Woman" + "\t\t" + "Man");
            Console.WriteLine("----------------------");
            for (int i = 0; i < marriedcouple.Length; i++)
            {
                if (marriedcouple[i] != -1)
                    Console.WriteLine(womanlist[i] + "\t+\t" + manlist[marriedcouple[i]]);
                else
                    Console.WriteLine(womanlist[i] + "\t+\t" + " - ");
            }
        }
    }
}
