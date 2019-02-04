using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VariationsAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            //въвеждаме броя на елементите и класа им
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("k = ");
            int k = int.Parse(Console.ReadLine());

            // логиката на алгоритъма ще работи само при правилни стойности, ако не се изпълнява елс условието по-долу
            if (1 <= k && k <= n)
            {
                int variations = 1; //винаги почваме с 1, защото при примерен вход от н=1 и к=1 вариацията е =1
                for (int i = n; i > n - k; i--) //този цикъл се изпълнява докато разликат на броя - класа е по-малка от съответната итерация
                {
                    variations *= i;  //тогава целочислената променлива зв вариациите нараства като се умножава по i
                }
                Console.WriteLine("Variations = " + variations);  // с този ред изписваме колко са на брой вариациите

                //от тук започваме да генерираме съответните к-торки
                for (int i = 0; i < variations; i++) //цикъла ще върви докато i e < броя на вариациите
                {
                    // isNotAvailable е "грешната" стойност i.e. isAvailable е "правилната"
                    bool[] isNotAvailable = new bool[n];

                    int numberOfAvailElems = n; //инициализираме нова променлива за броя на елементите с които разполагаме
                    int variationsOfAvailElems = variations; //инициализираме нова променлива за броя на възможните вариации 

                    for (int j = 0; j < k; j++) // този цикъл ще върви докато j < класа на вариациите
                    {
                        numberOfAvailElems--; //броя на елементите ще намалява с по един

                        if (numberOfAvailElems + 1 > 0)  //когато броя на елементите е по-голям от нула, то възможната вариация ще се получава от вариацията разделена на броя +1 
                        {
                            variationsOfAvailElems /= (numberOfAvailElems + 1);  
                        }
                        else
                        {
                            variationsOfAvailElems = 1;  // или ако броя на елементите е равен на 1, то възможната вариация също ще е 1
                        }

                        int lotId = i / variationsOfAvailElems;
                        int indexInListOfAvailElems = lotId % (numberOfAvailElems + 1);

                        int x = 0;
                        int counterOfAvailElems = indexInListOfAvailElems + 1;
                        while (x < n && counterOfAvailElems > 0)
                        {
                            if (!isNotAvailable[x])
                            {
                                counterOfAvailElems--;
                            }
                            x++;
                        }
                        isNotAvailable[x - 1] = true;
                       Console.Write("{0,3}",x);     
                    }
                  Console.WriteLine();
                }

            }
            else 
            {
                Console.WriteLine("Грешен вход! Допустимите стойности са: 1 <= k <= n."); 
            }
    }
    }
}
