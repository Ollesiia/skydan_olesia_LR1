using System;

using System.IO;

using Newtonsoft.Json;



namespace ConsoleApplication1
{  
   public class Interval
   {  
      private double left;
      
      private double right;


      public Interval(double left, double right)
      {
         this.left = left;
         this.right = right;
      }

      public double Left
      {
         get { return left; }
         set { left = value; }
      }

      public double Right
      {
         get { return right; }
         set { right = value; }
      }

      public void print()
      {
         Console.WriteLine("----------------------");
         Console.WriteLine("Лiва межа = " + this.left);
         Console.WriteLine("Права межа = " + this.right);
         Console.WriteLine("----------------------");
         Console.WriteLine("Довжина iнтервалу = " + lenght());
         Console.WriteLine("----------------------");
         
         
        
      }

      public double lenght()
      {
         double lenght = this.Right - this.Left;
         return lenght;
      }



      public void offset(double k)
      {
        
         if (k < 0)
         {
            Console.WriteLine("Змiщення вліво");
         }

         else if (k > 0)
         {
            Console.WriteLine("Змiщення вправо");
         }
         else
         {
            Console.WriteLine("Яке змiщення на 0, ви чого?");
         }
         
         

         this.Left += k;
         this.Right += k;
         
      }

      public void stretch(double s)
      {
         this.Left *= s;
         this.Right *= s;
      }

      public void comparison(Interval interval2)
      {
         if ((this.Right-this.Left) < (interval2.Right - interval2.Right))
         {
            Console.WriteLine("Iнтервал 1 менше за iнтервал 2");
         }
         else
         {
           Console.WriteLine("Iнтервал 2 менше за iнтервал 1");
         }
      }

      public double sum(Interval interval2)
      {
         double sum = (this.Right - this.Left) + (interval2.Right - interval2.Left);
         return sum;
      }
      public double subtracting(Interval interval2)
      {
         double subtracting = (this.Right - this.Left) - (interval2.Right - interval2.Left);
         return subtracting;
      }
      public void method1(string filename)
      {
                
         string toWrite = JsonConvert.SerializeObject(this);
         File.WriteAllText(filename, toWrite);
      }
      

      public static Interval method2(string filename)
      {
         StreamReader r = new StreamReader(filename);
         string jsonString = r.ReadToEnd();
         dynamic json = JsonConvert.DeserializeObject(jsonString);
         double left = json.Left;
         double right = json.Right;
         return new Interval( left, right);
      }
     

      

    }
   class Program
      
   {
      
      static void Main(string[] args)
      {
           
         
         
         Interval interval = Interval.method2("C:\\Users\\Dmitry\\RiderProjects\\Lab1\\Lab1\\NewFile1.json");
         interval.method1("C:\\Users\\Dmitry\\RiderProjects\\Lab1\\Lab1\\NewFile2.json");
         Interval interval2 = new Interval( 2, 4);
         interval.print();
         interval.stretch(5);
         interval.offset(3);
         interval.comparison(interval2);
         Console.WriteLine("Сума iнтервалiв = " + interval.sum(interval2));
         Console.WriteLine("Рiзниця iнтервалiв = " + interval.subtracting(interval2));
         
         



      }
   }
}
