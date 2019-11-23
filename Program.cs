using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork20191111
{
    class Program
    {

        static int EnterYourNumber(string str)
        {
            int num = 0;
            do
            {
                Console.WriteLine("Please, enter number " + str + " :");

            } while (PositiveInt(Console.ReadLine(), ref num) == false);
            return num;
        }

        static bool PositiveInt(string str, ref int num)
        {
            int myInt;
            bool isInt = int.TryParse(str, out myInt);
            if (isInt == true)
            {
                if (myInt > 0)
                {
                    num = myInt;
                    return true;
                }
                else
                {
                    Console.WriteLine("This is not positive number, try again");
                    num = 0;
                    return false;
                }

            }
            else
            {
                Console.WriteLine("This is not  number, try again");
                num = 0;
                return false;
            }
        }
        static int EnterMark(int i)
        {
            int num = 0;
            do
            {
                Console.WriteLine("Please, enter mark of the student numder "+(i+1));

            } while (NumValidation(Console.ReadLine(), ref num ,0,100) == false);
            return num;
        }
        static int EnterNum(string str,int top ,int bottom)
        {
            int num = 0;
            do
            {
                Console.WriteLine("Please, enter {2} from {0} to {1} ",top,bottom,str );

            } while (NumValidation(Console.ReadLine(), ref num, top, bottom) == false);
            return num;
        }
        static bool NumValidation(string str, ref int num, int top, int bottom)
        {
            int myInt;
            bool isInt = int.TryParse(str, out myInt);
            if (isInt == true)
            {
                if (myInt >= top&& myInt<= bottom)
                {
                    num = myInt;
                    return true;
                }
                else
                {
                    Console.WriteLine("Number is not valid, try again");
                    num = 0;
                    return false;
                }

            }
            else
            {
                Console.WriteLine("This is not  number, try again");
                num = 0;
                return false;
            }
        }
        static bool isContinue(int[,] matrix,int size)
        {

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    if (matrix[i, j] != 0)
                        return true;
                }
            return false;    
        }

        static void Main(string[] args)
        {
            Random rd=new Random();
 //Exercise 1
            Console.WriteLine("**********");
            Console.WriteLine("Exercise 1");
            Console.WriteLine("**********");
            int students=EnterYourNumber(" of students");
            int[] arr = new int[students];
            int mark=0;
            for (int i=0; i < students;i++ )
            {
               arr[i] = EnterMark(i);
            }
            mark = 0;
            for (int i=0; i < students; i++)
            {
                mark+=arr[i];
            }
            mark = (int)(mark / students);
            Console.WriteLine("Average mark is :"+mark);
 //Exercise 2
            Console.WriteLine("**********");
            Console.WriteLine("Exercise 2");
            Console.WriteLine("**********");
            int [,] matrix=new int[5,5];
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    matrix[i, j] = rd.Next(1, 11);
            int number = EnterNum("number",1,10);

            bool isExist = false;
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    if (matrix[i, j] == number)
                    {
                        
                        isExist = true;
                       Console.WriteLine("Your number is in the line : {0} and in the column : {1}" , i,j);
                    }
                }
            if (!isExist)
                Console.WriteLine("Your number is not exists in matrix");
/*/Exercise 3
            Console.WriteLine("**********");
            Console.WriteLine("Exercise 3");
            Console.WriteLine("**********");
            int[,] matrix1 = new int[3, 3];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    matrix1[i, j] = rd.Next(0, 2);
                    //Console.WriteLine("line=" + i + " " + "colomn=" + j + " " + matrix1[i, j]);
                }
            int line = 0;
            int col = 0;
            number = 0;
            
            do{
               line = EnterNum("number of line", 0, 2);
               col = EnterNum("number of column", 0, 2);
               if (matrix1[line, col] == 1)
               {
                   matrix1[line, col]=0;
                   Console.WriteLine("Boom");
                   mark++;
               }
               else
                   Console.WriteLine("Miss");
               number++;
   

            }while( isContinue(matrix1 ,3 ));
           Console.WriteLine("Was {0} hits from {1} attempts",mark,number);*/
//Exercise 4
           Console.WriteLine("**********");
           Console.WriteLine("Exercise 4");
           Console.WriteLine("**********");
           int classes= EnterYourNumber(" of classes");
           int[][] school=new int [classes] [];
           int [] sumClassMark= new int [classes];
           for (int i = 0; i < classes;i++ )
           {
               Console.WriteLine("Class {0}",(i+1));
               students = EnterYourNumber(" of student");
               school[i] = new int[students];
           }
           for (int i = 0; i < classes; i++)
           {
               Console.WriteLine("Class {0}" , (i + 1));
               for (int j = 0; j < school[i].Length; j++)
               {
                   school[i][j] = EnterMark(j);
                   sumClassMark[i] += school[i][j];
               }
              
           }
           int av;
           int max = 0;
         
           for (int i = 0; i < classes; i++)
           {
              
              
               av=(int)(sumClassMark[i] / school[i].Length);
               if (max < av)
                   max = av;
               Console.WriteLine("Average mark in the class {0} with {1} students is {2}", (i + 1), school[i].Length, av);
 
           }
           for (int i = 0; i < classes; i++)
           {


               if( (int)(sumClassMark[i] / school[i].Length)==max)
                   Console.WriteLine(" Class {0} has best average mark {1}", (i + 1), max);

           }

            Console.ReadLine();

        }
    }
}
